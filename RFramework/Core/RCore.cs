using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace RFramework
{
	public static class RCore
	{
		private static Dictionary<Type, Object> mObjects = new Dictionary<Type, object>();

		public static void SignUp<T>(Type _type) where T : class, IRoofen, new()
		{
			Authorized();
			
			if (mObjects.ContainsKey(_type))
			{
				throw new InvalidOperationException($"The type {_type} has already signed up.");
			}

			var entity = Activator.CreateInstance(_type);
			
			if (entity is IRInitWill init) init.OnInit();

			mObjects.Add(_type,entity);
		}

		public static T Get<T>() where T : class, IRoofen
		{
			Authorized();
			
			var type = typeof(T);

			if (!mObjects.ContainsKey(type))
			{
				throw new InvalidOperationException($"The type {type} is not signed up.");
			}

			return mObjects[type] as T;
		}

		public static T UseModule<T>(RModule<T> _rModule)
		{
			Authorized();
			
			return _rModule.Do();
		}
		
		public static void UseModule(RModule _rModule)
		{
			Authorized();
			
			_rModule.Do();
		}
		
		public static void UseExe(RExecution _rExecution)
		{
			Authorized();
			
			_rExecution.Do();
		}
		
		public static T UseRec<T>(RReception<T> _rReception)
		{
			Authorized();
			
			return _rReception.Do();
		}
		
		private static void Authorized()
		{
			var stackTrace = new System.Diagnostics.StackTrace();
			var callingMethod = stackTrace.GetFrame(1).GetMethod();
			var declaringType = callingMethod.DeclaringType;

			var authorize =  declaringType.GetCustomAttributes(typeof(AuthorizedAccessRCoreAttribute), true).Length > 0
			       || callingMethod.GetCustomAttributes(typeof(AuthorizedAccessRCoreAttribute), true).Length > 0;

			if (!authorize)
			{
				throw new InvalidOperationException($"Prohibit programs outside the framework from accessing RCore.");
			}
		}
	}
	
	[AttributeUsage(AttributeTargets.Method)]
	public class AuthorizedAccessRCoreAttribute : Attribute
	{
	}
}
