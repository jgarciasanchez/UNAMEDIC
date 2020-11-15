using System;
using System.Collections.Generic;
using System.Text;

namespace Salud.Utils
{
    class Singleton
    {
        private static Singleton INSTANCE = null;
        private static Dictionary<String, Object> context = new Dictionary<String, Object>();

        private Singleton()
        {
        }

        public static Singleton GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new Singleton();
            }
            return INSTANCE;
        }

        public Object get(String parameter)
        {
            Object val = context[parameter];
            return val;
        }

        public void set(String nombre, Object valor)
        {
            context[nombre] = valor;
        }
    }
}
