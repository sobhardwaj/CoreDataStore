using System.Collections.Generic;

namespace System.Linq
{
    //TODO ADD TO COMMON Project

    public static class LinqHelper
    {
        public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(
            this IEnumerable<TSource> source,
            int batchSize)
        {
            var batch = new List<TSource>();
            foreach (var item in source)
            {
                batch.Add(item);
                if (batch.Count == batchSize)
                {
                    yield return batch;
                    batch = new List<TSource>();
                }
            }

            if (batch.Any()) yield return batch;
        }
    }
}