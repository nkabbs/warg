using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Warg.Drawing;

namespace Warg.Organisms
{
    class Grass: Organism
    {
        protected Texture2D Texture { get; set; }
        protected Color Color { get; set; }

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

        public Grass(Texture2D texture,
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
    }
}
