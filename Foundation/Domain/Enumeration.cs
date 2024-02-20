using pipeline.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Foundation.Domain
{

    public class Enumeration
    {
        public Enumeration() { }

        public Enumeration(string display)
        {
            Display = display;
        }

        [JsonIgnore]
        public string Display { get; }

        public override string ToString()
        {
            return Display;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();
                if (info.GetValue(instance) is T locatedValue)
                {
                    yield return locatedValue;
                }
            }
        }

        public static T FromDisplay<T>(string display) where T : Enumeration, new()
        {
            return Parse<T, string>(display, "display", item => item.Display == display);
        }

        protected static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration, new()
        {
            var enumerations = GetAll<T>();
            var matchingItem = enumerations.FirstOrDefault(predicate);
            if (matchingItem != null) return matchingItem;

            var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
            throw new ApplicationException(message);
        }
    }

    public class Enumeration<TKey> : Enumeration, IComparable where TKey : IComparable
    {
        public Enumeration() { }

        public TKey Key { get; }

        protected Enumeration(TKey key) : this(key, key.ToString().PascalCaseToWords()) { }
        protected Enumeration(TKey key, string display) : base(display)
        {
            Key = key;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration<TKey>;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Key.Equals(otherValue.Key);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other)
        {
            return Key.CompareTo(((Enumeration<TKey>)other).Key);
        }

        public static T FromKey<T>(TKey key) where T : Enumeration<TKey>, new()
        {
            return Parse<T, TKey>(key, "key", item => item.Key.Equals(key));
        }
    }
}
