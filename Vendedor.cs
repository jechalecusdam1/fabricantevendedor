using System;
using System.Threading;

namespace fabricantevendedor
{
    public class Vendedor
    {
        private Almacen _a;
        private Thread _t;
        private Random _rnd = new Random();
        private int _initTime;
        private int _cont;
        public Vendedor(Almacen a, int contador, int initTime)
        {
            this._a = a;
            this._cont = contador;
            this._initTime = initTime;
        }

        public void Vende()
        {
            this._t = new Thread(() => this._Accion());
            this._t.Start();
        }

        public void Termina()
        {
            _t.Join();
        }

        private void _Accion()
        {
            int ms;
            for (int i = 0; i < _cont; i++)
            {
                ms = _initTime;
                Thread.Sleep(ms);
                _a.Sacar();
            }
        }
    }
}