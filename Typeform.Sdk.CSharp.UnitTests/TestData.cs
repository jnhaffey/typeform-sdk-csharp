using System;
using Bogus;

namespace Typeform.Sdk.CSharp.UnitTests
{
    public static class TestData
    {
        public const string EmptyValue = "";
        public const string WhiteSpaceValue = " ";
        public const string FormTitle = "TEST_FORM";
        public static Randomizer BogusRandomizer = new Randomizer(DateTime.UtcNow.Millisecond);
        public static Faker BogusFaker = new Faker();

        public static class Themes
        {
            public const string Name = "THEME_UNIT_TEST";
            public const string SixCharHexColor = "#000000";
            public const string ThreeCharHexColor = "#000";
        }

        public static class Guards
        {
            public const string ParameterName = "UNIT_TEST_PARAMETER_NAME";
        }

        public static class HiddenProperties
        {
            public const string Property1 = "PROPERTY_1";
            public const string Property2 = "PROPERTY_2";
        }
    }
}