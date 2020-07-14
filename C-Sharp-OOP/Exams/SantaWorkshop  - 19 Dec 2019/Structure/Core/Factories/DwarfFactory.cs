namespace SantaWorkshop.Core.Factories
{
    using SantaWorkshop.Models.Dwarfs;
    using SantaWorkshop.Models.Dwarfs.Contracts;

    public class DwarfFactory : IDwarfFactory
    {    
        public IDwarf Create(string type, string name)
        {
            IDwarf dwarf;

            if (type == "HappyDwarf")
            {
                dwarf = new HappyDwarf(name);
            }
            else if (type == "SleepyDwarf")
            {
                dwarf = new SleepyDwarf(name);
            }
            else
            {
                dwarf = null;
            }

            return dwarf;
        }
    }
}