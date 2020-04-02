using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Typeform.Sdk.CSharp.Models.Workspaces;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests.Models
{
    [ExcludeFromCodeCoverage]
    public class CreateWorkspaceTests
    {
        [Fact]
        public void Create_Default()
        {
            // ARRANGE
            // ACT
            var createWorkspace = CreateWorkspace.Create(TestData.Workspace.FullViewWorkspace.Name);

            // ASSERT
            createWorkspace.Name.Should().Be(TestData.Workspace.FullViewWorkspace.Name);
        }
    }
}