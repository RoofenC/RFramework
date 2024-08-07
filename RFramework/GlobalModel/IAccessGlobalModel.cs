namespace RFramework
{
	public interface IAccessGlobalModel
	{
    
	}
	
	public static class AccessOverallModelExtension
	{
		public static T AccessGlobalModel<T>(this IAccessGlobalModel _model) where T : RGlobalModel  => RCore.Access<T>();
	}
}
