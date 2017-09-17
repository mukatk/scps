using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpLZW;
using SPCS.Util;

namespace SPCS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LZWEncoder encoder = new LZWEncoder();
            LZWDecoder decoder = new LZWDecoder();
            string conteudo = Arquivo.Abrir("alice29.txt");

            Arquivo.Gravar(encoder.EncodeToByteList(conteudo), "alice29.scps");
        }
    }
}
