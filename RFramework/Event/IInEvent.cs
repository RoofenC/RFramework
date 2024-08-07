#region

using System;

#endregion

namespace RFramework
{
    public interface IInEvent
    {

    }
    
    public static class InEventExtension
    { 
        public static void InEvent<T>(this IInEvent _module, Action<T> _action) where T : struct => RCore.InEvent(_action);
		
        public static void OutEvent<T>(this IInEvent _module, Action<T> _action) where T : struct  => RCore.OutEvent(_action);
    }
}