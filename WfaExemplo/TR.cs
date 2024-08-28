namespace WfaExemplo
{
    public class TR : Triangulo
    {
        private double baseT;

        public double BaseT
        {
            get { return baseT; }
            set { baseT = value; }
        }

        private double alturaT;

        public double AlturaT
        {
            get { return alturaT; }
            set { alturaT = value; }
        }

        private double hipotenusa()
        {
            return System.Math.Sqrt(System.Math.Pow(baseT, 2) + System.Math.Pow(alturaT, 2));
        }

        public override double CalcularArea()
        {
            return (baseT * alturaT) / 2;
        }

        public override double CalcularPerimetro()
        {
            return baseT + alturaT + hipotenusa();
        }
        public override string ToString()
        {
            return $"Triangulo R. ({baseT} , {alturaT})";
        }
    }
}
