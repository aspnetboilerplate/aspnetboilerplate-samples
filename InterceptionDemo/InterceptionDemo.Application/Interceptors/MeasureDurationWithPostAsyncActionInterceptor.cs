using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Castle.DynamicProxy;

namespace InterceptionDemo.Interceptors
{
    public class MeasureDurationWithPostAsyncActionInterceptor : IInterceptor
    {
        public ILogger Logger { get; set; }

        public MeasureDurationWithPostAsyncActionInterceptor()
        {
            Logger = NullLogger.Instance;
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

            //Wait task execution and modify return value
            if (invocation.Method.ReturnType == typeof(Task))
            {
                invocation.ReturnValue = InternalAsyncHelper.AwaitTaskWithPostActionAndFinally(
                    (Task) invocation.ReturnValue,
                    async () => await TestActionAsync(invocation),
                    ex =>
                    {
                        LogExecutionTime(invocation, stopwatch);
                    });
            }
            else //Task<TResult>
            {
                invocation.ReturnValue = InternalAsyncHelper.CallAwaitTaskWithPostActionAndFinallyAndGetResult(
                    invocation.Method.ReturnType.GenericTypeArguments[0],
                    invocation.ReturnValue,
                    async () => await TestActionAsync(invocation),
                    ex =>
                    {
                        LogExecutionTime(invocation, stopwatch);
                    });
            }
        }

        private void InterceptSync(IInvocation invocation)
        {
            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            //Executing the actual method
            invocation.Proceed();

            //After method execution
            LogExecutionTime(invocation, stopwatch);
        }

        public static bool IsAsyncMethod(MethodInfo method)
        {
            return (
                method.ReturnType == typeof(Task) ||
                (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                );
        }

        private async Task TestActionAsync(IInvocation invocation)
        {
            Logger.Info("Waiting after method execution for " + invocation.MethodInvocationTarget.Name);
            await Task.Delay(200); //Here, we can await another methods. This is just for test.
            Logger.Info("Waited after method execution for " + invocation.MethodInvocationTarget.Name);
        }

        private void LogExecutionTime(IInvocation invocation, Stopwatch stopwatch)
        {
            stopwatch.Stop();
            Logger.InfoFormat(
                "MeasureDurationWithPostAsyncActionInterceptor: {0} executed in {1} milliseconds.",
                invocation.MethodInvocationTarget.Name,
                stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                );
        }
    }
}