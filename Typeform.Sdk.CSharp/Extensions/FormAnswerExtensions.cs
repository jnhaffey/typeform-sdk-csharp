using System;
using System.Collections.Generic;
using System.Linq;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Models.Webhook;

namespace Typeform.Sdk.CSharp.Extensions
{
    public static class FormAnswerExtensions
    {
        public static bool GetBooleanAnswer(this FormAnswer source)
        {
            return source.Type == FormAnswerType.Boolean
                ? source.Boolean
                : throw new InvalidAnswerTypeException(
                    $"Answer is of type {source.Type} and not {FormAnswerType.Boolean}.");
        }

        public static string GetChoiceAnswer(this FormAnswer source)
        {
            return source.Type == FormAnswerType.Choice
                ? string.IsNullOrWhiteSpace(source.Choice.Label) ? source.Choice.Other : source.Choice.Label
                : throw new InvalidAnswerTypeException(
                    $"Answer is of type {source.Type} and not {FormAnswerType.Choice}.");
        }

        public static List<string> GetChoicesAnswer(this FormAnswer source)
        {
            if (source.Type != FormAnswerType.Choices)
                throw new InvalidAnswerTypeException(
                    $"Answer is of type {source.Type} and not {FormAnswerType.Choices}.");

            var temp = new List<string>();
            if (source.Choices.Labels.Any()) temp.AddRange(source.Choices.Labels);
            if (!string.IsNullOrWhiteSpace(source.Choices.Other)) temp.Add(source.Choices.Other);
            return temp;
        }

        public static DateTime? GetDateAnswer(this FormAnswer source)
        {
            return source.Type == FormAnswerType.Date
                ? source.Date
                : throw new InvalidAnswerTypeException(
                    $"Answer is of type {source.Type} and not {FormAnswerType.Date}.");
        }

        public static string GetEmailAnswer(this FormAnswer source)
        {
            return source.Type == FormAnswerType.Email
                ? source.Email
                : throw new InvalidAnswerTypeException(
                    $"Answer is of type {source.Type} and not {FormAnswerType.Email}.");
        }

        public static int GetNumberAnswer(this FormAnswer source)
        {
            return source.Type == FormAnswerType.Number
                ? source.Number
                : throw new InvalidAnswerTypeException(
                    $"Answer is of type {source.Type} and not {FormAnswerType.Number}.");
        }

        public static string GetTextAnswer(this FormAnswer source)
        {
            return source.Type == FormAnswerType.Text
                ? source.Text
                : throw new InvalidAnswerTypeException(
                    $"Answer is of type {source.Type} and not {FormAnswerType.Text}.");
        }

        public static string GetFileUrlAnswer(this FormAnswer source)
        {
            return source.Type == FormAnswerType.FileUrl
                ? source.FileUrl
                : throw new InvalidAnswerTypeException(
                    $"Answer is of type {source.Type} and not {FormAnswerType.FileUrl}.");
        }

        public static string GetPhoneNumberAnswer(this FormAnswer source)
        {
            return source.Type == FormAnswerType.PhoneNumber
                ? source.PhoneNumber
                : throw new InvalidAnswerTypeException(
                    $"Answer is of type {source.Type} and not {FormAnswerType.PhoneNumber}.");
        }

        public static Payment GetPaymentAnswer(this FormAnswer source)
        {
            return source.Type == FormAnswerType.Payment
                ? source.Payment
                : throw new InvalidAnswerTypeException(
                    $"Answer is of type {source.Type} and not {FormAnswerType.Payment}.");
        }
    }
}