using System.Collections.Generic;
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

		private OrganismGenerator _organismGenerator;
		private List<Organism> _organisms;

		public GameMain()
			: base()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}
		protected override void Initialize()
		{
			_organisms = new List<Organism>();

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			var circle = Content.Load<Texture2D>("Circle.png");
			_organismGenerator = new OrganismGenerator(circle);

			for (var i = 0; i < 500; i++)
			{
				_organisms.Add(_organismGenerator.CreateOrganism());
			}
		}

		protected override void UnloadContent()
		{
			Content.Unload();
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			_organisms.ForEach(x => x.Update(gameTime));

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin();

			_organisms.ForEach(x => x.Draw(_spriteBatch));

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
