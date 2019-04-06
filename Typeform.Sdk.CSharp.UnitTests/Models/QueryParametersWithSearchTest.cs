using System;
using System.Diagnostics.CodeAnalysis;
using Bogus;
using FluentAssertions;
using Typeform.Sdk.CSharp.Models.Shared;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests.Models
{
    [ExcludeFromCodeCoverage]
    public class QueryParametersWithSearchTest
    {
        [Fact]
        public void QueryParametersWithSearch_ClearSearchFilter()
        {
            // ARRANGE
            var searchFilterToUse = TestData.BogusRandomizer.AlphaNumeric(15);
            var queryParameters = QueryParametersWithSearch.Create(searchFilterToUse);

            // ACT
            queryParameters.ClearSearchFilter();

            // ASSERT
            queryParameters.SearchFilter.Should().NotBe(searchFilterToUse);
            queryParameters.SearchFilter.Should().BeEmpty();
        }

        [Fact]
        public void QueryParametersWithSearch_Create_With_Page_Parameter_Only()
        {
            // ARRANGE
            // ACT
            var queryParameterToTest = QueryParametersWithSearch.Create(page: 100);

            // ASSERT
            queryParameterToTest.Should().BeOfType<QueryParametersWithSearch>();
            queryParameterToTest.Page.Should().NotBe(1);
            queryParameterToTest.Page.Should().Be(100);
            queryParameterToTest.PageSize.Should().Be(10);
            queryParameterToTest.SearchFilter.Should().BeEmpty();
        }

        [Fact]
        public void QueryParametersWithSearch_Create_With_PageSize_Parameter_Only()
        {
            // ARRANGE
            // ACT
            var queryParameterToTest = QueryParametersWithSearch.Create(pageSize: 100);

            // ASSERT
            queryParameterToTest.Should().BeOfType<QueryParametersWithSearch>();
            queryParameterToTest.Page.Should().Be(1);
            queryParameterToTest.PageSize.Should().NotBe(10);
            queryParameterToTest.PageSize.Should().Be(100);
            queryParameterToTest.SearchFilter.Should().BeEmpty();
        }

        [Fact]
        public void QueryParametersWithSearch_Create_With_SearchFilter_PageSize_Page_Parameter()
        {
            // ARRANGE
            var searchFilterValueToUse = TestData.BogusRandomizer.AlphaNumeric(25);

            // ACT
            var queryParameterToTest = QueryParametersWithSearch.Create(searchFilterValueToUse, 10, 100);

            // ASSERT
            queryParameterToTest.Should().BeOfType<QueryParametersWithSearch>();
            queryParameterToTest.Page.Should().NotBe(1);
            queryParameterToTest.Page.Should().Be(10);
            queryParameterToTest.PageSize.Should().NotBe(10);
            queryParameterToTest.PageSize.Should().Be(100);
            queryParameterToTest.SearchFilter.Should().NotBeNullOrEmpty();
            queryParameterToTest.SearchFilter.Should().Be(searchFilterValueToUse);
        }

        [Fact]
        public void QueryParametersWithSearch_Create_With_SearchFilter_Parameter_Only()
        {
            // ARRANGE
            var searchFilterValueToUse = TestData.BogusRandomizer.AlphaNumeric(25);

            // ACT
            var queryParameterToTest = QueryParametersWithSearch.Create(searchFilterValueToUse);

            // ASSERT
            queryParameterToTest.Should().BeOfType<QueryParametersWithSearch>();
            queryParameterToTest.Page.Should().Be(1);
            queryParameterToTest.PageSize.Should().Be(10);
            queryParameterToTest.SearchFilter.Should().NotBeNullOrEmpty();
            queryParameterToTest.SearchFilter.Should().Be(searchFilterValueToUse);
        }

        [Fact]
        public void QueryParametersWithSearch_Create_Without_Parameters()
        {
            // ARRANGE
            // ACT
            var queryParameterToTest = QueryParametersWithSearch.Create();

            // ASSERT
            queryParameterToTest.Should().BeOfType<QueryParametersWithSearch>();
            queryParameterToTest.Page.Should().Be(1);
            queryParameterToTest.PageSize.Should().Be(10);
            queryParameterToTest.SearchFilter.Should().BeEmpty();
        }

        [Fact]
        public void QueryParametersWithSearch_SetPage_AboveMinValue()
        {
            // ARRANGE
            var queryParameters = QueryParametersWithSearch.Create();

            // ACT
            Func<QueryParametersWithSearch> actionToTest = () => queryParameters.SetPage(10);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
            actionToTest.Invoke().Page.Should().Be(10);
        }

        [Fact]
        public void QueryParametersWithSearch_SetPage_BelowMinValue()
        {
            // ARRANGE
            var queryParameters = QueryParametersWithSearch.Create();

            // ACT
            Action actionToTest = () => queryParameters.SetPage(-1);

            // ASSERT
            actionToTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void QueryParametersWithSearch_SetPageSize_AboveMaxValue()
        {
            // ARRANGE
            var queryParameters = QueryParametersWithSearch.Create();

            // ACT
            Action actionToTest = () => queryParameters.SetPageSize(201);

            // ASSERT
            actionToTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void QueryParametersWithSearch_SetPageSize_BelowMinValue()
        {
            // ARRANGE
            var queryParameters = QueryParametersWithSearch.Create();

            // ACT
            Action actionToTest = () => queryParameters.SetPageSize(-1);

            // ASSERT
            actionToTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void QueryParametersWithSearch_SetPageSize_BetweenMinAndMaxValue()
        {
            // ARRANGE
            var queryParameters = QueryParametersWithSearch.Create();

            // ACT
            Func<QueryParametersWithSearch> actionToTest = () => queryParameters.SetPageSize(100);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
            actionToTest.Invoke().PageSize.Should().Be(100);
        }

        [Fact]
        public void QueryParametersWithSearch_SetSearchFilter()
        {
            // ARRANGE
            var searchFilterValue = TestData.BogusRandomizer.AlphaNumeric(15);
            var queryParameters = QueryParametersWithSearch.Create();

            // ACT
            Func<QueryParametersWithSearch> actionToTest = () => queryParameters.SetSearchFilter(searchFilterValue);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
            actionToTest.Invoke().SearchFilter.Should().Be(searchFilterValue);
        }
    }
}