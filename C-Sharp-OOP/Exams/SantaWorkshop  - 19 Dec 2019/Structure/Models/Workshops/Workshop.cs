namespace SantaWorkshop.Models.Workshops
{
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Models.Workshops.Contracts;
    using System.Linq;

    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (dwarf.Energy > 0 || !present.IsDone() || dwarf.Instruments.Any(x => !x.IsBroken()))
            {
                foreach (var instrument in dwarf.Instruments)
                {                   
                    while (!instrument.IsBroken())
                    {
                        instrument.Use();
                        dwarf.Work();
                        present.GetCrafted();
                    }                    
                }                
            }
        }
    }
}