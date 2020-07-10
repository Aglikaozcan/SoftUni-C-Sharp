namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;

    public class Room
    {
        public Room()
        {
            this.Patients = new List<string>();
        }

        public List<string> Patients { get; set; }

        public void PrintPatients(List<string> patients)
        {
            foreach (var patient in patients)
            {
                Console.WriteLine(patient);
            }
        }
    }
}
