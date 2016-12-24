using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Warg.Drawing;

namespace Warg.Organisms
{
    class Deer : Organism
    {
        public Deer(Texture2D texture,
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
            ID = Guid.NewGuid();
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
            Deer o = new Deer(Texture, Color, Radius, startPos, new Vector2(Rando.Next(-5, 5), Rando.Next(-5, 5)), MyType, Energy / 2, VisionRadius, ReproductionThreshold, ReactionDictionary);
            Energy = Energy / 2;
            return o;
        }

        public override void Move() //set velocity based on acceleration, set position based on velocity
        {
            Organism near = findNearestOrganism();
            if (near.MyType == Organism.OrganismType.DEER)
            {

            }

            if (Velocity.X == 0 && Velocity.Y == 0)
            {
                
            }

            if (near.MyType == Organism.OrganismType.GRASS)
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
            if (near.MyType == Organism.OrganismType.WOLF)
            {
                if (near.Position.X > Position.X)
                {
                    Velocity += new Vector2(-.1f, 0f);
                }
                if (near.Position.X < Position.X)
                {
                    Velocity += new Vector2(.1f, 0f);
                }
                if (near.Position.Y > Position.Y)
                {
                    Velocity += new Vector2(0f, -.1f);
                }
                if (near.Position.Y < Position.Y)
                {
                    Velocity += new Vector2(0f, .1f);
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
        public override void Consume(Organism o) //called when organism is in direct contact with 'something it can consume'
        {
            Velocity = new Vector2(0, 0);
            o.Velocity = new Vector2(0, 0);
            if (o.Energy > 1f)
            {
                Energy += o.Energy * .05f;
                o.Energy -= o.Energy * .05f;
            } else {
                Energy += o.Energy;
                o.Energy = 0;
                o.alive = false;
            }
            //Velocity = new Vector2(Rando.Next(-5, 5), Rando.Next(-5, 5));

        }

    }
    
}