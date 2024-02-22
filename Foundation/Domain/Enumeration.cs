using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Foundation.Helpers;

namespace Foundation.Domain
{
    // Attribution: https://github.com/ardalis/SmartEnum

    public abstract class Enumeration<TEnum,TKey> : IEnumeration<TKey>,
        IEquatable<Enumeration<TEnum, TKey>>,
        IComparable<Enumeration<TEnum, TKey>>
        where TEnum : Enumeration<TEnum, TKey>, new()
        where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        public TKey Key { get; }
        public string Display { get; }

        public Enumeration() { }

        protected Enumeration(TKey key) : this(key, key.ToString().PascalCaseToWords()) { }

        protected Enumeration(TKey key, string display) 
        {
            Key = key;
            Display = display;
        }

        public override string ToString()
        {
            return Display;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public static IEnumerable<TEnum> GetAll()
        {
            var type = typeof(TEnum);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new TEnum();
                if (info.GetValue(instance) is TEnum locatedValue)
                {
                    yield return locatedValue;
                }
            }
        }

        public static TEnum? FromKey(TKey key)
        {
            return Parse(item => item.Key.Equals(key));
        }

        public static TEnum? FromDisplay(string display)
        {
            return Parse(item => item.Display == display);
        }

        protected static TEnum? Parse(Func<TEnum, bool> predicate)
        {
            var enumerations = GetAll();
            return enumerations.FirstOrDefault<TEnum>(predicate);
        }

        bool IEquatable<Enumeration<TEnum, TKey>>.Equals(Enumeration<TEnum, TKey>? enumeration)
        {
            var otherValue = enumeration as Enumeration<TEnum, TKey>;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(enumeration.GetType());
            var valueMatches = Key.Equals(otherValue.Key);

            return typeMatches && valueMatches;
        }

    int IComparable<Enumeration<TEnum, TKey>>.CompareTo(Enumeration<TEnum, TKey>? enumeration)
        {
            return Key.CompareTo(enumeration.Key);
        }
    }
}
