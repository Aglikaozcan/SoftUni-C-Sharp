namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<Pilot> hiredPilots;
        private List<BaseMachine> machines;

        public MachinesManager()
        {
            this.hiredPilots = new List<Pilot>();
            this.machines = new List<BaseMachine>();
        }

        public string HirePilot(string name)
        {
            var pilot = this.hiredPilots.FirstOrDefault(p => p.Name == name);

            if (pilot == null)
            {
                pilot = new Pilot(name);
                this.hiredPilots.Add(pilot);

                return $"Pilot {pilot.Name} hired";
            }
            else
            {
                return $"Pilot {pilot.Name} is hired already";
            }            
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var tank = this.machines.FirstOrDefault(x => x.Name == name);

            if (tank == null)
            {
                tank = new Tank(name, attackPoints, defensePoints);
                this.machines.Add(tank);

                return $"Tank {tank.Name} manufactured - attack: {tank.AttackPoints:f2}; defense: {tank.AttackPoints:f2}";
            }
            else
            {
                return $"Machine {name} is manufactured already";
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            var fighter = this.machines
                .FirstOrDefault(x => x.Name == name);

            if (fighter == null)
            {
                fighter = new Fighter(name, attackPoints, defensePoints);
                this.machines.Add(fighter);

                return $"Fighter {fighter.Name} manufactured - attack: {fighter.AttackPoints:f2}; defense: {fighter.DefensePoints:f2}; aggressive: ON";
            }
            else
            {
                return $"Machine {fighter.Name} is manufactured already";
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = this.hiredPilots
                .FirstOrDefault(x => x.Name == selectedPilotName);

            var machine = this.machines
                .FirstOrDefault(x => x.Name == selectedMachineName);

            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return $"Pilot {pilot.Name} engaged machine {machine.Name}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attacker = this.machines.FirstOrDefault(x => x.Name == attackingMachineName);
            var defender = this.machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (attacker == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            if (defender == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if (attacker.HealthPoints <= 0)
            {
                return $"Dead machine {attacker.Name} cannot attack or be attacked";
            }

            if (defender.HealthPoints <= 0)
            {
                return $"Dead machine {defender.Name} cannot attack or be attacked";
            }

            attacker.Attack(defender);

            return $"Machine {defender.Name} was attacked by machine {attacker.Name} - current health: {defender.HealthPoints:f2}";
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = this.hiredPilots.First(p => p.Name == pilotReporting);

            return pilot.Report();            
        }

        public string MachineReport(string machineName)
        {
            var machine = this.machines.First(x => x.Name == machineName);

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = (Fighter)this.machines
                .FirstOrDefault(x => x.Name == fighterName);

            if (fighter == null)
            {
                return $"Machine {fighterName} could not be found";
            }
            else
            {
                fighter.ToggleAggressiveMode();

                return $"Fighter {fighter.Name} toggled aggressive mode";
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var tank = (Tank)this.machines
                .FirstOrDefault(x => x.Name == tankName);

            if (tank == null)
            {
                return $"Machine {tankName} could not be found";
            }
            else
            {
                tank.ToggleDefenseMode();

                return $"Tank {tank.Name} toggled defense mode";
            }
        }
    }
}