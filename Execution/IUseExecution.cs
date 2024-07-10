namespace RFramework
{
	public interface IUseExecution
	{
    
	}
	
	public static class UseExecutionExtension
	{
		[AuthorizedAccessRCore]
		public static void UseExe(this IUseExecution _module, RExecution _rExecution) => RCore.UseExe(_rExecution);
	}
}
