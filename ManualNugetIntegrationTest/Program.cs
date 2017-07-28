namespace ManualNugetIntegrationTest
{
    using System;

    using FluentAssertions;

    using Microsoft.Practices.Unity;

    using Ninject;
    using Ninject.Extensions.StaticProxy;

    using Unity.StaticProxyExtension;

    class Program
    {
        static void Main(string[] args)
        {
            TestNinject();

            TestUnity();

            Console.ReadKey();
        }

        private static void TestNinject()
        {
            const string ExpectedString = "Ninject";

            Console.WriteLine(ExpectedString);

            var kernel = new StandardKernel();

            kernel.Bind<Proxied>().ToSelf()
                .Intercept(x => x.By<FakeInterceptor>());

            var instance = kernel.Get<Proxied>();

            instance.FooGeneric<string>(ExpectedString).Should().Be(ExpectedString);

            instance.Foo(15).Should().Be(15);
        }

        private static void TestUnity()
        {
            const string ExpectedString = "Unity";

            Console.WriteLine();
            Console.WriteLine(ExpectedString);

            var container = new UnityContainer();
            container.AddNewExtension<StaticProxyExtension>();

            container.RegisterType<Proxied, Proxied>(new Intercept<FakeInterceptor>());

            var instance = container.Resolve<Proxied>();

            instance.FooGeneric<string>(ExpectedString).Should().Be(ExpectedString);

            instance.Foo(335).Should().Be(335);
        }
    }
}
