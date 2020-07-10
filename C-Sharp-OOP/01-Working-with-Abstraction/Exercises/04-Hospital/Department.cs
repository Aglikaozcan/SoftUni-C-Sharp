namespace P04_Hospital
{
    using System.Collections.Generic;

    public class Department
    {
        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
        }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; }        
    }
}
