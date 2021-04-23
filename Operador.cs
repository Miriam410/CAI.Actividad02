namespace CAI.Actividad02
{
    internal class Operador
    {
        public Operador(int numero)
        {
            Numero = numero;
        }

        public Orden OrdenActual { get; private set; }

        public int Numero { get; }
        public int OrdenesCumplidas { get; private set; }

        public void Asignar(Orden orden)
        {
            if (OrdenActual != null)
            {
                OrdenActual.Terminada = true;
                OrdenesCumplidas++;
            }

            OrdenActual = orden;
        }
    }
}