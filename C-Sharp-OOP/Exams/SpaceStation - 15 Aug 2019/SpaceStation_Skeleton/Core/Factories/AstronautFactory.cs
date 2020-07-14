namespace SpaceStation.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using SpaceStation.Models.Astronauts.Contracts;

    public class AstronautFactory : IAstronautFactory
    {
        public IAstronaut CreateAstronaut(string type, string name)
        {
            Type astronautType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            IAstronaut astronaut = (IAstronaut)Activator
                .CreateInstance(astronautType, name);

            return astronaut;
        }
    }
}