using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> heroes;

        public HeroRepository()
        {
            heroes = new List<Hero>();
        }

        public int Count
        {
            get
            {
                return this.heroes.Count;
            }
        }

        public void Add(Hero hero)
        {
            if (!this.heroes.Contains(hero))
            {
                heroes.Add(hero);
            }
        }

        public void Remove(string name)
        {
            var neededName = this.heroes.FirstOrDefault(x => x.Name == name);

            if (neededName != null)
            {
                heroes.Remove(neededName);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            var heroWithHighestStrength = this.heroes.OrderByDescending(x => x.Item.Strength).FirstOrDefault();

            return heroWithHighestStrength;
        }

        public Hero GetHeroWithHighestAbility()
        {
            var heroWithHighestAbility = this.heroes.OrderByDescending(x => x.Item.Ability).FirstOrDefault();

            return heroWithHighestAbility;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            var heroWithHighestIntelligence = this.heroes.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();

            return heroWithHighestIntelligence;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in this.heroes)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
