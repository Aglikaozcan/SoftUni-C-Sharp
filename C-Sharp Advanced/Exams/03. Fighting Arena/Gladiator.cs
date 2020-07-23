namespace FightingArena
{
    using System.Text;

    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            Name = name;
            Stat = stat;
            Weapon = weapon;
        }

        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            var sumOfStatProp = this.Stat.Agility + this.Stat.Flexibility + this.Stat.Intelligence + Stat.Skills + Stat.Strength;
            var sumOfWeaponProps = Weapon.Sharpness + Weapon.Size + Weapon.Solidity;

            return sumOfStatProp + sumOfWeaponProps;
        }

        public int GetWeaponPower()
        {
            var sumOfWeaponProps = Weapon.Sharpness + Weapon.Size + Weapon.Solidity;

            return sumOfWeaponProps;
        }

        public int GetStatPower()
        {
            var sumOfStatProp = this.Stat.Agility + this.Stat.Flexibility + this.Stat.Intelligence + Stat.Skills + Stat.Strength;

            return sumOfStatProp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {this.GetTotalPower()}");
            sb.AppendLine($"  Weapon Power: {this.GetWeaponPower()}");
            sb.AppendLine($"  Stat Power: {this.GetStatPower()}");

            return sb.ToString().TrimEnd();
        }
    }
}