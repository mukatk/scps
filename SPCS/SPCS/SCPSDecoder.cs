using SharpLZW;
using SCPS.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPS
{
    /// <summary>
    /// Classe responsável por decodificar arquivos SCPS
    /// </summary>
    public class SCPSDecoder
    {
        public static void Decode(string arquivo)
        {
            //Carrega arquivo comprimido
            byte[] dados = Arquivo.AbrirEmBytes(arquivo);
            
            BitArray bits = new BitArray(dados);

            Console.WriteLine("Iniciada a decompressão");
            DateTime dataInicial = DateTime.Now;

            HuffmanTree huffman = new HuffmanTree();

            //Decodificando a árvore huffman
            string huffmanDecoded = huffman.Decode(bits);

            LZWDecoder lZWDecoder = new LZWDecoder();

            //Decodificando LZW
            string conteudo = lZWDecoder.Decode(huffmanDecoded);

            DateTime dataFinal = DateTime.Now;

            string tempoDecorrido = (dataFinal - dataInicial).TotalSeconds.ToString("N2");

            //Contabiliza apenas os tempos para decompressão. Igora tempo de IO
            Console.WriteLine($"Arquivo descomprimido em {tempoDecorrido} segundos");

            Arquivo.Gravar(conteudo, $"{arquivo.Split('.')[0]} - Descomprimido.txt");
        }
    }
}
