using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            Name = name;
            gladiators = new List<Gladiator>();
        }

        public string Name { get; set; }

        public int Count
        {
            get
            {
                return this.gladiators.Count;
            }
        }

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            var neededName = gladiators.Where(x => x.Name == name).FirstOrDefault();

            if (gladiators.Contains(neededName))
            {
                gladiators.Remove(neededName);
            }
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            var gladitorWithHighestStatPower = gladiators.OrderByDescending(x => x.GetStatPower()).FirstOrDefault();

            return gladitorWithHighestStatPower;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            var gladitorWithHighestWeaponPower = gladiators.OrderByDescending(x => x.GetWeaponPower()).FirstOrDefault();

            return gladitorWithHighestWeaponPower;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            var gladitorWithHighestTotalPower = gladiators.OrderByDescending(x => x.GetTotalPower()).FirstOrDefault();

            return gladitorWithHighestTotalPower;
        }

        public override string ToString()
        {
            return $"{Name} - {Count} gladiators are participating.";
        }
    }
}
