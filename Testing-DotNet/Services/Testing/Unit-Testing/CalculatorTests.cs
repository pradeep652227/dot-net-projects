using Xunit;
using Xunit.Abstractions;

namespace unit_testing.Services.Unit_Testing
{
    public class CalculatorTests
    {   private readonly CalculatorService _calculatorService;
        private readonly ITestOutputHelper _output;
       public CalculatorTests(ITestOutputHelper output)
        {
            _calculatorService=new CalculatorService();
            _output = output;
        }

        [Fact]

        public void UTest_Add_ShouldReturnCorrectSum()
        {
            int a = 4;
            int b = 3;
            int correctSum = a + b;
            int result = _calculatorService.Add<int>(a,b);
            // Log the result
            _output.WriteLine($"Test Add: Expected={correctSum}, Result={result}");
            Assert.Equal(correctSum,result);
        }       
        [Fact]

        public void UTest_Sub_ShouldReturnCorrectSub()
        {
            int a = 10;
            int b = 5;
            int correctSub = a - b; 
            int result = _calculatorService.Sub<int>(a,b);
            Assert.Equal(correctSub,result);
        }      
        [Fact]

        public void UTest_Multiply_ShouldReturnCorrectMultiply()
        {
            int a = 10;
            int b = 5;
            int correctMultiply = a * b; 
            int result = _calculatorService.multiply<int>(a,b);
            Assert.Equal(correctMultiply,result);
        }      
        [Fact]

        public void UTest_Divide_ShouldReturnCorrectDivide()
        {
            int a = 10;
            int b = 5;
            int correctDivide = a / b; 
            int result = _calculatorService.divide<int>(a,b);
            Assert.Equal(correctDivide, result);
        }
    }
}
