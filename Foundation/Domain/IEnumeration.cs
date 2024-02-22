using System;

namespace Foundation.Domain;

public interface IEnumeration<TKey>
{
    TKey Key { get; }
    string Display { get; }
    
}