namespace ManualNugetIntegrationTest
{
    using System;

    [StaticProxy]
    public class Proxied
    {
        private static int RandomValue = (new Random()).Next(-100, 100);
        public void Foo()
        {
            Console.WriteLine(
                "inside original implementation of Proxied.Foo() with static random value {0}", 
                RandomValue);
        }
    }
}