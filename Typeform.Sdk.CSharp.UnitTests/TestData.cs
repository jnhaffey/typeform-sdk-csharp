using System.Security.Cryptography.X509Certificates;
using Typeform.Sdk.CSharp.Models;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.UnitTests
{
    public static class TestData
    {
        public const string EmptyValue = "";
        public const string WhiteSpaceValue = " ";
        public const string FormTitle = "TEST_FORM";

        public static class HiddenProperties
        {
            public const string Property1 = "PROPERTY_1";
            public const string Property2 = "PROPERTY_2";
        }
    }
}