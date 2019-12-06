using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace edge
{
    public class DiscardsFacts
    {
        // The two _ is two thing, both of them is not in storage

        [Fact]
        [SuppressMessage("ReSharper", "ConvertToConstant.Local")]
        public void a_crazy_discard_test_you_will_like()
        {
            // Only one _ in one scope 
            int _ = 0xABCD;
            int value = 0xCDEF;
            // _ used to discard the result
            if (int.TryParse("2345", result: out var _))
            {
                value = _;
            }

            // Please correct the following line to pass the test.
            const int expected = 0xABCD;
            
            Assert.Equal(expected, value);
        }
    }
}