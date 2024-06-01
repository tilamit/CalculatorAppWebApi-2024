using System;
using Xunit;

namespace Calculator.Tests
{
    public class ExpressionSpecs
    {
        [Theory]
        [InlineData(2 + 2, "2 + 2")]
        [InlineData(6 + 6 + 6, "6 + 6 + 6")]
        [InlineData(2 + (2 * 2), "2 + ( 2 * 2)")]
        [InlineData(-8 + -6, "-8 + -6")]
        [InlineData(-(5 + 5), "-(5 + 5)")]
        [InlineData(1 + 2 / 3, "1 + 2 / 3")]
        [InlineData(25, "5^2")]
        public void PerformsBasicCalculations(double expectedResult, string expression)
        {
            var parser = new ExpressionParser();
            Assert.Equal(expectedResult, parser.Execute(expression));
        }

        [Theory]
        [InlineData("5 + Foo")]
        [InlineData("(5 + 5")]
        public void FailsOnInvalidSyntax(string badExpression)
        {
            var parser = new ExpressionParser();
            Assert.Throws<Exception>(() => parser.Execute(badExpression));
        }

        [Theory]
        [InlineData(Math.PI, "pi")]
        public void SupportsMathConstants(double expectedResult, string expression)
        {
            var parser = new ExpressionParser();
            Assert.Equal(expectedResult, parser.Execute(expression));
        }

        [Theory]
        [InlineData((3 + 3) * 2 + (5 + 5), "(3 + 3) * 2 + (5 + 5)")]
        [InlineData((1 + 5) / 2, "(1 + 5) / 2")]
        [InlineData(2 * 2 * 3, "2 × 2 * 3")]
        public void SupportsMathSymbols(double expectedResult, string expression)
        {
            var parser = new ExpressionParser();
            Assert.Equal(expectedResult, parser.Execute(expression));
        }
    }
}
