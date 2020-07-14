namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planets.AsReadOnly();

        public void Add(IPlanet planet)
        {
            this.planets.Add(planet);
        }

        public IPlanet FindByName(string name)
        {
            return this.planets.First(x => x.Name == name);
        }

        public bool Remove(IPlanet planet)
        {
            return this.planets.Remove(planet);
        }
    }
}