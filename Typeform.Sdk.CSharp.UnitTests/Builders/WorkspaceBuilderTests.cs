using System;
using System.Threading.Tasks;
using FluentAssertions;
using Typeform.Sdk.CSharp.Builders;
using Typeform.Sdk.CSharp.Models.Workspaces;
using Xunit;
using Xunit.Abstractions;

namespace Typeform.Sdk.CSharp.UnitTests.Builders
{
    public class WorkspaceBuilderTests
    {
        public WorkspaceBuilderTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        private readonly ITestOutputHelper _testOutputHelper;

        [Fact]
        public void BuiltNew_Valid()
        {
            // ARRANGE
            var builderToUse = WorkspaceBuilder.Create(TestData.Workspace.FullWorkspace.Name);

            // ACT
            Func<CreateWorkspace> funcToTest = () => builderToUse.BuildNew();

            // ASSERT
            funcToTest.Should().NotThrow<InvalidOperationException>();
            funcToTest.Invoke().Should().BeOfType<CreateWorkspace>();
            funcToTest.Invoke().Name.Should().Be(TestData.Workspace.FullWorkspace.Name);
        }

        [Fact]
        public void Create_With_Workspace_Name_As_Empty()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceBuilder> functionToTest = () => WorkspaceBuilder.Create(TestData.EmptyValue);

            // ASSERT
            functionToTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Create_With_Workspace_Name_As_Null()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceBuilder> functionToTest = () => WorkspaceBuilder.Create(TestData.NullValue);

            // ASSERT
            functionToTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Create_With_Workspace_Name_As_Value()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceBuilder> functionToTest =
                () => WorkspaceBuilder.Create(TestData.Workspace.FullWorkspace.Name);

            // ASSERT
            functionToTest.Should().NotThrow<ArgumentException>();
            functionToTest.Invoke().Should().BeOfType<WorkspaceBuilder>();
        }

        [Fact]
        public void Create_With_Workspace_Name_As_Whitespace()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceBuilder> functionToTest = () => WorkspaceBuilder.Create(TestData.WhiteSpaceValue);

            // ASSERT
            functionToTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateFrom_Json_Empty()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceBuilder> functionToTest = () => WorkspaceBuilder.CreateFrom(TestData.EmptyValue);

            // ASSERT
            functionToTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateFrom_Json_Null()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceBuilder> functionToTest = () => WorkspaceBuilder.CreateFrom(TestData.NullValue);

            // ASSERT
            functionToTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateFrom_Json_Valid()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceBuilder> functionToTest = () => WorkspaceBuilder.CreateFrom(TestData.Workspace.DefaultJson);

            // ASSERT
            functionToTest.Should().NotThrow<ArgumentException>();
            functionToTest.Invoke().Should().BeOfType<WorkspaceBuilder>();
        }

        [Fact]
        public void CreateFrom_Json_WhiteSpace()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceBuilder> functionToTest = () => WorkspaceBuilder.CreateFrom(TestData.WhiteSpaceValue);

            // ASSERT
            functionToTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateFrom_Model_Null()
        {
            // ARRANGE
            ViewWorkspace nullModel = null;

            // ACT
            Func<WorkspaceBuilder> functionToTest = () => WorkspaceBuilder.CreateFrom(nullModel);

            // ASSERT
            functionToTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateFrom_Model_Valid()
        {
            // ARRANGE
            // ACT
            Func<WorkspaceBuilder> functionToTest = () => WorkspaceBuilder.CreateFrom(TestData.Workspace.FullWorkspace);

            // ASSERT
            functionToTest.Should().NotThrow<ArgumentException>();
            functionToTest.Invoke().Should().BeOfType<WorkspaceBuilder>();
        }

        [Fact]
        public async Task IsValid_Valid()
        {
            // ARRANGE
            var workspaceBuilderToUse = WorkspaceBuilder.Create(TestData.Workspace.FullWorkspace.Name);

            // ACT
            var result = await workspaceBuilderToUse.IsValid();

            // ASSERT
            result.Should().BeTrue();
        }
    }
}