using System;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Typeform.Sdk.CSharp.Models.Workspaces;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests.Models
{
    public class UpdateWorkspaceTests
    {
        [Fact]
        public void AddMember_Empty_String()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(workspaceId);
            var emailAddress = string.Empty;

            // ACT
            Action actionToTest = () => updateWorkspace.AddMember(emailAddress);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddMember_From_Valid_Value_To_Valid_Value()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(workspaceId);
            var emailAddress = TestData.BogusFaker.Internet.Email();
            updateWorkspace.AddMember(emailAddress);
            var emailAddressChangeTo = TestData.BogusFaker.Internet.Email();


            // ACT
            updateWorkspace.AddMember(emailAddressChangeTo);

            // ASSERT
            updateWorkspace.UpdateMemberOptions.Should().OnlyHaveUniqueItems();
            updateWorkspace.UpdateMemberOptions.First().Operation.Should().Be(OperationType.Add);
            updateWorkspace.UpdateMemberOptions.First().Path.Should().Be("/member");
            updateWorkspace.UpdateMemberOptions.Should().Contain(x => x.Value.Email.Equals(emailAddress));
            updateWorkspace.UpdateMemberOptions.Should().Contain(x => x.Value.Email.Equals(emailAddressChangeTo));
        }

        [Fact]
        public void AddMember_Null()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(workspaceId);
            string emailAddress = null;

            // ACT
            Action actionToTest = () => updateWorkspace.ChangeWorkspaceName(emailAddress);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddMember_Valid_Value()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(workspaceId);
            var emailAddress = TestData.BogusFaker.Internet.Email();

            // ACT
            updateWorkspace.AddMember(emailAddress);

            // ASSERT
            updateWorkspace.UpdateMemberOptions.Should().OnlyHaveUniqueItems();
            updateWorkspace.UpdateMemberOptions.First().Operation.Should().Be(OperationType.Add);
            updateWorkspace.UpdateMemberOptions.First().Path.Should().Be("/member");
            updateWorkspace.UpdateMemberOptions.First().Value.Email.Should().Be(emailAddress);
        }

        [Fact]
        public void ChangeWorkspaceName_Change_From_Valid_Value_To_Valid_Value()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(workspaceId);
            updateWorkspace.ChangeWorkspaceName(TestData.Workspace.FullWorkspace.Name);
            var nameToChangeTo = TestData.BogusRandomizer.AlphaNumeric(10);

            // ACT
            updateWorkspace.ChangeWorkspaceName(nameToChangeTo);

            // ASSERT
            updateWorkspace.UpdateWorkspaceName.Operation.Should().Be(OperationType.Replace);
            updateWorkspace.UpdateWorkspaceName.Path.Should().Be("/name");
            updateWorkspace.UpdateWorkspaceName.Value.Should().NotBe(TestData.Workspace.FullWorkspace.Name);
            updateWorkspace.UpdateWorkspaceName.Value.Should().Be(nameToChangeTo);
        }

        [Fact]
        public void ChangeWorkspaceName_Empty_String()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(workspaceId);
            var nameValue = string.Empty;

            // ACT
            Action actionToTest = () => updateWorkspace.ChangeWorkspaceName(nameValue);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ChangeWorkspaceName_Null()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(workspaceId);
            string nameValue = null;

            // ACT
            Action actionToTest = () => updateWorkspace.ChangeWorkspaceName(nameValue);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ChangeWorkspaceName_Valid_Value()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(workspaceId);

            // ACT
            updateWorkspace.ChangeWorkspaceName(TestData.Workspace.FullWorkspace.Name);

            // ASSERT
            updateWorkspace.UpdateWorkspaceName.Operation.Should().Be(OperationType.Replace);
            updateWorkspace.UpdateWorkspaceName.Path.Should().Be("/name");
            updateWorkspace.UpdateWorkspaceName.Value.Should().Be(TestData.Workspace.FullWorkspace.Name);
        }

        [Fact]
        public void Create_Default()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);

            // ACT
            var updateWorkspace = UpdateWorkspace.Create(workspaceId);

            // ASSERT
            updateWorkspace.WorkspaceId.Should().Be(workspaceId);
            updateWorkspace.UpdateMemberOptions.Should().NotBeNull();
        }

        [Fact]
        public void RemoveMember_Empty_String()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(workspaceId);
            var emailAddress = string.Empty;

            // ACT
            Action actionToTest = () => updateWorkspace.RemoveMember(emailAddress);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void RemoveMember_From_Valid_Value_To_Valid_Value()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(workspaceId);
            var emailAddress = TestData.BogusFaker.Internet.Email();
            updateWorkspace.RemoveMember(emailAddress);
            var emailAddressChangeTo = TestData.BogusFaker.Internet.Email();

            // ACT
            updateWorkspace.RemoveMember(emailAddressChangeTo);

            // ASSERT
            updateWorkspace.UpdateMemberOptions.Should().OnlyHaveUniqueItems();
            updateWorkspace.UpdateMemberOptions.First().Operation.Should().Be(OperationType.Remove);
            updateWorkspace.UpdateMemberOptions.First().Path.Should().Be("/member");
            updateWorkspace.UpdateMemberOptions.Should().Contain(x => x.Value.Email.Equals(emailAddress));
            updateWorkspace.UpdateMemberOptions.Should().Contain(x => x.Value.Email.Equals(emailAddressChangeTo));
        }

        [Fact]
        public void RemoveMember_Null()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(workspaceId);
            string emailAddress = null;

            // ACT
            Action actionToTest = () => updateWorkspace.RemoveMember(emailAddress);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void RemoveMember_Valid_Value()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(workspaceId);
            var emailAddress = TestData.BogusFaker.Internet.Email();

            // ACT
            updateWorkspace.RemoveMember(emailAddress);

            // ASSERT
            updateWorkspace.UpdateMemberOptions.Should().OnlyHaveUniqueItems();
            updateWorkspace.UpdateMemberOptions.First().Operation.Should().Be(OperationType.Remove);
            updateWorkspace.UpdateMemberOptions.First().Path.Should().Be("/member");
            updateWorkspace.UpdateMemberOptions.First().Value.Email.Should().Be(emailAddress);
        }
    }
}