namespace AquariumAdventure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Aquarium
    {
        private List<Fish> fishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            Name = name;
            Capacity = capacity;
            Size = size;
            fishInPool = new List<Fish>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Size { get; set; }

        public void Add(Fish fish)
        {
            if (this.fishInPool.Contains(fish) == false && this.Capacity > this.fishInPool.Count)
            {
                this.fishInPool.Add(fish);
            }
        }

        public bool Remove(string name)
        {
            var neededFish = fishInPool.FirstOrDefault(x => x.Name == name);

            if (fishInPool.Contains(neededFish))
            {
                fishInPool.Remove(neededFish);

                return true;
            }

            return false;
        }

        public Fish FindFish(string name)
        {
            var neededFish = fishInPool.FirstOrDefault(x => x.Name == name);

            return neededFish;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Aquarium: {Name} ^ Size: {Size}");

            foreach (var fish in fishInPool)
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}