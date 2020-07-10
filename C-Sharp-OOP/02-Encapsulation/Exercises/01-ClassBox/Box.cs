namespace P01.ClassBox
{
    using System.Text;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public double GetSurfaceArea()
        {
            double surfaceArea = 2 * 
                (this.length * this.width
                + this.length * this.height
                + this.width * this.height);

            return surfaceArea;
        }

        public double GetVolume()
        {
            double volume = this.length * this.width * this.height;

            return volume;
        }

        public double GetLateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * this.height * (this.length + this.width);

            return lateralSurfaceArea;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.GetSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.GetLateralSurfaceArea():f2}");
            sb.Append($"Volume - {this.GetVolume():f2}");

            return sb.ToString();
        }
    }
}