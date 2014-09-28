using System;
using System.Reactive.Linq;
using TreeBeard.Extensions;

namespace TreeBeard.Extensions
{
    public static class ObservableExtensions
    {
        public static IObservable<TSource> Trace<TSource>(this IObservable<TSource> source, string name)
        {
            return Observable.Create<TSource>(observer =>
            {
                Action<string, object> trace = (m, v) => observer.Log().Info("[{0}] {1}({2})", name, m, v);

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
