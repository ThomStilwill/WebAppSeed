using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Foundation.Helpers;

namespace Foundation.Domain
{
    public abstract class Enumeration<TEnum,TKey,TValue> : IEnumeration<TKey, TValue>,
        IEquatable<Enumeration<TEnum, TKey, TValue>>,
        IComparable<Enumeration<TEnum, TKey, TValue>>
        where TEnum : Enumeration<TEnum, TKey, TValue>, new()
        where TKey : System.Enum
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        public TKey Key { get; }
        public TValue Value { get; }
        public string Display { get; }

        public Enumeration() { }

        protected Enumeration(TKey key) : this(key, GenericConverter.ChangeType<TValue>(Enum.GetName(typeof(TKey),key).PascalCaseToWords())) { }
        protected Enumeration(TKey key, TValue value) : this(key, value, Enum.GetName(typeof(TKey), key).PascalCaseToWords()) { }
        protected Enumeration(TKey key, TValue value, string display) 
        {
            Key = key;
            Value = value;
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


        public static TEnum? FromValue(TValue value)
        {
            return Parse(item => item.Value.Equals(value));
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

        bool IEquatable<Enumeration<TEnum, TKey, TValue>>.Equals(Enumeration<TEnum, TKey, TValue>? enumeration)
        {
            var otherValue = enumeration as Enumeration<TEnum, TKey, TValue>;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(enumeration.GetType());
            var valueMatches = Key.Equals(otherValue.Key);

            return typeMatches && valueMatches;
        }

    int IComparable<Enumeration<TEnum, TKey, TValue>>.CompareTo(Enumeration<TEnum, TKey, TValue>? enumeration)
        {
            return Value.CompareTo(enumeration.Value);
        }
    }
}
