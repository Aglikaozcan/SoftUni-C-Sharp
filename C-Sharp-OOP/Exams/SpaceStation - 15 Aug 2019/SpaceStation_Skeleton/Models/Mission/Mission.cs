namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using System.Linq;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (astronauts.Any(x => x.CanBreath) || planet.Items.Count > 0)
            {
                var currentAstronaut = astronauts.Where(x => x.CanBreath).First();

                while (currentAstronaut.CanBreath)
                {
                    var currentPlanetItem = planet.Items.First();
                    
                    currentAstronaut.Breath();

                    currentAstronaut.Bag.Items.Add(currentPlanetItem);
                    planet.Items.Remove(currentPlanetItem);
                }
            }            
        }
    }
}