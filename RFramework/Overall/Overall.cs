using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

namespace RFramework
{
	public abstract class ROverall : IRInitWill
	{
		public abstract void OnInit();
		
		[AuthorizedAccessRCore]
		protected void SignUpSystem<T>(Type _system) where T : RSystem, IRoofen, new() => RCore.SignUp<T>(_system);
		
		[AuthorizedAccessRCore]
		protected void SignUpModel<T>(Type _model) where T : RModel, IRoofen, new() => RCore.SignUp<T>(_model);
	}
}
