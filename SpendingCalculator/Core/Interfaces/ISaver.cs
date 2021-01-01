using System;
using System.Collections.Generic;
using System.Text;

namespace SpendingCalculator.Core.Interfaces
{
    interface ISaver
    {
        void Save<TSource>(TSource source, string filePath);
    }
}
