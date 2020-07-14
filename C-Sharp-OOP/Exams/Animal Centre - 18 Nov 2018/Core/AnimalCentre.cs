namespace AnimalCentre.Core
{
    using global::AnimalCentre.Core.AnimalFactory;
    using global::AnimalCentre.Models.Contracts;
    using global::AnimalCentre.Models.Hotels;
    using global::AnimalCentre.Models.Procedures;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AnimalCentre
    {
        private IAnimalFactory animalFactory;
        private readonly IHotel hotel;
        private Dictionary<string, IProcedure> procedureAnimals;
        private Dictionary<string, List<string>> adoptedAnimals;

        public AnimalCentre()
        {
            this.animalFactory = new AnimalFactory.AnimalFactory();
            this.hotel = new Hotel();
            this.adoptedAnimals = new Dictionary<string, List<string>>();

            this.procedureAnimals = new Dictionary<string, IProcedure>
            {
                {"Chip", new Chip()},
                { "DentalCare", new DentalCare()},
                { "Fitness", new Fitness()},
                { "NailTrim", new NailTrim()},
                { "Play", new Play()},
                { "Vaccinate", new Vaccinate()}
            };
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animal = this.animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);
            this.hotel.Accommodate(animal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            this.CheckAnimalExists(name);

            var animal = this.hotel.Animals[name];
            this.procedureAnimals["Chip"].DoService(animal, procedureTime);

            return $"{animal.Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            this.CheckAnimalExists(name);

            var animal = this.hotel.Animals[name];
            this.procedureAnimals["Vaccinate"].DoService(animal, procedureTime);

            return $"{animal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            this.CheckAnimalExists(name);

            var animal = this.hotel.Animals[name];
            this.procedureAnimals["Fitness"].DoService(animal, procedureTime);

            return $"{animal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            this.CheckAnimalExists(name);

            var animal = this.hotel.Animals[name];
            this.procedureAnimals["Play"].DoService(animal, procedureTime);

            return $"{animal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            this.CheckAnimalExists(name);

            var animal = this.hotel.Animals[name];
            this.procedureAnimals["DentalCare"].DoService(animal, procedureTime);

            return $"{animal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            this.CheckAnimalExists(name);

            var animal = this.hotel.Animals[name];
            this.procedureAnimals["NailTrim"].DoService(animal, procedureTime);

            return $"{animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            this.CheckAnimalExists(animalName);

            var animal = this.hotel.Animals[animalName];
            this.hotel.Adopt(animalName, owner);

            if (this.adoptedAnimals.ContainsKey(owner) == false)
            {
                this.adoptedAnimals[owner] = new List<string>();
            }

            this.adoptedAnimals[owner].Add(animalName);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            return this.procedureAnimals[type].History();
        }

        public string AllAdoptedAnimals()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var owner in this.adoptedAnimals)
            {
                sb.AppendLine($"--Owner: {owner.Key}");
                sb.AppendLine($"    - Adopted animals: {string.Join(" ", owner.Value.OrderBy(x => x))}");
            }

            return sb.ToString().TrimEnd();
        }

        private void CheckAnimalExists(string name)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
        }
    }
}