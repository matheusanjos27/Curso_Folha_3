using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensoes
{
    public static class HelperExtensoes
    {
        public static List<T> RemoveRepetidos<T>(this List<T> list)
        {
            if (list == null) { throw new ArgumentNullException("A lista é nula"); }
            list = list.DistinctBy(x => x).ToList<T>();
            return list;
        }

        public static bool isArmstrong(this int x) // 407
        {
            string numero = x.ToString(); // "407"
            int tamanho = numero.Length; // 3

            int resultado = 0;
            for (int i = 0; i < tamanho; i++)
            {
                resultado += (int)Math.Pow(int.Parse(numero.Substring(i, 1)), tamanho);
            }
            return (resultado.Equals(x));

        }

    }
}
