using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

namespace RFramework
{
	public static class RCore
	{
		private static Dictionary<Type, Object> mObjects = new Dictionary<Type, object>();

		static RCore()
		{
			Entry();
		}
		
		private static void Entry()
		{
			var type = FindSubclassesOf<ROverall>();

			if(type == null) throw new InvalidOperationException($"No entry to the program");
			
			foreach (var overall in type)
			{
				var rOverall = (ROverall)Activator.CreateInstance(overall);
				rOverall.OnInit();
			}
		}

		public static void SignUp<T>()
		{
			Authorized();

			var type = FindSubclassOf<T>();

			if (type == null)
			{
				type = typeof(T);
			}

			if (!typeof(RSystem).IsAssignableFrom(type) && !typeof(RModel).IsAssignableFrom(type))
			{
				throw new InvalidOperationException($"The type {type.FullName} must be a subclass of RSystem or RModel.");
			}
			
			if (mObjects.ContainsKey(type))
			{
				throw new InvalidOperationException($"The type {type} has already signed up.");
			}

			var entity = Activator.CreateInstance(type);

			if (entity is IRInitWill init) init.OnInit();

			mObjects.Add(type, (T)entity);
		}

		public static T Access<T>() where T : class, IRoofen
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
		
		private static Type FindSubclassOf<T>()
		{
			var baseType = typeof(T);
			return InternalFindSubclasses(baseType, single: true).FirstOrDefault();
		}

		private static List<Type> FindSubclassesOf<T>()
		{
			var baseType = typeof(T);
			return InternalFindSubclasses(baseType, single: false);
		}

		private static List<Type> InternalFindSubclasses(Type baseType, bool single)
		{
			var result = new List<Type>();
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();

			foreach (var assembly in assemblies)
			{
				var types = assembly.GetTypes();

				foreach (var type in types)
				{
					if (type.IsSubclassOf(baseType) && !type.IsAbstract)
					{
						result.Add(type);
						if (single)
						{
							return result;
						}
					}
				}
			}

			return result.Count == 0 ? null : result;
		}
	}
	
	[AttributeUsage(AttributeTargets.Method)]
	public class AuthorizedAccessRCoreAttribute : Attribute
	{
	}
}
