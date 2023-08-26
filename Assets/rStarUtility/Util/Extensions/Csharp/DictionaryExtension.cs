#region

using System.Collections.Generic;

#endregion

namespace rStarUtility.Util.Extensions.Csharp
{
    public static class DictionaryExtension
    {
    #region Public Methods

        public static void AddOrSet<TKey , TValue>(
                this Dictionary<TKey , TValue> dictionary ,
                TKey                           key , TValue value)
        {
            if (dictionary.ContainsKey(key)) dictionary[key] = value;
            else dictionary.Add(key , value);
        }

        public static TValue GetOrReturn<TKey , TValue>(
                this Dictionary<TKey , TValue> dictionary ,
                TKey                           key , TValue value)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : value;
        }

    #endregion
    }

    public class NAryDictionary<TKey , TValue> :
            Dictionary<TKey , TValue> { }

    public class NAryDictionary<TKey1 , TKey2 , TValue> :
            Dictionary<TKey1 , NAryDictionary<TKey2 , TValue>> { }

    public class NAryDictionary<TKey1 , TKey2 , TKey3 , TValue> :
            Dictionary<TKey1 , NAryDictionary<TKey2 , TKey3 , TValue>> { }

    /// <summary>
    ///     https://softwareengineering.stackexchange.com/questions/319264/dictionary-of-dictionaries-design-in-c
    /// </summary>
    public static class NAryDictionaryExtensions
    {
    #region Public Methods

        public static NAryDictionary<TKey2 , TKey3 , TValue> New<TKey1 , TKey2 , TKey3 , TValue>(
                this NAryDictionary<TKey1 , TKey2 , TKey3 , TValue> dictionary)
        {
            return new NAryDictionary<TKey2 , TKey3 , TValue>();
        }

        public static NAryDictionary<TKey2 , TValue> New<TKey1 , TKey2 , TValue>(
                this NAryDictionary<TKey1 , TKey2 , TValue> dictionary)
        {
            return new NAryDictionary<TKey2 , TValue>();
        }

    #endregion
    }
}