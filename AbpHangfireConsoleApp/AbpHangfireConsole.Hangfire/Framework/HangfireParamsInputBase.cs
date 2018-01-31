namespace AbpHangfireConsole.Hangfire.Framework
{
    /// <summary>
    ///     Base class from which all ExecuteJob() parameters need to descend.
    /// </summary>
    /// <remarks>
    ///     This class will receive the same validation treatment that ABP provides elsewhere.
    /// </remarks>
    /// <seealso cref="https://aspnetboilerplate.com/Pages/Documents/Validating-Data-Transfer-Objects" />
    public abstract class HangfireParamsInputBase : IHangfireParamsInputBase
    {
    }
}