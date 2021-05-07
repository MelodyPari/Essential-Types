using System;

namespace Delegates__Custom_Attributes__Nullable_value_types
{
    class Program
    {
        internal delegate void DelegateChain();
        static void Main(string[] args)
        {
            int a = 5;
            int? b = null;
            int? c = null;
            int? e = 5;
            Console.WriteLine(b.Equals(a));//false - Свойство HasValue для b равно false, а параметр метода Equals(a) не равен null
            Console.WriteLine(b.Equals(c));//true - Свойству HasValue задано значение false, а параметру — null 
                                            //(то есть два нулевых значения равны по определению).
            Console.WriteLine(b.Equals(e));//false - свойство HasValue имеет значение true e и false для b, а значение, 
                                           //возвращаемое свойством Value, не равно null.
            Console.WriteLine(e.Equals(a));//true - свойство HasValue имеет значение true, а значение, 
                                           //возвращаемое свойством Value, равно значению параметра.

            Console.WriteLine("Цепочка делегатов");
            DelegateChain delegateChain = Func1;
            delegateChain += Func2;
            delegateChain += Func3;
            delegateChain();

            Console.WriteLine("Обработка исключения в цепочке");
            DelegateChain delegateChain1;
            delegateChain1 = Func1;
            delegateChain1 += Func4;
            delegateChain1 += Func2;
            Delegate[] delegateChain1Array = delegateChain1.GetInvocationList();
            foreach(DelegateChain d in delegateChain1Array)
            {
                try
                {
                    d();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Console.WriteLine("Пример обобщенного делегата");
            Func<int, int, int> action;
            Action<int> action2;
            action = Add;
            action2 = PrintResult;
            Compare(100, 1, action, action2);
            action = Subtract;
            Compare(100, 1, action, action2);

            Console.WriteLine("Калькулятор с двумя методами: вычитание и сравнение");
            Calculator calculator = new Calculator();
            Console.WriteLine($"100-1 = {calculator.Subtract(100, 1)}");
            Console.WriteLine($"100-null = {calculator.Subtract(100, null)}");
            Console.WriteLine($"100>1 = {calculator.Compare(100,1)}");
           
            
            Type t = typeof(Calculator);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (var attr in attrs)
            {
                Console.WriteLine(attr);
            }
        }

        static void Func1()
        {
            Console.WriteLine("Message 1");
        }
        static void Func2()
        {
            Console.WriteLine("Message 2");
        }
        static void Func3()
        {
            Console.WriteLine("Message 3");
        }
        static void Func4()
        {
            throw new Exception("Exception name");
        }
        static int Add(int v1, int v2)
        {
            return v1 + v2;
        }
        static int Subtract(int v1, int v2)
        {
            return v1 - v2;
        }
        static void Compare(int v1, int v2, Func<int, int, int> action, Action<int> action2)
        {
            if (v1 < v2) action2(action(v2, v1));
            else action2(action(v1, v2));   
        }
        static void PrintResult(int v)
        {
             Console.WriteLine(v);
        }
    }
    [CustomAttribute(1000)]
    public class Calculator
    {
        private int v = 100;
        public int? Subtract(int v1, int? v2)
        {
            return v2 !=null ? v1-v2 : null;
        }
        public int Compare(int v1, int? v2)
        {
            if (v1 < v2|| v2==null) return -1;
            else if (v2 < v1) return 1;
            else return 0;
        }
    }
    public class CustomAttribute : System.Attribute
    {
        public int v1 { get; set; }

        public CustomAttribute()
        { }

        public CustomAttribute(int v)
        {
            v1 = v;
        }
    }
}
