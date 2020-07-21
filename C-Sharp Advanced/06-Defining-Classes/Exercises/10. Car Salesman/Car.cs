namespace _09.CarSalesman
{
    using System.Text;

    public class Car
    {
        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public Car(string model, Engine engine, int weight)
            :this(model, engine, weight, "n/a")
        {
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, -1, color)
        {
        }

        public Car(string model, Engine engine)
            : this(model, engine, -1, "n/a")
        {
        }

        public string Model { get; set; }

        public Engine  Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine(Engine.ToString());

            if (this.Weight == -1 || this.Weight == 0)
            {
                sb.AppendLine($" Weight: n/a");
            }
            else
            {
                sb.AppendLine($" Weight: {this.Weight}");
            }

            sb.Append($" Color: {this.Color}");

            return sb.ToString();
        }
    }
}