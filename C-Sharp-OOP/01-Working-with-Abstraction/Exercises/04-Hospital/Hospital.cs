namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        private List<Doctor> doctors;
        private List<Department> departments;

        public Hospital()
        {
            this.doctors = new List<Doctor>();
            this.departments = new List<Department>();
        }

        public Doctor GetDoctor(string doctorName)
        {
            var doctor = this.doctors.FirstOrDefault(d => d.Name == doctorName);

            if (doctor == null)
            {
                doctor = new Doctor(doctorName);
                doctors.Add(doctor);
            }

            return doctor;
        }

        public Department GetDepartment(string departmentName)
        {
            var department = departments.FirstOrDefault(d => d.Name == departmentName);

            if (department == null)
            {
                department = new Department(departmentName);
                departments.Add(department);

                for (int i = 0; i < 20; i++)
                {
                    department.Rooms.Add(new Room());
                }
            }

            return department;
        }
    }
}
