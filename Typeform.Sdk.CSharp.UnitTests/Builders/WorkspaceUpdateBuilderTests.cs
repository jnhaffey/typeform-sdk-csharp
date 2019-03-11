using System;
using Bogus;
using FluentAssertions;
using Typeform.Sdk.CSharp.Builders;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests.Builders
{
    public class WorkspaceUpdateBuilderTests
    {
        private readonly Randomizer bogusRandomizer = new Randomizer(DateTime.UtcNow.Millisecond);
        private readonly Faker bogusFaker = new Faker();

        [Fact]
        public void Create_with_WorkspaceId()
        {
            // ARRANGE
            var workspaceIdToUse = bogusRandomizer.AlphaNumeric(5);

            // ACT
            Func<WorkspaceUpdateBuilder> functionToTest = () => WorkspaceUpdateBuilder.Create(workspaceIdToUse);

            // ASSERT
            functionToTest.Should().NotThrow<ArgumentException>();
            functionToTest.Invoke().Should().BeOfType<WorkspaceUpdateBuilder>();
            functionToTest.Invoke().WorkspaceId.Should().Be(workspaceIdToUse);
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
            var workspaceIdToUse = bogusRandomizer.AlphaNumeric(5);
            var workspaceNameToChange = bogusRandomizer.Word();
            var emailToAdd = bogusFaker.Person.Email;
            var emailToRemove = bogusFaker.Person.Email;
            var workspaceUpdateBuilderToTest = WorkspaceUpdateBuilder.Create(workspaceIdToUse)
                .ReplaceName(workspaceNameToChange)
                .AddMember(emailToAdd)
                .RemoveMember(emailToRemove);

            // ACT
            var jsonPatchData = workspaceUpdateBuilderToTest.ToJsonPatch();

            // ASSERT
        }
    }
}