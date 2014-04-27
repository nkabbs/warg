using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Warg.Drawing
{
	public class Camera
	{
		private const float MoveSpeed = 5f;
		private float _scale = 1f;

		public Vector2 Postion { get; set; }
		
		public Vector2 WorldSize { get; private set; }
		public Vector2 WorldOrigin { get; private set; }
		public Vector2 ViewportSize { get; private set; }
		public Vector2 ViewportOrigin { get; private set; }
		
		public Matrix Transform { get; private set; }

		public Camera(Vector2 worldSize, Vector2 viewportSize)
		{
			ViewportSize = viewportSize;
			ViewportOrigin = viewportSize / 2;

			WorldSize = worldSize;
			WorldOrigin = worldSize/2;

			Postion = WorldOrigin;

			CalculateTransform();
		}
		
		public void Update(GameTime gameTime)
		{
			CalculateTransform();

			ViewportOrigin /= _scale;
		}

		public void Move(Vector2 direction)
		{
			Postion += (direction*MoveSpeed);
		}

		private void CalculateTransform()
		{
			Transform = Matrix.Identity
				* Matrix.CreateTranslation(-Postion.X, -Postion.Y, 0)
				* Matrix.CreateTranslation(ViewportOrigin.X, ViewportOrigin.Y, 0)
				* Matrix.CreateScale(new Vector3(_scale));
		}
	}
}
