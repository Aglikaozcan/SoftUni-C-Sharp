namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int ShootingCapacity = 5;

        public Rifle(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel < ShootingCapacity)
            {
                this.Reload(InitialBulletsPerBarrel);
            }

            int firedBullets = this.DecreaseBullets(ShootingCapacity);

            return firedBullets;
        }
    }
}
