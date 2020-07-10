namespace P05_GreedyTimes2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private long capacity;
        private long currentCapacity;
        private long gold;
        private Dictionary<string, long> gems;
        private long totalGems;
        private Dictionary<string, long> cash;
        private long totalCash;

        public Bag(long capacity)
        {
            this.capacity = capacity;
            this.currentCapacity = 0;
            this.gold = 0;
            this.gems = new Dictionary<string, long>();
            this.totalGems = 0;
            this.cash = new Dictionary<string, long>();
            this.totalCash = 0;
        }

        public void AddCash(string item, long quantity)
        {
            if (this.HasFreeCapacity(quantity) && this.totalGems >= this.totalCash + quantity)
            {
                if (!this.cash.ContainsKey(item))
                {
                    this.cash.Add(item, 0);
                }
                this.cash[item] += quantity;

                this.currentCapacity += quantity;
                this.totalCash += quantity;
            }
        }

        public void AddGold(long quantity)
        {
            if (this.HasFreeCapacity(quantity))
            {
                this.gold += quantity;
                this.currentCapacity += quantity;
            }
        }

        public void AddGems(string item, long quantity)
        {
            if (this.HasFreeCapacity(quantity) && this.gold >= this.totalGems + quantity)
            {
                if (!this.gems.ContainsKey(item))
                {
                    this.gems.Add(item, 0);
                }
                this.gems[item] += quantity;

                this.currentCapacity += quantity;
                this.totalGems += quantity;
            }
        }

        private bool HasFreeCapacity(long quantity)
        {
            return this.currentCapacity + quantity <= this.capacity;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.gold > 0)
            {
                sb.AppendLine($"<Gold> ${this.gold}");
                sb.AppendLine($"##Gold - {this.gold}");
            }
                                    
            if (this.gems.Any())
            {
                var orderedGems = gems
                .OrderByDescending(x => x.Key)
                .ThenBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

                sb.AppendLine($"<Gem> ${this.totalGems}");
                sb.AppendLine(string.Join(Environment.NewLine, orderedGems.Select(x => $"##{x.Key} - {x.Value}")));
            }

            if (this.cash.Any())
            {
                var orderedCash = cash
                .OrderByDescending(x => x.Key)
                .ThenBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

                sb.AppendLine($"<Cash> ${this.totalCash}");
                sb.Append(string.Join(Environment.NewLine, orderedCash.Select(x => $"##{x.Key} - {x.Value}")));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
