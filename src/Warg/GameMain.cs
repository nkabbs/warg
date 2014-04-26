using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Warg.Organisms;

namespace Warg
{
	public class GameMain : Game
	{
		GraphicsDeviceManager _graphics;
		SpriteBatch _spriteBatch;

		private Organism _organism;

		public GameMain()
			: base()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}
		protected override void Initialize()
		{

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			var circle = Content.Load<Texture2D>("Circle.png");

			_organism = new Organism(circle, Color.DarkOrange, 30, new Vector2(400, 200));
		}

		protected override void UnloadContent()
		{
			Content.Unload();
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			_organism.Update(gameTime);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin();

			_organism.Draw(_spriteBatch);

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
