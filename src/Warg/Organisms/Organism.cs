using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Warg.Organisms
{
	public class Organism
	{
		protected Texture2D Texture { get; set; }
		protected Color Color { get; set; }

		public int Radius { get; protected set; }
		public Vector2 Postion { get; protected set; }
		public Vector2 Velocity { get; protected set; }

		public Organism(Texture2D texture, Color color, int radius, Vector2 startingPosition, Vector2 velocity)
		{
			Texture = texture;
			Color = color;
			Radius = radius;
			Postion = startingPosition;
			Velocity = velocity;
		}

		public void Update(GameTime gameTime)
		{
			Postion += Velocity;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Texture, new Rectangle((int)Postion.X, (int)Postion.Y, Radius, Radius), Color);
		}
	}
}
