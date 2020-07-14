namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public class DentalCare : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            //adds 12 happiness and 10 energy
            animal.Happiness += 12;
            animal.Energy += 10;            
        }
    }
}