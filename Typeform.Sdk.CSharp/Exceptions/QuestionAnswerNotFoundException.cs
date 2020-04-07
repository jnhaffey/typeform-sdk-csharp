using System;

namespace Typeform.Sdk.CSharp.Exceptions
{
    public class QuestionAnswerNotFoundException : Exception
    {
        public QuestionAnswerNotFoundException(string questionId)
            : base($"No question with id '{questionId}' was found in the form response.")
        {
            QuestionId = questionId;
        }

        public QuestionAnswerNotFoundException(string message, string questionId)
            : base(message)
        {
            QuestionId = questionId;
        }

        public string QuestionId { get; }
    }
}