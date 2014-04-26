using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Warg.Organisms
{
	public class OrganismGenerator
	{
		protected Texture2D OrganismTexture { get; set; }
		protected Random Rando;

		public OrganismGenerator(Texture2D organismTexture)
		{
			Rando = new Random();
			OrganismTexture = organismTexture;
		}

		public Organism CreateOrganism()
		{
			var xVelocity = Rando.Next(-50, 50) * 0.05f;
			var yVelocity = Rando.Next(-50, 50) * 0.05f;

			var organism = new Organism(OrganismTexture, GetOrganismColor(), 25, new Vector2(350,200), new Vector2(xVelocity,yVelocity));

			return organism;
		}

		private Color GetOrganismColor()
		{
			var r = Rando.Next(256);
			var g = Rando.Next(256);
			var b = Rando.Next(256);

			return new Color(r,g,b);
		}
	}
}
