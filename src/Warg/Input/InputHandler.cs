using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Warg.Input
{
	public abstract class InputHandler<T>
	{
		protected readonly Dictionary<Keys, Action<T>> KeyToAction;

		private readonly T _effected;

		protected InputHandler(T effected)
		{
			KeyToAction = new Dictionary<Keys, Action<T>>();
			_effected = effected;
		}

		protected void SetKeyToAction(Keys key, Action<T> action)
		{
			KeyToAction.Add(key, action);
		}

		public void Update(GameTime gameTime, KeyboardState keyboardState)
		{
			foreach (var func in KeyToAction)
			{
				if (keyboardState.IsKeyDown(func.Key))
				{
					func.Value(_effected);
				}
			}
		}
	}
}
