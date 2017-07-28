namespace ManualNugetIntegrationTest
{
    using System;

    [StaticProxy]
    public class Proxied
    {
        private static int RandomValue = (new Random()).Next(-100, 100);

        public int Foo(int value)
        {
            Console.WriteLine(
                "inside original implementation of Proxied.Foo() with static random value {0} and {1}",
                RandomValue, value);
            return value;
        }

        public T FooGeneric<T>(T value)
        {
            Console.WriteLine(
                "inside original implementation of Proxied.FooGeneric<T>() with static random value {0} and {1}", 
                RandomValue, value);

            return value;
        }
    }
}