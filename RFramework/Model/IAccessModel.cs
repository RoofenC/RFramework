namespace RFramework
{
	public interface IAccessModel
	{
    
	}
	
	public static class AccessModelExtension
	{
		public static T AccessModel<T>(this IAccessModel _model) where T : IRoofen  => RCore.Access<T>();
	}
}
