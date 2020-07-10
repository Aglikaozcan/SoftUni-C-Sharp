namespace P02.ClassBoxDataValidation
{
    using System;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                this.ValidateParameter(value, nameof(this.Length));
                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {                
                this.ValidateParameter(value, nameof(this.Width));
                this.width = value;
            }
        }       

        public double Height
        {
            get => this.height;
            private set
            {
                this.ValidateParameter(value, nameof(this.Height));
                this.height = value;
            }
        }

        private void ValidateParameter(double value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{parameterName} cannot be zero or negative.");
            }
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
    }
}
