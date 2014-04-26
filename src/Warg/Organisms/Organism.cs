using System;
using System.Collections.Generic;
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

		public Vector2 MostImportantOrganismDirection { get; set; }
		public Reaction MostImportantOrganismTypeReaction { get; set; }

		//Behavior Properties
		public float Energy { get; set; }
		public Vector2 Accelleration { get; set; }
		public float VisionRadius { get; set; }
		public float ReproductionThreshold { get; set; }
		public OrganismType MyType { get; set; }
		public Dictionary<Organism.OrganismType, Reaction> ReactionDictionary { get; set; }

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
			Postion = startingPosition;
			Velocity = velocity;

			MyType = organismType;
			Energy = initialEnergy;
			VisionRadius = visionRadius;
			ReproductionThreshold = reproductionThreshold;
			ReactionDictionary = reactionDictionary;

		}

		public void Update(GameTime gameTime)
		{
			Postion += Velocity;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Texture, new Rectangle((int)Postion.X, (int)Postion.Y, Radius, Radius), Color);
		}

		//Behavior Methods

		private void ChooseMostImportantOrganism() //set MostImportantOrganismTypeReaction, set MostImportantOrganismDirection
		{
	        
			SetAcceleration();
		}

		private void SetAcceleration() //set acceleration based on MostImportnatOrganismTypeReaction and MostImportantOrganismDirection.  Or randomly or something if there is no nearby organism
		{
	        
			Move();
		}

		private void Move() //set velocity based on acceleration, set position based on velocity
		{
	        
		}

		private void Reproduce() //called when energy exceeds energy threshold, creates a new mutated 'child organism' with half the current organism's energy
		{
	        
		}

		private void Die() //called when energy <= 0
		{
	        
		}

		private void Consume() //called when organism is in direct contact with 'something it can consume'
		{
	        
		}
	}
}
