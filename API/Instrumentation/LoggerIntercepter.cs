using Castle.DynamicProxy;
using System.Diagnostics;
using System.Linq;

namespace API.Instrumentation
{
    public class LoggerIntercepter: IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Debug.WriteLine($"Executing {invocation.Method.Name} with parameters: " +
                              string.Join(", ", invocation.Arguments.Select(a => a?.ToString()).ToArray()));

            // Invoke the method
            invocation.Proceed();

            Debug.WriteLine($"Finished executing {invocation.Method}");
        }
    }
}
