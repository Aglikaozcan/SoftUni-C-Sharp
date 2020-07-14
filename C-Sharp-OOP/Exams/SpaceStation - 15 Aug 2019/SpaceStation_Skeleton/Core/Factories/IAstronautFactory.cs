namespace SpaceStation.Core.Factories
{
    using SpaceStation.Models.Astronauts.Contracts;

    public interface IAstronautFactory
    {
        IAstronaut CreateAstronaut(string type, string name);
    }
}