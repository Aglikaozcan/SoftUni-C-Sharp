namespace AnimalCentre.Models.Hotels
{
    using Contracts;

    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;

    public class Hotel : IHotel
    {
        private const int Capacity = 10;
        private readonly Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals 
            => this.animals.ToImmutableDictionary();

        public void Accommodate(IAnimal animal)
        {
            if (animals.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            //If the provided animal name does not exist in the hotel, 
            //throw an ArgumentException with the message "Animal {animal name} does not exist"

            if (!this.animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            //If an animal with that name exist, change its owner, its adoption status and remove the animal from the hotel.

            animals[animalName].Owner = owner;
            animals[animalName].IsAdopt = true;

            animals.Remove(animalName);
        }
    }
}