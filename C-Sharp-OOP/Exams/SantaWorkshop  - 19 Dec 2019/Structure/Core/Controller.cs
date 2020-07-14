namespace SantaWorkshop.Core
{
    using SantaWorkshop.Core.Contracts;
    using SantaWorkshop.Core.Factories;
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Instruments;
    using SantaWorkshop.Models.Presents;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Models.Workshops;
    using SantaWorkshop.Models.Workshops.Contracts;
    using SantaWorkshop.Repositories;
    using SantaWorkshop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Controller : IController
    {
        private DwarfRepository dwarfRepository;
        private PresentRepository presentRepository;
        private IDwarfFactory dwarfFactory;
        private IWorkshop workshop;
        private List<IPresent> craftedPresents;

        public Controller()
        {
            this.dwarfRepository = new DwarfRepository();
            this.presentRepository = new PresentRepository();
            this.dwarfFactory = new DwarfFactory();
            this.workshop = new Workshop();
            this.craftedPresents = new List<IPresent>();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = this.dwarfFactory.Create(dwarfType, dwarfName);

            this.dwarfRepository.Add(dwarf);

            return string.Format(
                OutputMessages.DwarfAdded,
                dwarfType,
                dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            Instrument instrument = new Instrument(power);

            var dwarf = this.dwarfRepository.FindByName(dwarfName);

            dwarf.AddInstrument(instrument);

            return string.Format(
                OutputMessages.InstrumentAdded,
                power,
                dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            Present present = new Present(presentName, energyRequired);

            this.presentRepository.Add(present);

            return string.Format(
                OutputMessages.PresentAdded,
                presentName);
        }

        public string CraftPresent(string presentName)
        {
            var present = this.presentRepository.FindByName(presentName);                       

            foreach (var dwarf in this.dwarfRepository.Models)
            {
                if (dwarf.Energy < 50)
                {
                    continue;
                }

                this.workshop.Craft(present, dwarf);

                if (dwarf.Energy <= 0)
                {
                    this.dwarfRepository.Remove(dwarf);
                }
            }


            if (present.IsDone())
            {
                craftedPresents.Add(present);

                return string.Format(
                OutputMessages.PresentIsDone,
                presentName);
            }
            else
            {
                return string.Format(
                OutputMessages.PresentIsNotDone,
                presentName);
            }
        }

        public string Report()
        {
            string message = string.Empty;

            message += $"{this.craftedPresents.Count} presents are done!" + Environment.NewLine;
            message += "Dwarfs info:" + Environment.NewLine;

            foreach (var dwarf in this.dwarfRepository.Models)
            {
                message += $"Name: {dwarf.Name}" + Environment.NewLine;
                message += $"Energy: {dwarf.Energy}" + Environment.NewLine;
                message += $"Instruments {dwarf.Instruments.Where(x => !x.IsBroken())} not broken left" + Environment.NewLine;
            }

            return message;
        }
    }
}