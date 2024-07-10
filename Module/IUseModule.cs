namespace RFramework
{
	public interface IUseModule
	{
    
	}
	
	public static class UseModuleExtension
	{
		[AuthorizedAccessRCore]
		public static T UseModule<T>(this IUseModule _module, RModule<T> _rModule) => RCore.UseModule(_rModule);
		[AuthorizedAccessRCore]
		public static void UseModule(this IUseModule _module, RModule _rModule) => RCore.UseModule(_rModule);
	}
}
