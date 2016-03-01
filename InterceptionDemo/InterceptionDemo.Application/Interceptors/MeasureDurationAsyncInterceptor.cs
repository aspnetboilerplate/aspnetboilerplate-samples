using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Castle.DynamicProxy;

namespace InterceptionDemo.Interceptors
{
    public class MeasureDurationAsyncInterceptor : IInterceptor
    {
        private readonly ILogger _logger;

        public MeasureDurationAsyncInterceptor(ILogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            if (IsAsyncMethod(invocation.Method))
            {
                InterceptAsync(invocation);
            }
            else
            {
                InterceptSync(invocation);
            }
        }

        private void InterceptAsync(IInvocation invocation)
        {
            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            //Calling the actual method, but execution has not been finished yet
            invocation.Proceed();

            //We should wait for finishing of the method execution
            ((Task) invocation.ReturnValue)
                .ContinueWith(task =>
                {
                    //After method execution
                    stopwatch.Stop();
                    _logger.InfoFormat(
                        "MeasureDurationAsyncInterceptor: {0} executed in {1} milliseconds.",
                        invocation.MethodInvocationTarget.Name,
                        stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                        );
                });
        }

        private void InterceptSync(IInvocation invocation)
        {
            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            //Executing the actual method
            invocation.Proceed();

            //After method execution
            stopwatch.Stop();
            _logger.InfoFormat(
                "MeasureDurationAsyncInterceptor: {0} executed in {1} milliseconds.",
                invocation.MethodInvocationTarget.Name,
                stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                );
        }
        
        public static bool IsAsyncMethod(MethodInfo method)
        {
            return (
                method.ReturnType == typeof(Task) ||
                (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                );
        }
    }
}