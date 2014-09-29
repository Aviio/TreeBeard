using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

namespace TreeBeard
{
    public sealed class Event : DynamicObject
    {
        private Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public string Type { get; set; }
        public string Id { get; set; }
        public DateTime TimeStamp { get; set; }

        public object this[string key]
        {
            get { return GetMember(key); }
            set { SetMember(key, value); }
        }

        public Event()
        {
            TimeStamp = DateTime.Now;
        }

        public Event(string type, string id) : this()
        {
            Type = type;
            Id = id;
        }

        public Event(string type, string id, DateTime timeStamp)
        {
            Type = type;
            Id = id;
            TimeStamp = timeStamp;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name.ToLower();

            return _dictionary.TryGetValue(name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _dictionary[binder.Name.ToLower()] = value;

            return true;
        }

        public object GetMember(string propName)
        {
            var binder = Binder.GetMember(CSharpBinderFlags.None,
                  propName, this.GetType(),
                  new List<CSharpArgumentInfo>{
                       CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)});
            var callsite = CallSite<Func<CallSite, object, object>>.Create(binder);

            return callsite.Target(callsite, this);
        }

        public void SetMember(string propName, object val)
        {
            var binder = Binder.SetMember(CSharpBinderFlags.None,
                   propName, this.GetType(),
                   new List<CSharpArgumentInfo>{
                       CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                       CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)});
            var callsite = CallSite<Func<CallSite, object, object, object>>.Create(binder);

            callsite.Target(callsite, this, val);
        }

        public void RemoveMember(string propName)
        {
            _dictionary.Remove(propName.ToLower());
        }

        public bool HasMember(string propName)
        {
            return (propName == "Type" || propName == "Id" || propName == "TimeStamp" || _dictionary.ContainsKey(propName.ToLower()));
        }

        public IEnumerable<KeyValuePair<string, object>> GetMembers(bool includeInstanceMembers = false)
        {
            if (includeInstanceMembers)
            {
                yield return new KeyValuePair<string, object>("Type", Type);
                yield return new KeyValuePair<string, object>("Id", Id);
                yield return new KeyValuePair<string, object>("TimeStamp", TimeStamp);
            }
        
            foreach (var kvp in _dictionary)
            {
                yield return kvp;
            }
        }

        public string AsJson(bool includeInstanceMembers = false)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.WriteStartObject();
                foreach (var item in GetMembers(includeInstanceMembers))
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteValue(item.Value);
                }
                writer.WriteEndObject();

                return sw.ToString();
            }
        }

        public string AsXml(bool includeInstanceMembers = false)
        {
            return JsonConvert.DeserializeXmlNode(AsJson(includeInstanceMembers), "Event").OuterXml;
        }

        public string AsString()
        {
            string source = Type;
            if (!string.IsNullOrEmpty(Id)) source += ":" + Id;
            return string.Format("[{0}] [{1}] {2}", TimeStamp, source, AsJson(false));
        }
    }
}
