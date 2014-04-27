using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Warg.Drawing;

namespace Warg.Input
{
	public class InputManager
	{
		public CameraInputHandler CameraInputHandler { get; private set; }

		public InputManager(Camera camera)
		{
			CameraInputHandler = new CameraInputHandler(camera);
		}

		public void Update(GameTime gameTime, KeyboardState keyboardState)
		{
			CameraInputHandler.Update(gameTime, keyboardState);
		}
	}
}
