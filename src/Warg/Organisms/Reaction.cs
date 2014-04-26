using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warg.Organisms
{
	public class Reaction
	{
		public Organism.OrganismType OrganismType { get; set; }
		public double ProximityMultiplier { get; set; }
		public double AccelerationReaction { get; set; }
	}
}
