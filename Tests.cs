using Xunit;
using FsCheck.Xunit;

namespace PropertyBasedTesting
{
    public class Tests
    {
        [Property(Verbose = true)]
        public void TheResultShouldNotDependOnTheOrderOfTheParameters(int number1, int number2)
        {
            var result1 = Maths.Add(number1, number2);
            var result2 = Maths.Add(number2, number1);

            Assert.Equal(result1, result2);
        }

        [Property(Verbose = true)]
        public void TheOrderOfTheOperationsDoesNotMatter(int number1, int number2, int number3)
        {
            var result1 = Maths.Add(Maths.Add(number1, number2), number3);
            var result2 = Maths.Add(number1, Maths.Add(number2, number3));

            Assert.Equal(result1, result2);
        }

        [Property(Verbose = true)]
        public void AddingZeroIsTheSameAsDoingNothing(int number1)
        {
            var result1 = Maths.Add(number1, 0);
            var result2 = number1;

            Assert.Equal(result1, result2);
        }
    }
}
