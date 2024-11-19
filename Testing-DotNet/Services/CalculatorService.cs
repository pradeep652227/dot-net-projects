using System;

namespace unit_testing.Services
{
    public class CalculatorService
    {
       // CalculatorService() { }


        public T Add<T>(T a,T b)
        {   
            return (dynamic)a + (dynamic)b;
        }

        public T Sub<T>(T a, T b)
        {
            return (dynamic)a - (dynamic)b;
        }

        public T multiply<T>(T a, T b)
        {

        return (dynamic)a * (dynamic)b; 
        }

        public T divide<T>(T a, T b) 
        {
           
                if ((dynamic)b == 0 || (dynamic)b==0.0)
                    throw new DivideByZeroException("Cannot divide by zero");

                return (dynamic)a / (dynamic)b;
           
        }
    
    }
}
