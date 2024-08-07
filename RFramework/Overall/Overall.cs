namespace RFramework
{
	public abstract class ROverall : IRoofen
	{
		public abstract void OnInit();
		
		
		protected void InSystem<T>() where T : IRoofen => RCore.In<T>();
		
		
		protected void InModel<T>() where T : IRoofen => RCore.In<T>();
		
		
		protected void InGlobalModel<T>() where T : IRoofen => RCore.In<T>();
	}
}
