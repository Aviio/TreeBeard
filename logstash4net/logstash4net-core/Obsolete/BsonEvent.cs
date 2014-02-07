//using logstash4net.Interfaces;
//using MongoDB.Bson;
//using System;

//namespace logstash4net.Events
//{
//    public class BsonEvent : IEvent
//    {
//        private readonly BsonDocument _document;

//        public BsonEvent(BsonDocument document)
//        {
//            _document = document;

//            var objectId = _document["_id"] as BsonObjectId;
//            TimeStamp = (objectId != null) ? objectId.Value.CreationTime : DateTime.Now;
//        }

//        public DateTime TimeStamp { get; private set; }

//        public string AsString()
//        {
//            return string.Format("[{0}] {1}", TimeStamp, _document.ToJson());
//        }
//    }
//}
