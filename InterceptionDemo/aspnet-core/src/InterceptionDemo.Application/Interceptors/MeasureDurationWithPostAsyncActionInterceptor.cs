using Abp.Dependency;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace InterceptionDemo.Interceptors
{
    public class MeasureDurationWithPostAsyncActionInterceptor : AbpInterceptorBase, ITransientDependency
    {
        public ILogger Logger { get; set; }

        public MeasureDurationWithPostAsyncActionInterceptor()
        {
            Logger = NullLogger.Instance;
        }

        public override void InterceptSynchronous(IInvocation invocation)
        {
            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            //Executing the actual method
            invocation.Proceed();

            //After method execution
            LogExecutionTime(invocation, stopwatch);
        }

        protected override async Task InternalInterceptAsynchronous(IInvocation invocation)
        {
            var proceedInfo = invocation.CaptureProceedInfo();

            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            proceedInfo.Invoke();
            var task = (Task)invocation.ReturnValue;
            await TestActionAsync(invocation.MethodInvocationTarget.Name);
            await task;

            //After method execution
            LogExecutionTime(invocation, stopwatch);
        }

        protected override async Task<TResult> InternalInterceptAsynchronous<TResult>(IInvocation invocation)
        {
            var proceedInfo = invocation.CaptureProceedInfo();

            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            proceedInfo.Invoke();

            var taskResult = (Task<TResult>)invocation.ReturnValue;
            await TestActionAsync(invocation.MethodInvocationTarget.Name);
            var result = await taskResult;

            //After method execution
            LogExecutionTime(invocation, stopwatch);

            return result;
        }

        private async Task TestActionAsync(string methodName)
        {
            Logger.Info($"Waiting after method execution for {methodName}");
            await Task.Delay(200); // Here, we can await other methods. This is just for test.
            Logger.Info($"Waited after method execution for {methodName}");
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
