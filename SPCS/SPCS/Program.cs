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
            SCPSEncoder.Encode("alice29.txt");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Aperte qualquer tecla para inicar a descompressão...");
            Console.WriteLine("--------------------------------------------------");
            Console.ReadLine();

            SCPSDecoder.Decode("alice29.scps");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Aperte qualquer tecla para encerrar...");
            Console.WriteLine("--------------------------------------------------");
            Console.ReadLine();
        }
    }
}
