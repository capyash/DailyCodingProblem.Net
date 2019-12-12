using FluentAssertions;
using NUnit.Framework;

namespace YashCapoor.DailyCodingProblem.Solutions.Tests
{
    [TestFixture]
    public class Problem386SolutionTests
    {
        private Problem386Solution problem386Solution;

        [SetUp]
        public void Setup()
        {
            problem386Solution = new Problem386Solution();
        }

        [Test]
        public void SortStringByDecreasingFrequencyGoodData()
        {
            var result = problem386Solution.SortStringByDecreasingFrequency("tweet");
            result.Should().BeOneOf(new[] {"tteew", "eettw"});
        }
    }
}