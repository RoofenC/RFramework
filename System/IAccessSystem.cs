namespace RFramework
{
	public interface IAccessSystem
	{
    
	}
	
	public static class AccessSystemExtension
	{
		public static T GetSystem<T>(this IAccessModel _model) where T : RSystem  => RCore.Get<T>();
	}
}
