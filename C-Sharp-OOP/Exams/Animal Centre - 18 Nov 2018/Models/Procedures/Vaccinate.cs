namespace AnimalCentre.Models.Procedures
{   
    using Contracts;

    public class Vaccinate : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            //removes 8 energy and vaccinates current animal
            animal.Energy -= 8;
            animal.IsVaccinated = true;
        }
    }
}