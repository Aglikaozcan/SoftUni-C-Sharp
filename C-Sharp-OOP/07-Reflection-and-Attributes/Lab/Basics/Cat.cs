using System;
using System.Collections.Generic;
using System.Text;

namespace basics
{
    public class Cat : Animal, ICat
    {
        public Cat(string name) 
            : base(name)
        {
        }

        public int Age { get; set; }

        public string SayHello()
        {
            return $"I'm a cat and my name is {this.Name}";
        }
    }
}
