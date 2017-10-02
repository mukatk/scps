using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCS.Util
{
    public static class Arquivo
    {
        private static string CaminhoPadrao = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Abre um arquivo de texto e lê seu conteúdo
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        public static string Abrir(string arquivo)
        {
            string conteudo = string.Empty;
            string caminho = GetCaminho(arquivo);

            if (!File.Exists(caminho))
            {
                throw new IOException("Arquivo não encontrado");
            }

            try
            {
                using (StreamReader streamReader = new StreamReader(caminho))
                {
                    conteudo = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return conteudo;
        }

        /// <summary>
        /// Abre um arquivo e retorna os bytes contidos nele
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns></returns>
        public static byte[] AbrirEmBytes(string arquivo)
        {
            string caminho = GetCaminho(arquivo);

            if (!File.Exists(caminho))
            {
                throw new IOException("Arquivo não encontrado");
            }

            return File.ReadAllBytes(caminho);
        }

        public static void Gravar(byte[] conteudo, string arquivo)
        {
            string caminho = GetCaminho(arquivo);

            try
            {
                using (FileStream fileStream = new FileStream(caminho, FileMode.Create))
                {
                    fileStream.Write(conteudo, 0, conteudo.Length);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void Gravar(string conteudo, string arquivo)
        {
            byte[] bufferedString = ASCIIEncoding.ASCII.GetBytes(conteudo);
            Gravar(bufferedString, arquivo);
        }

        private static string GetCaminho(string arquivo)
        {
            return Path.Combine(CaminhoPadrao, arquivo);
        }
    }
}
