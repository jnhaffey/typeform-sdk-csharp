using System;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Exceptions;
using Typeform.Sdk.CSharp.Models.Workspaces;
using Typeform.Sdk.CSharp.Modifiers;
using Xunit;
using Xunit.Abstractions;

namespace Typeform.Sdk.CSharp.UnitTests.Modifiers
{
    public class WorkspaceModifierTests
    {
        public WorkspaceModifierTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        private readonly ITestOutputHelper _testOutputHelper;

        [Fact]
        public void AddMember_With_Empty_String()
        {
            // ARRANGE
            var workspaceModifierToUse = WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);

            // ACT
            Action actionToTest = () => workspaceModifierToUse.AddMember(TestData.EmptyValue);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>()
                .WithMessage("emailAddress cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void AddMember_With_Invalid_Email()
        {
            // ARRANGE
            var workspaceModifierToUse = WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);
            var invalidEmail = TestData.BogusRandomizer.AlphaNumeric(10);

            // ACT
            Action actionToTest = () => workspaceModifierToUse.AddMember(invalidEmail);

            // ASSERT
            actionToTest.Should().Throw<InvalidEmailException>()
                .WithMessage(
                    $"The email address provided, '{invalidEmail}' in the parameter 'emailAddress' is not valid.");
        }

        [Fact]
        public void AddMember_With_Null_String()
        {
            // ARRANGE
            var workspaceModifierToUse = WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);

            // ACT
            Action actionToTest = () => workspaceModifierToUse.AddMember(TestData.NullValue);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>()
                .WithMessage("emailAddress cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void AddMember_With_Valid_Email()
        {
            // ARRANGE
            var workspaceModifierToUse = WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);

            // ACT
            Action actionToTest = () => workspaceModifierToUse.AddMember(TestData.BogusFaker.Internet.Email());

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void BuiltUpdate_Valid()
        {
            // ARRANGE
            var workspaceModifierToUse = WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);

            // ACT
            Func<UpdateWorkspace> funcToTest = () => workspaceModifierToUse.BuildUpdate();

            // ASSERT
            funcToTest.Should().NotThrow<InvalidOperationException>();
            funcToTest.Invoke().Should().BeOfType<UpdateWorkspace>();
            funcToTest.Invoke().WorkspaceId.Should().Be(TestData.Workspace.FullWorkspace.Id);
        }

        [Fact]
        public void Create_With_Empty_String()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceModifier> funcToTest = () => WorkspaceModifier.Create(TestData.EmptyValue);

            // ASSERT
            funcToTest.Should().Throw<ArgumentException>()
                .WithMessage("workspaceJson cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void Create_With_Invalid_Workspace_Json_String()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceModifier> funcToTest = () => WorkspaceModifier.Create(TestData.InvalidJson);

            // ASSERT
            funcToTest.Should().Throw<JsonReaderException>();
        }

        [Fact]
        public void Create_With_Null_String()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceModifier> funcToTest = () => WorkspaceModifier.Create(TestData.NullValue);

            // ASSERT
            funcToTest.Should().Throw<ArgumentException>()
                .WithMessage("workspaceJson cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void Create_With_Null_Workspace_Object()
        {
            // ARRANGE
            ViewWorkspace nullWorkspace = null;
            // ACT
            Func<WorkspaceModifier> funcToTest = () => WorkspaceModifier.Create(nullWorkspace);

            // ASSERT
            funcToTest.Should().Throw<ArgumentException>()
                .WithMessage("workspace cannot be null.*");
        }

        [Fact]
        public void Create_With_Valid_Workspace_Json_String()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceModifier> funcToTest = () => WorkspaceModifier.Create(TestData.Workspace.DefaultJson);

            // ASSERT
            funcToTest.Should().NotThrow();
        }

        [Fact]
        public void Create_With_Valid_Workspace_Object()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceModifier> funcToTest = () => WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);

            // ASSERT
            funcToTest.Should().NotThrow();
        }

        [Fact]
        public async Task IsValid_Pass()
        {
            // ARRANGE
            var workspaceModifierToUse = WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);
            workspaceModifierToUse.ReplaceName(TestData.BogusRandomizer.AlphaNumeric(5));

            // ACT
            var results = await workspaceModifierToUse.IsValid();

            // ARRANGE
            results.Should().BeTrue();
        }

        [Fact]
        public async Task IsValid_Fail_No_Change()
        {
            // ARRANGE
            var workspaceModifierToUse = WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);

            // ACT
            Func<Task> funcToTest = async () => await workspaceModifierToUse.IsValid();

            // ARRANGE
            funcToTest.Should().Throw<ValidationException>()
                .WithMessage("*-- UpdateMemberOptions: There are no changes applied to the workspace.*" +
                             "*-- UpdateWorkspaceName: There are no changes applied to the workspace.*");
        }

        [Fact]
        public void RemoveMember_With_Empty_String()
        {
            // ARRANGE
            var workspaceModifierToUse = WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);

            // ACT
            Func<WorkspaceModifier> funcToTest = () => workspaceModifierToUse.RemoveMember(TestData.EmptyValue);

            // ASSERT
            funcToTest.Should().Throw<ArgumentNullException>()
                .WithMessage("emailAddress cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void RemoveMember_With_Invalid_Email()
        {
            // ARRANGE
            var workspaceModifierToUse = WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);
            var invalidEmailAddress = TestData.BogusRandomizer.AlphaNumeric(15);

            // ACT
            Func<WorkspaceModifier> funcToTest = () => workspaceModifierToUse.RemoveMember(invalidEmailAddress);

            // ASSERT
            funcToTest.Should().Throw<InvalidEmailException>()
                .WithMessage($"The email address provided, '{invalidEmailAddress}' in the parameter 'emailAddress' is not valid.");
        }

        [Fact]
        public void RemoveMember_With_Null_String()
        {
            // ARRANGE
            var workspaceModifierToUse = WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);

            // ACT
            Func<WorkspaceModifier> funcToTest = () => workspaceModifierToUse.RemoveMember(TestData.NullValue);

            // ASSERT
            funcToTest.Should().Throw<ArgumentNullException>()
                .WithMessage("emailAddress cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void RemoveMember_With_Valid_Email()
        {
            // ARRANGE
            var workspaceModifierToUse = WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);
            var validEmailAddress = TestData.BogusFaker.Internet.Email();

            // ACT
            Func<WorkspaceModifier> funcToTest = () => workspaceModifierToUse.RemoveMember(validEmailAddress);

            // ASSERT
            funcToTest.Should().NotThrow();
        }

        [Fact]
        public void ReplaceName_With_Empty_String()
        {
            // ARRANGE
            var workspaceModifierToUse = WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);

            // ACT
            Func<WorkspaceModifier> funcToTest = () => workspaceModifierToUse.ReplaceName(TestData.EmptyValue);

            // ASSERT
            funcToTest.Should().Throw<ArgumentNullException>()
                .WithMessage("name cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void ReplaceName_With_Null_String()
        {
            // ARRANGE
            var workspaceModifierToUse = WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);

            // ACT
            Func<WorkspaceModifier> funcToTest = () => workspaceModifierToUse.ReplaceName(TestData.NullValue);

            // ASSERT
            funcToTest.Should().Throw<ArgumentNullException>()
                .WithMessage("name cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void ReplaceName_With_Valid_String()
        {
            // ARRANGE
            var workspaceModifierToUse = WorkspaceModifier.Create(TestData.Workspace.FullWorkspace);
            var nameToReplaceWith = TestData.BogusRandomizer.AlphaNumeric(15);

            // ACT
            Func<WorkspaceModifier> funcToTest = () => workspaceModifierToUse.ReplaceName(nameToReplaceWith);

            // ASSERT
            funcToTest.Should().NotThrow();
        }

        [Fact]
        public void ToJsonPatch_Valid()
        {
            // ARRANGE
            var workspaceNameToChange = TestData.BogusRandomizer.Word();
            var emailToAdd = TestData.BogusFaker.Person.Email;
            var emailToRemove = TestData.BogusFaker.Person.Email;
            var workspaceModifierToUse = WorkspaceModifier
                .Create(TestData.Workspace.FullWorkspace)
                .ReplaceName(workspaceNameToChange)
                .AddMember(emailToAdd)
                .RemoveMember(emailToRemove);

            // ACT
            var jsonPatchData = workspaceModifierToUse.ToJsonPatch();

            // ASSERT
            jsonPatchData.Should().NotBeEmpty();
            _testOutputHelper.WriteLine($"Raw Json: {jsonPatchData}");
        }
    }
}