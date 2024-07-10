namespace RFramework
{
	public abstract class RModule<T> : IRoofen
	{
		public abstract T Do();
	}
	
	public abstract class RModule : IRoofen
	{
		public abstract void Do();
	}
}
