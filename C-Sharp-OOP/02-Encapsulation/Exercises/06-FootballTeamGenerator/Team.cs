namespace P06.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            int playerIndex = this.players.FindIndex(x => x.Name == playerName);

            if (playerIndex == -1)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            players.RemoveAt(playerIndex);
        }

        public double GetRating()
        {
            if (this.players.Count > 0)
            {
                return (int)Math.Round(this.players.Average(x => x.OverallSkillLevel());
            }
            return this.players.
        }
    }
}
