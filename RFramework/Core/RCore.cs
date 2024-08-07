#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace RFramework
{
	public static class RCore
	{
		private static Dictionary<Type, Object> m_Objects = new Dictionary<Type, object>();
		private static StructEventSystem m_Event = new StructEventSystem();
		
		static RCore() => Entry();

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

		public static void In<T>() where T : IRoofen
		{
			var type = FindSubclassOf<T>();

			if (type == null)
			{
				type = typeof(T);
			}

			if (!typeof(RSystem).IsAssignableFrom(type) && !typeof(RModel).IsAssignableFrom(type))
			{
				throw new InvalidOperationException($"The type {type.FullName} must be a subclass of RSystem or RModel.");
			}
			
			if (m_Objects.ContainsKey(type))
			{
				throw new InvalidOperationException($"The type {type} has already signed up.");
			}

			var entity = Activator.CreateInstance(type);

			if (entity is IRInitWill init) init.OnInit();

			m_Objects.Add(typeof(T), (T)entity);
		}

		public static T Access<T>() where T : IRoofen
		{
			var type = typeof(T);

			if (!m_Objects.ContainsKey(type))
			{
				throw new InvalidOperationException($"The type {type} is not signed up.");
			}

			return (T)m_Objects[type];
		}

		public static T UseModule<T>(RModule<T> _rModule) => _rModule.Do();

		public static void UseModule(RModule _rModule) => _rModule.Do();

		public static void UseExe(RExecution _rExecution) => _rExecution.Do();

		public static T UseExe<T>(RExecution<T> _rExecution) => _rExecution.Do();


		public static T UseRec<T>(RReception<T> _rReception) => _rReception.Do();

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
					if ((baseType.IsInterface && baseType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract) ||
					    (type.IsSubclassOf(baseType) && !type.IsAbstract))
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
		
		public static void InEvent<T>(Action<T> onEvent) where T : struct => m_Event.SignUp(onEvent);

		public static void OutEvent<T>(Action<T> onEvent) where T : struct => m_Event.LogOut(onEvent);

		public static void UseEvent<T>(T eventData) where T : struct => m_Event.Use(eventData);
	}
}