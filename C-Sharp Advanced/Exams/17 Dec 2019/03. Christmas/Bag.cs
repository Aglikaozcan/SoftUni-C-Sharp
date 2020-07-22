using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            this.data = new List<Present>();
        }

        public string Color { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Present present)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            var present = this.data.FirstOrDefault(x => x.Name == name);

            if (this.data.Contains(present))
            {
                this.data.Remove(present);

                return true;
            }

            return false;
        }

        public Present GetHeaviestPresent()
        {
            var present = this.data.OrderByDescending(x => x.Weight).First();

            return present;
        }

        public Present GetPresent(string name)
        {
            var present = this.data.FirstOrDefault(x => x.Name == name);

            return present;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Color} bag contains:");
            
            foreach (var present in this.data)
            {
                sb.AppendLine(present.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
