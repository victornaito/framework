using FrameworkChallenge.API.Application.Queries;
using Xunit;

namespace FrameworkChallenge.Test
{

    public sealed class CalculationTest
    {

        private ICalculatePrimeNumbers calculatePrimeNumbersMock;

        public CalculationTest()
        {
            this.calculatePrimeNumbersMock = new CalculatePrimeNumbers();
        }

        [Fact]
        public void DeveCalcularDivisoresPrimos()
        {
            const int primeNumber = 45;
            var expectedPrimeNumbers = new int[] { 3, 5 };

            var result = calculatePrimeNumbersMock.Calculate(primeNumber);

            Assert.Equal(expectedPrimeNumbers, result.PrimeDividers);
        }

        [Fact]
        public void NaoDeveCalcularDivisoresPrimos()
        {
            const int primeNumber = 45;
            var expectedPrimeNumbers = new int[] { 1, 2 };

            var result = calculatePrimeNumbersMock.Calculate(primeNumber);

            Assert.NotEqual(expectedPrimeNumbers, result.PrimeDividers);
        }

        [Fact]
        public void DeveCalcularDivisores()
        {
            const int number = 360;
            var expectedDividers = new int[] { 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, 18, 20, 24, 30, 36, 40, 45, 60, 72, 90, 120, 180, 360 };

            var result = calculatePrimeNumbersMock.Calculate(number);

            Assert.Equal(expectedDividers, result.Dividers);
        }

        [Fact]
        public void NaoDeveCalcularDivisores()
        {
            const int number = 360;
            var expectedDividers = new int[] { 20, 25, 30, 36, 40, 45, 60, 72, 90, 120, 340 };

            var result = calculatePrimeNumbersMock.Calculate(number);

            Assert.NotEqual(expectedDividers, result.Dividers);
        }
    }
}