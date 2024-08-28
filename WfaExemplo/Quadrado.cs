namespace WfaExemplo
{
    public class Quadrado : FormaGeometrica
    {
        private double _base;

        public double Base
        {
            get { return _base; }
            set { _base = value; }
        }

        public override double CalcularArea()
        {
            // return lado * lado
            return System.Math.Pow(_base, 2);
        }

        public override double CalcularPerimetro()
        {
            return _base * 4;
        }

        public override string ToString()
        {
            return $"Quadrado ({_base})";
        }
    }
}
