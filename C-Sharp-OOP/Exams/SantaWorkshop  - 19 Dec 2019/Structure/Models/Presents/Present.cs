namespace SantaWorkshop.Models.Presents
{
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Utilities.Messages;
    using System;

    public class Present : IPresent
    {
        private const int DecreasedEnergyUnit = 10;
        private string name;
        private int energyRequired;

        public Present(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Present name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            protected set
            {
                if (value < 0)
                {
                    this.EnergyRequired = 0;
                }

                this.energyRequired = value;
            }
        }

        public void GetCrafted()
        {
            if (this.EnergyRequired - DecreasedEnergyUnit >= 0)
            {
                this.EnergyRequired -= DecreasedEnergyUnit;
            }            
        }

        public bool IsDone() => this.EnergyRequired == 0;        
    }
}