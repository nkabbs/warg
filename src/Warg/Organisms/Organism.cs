using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Warg.Drawing;

namespace Warg.Organisms
{
	public class Organism
	{

        public Organism()
        {

        }
        public Guid ID { get; set; }

		protected Texture2D Texture { get; set; }
		protected Color Color { get; set; }

        //new doctor P
        public decimal randomID { get; set; }
        //end

        public Random Rando;
		public int Radius { get; protected set; }
		public Vector2 Position { get; protected set; }
		public Vector2 Velocity { get; set; }

		public Vector2 MostImportantOrganismDirection { get; set; }
		public Reaction MostImportantOrganismTypeReaction { get; set; }

		//Behavior Properties
		public float Energy { get; set; }
		public Vector2 Accelleration { get; set; }
		public float VisionRadius { get; set; }
		public float ReproductionThreshold { get; set; }
		public OrganismType MyType { get; set; }
		public Dictionary<Organism.OrganismType, Reaction> ReactionDictionary { get; set; }
        public Boolean alive;

		public enum OrganismType
		{
			GRASS,
			DEER,
			WOLF,
		}

        //End Properties

        public Organism(Texture2D texture,
            Color color,
            int radius,
            Vector2 startingPosition,
            Vector2 velocity,
            Organism.OrganismType organismType,
            float initialEnergy,
            float visionRadius,
            float reproductionThreshold,
            Dictionary<Organism.OrganismType, Reaction> reactionDictionary)
        {
            Texture = texture;
            Color = color;
            Radius = radius;
            Position = startingPosition;
            Velocity = velocity;

            MyType = organismType;
            Energy = initialEnergy;
            VisionRadius = visionRadius;
            ReproductionThreshold = reproductionThreshold;
            ReactionDictionary = reactionDictionary;
            Rando = new Random();
            alive = true;
        }
	

		public void Update(GameTime gameTime)
		{
			Position += Velocity;
            Radius = (int)Math.Sqrt(Energy) * 2;
            if (MyType == Organism.OrganismType.GRASS)
            {
                Radius = (int) (Math.Sqrt(Energy) * 10);
            }
            Move();
            UpdateEnergy();

            if (Energy <= 0)
                Die();
            
        }

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, Radius, Radius), Color);
		}

		//Behavior Methods

		private void ChooseMostImportantOrganism() //set MostImportantOrganismTypeReaction, set MostImportantOrganismDirection
		{
	        
			SetAcceleration();
		}

		private void SetAcceleration() //set acceleration based on MostImportantOrganismTypeReaction and MostImportantOrganismDirection.  Or randomly or something if there is no nearby organism
		{
	        
			Move();
		}

        private void UpdateEnergy()
        {
            switch (MyType)
            {
                case OrganismType.GRASS:
                    if (EnergyTotal.energy > 0)
                    {
                        Energy += .01f;
                        EnergyTotal.energy -= .01f;
                    }
                    break;
                case OrganismType.DEER:
                    Energy -= .02f;
                    EnergyTotal.energy += .02f;
                    break;
                case OrganismType.WOLF:
                    Energy -= .05f;
                    EnergyTotal.energy += .05f;
                    break;
            }
        }

        public virtual Organism Reproduce()
        {
            Vector2 startPos = Position + new Vector2(Rando.Next(-25, 25), Rando.Next(-25, 25));
            Organism o = new Organism(Texture, Color, Radius, startPos, new Vector2(Rando.Next(-5, 5), Rando.Next(-5, 5)), MyType, Energy / 2, VisionRadius, ReproductionThreshold, ReactionDictionary);
            Energy = Energy / 2;
            return o;
        }

        public Organism findNearestOrganism()
        {
            double minDistance = 1000f;
            double distance = 1000f;
            Organism ret = this;

            foreach (Organism o in OrganismList.organisms)
            {
                distance = Math.Sqrt(Math.Pow(o.Position.X - Position.X, 2) + Math.Pow(o.Position.Y - Position.Y, 2));
                if (o != this && distance < VisionRadius && distance < minDistance && o.MyType == OrganismType.GRASS)
                {
                    ret = o;
                    minDistance = distance;
                }
            }
            return ret;
        }

		public virtual void Move() //set velocity based on acceleration, set position based on velocity
		{
            if (this.MyType != OrganismType.GRASS)
            {
                if (this.Position.X > 1000)
                {
                    Velocity += new Vector2(-.1f, 0);
                }
                if (this.Position.X < 0)
                {
                    Velocity += new Vector2(.1f, 0);
                }
                if (this.Position.Y > 1000)
                {
                    Velocity += new Vector2(0, -.1f);
                }
                if (this.Position.Y < 0)
                {
                    Velocity += new Vector2(0, .1f);
                }
            }
        }

		private void Die() //called when energy <= 0
		{
            alive = false;
		}

		public virtual void Consume(Organism o) //called when organism is in direct contact with 'something it can consume'
		{
            Velocity = new Vector2(0, 0);
            o.Velocity = new Vector2(0, 0);
            Energy += o.Energy;
            o.Energy = 0;
            o.alive = false;
            //Velocity = new Vector2(Rando.Next(-5, 5), Rando.Next(-5, 5));
            
        }
	}
}
