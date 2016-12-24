using System;
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
        private Random Rando;

		public GameMain()
			: base()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
            Rando = new Random();
		}
		protected override void Initialize()
		{
			_worldSize = new Vector2(800, 800);
            //_organisms = new List<Organism>();
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
            int choice;
            EnergyTotal.energy = 0;

			for (var i = 0; i < 500; i++)
			{

                choice = Rando.Next(200);

                if (choice <= 190)
                    choice = 0;
                else if (choice < 199)
                    choice = 1;
                else
                    choice = 2;

                switch(choice)
                {
                    case (0):
                        OrganismList.organisms.Add(_organismGenerator.CreateOrganismGrass());
                        //_organisms.Add(_organismGenerator.CreateOrganismGrass());
                        break;
                    case 1:
                        OrganismList.organisms.Add(_organismGenerator.CreateOrganismDeer());
                        //_organisms.Add(_organismGenerator.CreateOrganismDeer());
                        break;
                    case 2:
                        OrganismList.organisms.Add(_organismGenerator.CreateOrganismWolf());
                        //_organisms.Add(_organismGenerator.CreateOrganismWolf());
                        break;

                }
                
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
            UpdateOrganisms(gameTime);
            foreach (Organism o in OrganismList.organisms)
            {

                

                if (o.MyType == Organism.OrganismType.DEER)
                {
                    foreach (Organism j in OrganismList.organisms)
                    {

                        if (j.MyType == Organism.OrganismType.GRASS && Math.Abs(j.Position.X - o.Position.X) + Math.Abs(j.Position.Y - o.Position.Y) < 5)
                        {
                            o.Consume(j);
                        }
                    }
                }
                if (o.MyType == Organism.OrganismType.WOLF)
                {
                    foreach (Organism j in OrganismList.organisms)
                    {

                        if (j.MyType == Organism.OrganismType.DEER && Math.Abs(j.Position.X - o.Position.X) + Math.Abs(j.Position.Y - o.Position.Y) < 5)
                        {
                            o.Consume(j);
                        }
                    }
                }
            }

            for (int i = 0; i < OrganismList.organisms.Count; i++)
            {
                Organism o = OrganismList.organisms[i];
                if (o.Energy > o.ReproductionThreshold)
                {
                    Organism o1 = o.Reproduce();
                    OrganismList.organisms.Add(o1);
                }
                else if (!o.alive)
                {
                    OrganismList.organisms.Remove(o);
                }
            }
			_camera.Update(gameTime);


			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend
				,SamplerState.LinearWrap, DepthStencilState.None, RasterizerState.CullNone,
				null, _camera.Transform);

            OrganismList.organisms.ForEach(x => x.Draw(_spriteBatch));

			_spriteBatch.End();

			base.Draw(gameTime);
		}

        public void UpdateOrganisms(GameTime gameTime)
        {
            OrganismList.organisms.ForEach(x => x.Update(gameTime));
        }
	}

}
