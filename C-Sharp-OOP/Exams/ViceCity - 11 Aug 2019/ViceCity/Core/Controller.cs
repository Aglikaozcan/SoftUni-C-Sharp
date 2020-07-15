namespace ViceCity.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ViceCity.Core.Contracts;
    using ViceCity.Models.Guns;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;

    public class Controller : IController
    {
        private IPlayer mainPlayer;
        private List<IPlayer> players;
        private Queue<IGun> guns;
        private INeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.players = new List<IPlayer>();
            this.guns = new Queue<IGun>();
            this.gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;

            if (type == "Pistol")
            {
                gun = new Pistol(name);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }

            this.guns.Enqueue(gun);

            return $"Successfully added {gun.Name} of type: {gun.GetType().Name}";
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            var gun = this.guns.Peek();

            if (name == "Vercetti")
            {
                this.mainPlayer.GunRepository.Add(gun);
                this.guns.Dequeue();

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            else if (!this.players.Any(x => x.Name == name))
            {
                return "Civil player with that name doesn't exists!";
            }
            else
            {
                var player = this.players.Find(x => x.Name == name);
                player.GunRepository.Add(gun);
                this.guns.Dequeue();

                return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
            }
        }

        public string AddPlayer(string name)
        {
            CivilPlayer civilPlayer = new CivilPlayer(name);
            this.players.Add(civilPlayer);

            return $"Successfully added civil player: {civilPlayer.Name}!";
        }

        public string Fight()
        {
            int mainPlayerInitialLifePoints = this.mainPlayer.LifePoints;
            int civilPlayersHealth = this.players.Sum(x => x.LifePoints);

            this.gangNeighbourhood.Action(mainPlayer, players);

            int mainPlayerLastLifePoints = this.mainPlayer.LifePoints;
            int civilPlayersLastHealth = this.players.Sum(x => x.LifePoints);
            
            int deadCivilPlayers = this.players.Count(x => !x.IsAlive);

            string message = string.Empty;

            if (mainPlayerInitialLifePoints == mainPlayerLastLifePoints 
                && civilPlayersHealth == civilPlayersLastHealth)
            {
                message = "Everything is okay!";
            }
            else
            {
                message = "A fight happened:" + Environment.NewLine;
                message += $"Tommy live points: {mainPlayerLastLifePoints}!" + Environment.NewLine;
                message += $"Tommy has killed: {deadCivilPlayers} players!" + Environment.NewLine;
                message += $"Left Civil Players: {this.players.Count(x => x.IsAlive)}!";                
            }

            return message;
        }
    }
}
