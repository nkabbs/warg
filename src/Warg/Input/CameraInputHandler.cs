using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Warg.Drawing;

namespace Warg.Input
{
	public class CameraInputHandler : InputHandler<Camera>
	{
		public CameraInputHandler(Camera camera) : base(camera)
		{
			var up = new Vector2(0, -1);
			var down = new Vector2(0, 1);
			var left = new Vector2(-1, 0);
			var right = new Vector2(1, 0);

			SetKeyToAction(Keys.Up, cam => cam.Move(up) );
			SetKeyToAction(Keys.Down, cam => cam.Move(down) );
			SetKeyToAction(Keys.Left, cam => cam.Move(left) );
			SetKeyToAction(Keys.Right, cam => cam.Move(right) );
		}
	}
}
