using Abp.Dependency;
using Hangfire.Server;

namespace AbpHangfireConsole.Hangfire.Framework
{
    /// <summary>
    ///     All hangfire jobs need to descend from this class. We include ITransientDependency
    ///     so that they can easily participate in ABP IoC
    /// </summary>
    public abstract class HangfireJobBase<TJobParams> : ITransientDependency where TJobParams : HangfireParamsInputBase
    {
        /// <summary>
        ///     Called when the job is to be executed.
        /// </summary>
        /// <param name="aContext">Context of the job within HangFire.</param>
        /// <param name="aParams">Parameters for the job being executed.</param>
        public abstract void ExecuteJob(PerformContext aContext, TJobParams aParams);
    }
}