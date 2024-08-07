namespace RFramework
{
	public interface IUseReception
	{
    
	}
	
	public static class UseReceptionExtension
	{
		public static T UseRec<T>(this IUseReception _module, RReception<T> _rReception) => RCore.UseRec(_rReception);
	}
}
