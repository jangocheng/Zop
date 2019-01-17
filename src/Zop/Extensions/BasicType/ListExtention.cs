﻿using System.Linq;

namespace System.Collections.Generic
{
    /// <summary>
    /// List 扩展类
    /// </summary>
    public static class ListExtention
    {
        /// <summary>
        /// 是否可用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsNullOrAuy<T>(this IList<T> target)
        {
            if (target == null)
                return false;
            return target.Any();
        }
        /// <summary>
        /// List合并
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="target">目标对象</param>
        /// <param name="source">来源对象</param>
        /// <param name="func">重复项依据方法 true-没有重复项，可以合并，fale-有重复项，不能合并</param>
        /// <returns>返回合并后的目标对象 - 排除重复项</returns>
        public static IList<T> Merged<T>(this IList<T> target, IList<T> source, Func<IList<T>, T, bool> func)
        {
            foreach (T t in source)
            {
                if (func(target, t))
                {
                    target.Add(t);
                }
            }
            return target;
        }

        /// <summary>
        /// List转化扩展方法
        /// </summary>
        /// <typeparam name="TPara"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="list"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<TResult> ConvertAll<TPara, TResult>(this List<TPara> list, Func<TPara, TResult> func)
        {
            if (list == null)
                return null;
            var resultList = new List<TResult>(list.Count);
            list.ForEach(e => resultList.Add(func(e)));
            return resultList;
        }

        /// <summary>
        /// List拷贝
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static IList<T> Copy<T>(this List<T> source)
        {
            return source.ToList<T>();
        }
    }
}
