#region

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

#endregion

namespace rStarUtility.Util
{
    public static class RandomUtilities
    {
    #region Public Variables

        public const int DefaultValue = -999;

        public static bool Log;
        public static bool UseFake;
        public static int  NextRandomIndex;

    #endregion

    #region Public Methods

        public static T GetRandomData<T>(List<T> datas)
        {
            var datasCount = datas.Count;
            Assert.AreNotEqual(0 , datasCount , "count can not be zero");
            if (datasCount == 0) return default;

            var randomIndex = UseFake ? NextRandomIndex : Random.Range(0 , datasCount);
            return datas[randomIndex];
        }

        public static int GetRandomIntValue()
        {
            return GetRandomValue(-1 , 1);
        }

        /// <summary>
        ///     Return a random integer number between min [inclusive] and max [inclusive] (Read Only)
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool GetRandomResult(int rate , int max)
        {
            var randomValue = GetRandomValue(max);
            return GetRPNGResult(randomValue , rate);
        }

        /// <summary>
        ///     Return a random float number between min [inclusive] and max [inclusive] (Read Only)
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool GetRandomResult(float rate , float max)
        {
            var randomValue = GetRandomValue(max);
            return GetRPNGResult(randomValue , rate);
        }

        /// <summary>
        ///     start from 1 to max (include)
        /// </summary>
        /// <param name="max">include</param>
        /// <returns></returns>
        public static int GetRandomValue(int max)
        {
            return GetRandomValue(1 , max);
        }

        /// <summary>
        ///     start from 1 to max (include)
        /// </summary>
        /// <param name="max">include</param>
        /// <returns></returns>
        public static float GetRandomValue(float max)
        {
            return GetRandomValue(1 , max);
        }

        public static float GetRandomValue()
        {
            return GetRandomValue(-1f , 1f);
        }

        /// <summary>
        ///     return min to max
        /// </summary>
        /// <param name="min">include</param>
        /// <param name="max">include</param>
        public static int GetRandomValue(int min , int max)
        {
            if (UseFake) return NextRandomIndex;
            var minValue    = min >= max ? max : min;
            var maxValue    = max + 1;
            var randomValue = Random.Range(minValue , maxValue);
            return randomValue;
        }

        /// <summary>
        ///     return min to max
        /// </summary>
        /// <param name="min">include</param>
        /// <param name="max">include</param>
        public static float GetRandomValue(float min , float max)
        {
            if (UseFake) return NextRandomIndex;
            var minValue    = min >= max ? max : min;
            var maxValue    = max;
            var randomValue = Random.Range(minValue , maxValue);
            return randomValue;
        }

        /// <summary>
        ///     計算圓桌數值
        /// </summary>
        /// <param name="roundTables"></param>
        /// <param name="weightValue">可指定Weight，Weight不可為0，不可大於TotalWeight</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception">輸入值違反時會丟Exception</exception>
        public static T GetRoundTableValue<T>(List<RoundTable<T>> roundTables , int weightValue = DefaultValue)
        {
            var totalWeight = roundTables.Sum(table => table.Weight);
            if (roundTables == null) throw new Exception("roundTables count is null");
            if (roundTables.Count == 0) throw new Exception("roundTables count is 0");
            if (weightValue <= 0 && weightValue != DefaultValue)
                throw new Exception($"Wrong weight value small than min value, {weightValue}");
            if (weightValue > totalWeight)
                throw new Exception(
                        $"Wrong weight value big than max value, {weightValue} , Total weight is {totalWeight}");
            // Is normal path or unit test path
            var randomWeightValue = weightValue == DefaultValue ? GetRandomValue(totalWeight) : weightValue;
            T   result            = default;
            if (Log) Debug.Log($"[GetRoundTableValue] weightValue : {weightValue}");
            for (var index = 0 ; index < roundTables.Count ; index++)
            {
                var roundTable     = roundTables[index];
                var weight         = roundTable.Weight;
                var subtractResult = randomWeightValue - weight;
                if (Log)
                    Debug.Log($"index: {index} , weight : {weight} , value : {roundTable.Value} "
                            + $"totalWeight : {randomWeightValue} , Subtract result : {subtractResult}");
                randomWeightValue = subtractResult;
                if (randomWeightValue > 0) continue;
                result = roundTable.Value;
                break;
            }

            return result;
        }

        public static bool GetRPNGResult(int randomValue , int rate)
        {
            return randomValue <= rate;
        }

        public static bool GetRPNGResult(float randomValue , float rate)
        {
            return randomValue <= rate;
        }

        public static List<T> GetUniqueRoundTableValue<T>(List<RoundTable<T>> roundTables , int uniqueNumber)
        {
            Contract.Require(uniqueNumber >= 0 , $"uniqueNumber[{uniqueNumber}] need grater or equal than 0.");
            var resultList = new List<T>();
            for (var i = 0 ; i < uniqueNumber ; i++)
            {
                var randomRoundTableValue = GetRoundTableValue(roundTables);
                resultList.Add(randomRoundTableValue);
                var itemToRemove = roundTables.Find(data => data.Value.Equals(randomRoundTableValue));
                roundTables.Remove(itemToRemove);
            }

            return resultList;
        }

    #endregion
    }

    [Serializable]
    public class RoundTable<T>
    {
    #region Public Variables

        public int Weight { get; private set; }
        public T   Value  { get; private set; }

    #endregion

    #region Constructor

        public RoundTable(int weight , T value)
        {
            Contract.Require(weight >= 0 , "weight need to grater or equal than 0.");
            Weight = weight;
            Value  = value;
        }

    #endregion

    #region Public Methods

        public void AddWeight(int weight)
        {
            Weight += weight;
        }

        public void SetValue(T newValue)
        {
            Value = newValue;
        }

    #endregion
    }
}