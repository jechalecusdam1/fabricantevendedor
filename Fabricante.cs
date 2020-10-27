using System;
using System.Threading;

namespace fabricantevendedor
{
    public class Fabricante
    {
        private Almacen _a;
        private Thread _t;
        private Random _rnd = new Random();
        private int _initTime;
        private int _contador;
        public Fabricante(Almacen a, int contador, int initTime)
        {
            this._a = a;
            this._initTime = initTime;
            this._contador = contador;
        }

        public void Fabrica()
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
            for (int i = 0; i < _contador; i++)
            {
                ms = _initTime;
                Thread.Sleep(ms);
                _a.Guardar();
            }
        }
    }

}