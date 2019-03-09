using System;
using Bogus;
using FluentAssertions;
using Typeform.Sdk.CSharp.Models;
using Typeform.Sdk.CSharp.Models.Shared;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests.Models
{
    public class QueryParametersTest
    {
        private readonly Randomizer bogusRandomizer = new Randomizer(DateTime.UtcNow.Millisecond);

        [Fact]
        public void QueryParameters_ClearSearchFilter()
        {
            // ARRANGE
            var searchFilterToUse = bogusRandomizer.AlphaNumeric(15);
            var queryParameters = QueryParameters.Create(searchFilterToUse);

            // ACT
            queryParameters.ClearSearchFilter();

            // ASSERT
            queryParameters.SearchFilter.Should().NotBe(searchFilterToUse);
            queryParameters.SearchFilter.Should().BeEmpty();
        }

        [Fact]
        public void QueryParameters_Create_With_Page_Parameter_Only()
        {
            // ARRANGE
            // ACT
            var queryParameterToTest = QueryParameters.Create(page: 100);

            // ASSERT
            queryParameterToTest.Should().BeOfType<QueryParameters>();
            queryParameterToTest.Page.Should().NotBe(1);
            queryParameterToTest.Page.Should().Be(100);
            queryParameterToTest.PageSize.Should().Be(10);
            queryParameterToTest.SearchFilter.Should().BeEmpty();
        }

        [Fact]
        public void QueryParameters_Create_With_PageSize_Parameter_Only()
        {
            // ARRANGE
            // ACT
            var queryParameterToTest = QueryParameters.Create(pageSize: 100);

            // ASSERT
            queryParameterToTest.Should().BeOfType<QueryParameters>();
            queryParameterToTest.Page.Should().Be(1);
            queryParameterToTest.PageSize.Should().NotBe(10);
            queryParameterToTest.PageSize.Should().Be(100);
            queryParameterToTest.SearchFilter.Should().BeEmpty();
        }

        [Fact]
        public void QueryParameters_Create_With_SearchFilter_PageSize_Page_Parameter()
        {
            // ARRANGE
            var searchFilterValueToUse = bogusRandomizer.AlphaNumeric(25);

            // ACT
            var queryParameterToTest = QueryParameters.Create(searchFilterValueToUse, 10, 100);

            // ASSERT
            queryParameterToTest.Should().BeOfType<QueryParameters>();
            queryParameterToTest.Page.Should().NotBe(1);
            queryParameterToTest.Page.Should().Be(10);
            queryParameterToTest.PageSize.Should().NotBe(10);
            queryParameterToTest.PageSize.Should().Be(100);
            queryParameterToTest.SearchFilter.Should().NotBeNullOrEmpty();
            queryParameterToTest.SearchFilter.Should().Be(searchFilterValueToUse);
        }

        [Fact]
        public void QueryParameters_Create_With_SearchFilter_Parameter_Only()
        {
            // ARRANGE
            var searchFilterValueToUse = bogusRandomizer.AlphaNumeric(25);

            // ACT
            var queryParameterToTest = QueryParameters.Create(searchFilterValueToUse);

            // ASSERT
            queryParameterToTest.Should().BeOfType<QueryParameters>();
            queryParameterToTest.Page.Should().Be(1);
            queryParameterToTest.PageSize.Should().Be(10);
            queryParameterToTest.SearchFilter.Should().NotBeNullOrEmpty();
            queryParameterToTest.SearchFilter.Should().Be(searchFilterValueToUse);
        }

        [Fact]
        public void QueryParameters_Create_Without_Parameters()
        {
            // ARRANGE
            // ACT
            var queryParameterToTest = QueryParameters.Create();

            // ASSERT
            queryParameterToTest.Should().BeOfType<QueryParameters>();
            queryParameterToTest.Page.Should().Be(1);
            queryParameterToTest.PageSize.Should().Be(10);
            queryParameterToTest.SearchFilter.Should().BeEmpty();
        }

        [Fact]
        public void QueryParameters_SetPage_AboveMinValue()
        {
            // ARRANGE
            var queryParameters = QueryParameters.Create();

            // ACT
            Func<QueryParameters> actionToTest = () => queryParameters.SetPage(10);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
            actionToTest.Invoke().Page.Should().Be(10);
        }

        [Fact]
        public void QueryParameters_SetPage_BelowMinValue()
        {
            // ARRANGE
            var queryParameters = QueryParameters.Create();

            // ACT
            Action actionToTest = () => queryParameters.SetPage(-1);

            // ASSERT
            actionToTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void QueryParameters_SetPageSize_AboveMaxValue()
        {
            // ARRANGE
            var queryParameters = QueryParameters.Create();

            // ACT
            Action actionToTest = () => queryParameters.SetPageSize(201);

            // ASSERT
            actionToTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void QueryParameters_SetPageSize_BelowMinValue()
        {
            // ARRANGE
            var queryParameters = QueryParameters.Create();

            // ACT
            Action actionToTest = () => queryParameters.SetPageSize(-1);

            // ASSERT
            actionToTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void QueryParameters_SetPageSize_BetweenMinAndMaxValue()
        {
            // ARRANGE
            var queryParameters = QueryParameters.Create();

            // ACT
            Func<QueryParameters> actionToTest = () => queryParameters.SetPageSize(100);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
            actionToTest.Invoke().PageSize.Should().Be(100);
        }

        [Fact]
        public void QueryParameters_SetSearchFilter()
        {
            // ARRANGE
            var searchFilterValue = bogusRandomizer.AlphaNumeric(15);
            var queryParameters = QueryParameters.Create();

            // ACT
            Func<QueryParameters> actionToTest = () => queryParameters.SetSearchFilter(searchFilterValue);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
            actionToTest.Invoke().SearchFilter.Should().Be(searchFilterValue);
        }
    }
}