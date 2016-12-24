using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Warg.Drawing;

namespace Warg.Organisms
{
    class Wolf : Organism
    {
        public Wolf(Texture2D texture,
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

        public Organism findNearestDeer()
        {
            double minDistance = 1000f;
            double distance = 1000f;
            Organism ret = this;

            foreach (Organism o in OrganismList.organisms)
            {
                distance = Math.Sqrt(Math.Pow(o.Position.X - Position.X, 2) + Math.Pow(o.Position.Y - Position.Y, 2));
                if (o != this && distance < VisionRadius && distance < minDistance && o.MyType == OrganismType.DEER)
                {
                    ret = o;
                    minDistance = distance;
                }
            }
            return ret;
        }

        public override Organism Reproduce()
        {
            Vector2 startPos = Position + new Vector2(Rando.Next(-25, 25), Rando.Next(-25, 25));
            Wolf o = new Wolf(Texture, Color, Radius, startPos, new Vector2(Rando.Next(-5, 5), Rando.Next(-5, 5)), MyType, Energy / 2, VisionRadius, ReproductionThreshold, ReactionDictionary);
            Energy = Energy / 2;
            return o;
        }

        public override void Move() //set velocity based on acceleration, set position based on velocity
        {
            Organism near = findNearestDeer();
            if (near.MyType == Organism.OrganismType.DEER)
            {
                if (near.Position.X > Position.X)
                {
                    Velocity += new Vector2(.1f, 0f);
                }
                if (near.Position.X < Position.X)
                {
                    Velocity += new Vector2(-.1f, 0f);
                }
                if (near.Position.Y > Position.Y)
                {
                    Velocity += new Vector2(0f, .1f);
                }
                if (near.Position.Y < Position.Y)
                {
                    Velocity += new Vector2(0f, -.1f);
                }
            }
            

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

}