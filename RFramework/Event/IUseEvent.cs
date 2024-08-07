namespace RFramework
{
    public interface IUseEvent
    {

    }
    
    public static class UseEventExtension
    { 
        public static void UseEve<T>(this IUseEvent _useEvent, T _struct) where T : struct => RCore.UseEvent(_struct);
    }
}