using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Warg.Organisms;
using static Warg.Organisms.Organism;

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

        public Organism CreateOrganismGrass()
        {
            var xVelocity = 0;
            var yVelocity = 0;

            var organism = new Grass(OrganismTexture, GetOrganismColor(OrganismType.GRASS), 25, new Vector2(Rando.Next(-500,500) + 500, Rando.Next(-500,500) + 500),
                new Vector2(xVelocity, yVelocity), Organism.OrganismType.GRASS, 1f, 100f, 5f,
                new Dictionary<Organism.OrganismType, Reaction>());

            return organism;
        }

        public Organism CreateOrganismDeer()
        {
            var xVelocity = Rando.Next(-50, 50) * 0.05f;
            var yVelocity = Rando.Next(-50, 50) * 0.05f;

            var organism = new Deer(OrganismTexture, GetOrganismColor(OrganismType.DEER), 25, new Vector2(Rando.Next(-500, 500) + 500, Rando.Next(-500, 500) + 500),
                new Vector2(xVelocity, yVelocity), Organism.OrganismType.DEER, 100f, 100f, 200f,
                new Dictionary<Organism.OrganismType, Reaction>());

            return organism;
        }

        public Organism CreateOrganismWolf()
        {
            var xVelocity = Rando.Next(-50, 50) * 0.05f;
            var yVelocity = Rando.Next(-50, 50) * 0.05f;

            var organism = new Organism(OrganismTexture, GetOrganismColor(OrganismType.WOLF), 25, new Vector2(Rando.Next(-500, 500) + 500, Rando.Next(-500, 500) + 500),
                new Vector2(xVelocity, yVelocity), Organism.OrganismType.WOLF, 200f, 100f, 16000f,
                new Dictionary<Organism.OrganismType, Reaction>());

            return organism;
        }
        private Color GetOrganismColor(OrganismType o)
		{
            var r = 0;
            var g = 0;
            var b = 0;
            if (o == OrganismType.GRASS)
            {
                r = Rando.Next(50) + 10;
                g = Rando.Next(100) + 150;
                b = Rando.Next(50) + 10;
            }

            if (o == OrganismType.DEER)
            {
                r = Rando.Next(150) + 50;
                g = Rando.Next(75) + 20;
                b = Rando.Next(30) + 5;
            }

            if (o == OrganismType.WOLF)
            {
                r = Rando.Next(100) + 160;
                g = Rando.Next(50);
                b = Rando.Next(50);
            }

			return new Color(r,g,b);
		}
	}
}
