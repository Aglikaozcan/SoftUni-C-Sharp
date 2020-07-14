namespace SantaWorkshop.Models.Instruments
{
    using SantaWorkshop.Models.Instruments.Contracts;

    public class Instrument : IInstrument
    {
        private const int DecreasePowerUnit = 10;
        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => this.power;
            private set
            {
                if (value < 0)
                {
                    this.Power = 0;
                }

                this.power = value;
            }
        }

        public bool IsBroken() => this.Power == 0;        

        public void Use()
        {
            if (this.Power - DecreasePowerUnit >= 0)
            {
                this.Power -= DecreasePowerUnit;
            }
            else
            {
                this.Power = 0;
            }
        }
    }
}