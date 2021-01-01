using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SpendingCalculator.Extensions
{
    public static class ObservableCollectionExtension
    {
        public static void AddRange<T>(this ObservableCollection<T> source, IEnumerable<T> enumerable)
        {
            foreach (var value in enumerable)
                source.Add(value);
        }
    }
}
