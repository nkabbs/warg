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
            : base(texture, color, radius, startingPosition, velocity, organismType, initialEnergy, visionRadius, reproductionThreshold, reactionDictionary)
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

        public override Organism Reproduce()
        {
            Vector2 startPos = Position + new Vector2(Rando.Next(-25, 25), Rando.Next(-25, 25)); 
            while (startPos.X < 0 || startPos.X > 1000 || startPos.Y < 0 || startPos.Y > 1000)
            {
                startPos = Position + new Vector2(Rando.Next(-25, 25), Rando.Next(-25, 25));
            }
            
            Grass o = new Grass(Texture, Color, Radius, startPos, new Vector2(0, 0), MyType, Energy / 2, VisionRadius, ReproductionThreshold, ReactionDictionary);
            Energy = Energy / 2;
            return o;
        }

    }

}
