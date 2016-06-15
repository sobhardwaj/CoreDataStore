using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDataStore.Common.Helpers
{
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

        public static void Batch()
        {
            throw new NotImplementedException();
        }
    }
}