using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace TreeBeard.Events
{
    public sealed class Event : DynamicObject
    {
        private Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public string Type { get; set; }
        public string Id { get; set; }
        public DateTime TimeStamp { get; set; }

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

        public string AsString()
        {
            string source = Type;
            if (!string.IsNullOrEmpty(Id)) source += ":" + Id;
            return string.Format("[{0}] [{1}] {2}", TimeStamp, source, JsonConvert.SerializeObject(_dictionary));
        }
    }
}
