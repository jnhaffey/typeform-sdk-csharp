using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Typeform.Sdk.CSharp.Models.Workspaces;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests.Models
{
    [ExcludeFromCodeCoverage]
    public class UpdateWorkspaceTests
    {
        [Fact]
        public void AddMember_Empty_String()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(TestData.Workspace.FullViewWorkspace);
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
            var updateWorkspace = UpdateWorkspace.Create(TestData.Workspace.FullViewWorkspace);
            var emailAddress = TestData.BogusFaker.Internet.Email();
            updateWorkspace.AddMember(emailAddress);
            var emailAddressChangeTo = TestData.BogusFaker.Internet.Email();


            // ACT
            updateWorkspace.AddMember(emailAddressChangeTo);

            // ASSERT
            updateWorkspace.GetMemberUpdates.Should().OnlyHaveUniqueItems();
            updateWorkspace.GetMemberUpdates.First().Operation.Should().Be(OperationType.Add);
            updateWorkspace.GetMemberUpdates.First().Path.Should().Be("/member");
            updateWorkspace.GetMemberUpdates.Should().Contain(x => x.Value.Email.Equals(emailAddress));
            updateWorkspace.GetMemberUpdates.Should().Contain(x => x.Value.Email.Equals(emailAddressChangeTo));
        }

        [Fact]
        public void AddMember_Null()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(TestData.Workspace.FullViewWorkspace);
            string emailAddress = null;

            // ACT
            Action actionToTest = () => updateWorkspace.AddMember(emailAddress);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddMember_Valid_Value()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(TestData.Workspace.FullViewWorkspace);
            var emailAddress = TestData.BogusFaker.Internet.Email();

            // ACT
            updateWorkspace.AddMember(emailAddress);

            // ASSERT
            updateWorkspace.GetMemberUpdates.Should().OnlyHaveUniqueItems();
            updateWorkspace.GetMemberUpdates.First().Operation.Should().Be(OperationType.Add);
            updateWorkspace.GetMemberUpdates.First().Path.Should().Be("/member");
            updateWorkspace.GetMemberUpdates.First().Value.Email.Should().Be(emailAddress);
        }

        [Fact]
        public void ChangeWorkspaceName_Change_From_Valid_Value_To_Valid_Value()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(TestData.Workspace.FullViewWorkspace);
            updateWorkspace.ChangeName(TestData.Workspace.FullViewWorkspace.Name);
            var nameToChangeTo = TestData.BogusRandomizer.AlphaNumeric(10);

            // ACT
            updateWorkspace.ChangeName(nameToChangeTo);

            // ASSERT
            updateWorkspace.GetNameChange.Operation.Should().Be(OperationType.Replace);
            updateWorkspace.GetNameChange.Path.Should().Be("/name");
            updateWorkspace.GetNameChange.Value.Should().NotBe(TestData.Workspace.FullViewWorkspace.Name);
            updateWorkspace.GetNameChange.Value.Should().Be(nameToChangeTo);
        }

        [Fact]
        public void ChangeWorkspaceName_Empty_String()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(TestData.Workspace.FullViewWorkspace);
            var nameValue = string.Empty;

            // ACT
            Action actionToTest = () => updateWorkspace.ChangeName(nameValue);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ChangeWorkspaceName_Null()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(TestData.Workspace.FullViewWorkspace);
            string nameValue = null;

            // ACT
            Action actionToTest = () => updateWorkspace.ChangeName(nameValue);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ChangeWorkspaceName_Valid_Value()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(TestData.Workspace.FullViewWorkspace);

            // ACT
            updateWorkspace.ChangeName(TestData.Workspace.FullViewWorkspace.Name);

            // ASSERT
            updateWorkspace.GetNameChange.Operation.Should().Be(OperationType.Replace);
            updateWorkspace.GetNameChange.Path.Should().Be("/name");
            updateWorkspace.GetNameChange.Value.Should().Be(TestData.Workspace.FullViewWorkspace.Name);
        }

        [Fact]
        public void Create_Default()
        {
            // ARRANGE
            // ACT
            var updateWorkspace = UpdateWorkspace.Create(TestData.Workspace.FullViewWorkspace);

            // ASSERT
            updateWorkspace.Id.Should().Be(TestData.Workspace.FullViewWorkspace.Id);
            updateWorkspace.GetMemberUpdates.Should().NotBeNull();
        }

        [Fact]
        public void RemoveMember_Empty_String()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(TestData.Workspace.FullViewWorkspace);
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
            var updateWorkspace = UpdateWorkspace.Create(TestData.Workspace.FullViewWorkspace);
            var emailAddress = TestData.BogusFaker.Internet.Email();
            updateWorkspace.RemoveMember(emailAddress);
            var emailAddressChangeTo = TestData.BogusFaker.Internet.Email();

            // ACT
            updateWorkspace.RemoveMember(emailAddressChangeTo);

            // ASSERT
            updateWorkspace.GetMemberUpdates.Should().OnlyHaveUniqueItems();
            updateWorkspace.GetMemberUpdates.First().Operation.Should().Be(OperationType.Remove);
            updateWorkspace.GetMemberUpdates.First().Path.Should().Be("/member");
            updateWorkspace.GetMemberUpdates.Should().Contain(x => x.Value.Email.Equals(emailAddress));
            updateWorkspace.GetMemberUpdates.Should().Contain(x => x.Value.Email.Equals(emailAddressChangeTo));
        }

        [Fact]
        public void RemoveMember_Null()
        {
            // ARRANGE
            var workspaceId = TestData.BogusRandomizer.AlphaNumeric(10);
            var updateWorkspace = UpdateWorkspace.Create(TestData.Workspace.FullViewWorkspace);
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
            var updateWorkspace = UpdateWorkspace.Create(TestData.Workspace.FullViewWorkspace);
            var emailAddress = TestData.BogusFaker.Internet.Email();

            // ACT
            updateWorkspace.RemoveMember(emailAddress);

            // ASSERT
            updateWorkspace.GetMemberUpdates.Should().OnlyHaveUniqueItems();
            updateWorkspace.GetMemberUpdates.First().Operation.Should().Be(OperationType.Remove);
            updateWorkspace.GetMemberUpdates.First().Path.Should().Be("/member");
            updateWorkspace.GetMemberUpdates.First().Value.Email.Should().Be(emailAddress);
        }
    }
}