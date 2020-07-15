namespace ViceCity.Models.Neghbourhoods
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        private ICollection<IPlayer> civilPlayers;

        public GangNeighbourhood()
        {
            this.civilPlayers = new List<IPlayer>();
        }

        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var currentGun in mainPlayer.GunRepository.Models)
            {
                foreach (var currentCivil in civilPlayers)
                {
                    while (currentCivil.IsAlive && currentGun.CanFire)
                    {
                        int takenLifePoints = currentGun.Fire();
                        currentCivil.TakeLifePoints(takenLifePoints);
                    }

                    if (!currentGun.CanFire)
                    {
                        mainPlayer.GunRepository.Remove(currentGun);
                        break;
                    }                    
                }
            }

            foreach (var currentCivil in civilPlayers.Where(x => x.IsAlive))
            {
                foreach (var currentGun in currentCivil.GunRepository.Models)
                {
                    while (mainPlayer.IsAlive && currentGun.CanFire)
                    {
                        int takenLifePoints = currentGun.Fire();
                        mainPlayer.TakeLifePoints(takenLifePoints);
                    }

                    if (!currentGun.CanFire)
                    {
                        currentCivil.GunRepository.Remove(currentGun);
                        break;
                    }

                    if (mainPlayer.IsAlive == false)
                    {
                        break;
                    }
                }

                if (mainPlayer.IsAlive == false)
                {
                    break;
                }
            }            
        }
    }
}