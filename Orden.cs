namespace CAI.Actividad02
{
    internal class Orden
    {
        public Orden(int numero)
        {
            Numero = numero;
        }

        public bool Terminada { get; set; }
        public int Numero { get; }
    }
}