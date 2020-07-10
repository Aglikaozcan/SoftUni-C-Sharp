namespace P04_Hospital
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Hospital hospital = new Hospital();

            string input = Console.ReadLine();

            while (input != "Output")
            {
                string[] tokens = input.Split();

                var departamentName = tokens[0];
                var doctorName = tokens[1] + " " + tokens[2];
                var patient = tokens[3];

                Doctor doctor = hospital.GetDoctor(doctorName);
                Department department = hospital.GetDepartment(departamentName);

                bool hasFreeSpace = department.Rooms.Sum(r => r.Patients.Count) < 60;

                if (hasFreeSpace)
                {                    
                    for (int room = 0; room < department.Rooms.Count; room++)
                    {
                        if (department.Rooms[room].Patients.Count < 3)
                        {
                            department.Rooms[room].Patients.Add(patient);
                            doctor.Patients.Add(patient);
                            break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                string[] args = input.Split();

                if (args.Length == 1)
                {
                    string departmentName = args[0];

                    Department department = hospital.GetDepartment(departmentName);

                    foreach (var room in department.Rooms.Where(r => r.Patients.Count > 0))
                    {
                        room.PrintPatients(room.Patients);
                    }
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    string departmentName = args[0];
                    Department department = hospital.GetDepartment(departmentName);

                    int roomNumber = int.Parse(args[1]) - 1;
                    var patients = department.Rooms[roomNumber]
                        .Patients
                        .OrderBy(p => p)
                        .ToList();

                    foreach (var patient in patients)
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    var doctorName = args[0] + ' ' + args[1];
                    var doctor = hospital.GetDoctor(doctorName);
                    var patients = doctor
                        .Patients
                        .OrderBy(p => p)
                        .ToList();

                    foreach (var patient in patients)
                    {
                        Console.WriteLine(patient);
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
