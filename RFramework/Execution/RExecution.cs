namespace RFramework
{
	public abstract class RExecution : IAccessSystem, IAccessModel,IUseReception, IUseModule, IUseEvent, IUseExecution
	{
		public abstract void Do();
	}
	
	public abstract class RExecution<T> : IAccessSystem, IAccessModel,IUseReception, IUseModule, IUseEvent, IUseExecution
	{
		public abstract T Do();
	}
}
