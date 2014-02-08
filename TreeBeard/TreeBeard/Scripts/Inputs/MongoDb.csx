﻿using TreeBeard.Events;
using TreeBeard.Inputs;
using TreeBeard.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

public class MongoDbInput : AbstractInput
{
    private string _uri;
    private string _database;
    private string _collection;

    private MongoCollection<BsonDocument> _mongoCollection;
    private BsonValue _lastId;

    public override IObservable<IEvent> Execute()
    {
        return Observable.Interval(TimeSpan.FromSeconds(1)).SelectMany(_ => GetEvents());
    }

    public override void Initialize(params string[] args)
    {
        _uri = args[0];
        _database = args[1];
        _collection = args[2];
    }

    private IEnumerable<IEvent> GetEvents()
    {
        if (_mongoCollection == null)
        {
            _mongoCollection = GetMongoCollection();
            _lastId = null;
        }
        if (_lastId == null)
        {
            _lastId = GetLastId(_mongoCollection);
        }
        var query = Query.GT("_id", _lastId);
        foreach (var document in _mongoCollection.Find(query).SetSortOrder("$natural"))
        {
            yield return new BsonEvent(Source, document);
            _lastId = document["_id"];
        }
    }

    private MongoCollection<BsonDocument> GetMongoCollection()
    {
        var client = new MongoClient(_uri);
        var server = client.GetServer();
        var database = server.GetDatabase(_database);
        return database.GetCollection(_collection);
    }

    private BsonValue GetLastId(MongoCollection<BsonDocument> collection)
    {
        BsonDocument lastRecord = null;
        if (collection.Exists() && collection.Count() > 0)
        {
            lastRecord = collection.AsQueryable().Last();
        }
        return (lastRecord != null) ? lastRecord["_id"] : BsonMinKey.Value;
    }

    private class BsonEvent : Event
    {
        private readonly BsonDocument _document;

        public BsonEvent(string source, BsonDocument document)
            : base(source, document.ToJson(), GetTimeStamp(document))
        {
            _document = document;
        }

        private static DateTime GetTimeStamp(BsonDocument document)
        {     
            var objectId = document["_id"] as BsonObjectId;
            return (objectId != null) ? objectId.Value.CreationTime : DateTime.Now;
        }
    }
}
