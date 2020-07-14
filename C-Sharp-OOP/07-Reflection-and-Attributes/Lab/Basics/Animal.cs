using System;
using System.Collections.Generic;
using System.Text;

namespace basics
{
    public abstract class Animal : IAnimal
    {
        private string name;

        protected Animal(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Cat is too young!");
                }

                this.name = value;
            }
        }
    }
}
