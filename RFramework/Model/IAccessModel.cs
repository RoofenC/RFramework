namespace RFramework
{
	public interface IAccessModel
	{
    
	}
	
	public static class AccessModelExtension
	{
		public static T GetModel<T>(this IAccessModel _model) where T : RModel  => RCore.Access<T>();
	}
}
