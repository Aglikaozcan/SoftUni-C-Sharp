namespace P04_Hospital
{
    using System.Collections.Generic;

    public class Doctor
    {
        public Doctor(string name)
        {
            this.Name = name;
            this.Patients = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Patients { get; set; }
    }
}
