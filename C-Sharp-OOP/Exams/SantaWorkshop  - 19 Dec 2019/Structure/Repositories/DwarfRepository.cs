namespace SantaWorkshop.Repositories
{
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class DwarfRepository : IRepository<IDwarf>
    {
        private List<IDwarf> models;

        public DwarfRepository()
        {
            this.models = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => this.models.AsReadOnly();

        public void Add(IDwarf dwarf)
        {
            this.models.Add(dwarf);
        }

        public IDwarf FindByName(string name)
        {
            var dwarf = this.models.FirstOrDefault(x => x.Name == name);

            return dwarf;
        }

        public bool Remove(IDwarf dwarf)
        {
            return this.models.Remove(dwarf);
        }
    }
}