using FluentAssertions;

namespace RomanNumeralGenerator.Tests
{
    [TestClass]
    public class GeneratorTests
    {
        private Generator _generator;

        [TestInitialize]
        public void Setup()
        {
            _generator = new Generator();
        }

        [TestMethod]
        public void Generate_ProvideValidInput_ReturnsResult()
        {
            var output1 = _generator.Generate(1);
            var output4 = _generator.Generate(4);
            var output9 = _generator.Generate(9);
            var output176 = _generator.Generate(176);
            var output828 = _generator.Generate(828);
            var output3888 = _generator.Generate(3888);

            output1.Should().Be("I");
            output4.Should().Be("IV");
            output9.Should().Be("IX");
            output176.Should().Be("CLXXVI");
            output828.Should().Be("DCCCXXVIII");
            output3888.Should().Be("MMMDCCCLXXXVIII");
        }

        [TestMethod]
        public void Generate_ProvideInvalidInput_ReturnsResult()
        {
            var negative = _generator.Generate(-1);
            var zero = _generator.Generate(0);
            var big = _generator.Generate(6565);

            negative.Should().Be("Number out of bounds");
            zero.Should().Be("Number out of bounds");
            big.Should().Be("Number out of bounds");
        }
    }
}