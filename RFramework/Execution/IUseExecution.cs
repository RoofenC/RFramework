namespace RFramework
{
	public interface IUseExecution
	{
    
	}
	
	public static class UseExecutionExtension
	{ 
		public static void UseExe(this IUseExecution _module, RExecution _rExecution) => RCore.UseExe(_rExecution);
		
		public static T UseExe<T>(this IUseExecution _module, RExecution<T> _rExecution) => RCore.UseExe(_rExecution);
	}
}
