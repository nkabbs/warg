using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Warg.Drawing;
using Warg.Input;
using Warg.Organisms;

namespace Warg
{
	public class GameMain : Game
	{
		GraphicsDeviceManager _graphics;
		SpriteBatch _spriteBatch;

		private OrganismGenerator _organismGenerator;
		private List<Organism> _organisms;
		private Camera _camera;
		private InputManager _input;
		private Vector2 _worldSize;

		public GameMain()
			: base()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}
		protected override void Initialize()
		{
			_worldSize = new Vector2(800, 800);
			_organisms = new List<Organism>();

			_camera = new Camera(_worldSize, 
				new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight));

			_input = new InputManager(_camera);

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

			_input.Update(gameTime, Keyboard.GetState());

			_organisms.ForEach(x => x.Update(gameTime));

			_camera.Update(gameTime);


			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend
				,SamplerState.LinearWrap, DepthStencilState.None, RasterizerState.CullNone,
				null, _camera.Transform);

			_organisms.ForEach(x => x.Draw(_spriteBatch));

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
