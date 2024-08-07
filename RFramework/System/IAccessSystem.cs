namespace RFramework
{
	public interface IAccessSystem
	{
    
	}
	
	public static class AccessSystemExtension
	{
		public static T AccessSystem<T>(this IAccessSystem _model) where T : IRoofen  => RCore.Access<T>();
	}
}
