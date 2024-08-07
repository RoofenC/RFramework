namespace RFramework
{
	public abstract class RReception<T> : IAccessModel, IAccessGlobalModel, IUseReception, IUseModule, IUseExecution
	{
		public abstract T Do();
	}
}
