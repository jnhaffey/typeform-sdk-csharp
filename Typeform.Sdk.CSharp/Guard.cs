using System;
using System.Collections.Generic;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp
{
    public static class Guard
    {
        /// <summary>
        ///     Checks if the value is Null.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <typeparam name="TParam"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ForNullValue<TParam>(TParam value, string parameterName)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName,
                    string.Format(ErrorMessages.Guard_ForNullValue, parameterName));
        }

        /// <summary>
        /// Checks if the string value is Null, Empty, or Whitespaces only.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ForNullOrEmptyOrWhitespace(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(parameterName,
                    string.Format(ErrorMessages.Guard_ForNullOrEmptyOrWhitespace, parameterName));
        }

        /// <summary>
        ///     Checks if the value is already in the list.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <param name="list"></param>
        /// <param name="listName"></param>
        /// <typeparam name="TData"></typeparam>
        /// <exception cref="ArgumentException"></exception>
        public static void ForDuplicateItemsInList<TData>(TData value, string parameterName, List<TData> list,
            string listName)
        {
            if (list.Contains(value))
                throw new ArgumentException(
                    string.Format(ErrorMessages.Guard_ForDuplicateItemsInList, parameterName, value, listName));
        }
    }
}