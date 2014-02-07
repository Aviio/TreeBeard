//css_reference MongoDB.Bson.dll;
//css_reference MongoDB.Driver.dll;
using logstash4net.Events;
using logstash4net.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

public class MongoDbInput : IInput
{
    private string _uri;
    private string _database;
    private string _collection;

    private MongoCollection<BsonDocument> _mongoCollection;
    private BsonValue _lastId;

    public IObservable<IEvent> Execute()
    {
        return Observable.Interval(TimeSpan.FromSeconds(1)).SelectMany(_ => GetEvents());
    }

    public void Initialize(params string[] args)
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
            yield return new BsonEvent(document);
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

    private class BsonEvent : IEvent
    {
        private readonly BsonDocument _document;

        public BsonEvent(BsonDocument document)
        {
            _document = document;

            var objectId = _document["_id"] as BsonObjectId;
            TimeStamp = (objectId != null) ? objectId.Value.CreationTime : DateTime.Now;
        }

        public DateTime TimeStamp { get; private set; }

        public string AsString()
        {
            return string.Format("[{0}] {1}", TimeStamp, _document.ToJson());
        }
    }
}
