using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Reactive
{
    public static class ObservableExtensions
    {
        public static IObservable<T> ErrorWithProbability<T>(this IObservable<T> src, int percent)
        {
            return src;
        }
        public static IObservable<T> DelayIf<T>(this IObservable<T> src, bool enableRandomDelays, int startMs, int endMs)
        {
            return src;
        }

    }
}
