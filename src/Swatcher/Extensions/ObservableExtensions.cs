using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
#pragma warning disable 1591

namespace BraveLantern.Swatcher.Extensions
{
    public static class ObservableExtensions
    {
        public static IObservable<Unit> ToUnit<T>(this IObservable<T> source)
        {
            return source.Select(x => Unit.Default);
        }

        public static IObservable<T> WhenAnyCommand<T, TRet>(this IObservable<IEnumerable<T>> listStream,
            Func<T, IObservable<TRet>> selector)
        {
            return listStream
                .Select(list => list?.Select(t => selector(t).Select(_ => t)).Merge() ?? Observable.Empty<T>())
                .Switch();
        }

        /// <summary>
        ///     Equivalent to observable.Where(x => x != null)
        /// </summary>
        public static IObservable<T> WhereNotNull<T>(this IObservable<T> observable) where T : class
        {
            return observable.Where(x => x != null);
        }

        public static IObservable<bool> WhereTrue(this IObservable<bool> observable)
        {
            return observable.Where(x => x);
        }

        public static IObservable<bool> WhereFalse(this IObservable<bool> observable)
        {
            return observable.Where(x => !x);
        }

        /// <summary>
        ///     Equivalent to observable.Where(x => x.Any())
        /// </summary>
        public static IObservable<IEnumerable<T>> WhereNotEmpty<T>(this IObservable<IEnumerable<T>> observable)
        {
            return observable.Where(x => (x != null) && x.Any());
        }

        public static IObservable<T> DebugWriteLine<T>(this IObservable<T> stream, string format, params object[] args)
        {
            return stream.Do(x => Debug.WriteLine(format, args));
        }

        public static IObservable<T> DebugWriteLine<T>(this IObservable<T> stream, Func<T, string> selector)
        {
            return stream.Do(x => Debug.WriteLine(selector(x)));
        }


        public static void DisposeWith(this IDisposable disposable, Action<IDisposable> bag)
        {
            bag(disposable);
        }

        public static void DisposeWith(this IDisposable disposable, CompositeDisposable bag)
        {
            bag.Add(disposable);
        }

        /// <summary>
        ///     Perform an action when the consumer subscribes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source observable stream.</param>
        /// <param name="onSubscribe">The action to perform upon subscription to the source observable stream.</param>
        /// <returns></returns>
        public static IObservable<T> OnSubscribe<T>(this IObservable<T> source, Action onSubscribe)
        {
            return Observable.Create<T>(observer =>
            {
                onSubscribe();
                return source.Subscribe(observer);
            });
        }

        public static IObservable<IList<T>> CombineWithPreviousBuffer<T>(
            this IObservable<IList<T>> source)
        {
            return Observable.Create<IList<T>>(observer =>
            {
                var previous = source;
                var current = source.Skip(1);

                return previous.Merge(current).Subscribe(observer);
            });
        }

        public static IObservable<TResult> CombineWithPrevious<TSource, TResult>(
            this IObservable<TSource> source, Func<TSource,TSource,TResult> selector)
        {
            return source.Scan(
                    Tuple.Create(default(TSource), default(TSource)),
                    (previous, current) => Tuple.Create(previous.Item2, current))
                .Select(t =>selector(t.Item1, t.Item2));
        }

        public static IObservable<T> StepInterval<T>(this IObservable<T> source)
        {
            return source.StepInterval(TimeSpan.MinValue);
        }

        public static IObservable<T> StepInterval<T>(this IObservable<T> source, TimeSpan minDelay)
        {
            return source.Select(x =>
                    Observable.Empty<T>()
                        .Delay(minDelay)
                        .StartWith(x)
            ).Concat();
        }

        public static IObservable<Unit> AsCompletion<T>(this IObservable<T> observable)
        {
            return Observable.Create<Unit>(observer =>
            {
                Action onCompleted = () =>
                {
                    observer.OnNext(Unit.Default);
                    observer.OnCompleted();
                };
                return observable.Subscribe(_ => { }, observer.OnError, onCompleted);
            });
        }

        public static IObservable<TRet> ContinueAfter<T, TRet>(
            this IObservable<T> observable, Func<IObservable<TRet>> selector)
        {
            return AsCompletion(observable).SelectMany(_ => selector());
        }

        public static IObservable<TRet> CombineLatestFromLeft<TRet, TLeft, TRight>(
            this IObservable<TLeft> left,
            IObservable<TRight> right,
            Func<TLeft, TRight, TRet> selector)
        {
            return right.Publish(rs => left.Zip(rs.MostRecent(default(TRight)), selector)); //.SkipUntil(rs));
        }

        /// <summary>
        ///     Filters the original stream to values produced when the conditional stream's latest value is true.
        /// </summary>
        /// <typeparam name="T">Original stream's type.</typeparam>
        /// <param name="originalStream">The original stream.</param>
        /// <param name="conditionalStream">The stream used to filter the original stream.</param>
        /// <returns>A filtered version of the original stream.</returns>
        public static IObservable<T> WhenTrue<T>(this IObservable<T> originalStream, IObservable<bool> conditionalStream)
        {
            return originalStream
                .CombineLatest(conditionalStream, (orig, condition) => new {orig, condition})
                .Where(x => x.condition)
                .Select(x => x.orig);
        }

        /// <summary>
        ///     Filters the original stream to values produced when the conditional stream's latest value is false.
        /// </summary>
        /// <typeparam name="T">Original stream's type.</typeparam>
        /// <param name="originalStream">The original stream.</param>
        /// <param name="conditionalStream">The stream used to filter the original stream.</param>
        /// <returns>A filtered version of the original stream.</returns>
        public static IObservable<T> WhenFalse<T>(this IObservable<T> originalStream,
            IObservable<bool> conditionalStream)
        {
            return originalStream
                .CombineLatest(conditionalStream, (orig, condition) => new {orig, condition})
                .Where(x => !x.condition)
                .Select(x => x.orig);
        }

        /// <summary>
        ///     Same as <c>Where(condition => condition)</c>.
        /// </summary>
        public static IObservable<bool> WhenTrue(this IObservable<bool> originalStream)
        {
            return originalStream.Where(condition => condition);
        }

        /// <summary>
        ///     Same as <c>Where(condition => !condition)</c>.
        /// </summary>
        public static IObservable<bool> WhenFalse(this IObservable<bool> originalStream)
        {
            return originalStream.Where(condition => !condition);
        }

        /// <summary>
        ///     Same as <c>Select(condition => !condition)</c>.
        /// </summary>
        public static IObservable<bool> Invert(this IObservable<bool> originalStream)
        {
            return originalStream.Select(condition => !condition);
        }

        /// <summary>
        ///     Shorthand for calculating the average of a stream of TimeSpans.
        /// </summary>
        public static IObservable<TimeSpan> Average(this IObservable<TimeSpan> originalStream)
        {
            return
                originalStream.Average(timeSpan => timeSpan.Ticks).Select(ticks => new TimeSpan(Convert.ToInt64(ticks)));
        }

        /// <summary>
        ///     Shorthand for calculating the sum of a stream of TimeSpans.
        /// </summary>
        public static IObservable<TimeSpan> Sum(this IObservable<TimeSpan> originalStream)
        {
            return originalStream.Sum(timeSpan => timeSpan.Ticks).Select(ticks => new TimeSpan(Convert.ToInt64(ticks)));
        }
    }
}