using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Models.Workspaces;
using Xunit;
using Xunit.Abstractions;

namespace Typeform.Sdk.CSharp.UnitTests.Models
{
    [ExcludeFromCodeCoverage]
    public class ViewWorkspaceTests
    {
        public ViewWorkspaceTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        private readonly ITestOutputHelper _testOutputHelper;

        [Fact]
        public void FromJson_With_Empty_Value()
        {
            // ARRANGE
            var viewWorkspace = new ViewWorkspace();

            // ACT
            Action actionToTest = () => viewWorkspace.FromJson(string.Empty);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>()
                .WithMessage("jsonData cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void FromJson_With_Null_Value()
        {
            // ARRANGE
            var viewWorkspace = new ViewWorkspace();
            string nullValue = null;

            // ACT
            Action actionToTest = () => viewWorkspace.FromJson(nullValue);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>()
                .WithMessage("jsonData cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void FromJson_With_Valid_Value()
        {
            // ARRANGE
            var viewWorkspaceToTest = new ViewWorkspace();

            // ACT
            viewWorkspaceToTest.FromJson(TestData.Workspace.DefaultJson);

            // ASSERT
            viewWorkspaceToTest.Id.Should().Be(TestData.Workspace.FullWorkspace.Id);
            viewWorkspaceToTest.Name.Should().Be(TestData.Workspace.FullWorkspace.Name);
            viewWorkspaceToTest.Default.Should().Be(TestData.Workspace.FullWorkspace.Default);
            viewWorkspaceToTest.Shared.Should().Be(TestData.Workspace.FullWorkspace.Shared);
            viewWorkspaceToTest.SelfLink.Url.Should().Be(TestData.Workspace.FullWorkspace.SelfLink.Url);
            viewWorkspaceToTest.Forms.Count.Should().Be(TestData.Workspace.FullWorkspace.Forms.Count);
            viewWorkspaceToTest.Forms.Url.Should().Be(TestData.Workspace.FullWorkspace.Forms.Url);
            //viewWorkspaceToTest.Members.Should().Contain(TestData.Workspace.FullWorkspace.Members);
        }

        [Fact]
        public void GenerateUpdateWorkspaceModel()
        {
            // ARRANGE
            var originalViewWorkspace = TestData.Workspace.FullWorkspace;
            var updatedViewWorkspace = new ViewWorkspace
            {
                Id = originalViewWorkspace.Id,
                Name = TestData.BogusRandomizer.AlphaNumeric(10),
                Members = new List<WorkspaceMember>
                {
                    new WorkspaceMember
                    {
                        Name = originalViewWorkspace.Members[0].Name,
                        Email = originalViewWorkspace.Members[0].Email,
                        Role = originalViewWorkspace.Members[0].Role
                    },
                    new WorkspaceMember
                    {
                        Name = TestData.BogusFaker.Person.FullName,
                        Email = TestData.BogusFaker.Person.Email,
                        Role = MemberRoleType.Member
                    }
                }
            };

            // ACT
            var results = originalViewWorkspace.GenerateUpdateWorkspaceModel(updatedViewWorkspace);

            // ASSERT
            results.UpdateWorkspaceName.Operation.Should().Be(OperationType.Replace);
            results.UpdateWorkspaceName.Path.Should().Be("/name");
            results.UpdateWorkspaceName.Value.Should().Be(updatedViewWorkspace.Name);

            results.UpdateMemberOptions.Where(x => x.Operation == OperationType.Add).Should().HaveCount(1);
            results.UpdateMemberOptions.FirstOrDefault(x => x.Operation == OperationType.Add).Path.Should()
                .Be("/member");
            results.UpdateMemberOptions.FirstOrDefault(x => x.Operation == OperationType.Add)
                .Value.Email.Should().Be(updatedViewWorkspace.Members[1].Email);

            results.UpdateMemberOptions.Where(x => x.Operation == OperationType.Remove).Should().HaveCount(1);
            results.UpdateMemberOptions.FirstOrDefault(x => x.Operation == OperationType.Remove).Path.Should()
                .Be("/member");
            results.UpdateMemberOptions.FirstOrDefault(x => x.Operation == OperationType.Remove)
                .Value.Email.Should().Be(TestData.Workspace.FullWorkspace.Members[1].Email);
        }

        [Fact]
        public void ToJson()
        {
            // ARRANGE
            var modelToUse = TestData.Workspace.FullWorkspace;

            // ACT
            var jsonValueToTest = modelToUse.ToJson();

            // ASSERT
            jsonValueToTest.Should().NotBeNullOrEmpty();
            jsonValueToTest.Should().BeEquivalentTo(TestData.Workspace.DefaultJson);
            _testOutputHelper.WriteLine(jsonValueToTest);
        }
    }
}