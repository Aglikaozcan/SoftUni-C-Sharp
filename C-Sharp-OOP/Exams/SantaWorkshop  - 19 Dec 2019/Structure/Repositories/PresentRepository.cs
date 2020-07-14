namespace SantaWorkshop.Repositories
{
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PresentRepository : IRepository<IPresent>
    {
        private List<IPresent> models;

        public PresentRepository()
        {
            this.models = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models => this.models.AsReadOnly();

        public void Add(IPresent present)
        {
            this.models.Add(present);
        }

        public IPresent FindByName(string name)
        {
            var present = this.models.FirstOrDefault(x => x.Name == name);

            return present;
        }

        public bool Remove(IPresent present)
        {
            return this.models.Remove(present);
        }
    }
}