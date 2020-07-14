using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, InitialHealthPoints, attackPoints, defensePoints)
        {
            this.DefenseMode = true;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (!this.DefenseMode)
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            if (this.DefenseMode)
            {
                sb.AppendLine($" *Defense: ON");
            }
            else
            {
                sb.AppendLine($" *Defense: OFF");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
