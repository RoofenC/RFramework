namespace RFramework
{
	public interface IUseReception
	{
    
	}
	
	public static class UseReceptionExtension
	{
		[AuthorizedAccessRCore]
		public static void UseRec<T>(this IUseReception _module, RReception<T> _rReception) => RCore.UseRec(_rReception);
	}
}
