namespace FrameworkChallenge.API.Application.Queries
{
    public sealed class CalculatePrimeNumbers : ICalculatePrimeNumbers
    {
        public MathDTO Calculate(int number)
        {
            var dividers = new List<int>();
            var primes = new List<int>();

            for (int index = 0; index <= number; index++)
                if (IsDividerNumber(number, index)) dividers.Add(index);

            foreach (var divider in dividers)
                if (IsPrimeNumber(divider)) primes.Add(divider);

            return new MathDTO
            {
                Dividers = dividers,
                PrimeDividers = primes
            };
        }

        private static bool IsPrimeNumber(int number)
        {
            if (number == 0 || number == 1) return false;
            if (number != 2 && number % 2 == 0) return false;
            if (number != 3 && number % 3 == 0) return false;
            if (number != 5 && number % 5 == 0) return false;
            if (number != 7 && number % 7 == 0) return false;

            return true;
        }

        private static bool IsDividerNumber(int number, int index) => index == 0 ? false : number % index == 0;
    }
}
