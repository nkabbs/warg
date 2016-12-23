using System.Collections.Generic;

namespace Warg.Organisms.Behavior
{
    public static class GlobalInteractions
    {
        public static List<InteractionPairing> InteractionPairings = new List<InteractionPairing>()
        {
            new InteractionPairing()
            {
                Type1 = Organism.OrganismType.DEER,
                Type2 = Organism.OrganismType.DEER,

                multiplier1 = 0,
                multiplier2 = 0
            },
            new InteractionPairing()
            {
                Type1 = Organism.OrganismType.DEER,
                Type2 = Organism.OrganismType.WOLF,

                multiplier1 = .08f,
                multiplier2 = .5f
            },
            new InteractionPairing()
            {
                Type1 = Organism.OrganismType.WOLF,
                Type2 = Organism.OrganismType.DEER,

                multiplier1 = .5f,
                multiplier2 = .08f
            },
            new InteractionPairing()
            {
                Type1 = Organism.OrganismType.WOLF,
                Type2 = Organism.OrganismType.WOLF,

                multiplier1 = .2f,
                multiplier2 = .2f
            },
            new InteractionPairing()
            {
                Type1 = Organism.OrganismType.DEER,
                Type2 = Organism.OrganismType.GRASS,

                multiplier1 = .1f,
                multiplier2 = .0f
            },
            new InteractionPairing()
            {
                Type1 = Organism.OrganismType.GRASS,
                Type2 = Organism.OrganismType.DEER,

                multiplier1 = .0f,
                multiplier2 = .1f
            },
            new InteractionPairing()
            {
                Type1 = Organism.OrganismType.WOLF,
                Type2 = Organism.OrganismType.GRASS,

                multiplier1 = .0f,
                multiplier2 = .0f
            },
            new InteractionPairing()
            {
                Type1 = Organism.OrganismType.GRASS,
                Type2 = Organism.OrganismType.WOLF,

                multiplier1 = .0f,
                multiplier2 = .0f
            },

        };
    }

    public class InteractionPairing
    {
        public Organism.OrganismType Type1;
        public Organism.OrganismType Type2;
        public float multiplier1;
        public float multiplier2;

        public void Interact(Organism firstOrganism, Organism secondOrganism)
        {
            float firstOrganismEnergy = firstOrganism.Energy - multiplier2 * secondOrganism.Energy;
            float secondOrganismEnergy = secondOrganism.Energy -= multiplier1 * firstOrganism.Energy;

            firstOrganism.Energy = firstOrganismEnergy;
            secondOrganism.Energy = secondOrganismEnergy;
        }
    }
}