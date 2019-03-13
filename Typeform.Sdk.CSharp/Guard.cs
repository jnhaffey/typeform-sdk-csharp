using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Flurl;
using Typeform.Sdk.CSharp.Abstracts;
using Typeform.Sdk.CSharp.Exceptions;
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
        ///     Checks if the string value is Null, Empty, or Whitespaces only.
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

        /// <summary>
        ///     Checks if the value is below the minimum value allowed.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValueAllowed"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ForMinValue(int value, int minValueAllowed, string parameterName)
        {
            if (value < minValueAllowed)
                throw new ArgumentException(string.Format(ErrorMessages.Guard_ForMinValue, parameterName, value,
                    minValueAllowed));
        }

        /// <summary>
        ///     Checks if the value is above the maximum value allowed.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxValueAllowed"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ForMaxValue(int value, int maxValueAllowed, string parameterName)
        {
            if (value > maxValueAllowed)
                throw new ArgumentException(string.Format(ErrorMessages.Guard_ForMaxValue, parameterName, value,
                    maxValueAllowed));
        }

        /// <summary>
        ///     Checks that the API Key has been initialized.
        /// </summary>
        /// <exception cref="UninitializedClientException"></exception>
        public static void ForInitializedClient<TApiClient>(TApiClient apiClient)
            where TApiClient : ApiClientBase
        {
            if (string.IsNullOrWhiteSpace(apiClient.ApiKey))
                throw new UninitializedClientException(typeof(TApiClient).Name);
        }

        /// <summary>
        ///     Checks that a string value is a valid hex format.
        /// </summary>
        /// <param name="hexColor"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="InvalidHexColorException"></exception>
        public static void ForHexColorValue(string hexColor, string parameterName)
        {
            ForNullOrEmptyOrWhitespace(hexColor, parameterName);
            if (!Regex.Match(hexColor, "^#(?:[0-9a-fA-F]{3}){1,2}$").Success)
                throw new InvalidHexColorException(string.Format(ErrorMessages.Guard_ForHexColorValue, hexColor,
                    parameterName));
        }

        /// <summary>
        ///     Checks that a value is between a min and max value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ForBetweenValues(decimal value, decimal minValue, decimal maxValue, string parameterName)
        {
            if (value < minValue || value > maxValue)
                throw new ArgumentOutOfRangeException(parameterName, string.Format(ErrorMessages.Guard_ForBetweenValues,
                    value,
                    parameterName, minValue, maxValue));
        }

        /// <summary>
        ///     Check if a string value is a valid URI.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <exception cref="UriFormatException"></exception>
        public static void ForInvalidUrl(string value, string parameterName)
        {
            if (!Url.IsValid(value))
                throw new UriFormatException(string.Format(ErrorMessages.Guard_ForInvalidUrl, value, parameterName));
        }
    }
}