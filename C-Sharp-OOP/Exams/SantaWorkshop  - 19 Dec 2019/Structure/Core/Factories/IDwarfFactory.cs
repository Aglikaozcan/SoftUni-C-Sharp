namespace SantaWorkshop.Core.Factories
{
    using SantaWorkshop.Models.Dwarfs.Contracts;

    public interface IDwarfFactory
    {
        IDwarf Create(string type, string name);
    }
}