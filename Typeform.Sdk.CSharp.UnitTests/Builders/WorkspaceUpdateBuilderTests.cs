using System;
using FluentAssertions;
using Typeform.Sdk.CSharp.Builders;
using Xunit;
using Xunit.Abstractions;

namespace Typeform.Sdk.CSharp.UnitTests.Builders
{
    public class WorkspaceUpdateBuilderTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public WorkspaceUpdateBuilderTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact]
        public void Create_with_WorkspaceId()
        {
            // ARRANGE
            var workspaceIdToUse = TestData.BogusRandomizer.AlphaNumeric(5);

            // ACT
            Func<WorkspaceUpdateBuilder> functionToTest = () => WorkspaceUpdateBuilder.Create(workspaceIdToUse);

            // ASSERT
            functionToTest.Should().NotThrow<ArgumentException>();
            functionToTest.Invoke().Should().BeOfType<WorkspaceUpdateBuilder>();
        }

        [Fact]
        public void Create_without_WorkspaceId()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceUpdateBuilder> functionToTest = () => WorkspaceUpdateBuilder.Create(string.Empty);

            // ASSERT
            functionToTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ToJsonPatch()
        {
            // ARRANGE
            var workspaceIdToUse = TestData.BogusRandomizer.AlphaNumeric(5);
            var workspaceNameToChange = TestData.BogusRandomizer.Word();
            var emailToAdd = TestData.BogusFaker.Person.Email;
            var emailToRemove = TestData.BogusFaker.Person.Email;
            var workspaceUpdateBuilder = WorkspaceUpdateBuilder.Create(workspaceIdToUse)
                .ReplaceName(workspaceNameToChange)
                .AddMember(emailToAdd)
                .RemoveMember(emailToRemove);

            // ACT
            var jsonPatchData = workspaceUpdateBuilder.ToJsonPatch();

            // ASSERT
            jsonPatchData.Should().NotBeEmpty();
            _testOutputHelper.WriteLine($"Raw Json: {jsonPatchData}");
        }
    }
}