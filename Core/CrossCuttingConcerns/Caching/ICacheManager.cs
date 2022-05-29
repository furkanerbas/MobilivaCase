using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager : IDisposable
    {
        void Set(string key, object value, int minutesToCache);
        void Remove(object key);
        bool TryGetValue(object key, out object value);
    }
}
