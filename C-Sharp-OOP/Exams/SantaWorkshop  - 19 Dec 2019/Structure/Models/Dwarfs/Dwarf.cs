namespace SantaWorkshop.Models.Dwarfs
{
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Instruments.Contracts;

    using System;
    using System.Collections.Generic;

    public abstract class Dwarf : IDwarf
    {
        private const int DecreaseEnergyUnit = 10;
        private string name;
        private int energy;
        private List<IInstrument> instruments;

        protected Dwarf(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.instruments = new List<IInstrument>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Dwarf name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            private set
            {
                if (value < 0)
                {
                    this.Energy = 0;
                }

                this.energy = value;
            }
        }

        public ICollection<IInstrument> Instruments => this.instruments;

        public void AddInstrument(IInstrument instrument)
        {
            this.Instruments.Add(instrument);
        }

        public virtual void Work()
        {
            if (this.Energy - DecreaseEnergyUnit >= 0)
            {
                this.Energy -= DecreaseEnergyUnit;
            }
            else
            {
                this.Energy = 0;
            }
        }
    }
}