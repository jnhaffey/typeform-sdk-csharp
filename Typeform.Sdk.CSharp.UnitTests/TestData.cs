using Bogus;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Exceptions;
using Typeform.Sdk.CSharp.Models.Shared;
using Typeform.Sdk.CSharp.Models.Workspaces;

namespace Typeform.Sdk.CSharp.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class TestData
    {
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

            public static ViewWorkspace FullWorkspace = new ViewWorkspace
            {
                Id = FullWorkspaceId,
                Name = "UNIT_TEST_WORKSPACE",
                Default = true,
                Shared = false,
                SelfLink = new HrefObject
                {
                    Url = FullWorkspaceSelfUrl
                },
                Forms = new WorkspaceForms
                {
                    Count = 0,
                    Url = FullWorkspaceFormsUrl
                },
                Members = new List<WorkspaceMember>
                {
                    new WorkspaceMember
                    {
                        Email = "owner@example.com",
                        Name = "Account Owner",
                        Role = MemberRoleType.Owner
                    },
                    new WorkspaceMember
                    {
                        Email = "member@example.com",
                        Name = "Account Member",
                        Role = MemberRoleType.Member
                    }
                }
            };

            public static string DefaultJson = $"{{\"id\":\"{FullWorkspace.Id}\"," +
                                               $"\"name\":\"{FullWorkspace.Name}\"," +
                                               $"\"default\":{FullWorkspace.Default.ToLowerString()}," +
                                               $"\"shared\":{FullWorkspace.Shared.ToLowerString()}," +
                                               $"\"forms\":{{\"count\":{FullWorkspace.Forms.Count},\"href\":\"{FullWorkspace.Forms.Url}\"}}," +
                                               $"\"self\":{{\"href\":\"{FullWorkspace.SelfLink.Url}\"}}," +
                                               $"\"members\":[{{\"name\":\"{FullWorkspace.Members[0].Name}\",\"email\":\"{FullWorkspace.Members[0].Email}\",\"role\":{(int)FullWorkspace.Members[0].Role}}},{{\"name\":\"{FullWorkspace.Members[1].Name}\",\"email\":\"{FullWorkspace.Members[1].Email}\",\"role\":{(int)FullWorkspace.Members[1].Role}}}]}}";
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