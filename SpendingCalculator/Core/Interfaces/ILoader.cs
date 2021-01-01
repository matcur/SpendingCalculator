using System;
using System.Collections.Generic;
using System.Text;

namespace SpendingCalculator.Core.Interfaces
{
    interface ILoader
    {
        TSource Load<TSource>(string filePath);
    }
}
