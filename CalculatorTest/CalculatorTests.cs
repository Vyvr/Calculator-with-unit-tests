
namespace Calculator.test
{
    [TestFixture]
    public class Tests
    {
        Calculator calc;
        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }

        [TestCase("2, 3" ,5)]
        [TestCase("", 0)]
        [TestCase("3", 3)]
        [TestCase("3,", 3)]
        [TestCase(",2", 2)]
        [TestCase(",", 0)]
        [TestCase("1, 2, 3, 4 ,5,",15)]
        public void CommaAsSeparator(string input, int res)
        {
            var result = calc.add(input);
            Assert.That(result, Is.EqualTo(res));
        }

        [TestCase("2\n3", 5)]
        [TestCase("\n", 0)]
        [TestCase("3", 3)]
        [TestCase("3\n", 3)]
        [TestCase("\n2", 2)]
        [TestCase("1, 2\n 3, 4\n5,", 15)]
        public void NewLineAsSeparator(string input, int res)
        {
            var result = calc.add(input);
            Assert.That(result, Is.EqualTo(res));
        }

        [TestCase("//;\n2; 3", 5)]
        [TestCase("//.\n", 0)]
        [TestCase("//]\n3", 3)]
        [TestCase("//+\n3+", 3)]
        [TestCase("//:\n:2", 2)]
        [TestCase("//:\n:", 0)]
        [TestCase("//[[[\n1[[[ 2[[[ 3[[[ 4 [[[5[[[", 15)]
        public void DifferentAndMultiDelimiters(string input, int res)
        {
            var result = calc.add(input);
            Assert.That(result, Is.EqualTo(res));
        }

        [TestCase("2, -3", 5)]
        [TestCase("-3", 3)]
        [TestCase("-3,", 3)]
        [TestCase(",-2", 2)]
        [TestCase("1, -2, 3, 4 ,5,", 15)]
        [TestCase("//:\n:-2", 2)]
        [TestCase("//]\n-3", 3)]
        [TestCase("//+\n-3+", 3)]
        public void NegativeNumberErrorHandling(string input, int res)
        {
            var exception = Assert.Throws<ArgumentException>(() => calc.add(input));
            Assert.That(exception.Message, Is.EqualTo("negatives not allowed"));
        }

        [TestCase("2, 3000", 2)]
        [TestCase("2, 1000", 1002)]
        [TestCase("2, 1001", 2)]
        [TestCase("1, 2000, 3, 4 ,5,", 13)]
        public void SecondNumberHigherThanThousand(string input, int res)
        {
            var result = calc.add(input);
            Assert.That(result, Is.EqualTo(res));
        }
    }
}