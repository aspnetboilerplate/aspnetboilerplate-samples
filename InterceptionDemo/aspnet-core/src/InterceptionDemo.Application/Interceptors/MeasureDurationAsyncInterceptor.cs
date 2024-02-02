using Abp.Dependency;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace InterceptionDemo.Interceptors
{
    public class MeasureDurationAsyncInterceptor : AbpInterceptorBase, ITransientDependency
    {
        public ILogger Logger { get; set; }

        public MeasureDurationAsyncInterceptor()
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
            stopwatch.Stop();
            Logger.InfoFormat(
                "MeasureDurationAsyncInterceptor: {0} executed in {1} milliseconds.",
                invocation.MethodInvocationTarget.Name,
                stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                );
        }

        protected override async Task InternalInterceptAsynchronous(IInvocation invocation)
        {
            var proceedInfo = invocation.CaptureProceedInfo();

            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            proceedInfo.Invoke();
            var task = (Task)invocation.ReturnValue;
            await task;

            //After method execution
            stopwatch.Stop();
            Logger.InfoFormat(
                "MeasureDurationAsyncInterceptor: {0} executed in {1} milliseconds.",
                invocation.MethodInvocationTarget.Name,
                stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                );
        }

        protected override async Task<TResult> InternalInterceptAsynchronous<TResult>(IInvocation invocation)
        {
            var proceedInfo = invocation.CaptureProceedInfo();

            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            proceedInfo.Invoke();

            var taskResult = (Task<TResult>)invocation.ReturnValue;
            var result = await taskResult;

            //After method execution
            stopwatch.Stop();
            Logger.InfoFormat(
                "MeasureDurationAsyncInterceptor: {0} executed in {1} milliseconds.",
                invocation.MethodInvocationTarget.Name,
                stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                );

            return result;
        }       
    }
}
