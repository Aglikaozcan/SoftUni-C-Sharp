namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class Play : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            //removes 6 energy and adds 12 happiness
            animal.Happiness -= 12;
            animal.Energy -= 6;
        }
    }
}