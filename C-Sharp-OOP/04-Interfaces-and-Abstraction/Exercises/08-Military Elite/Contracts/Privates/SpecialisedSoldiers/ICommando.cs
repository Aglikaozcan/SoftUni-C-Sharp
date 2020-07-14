namespace P08.MilitaryElite.Contracts.Privates.SpecialisedSoldiers
{
    using P08.MilitaryElite.Models.Privates.SpecialisedSoldiers;
    using System.Collections.Generic;

    public interface ICommando
    {
        IReadOnlyCollection<Mission> Missions { get; }

        void CompleteMission(string codeName);
    }
}
