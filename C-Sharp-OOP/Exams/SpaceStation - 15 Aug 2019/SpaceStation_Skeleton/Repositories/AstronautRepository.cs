namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.astronauts.AsReadOnly();

        public void Add(IAstronaut astronaut)
        {
            this.astronauts.Add(astronaut);
        }

        public IAstronaut FindByName(string name)
        {
            var astronaut = this.astronauts.FirstOrDefault(x => x.Name == name);

            return astronaut;
        }

        public bool Remove(IAstronaut astronaut)
        {
            return this.astronauts.Remove(astronaut);
        }
    }
}