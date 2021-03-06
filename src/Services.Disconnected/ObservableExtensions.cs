﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveSearch.Services.Disconnected;
using ReactiveSearch.Utility;

namespace System.Reactive
{
    public static class ObservableExtensions
    {
        private static readonly Random Random = new Random();
        public static IObservable<T> ErrorWithProbabilityIf<T>(this IObservable<T> src, bool enableRandomErrors, int percent)
        {
            Ensure.ArgumentCondition(percent >= 0, "percent must be greater than or equal to zero.", nameof(percent));
            Ensure.ArgumentCondition(percent <= 100, "percent must be less than or equal to one hundred.", nameof(percent));

            if (enableRandomErrors)
            {
                if (Random.Next(0, 100) < percent)
                {
                    return Observable.Throw<T>(new DisconnectedErrorException($"Sequence failed due to {percent}% chance of failure."));
                }
                else
                {
                    return src;
                }
            }
            else
            {
                return src;
            }
        }
        public static IObservable<T> DelayIf<T>(this IObservable<T> src, bool enableRandomDelays, int minValue, int maxValue)
        {
            if (enableRandomDelays)
            {
                return src.Delay(TimeSpan.FromMilliseconds(Random.Next(minValue, maxValue)));
            }
            else
            {
                return src;
            }
        }
    }
}
