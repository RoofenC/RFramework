namespace RFramework
{
	public abstract class RSystem : IRoofen, IRInitWill, IUseExecution, IUseModule, IUseReception, IAccessGlobalModel
	{
		public abstract void OnInit();
	}
}
