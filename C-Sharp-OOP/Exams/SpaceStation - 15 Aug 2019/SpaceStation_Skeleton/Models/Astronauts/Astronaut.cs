﻿namespace SpaceStation.Models.Astronauts
{
    using Models.Astronauts.Contracts;
    using Models.Bags;
    using Utilities.Messages;

    using System;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private const int DecreaseOxygenUnit = 10;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new AggregateException(ExceptionMessages.InvalidOxygen);
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag { get; }

        public virtual void Breath()
        {
            if (this.Oxygen - DecreaseOxygenUnit >= 0)
            {
                this.Oxygen -= DecreaseOxygenUnit;
            }
        }
    }
}