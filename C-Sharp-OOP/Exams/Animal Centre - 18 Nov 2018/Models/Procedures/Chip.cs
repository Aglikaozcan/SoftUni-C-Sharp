﻿namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AnimalCentre.Models.Contracts;

    public class Chip : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            //removes 5 happiness and chips current animal. Animal can be chipped once. 
            //If animal is already chipped throw an ArgumentException with message "{animal name} is already chipped"

            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            base.DoService(animal, procedureTime);

            animal.Happiness -= 5;
            animal.IsChipped = true;            
        }
    }
}