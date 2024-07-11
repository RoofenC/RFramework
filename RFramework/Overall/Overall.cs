using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

namespace RFramework
{
	public abstract class ROverall
	{
		public abstract void OnInit();
		
		[AuthorizedAccessRCore]
		protected void SignUpSystem<T>() => RCore.SignUp<T>();
		
		[AuthorizedAccessRCore]
		protected void SignUpModel<T>() => RCore.SignUp<T>();
	}
}
