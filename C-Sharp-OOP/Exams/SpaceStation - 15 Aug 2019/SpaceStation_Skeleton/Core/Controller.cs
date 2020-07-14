namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Core.Factories;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories;
    using SpaceStation.Repositories.Contracts;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private IAstronautFactory astronautFactory;
        private IRepository<IAstronaut> astronauts;
        private IRepository<IPlanet> planets;
        private IMission mission;
        private List<IPlanet> exploredPlanets;

        public Controller()
        {
            this.astronautFactory = new AstronautFactory();
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.mission = new Mission();
            this.exploredPlanets = new List<IPlanet>();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            var astronaut = this.astronautFactory.CreateAstronaut(type, astronautName);

            this.astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);
            planet.Items = items.ToList();

            this.planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            ICollection<IAstronaut> selectedAstronauts = this.astronauts.Models.Where(x => x.Oxygen > 60).ToList();
                      
            var planet = this.planets.FindByName(planetName);

            this.mission.Explore(planet, selectedAstronauts);

            this.exploredPlanets.Add(planet);

            var deadAstronauts = selectedAstronauts.Where(x => !x.CanBreath);

            return $"Planet: {planet.Name} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            string message = string.Empty;

            message = $"{this.exploredPlanets.Count} planets were explored!" + Environment.NewLine;
            message += "Astronauts info:" + Environment.NewLine;

            foreach (var astronaut in this.astronauts.Models)
            {
                message += $"Name: {astronaut.Name}" + Environment.NewLine;
                message += $"Oxygen: {astronaut.Oxygen}" + Environment.NewLine;
                message += $"Bag items: ";

                if (astronaut.Bag.Items.Count == 0)
                {
                    message += "none" + Environment.NewLine;
                }
                else
                {
                    message += string.Join(", ", astronaut.Bag.Items) + Environment.NewLine;
                }
            }

            return message;
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronauts.FindByName(astronautName);

            this.astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}