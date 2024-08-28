namespace WfaExemplo
{
    public class TE : Triangulo
    {
        private double _base;

        public double Base
        {
            get { return _base; }
            set { _base = value; }
        }
        
        public override double CalcularArea()
        {
            return (System.Math.Sqrt(3) / 4) * System.Math.Pow(_base, 2);
        }

        public override double CalcularPerimetro()
        {
            return _base * 3;
        }
        public override string ToString()
        {
            return $"Triangulo E. ({_base})";
        }
    }
}