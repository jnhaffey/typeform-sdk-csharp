using System;
using System.Diagnostics.CodeAnalysis;
using Bogus;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Models.Workspaces;

namespace Typeform.Sdk.CSharp.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class TestData
    {
        public const string ApiKey = "UNIT_TEST_API_KEY";
        public const string NullValue = null;
        public const string EmptyValue = "";
        public const string WhiteSpaceValue = " ";
        public const string FormTitle = "TEST_FORM";
        public const string InvalidJson = "{{[]}}";
        public static Randomizer BogusRandomizer = new Randomizer(DateTime.UtcNow.Millisecond);
        public static Faker BogusFaker = new Faker();

        public static class Workspace
        {
            private static readonly string FullWorkspaceId = "ABC123";

            private static readonly string FullWorkspaceSelfUrl =
                $"https://api.typeform.com/workspaces/{FullWorkspaceId}";

            private static readonly string FullWorkspaceFormsUrl = $"{FullWorkspaceSelfUrl}/forms";

            public static readonly string DefaultJson = "{\"name\":\"UNIT_TEST_WORKSPACE\"," +
                                                        "\"default\":true," +
                                                        "\"shared\":false," +
                                                        $"\"forms\":{{\"count\":0,\"href\":\"{FullWorkspaceFormsUrl}\"}}," +
                                                        $"\"self\":{{\"href\":\"{FullWorkspaceSelfUrl}\"}}," +
                                                        $"\"members\":[{{\"name\":\"Account Owner\",\"email\":\"owner@example.com\",\"role\":{(int) MemberRoleType.Owner}}}," +
                                                        $"{{\"name\":\"Account Member\",\"email\":\"member@example.com\",\"role\":{(int) MemberRoleType.Member}}}]," +
                                                        $"\"id\":\"{FullWorkspaceId}\"}}";

            public static readonly ViewWorkspace FullViewWorkspace =
                JsonConvert.DeserializeObject<ViewWorkspace>(DefaultJson);

            public static readonly ViewWorkspace Null = null;
        }

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

    public enum TestEnum
    {
        Test0 = 0,
        Test1 = 1,
        Test2 = 2
    }
}