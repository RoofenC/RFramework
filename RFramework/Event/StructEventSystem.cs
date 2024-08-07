#region

using System;
using System.Collections.Generic;

#endregion

namespace RFramework
{
    public class StructEventSystem
    {
        private readonly Dictionary<Type, object> mEvents = new();

        public void SignUp<T>(Action<T> onEvent) where T : struct
        {
            if (!mEvents.ContainsKey(typeof(T)))
            {
                mEvents[typeof(T)] = null;
            }

            var action = (Action<T>)mEvents[typeof(T)];
            action += onEvent;
            mEvents[typeof(T)] = action;
        }

        public void LogOut<T>(Action<T> onEvent) where T : struct
        {
            if (mEvents.ContainsKey(typeof(T)))
            {
                var action = (Action<T>)mEvents[typeof(T)];
                action -= onEvent;

                if (action == null)
                {
                    mEvents.Remove(typeof(T));
                }
                else
                {
                    mEvents[typeof(T)] = action;
                }
            }
        }

        public void Use<T>(T eventData) where T : struct
        {
            if (mEvents.ContainsKey(typeof(T)))
            {
                var action = (Action<T>)mEvents[typeof(T)];
                action?.Invoke(eventData);
            }
        }
    }
}