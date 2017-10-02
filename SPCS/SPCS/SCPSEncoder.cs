using SharpLZW;
using SPCS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCS
{
    /// <summary>
    /// Classe responsável por comprimir arquivos
    /// </summary>
    public class SCPSEncoder
    {
        public static void Encode(string arquivo)
        {
            LZWEncoder encoder = new LZWEncoder();
            string conteudo = Arquivo.Abrir(arquivo);

            Console.WriteLine("Iniciada a compressão");
            DateTime dataInicial = DateTime.Now;

            //Codificação LZW
            string lzwEncoded = encoder.Encode(conteudo);

            HuffmanTree huffman = new HuffmanTree();

            //Criação da árvore huffman
            huffman.Build(lzwEncoded);

            //Codificação huffman
            var huffmanEncoded = huffman.Encode(lzwEncoded);

            DateTime dataFinal = DateTime.Now;

            string tempoDecorrido = (dataFinal - dataInicial).TotalSeconds.ToString("N2");

            //Contabiliza apenas os tempos para compressão. Igora tempo de IO
            Console.WriteLine($"Arquivo comprimido em {tempoDecorrido} segundos");

            byte[] ret = new byte[(huffmanEncoded.Length - 1) / 8 + 1];
            huffmanEncoded.CopyTo(ret, 0);

            //Gravando arquivo comprimido
            Arquivo.Gravar(ret, $"{arquivo.Split('.')[0]}.scps");
        }
    }
}
