using System;

namespace Foundation.Domain;

public interface IEnumeration<TKey,TValue>
{
    TKey Key { get; }
    TValue Value { get; }
    string Display { get; }
    
}