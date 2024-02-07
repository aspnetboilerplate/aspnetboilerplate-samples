using Abp.Dependency;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using System.Diagnostics;
using System.Threading.Tasks;

namespace InterceptionDemo.Interceptors
{
    public class MeasureDurationInterceptor : AbpInterceptorBase, ITransientDependency
    {
        public ILogger Logger { get; set; }

        public MeasureDurationInterceptor()
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
                "MeasureDurationInterceptor: {0} executed in {1} milliseconds.",
                invocation.MethodInvocationTarget.Name,
                stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                );
        }

        protected override Task InternalInterceptAsynchronous(IInvocation invocation)
        {
            throw new System.NotImplementedException();
        }

        protected override Task<TResult> InternalInterceptAsynchronous<TResult>(IInvocation invocation)
        {
            throw new System.NotImplementedException();
        }
    }
}
