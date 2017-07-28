namespace ManualNugetIntegrationTest
{
    using System;
    using System.Linq;

    public class FakeInterceptor : IDynamicInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            string methodName = CalculateMethodName(invocation);

            Console.WriteLine("intercepting. Before {0}", methodName);

            invocation.Proceed();

            Console.WriteLine($"Intercepting Ends. ReturnValue = {invocation.ReturnValue}");
        }

        private static string CalculateMethodName(IInvocation invocation)
        {
            string parameters = "(" + string.Join(", ", invocation.Arguments) + ")";

            if(invocation.Method.IsGenericMethod)
            {
                string genericArguments = string.Join(", ", invocation.GenericArguments.Select(x => x.Name));

                return $"{invocation.Method.Name}<{genericArguments}>{parameters}";
            }

            return $"{invocation.Method.Name}{parameters}";
        }
    }
}