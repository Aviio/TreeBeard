using System;
using System.Reactive.Linq;
using TreeBeard.Utils;

namespace TreeBeard.ExtensionMethods
{
    public static class ObservableExtensions
    {
        public static IObservable<TSource> Trace<TSource>(this IObservable<TSource> source, string name)
        {
            if (!Log.IsDebug()) return source;

            return Observable.Create<TSource>(observer =>
            {
                Action<string, object> trace = (m, v) => Log.Information(name, m, v);

                trace("Subscribe", null);
                IDisposable disposable = source.Subscribe(
                    v => { trace("OnNext", v); observer.OnNext(v); },
                    e => { trace("OnError", e); observer.OnError(e); },
                    () => { trace("OnCompleted", null); observer.OnCompleted(); });

                return () => { trace("Dispose", null); disposable.Dispose(); };
            });
        }
    }
}
