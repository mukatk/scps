using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpLZW;
using static SPCS.Util.Arquivo;

namespace SPCS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Gravar("teste", "teste.scps");
            string conteudo = Abrir("teste.scps");
        }
    }
}
