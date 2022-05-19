using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiceRemissivoApp
{
    public class ParPalavraContador
    {
        public string Palavra { get; set; }
        public int Contador { get; set; }
        public List<int> Linhas { get; set; }

        public ParPalavraContador()
        {
            Linhas = new List<int>();
        }
    }

    public class IndiceRemissivo
    {
        private string pathtxt;
        public string PathTXT { get { return pathtxt; } }

        private string pathignore;
        public string PathIgnore { get { return pathignore; } }

        public List<string> Texto { get; set; }
        public List<string> Ignore { get; set; }

        public List<ParPalavraContador> PalavrasContador { get; set; }

        public IndiceRemissivo()
        {
            PalavrasContador = new List<ParPalavraContador>();
            Texto = new List<string>();
            Ignore = new List<string>();
        }

        public IndiceRemissivo(string _pathTXT, string _pathIgnore)
        {
            PalavrasContador = new List<ParPalavraContador>();
            Texto = new List<string>();
            Ignore = new List<string>();

            this.pathtxt = _pathTXT;
            this.pathignore = _pathIgnore;

            StreamReader sr;

            sr = File.OpenText(this.pathtxt);
            while (sr.EndOfStream != true)
            {
                string linha = sr.ReadLine();
                Texto.Add(linha);
            }
            //
            if (!string.IsNullOrEmpty(_pathIgnore))
            {
                sr = File.OpenText(this.pathignore);
                while (sr.EndOfStream != true)
                {
                    string linha = sr.ReadLine();
                    Ignore.Add(linha);
                }
            }

        }

        private void TotalizarPalavras()
        {
            PalavrasContador = new List<ParPalavraContador>();

            foreach (string linha in Texto)
            {
                string texto = new string(linha.Where(c => !char.IsPunctuation(c)).ToArray());
                string[] palavras = texto.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                int totalPalavrasUsadas = 0;

                //
                for (int i = 0; i < palavras.Length; i++)
                {
                    bool encontrou = false;
                    foreach (ParPalavraContador pc in PalavrasContador)
                    {
                        if (pc.Palavra.Equals(palavras[i]))
                        {
                            encontrou = true;
                            pc.Contador++;
                            break;
                        }
                    }
                    if (!encontrou)
                    {
                        if (Ignore.Where(c => c.ToLower().Equals(palavras[i].ToLower())).Count() == 0)
                        {
                            PalavrasContador.Add(new ParPalavraContador()
                            {
                                Palavra = palavras[i],
                                Contador = 1
                            });
                            totalPalavrasUsadas++;
                        }
                    }
                }

            }

            foreach (ParPalavraContador pc in PalavrasContador)
            {
                ContarLinhasPalavra(pc);
            }
        }

        private void ContarLinhasPalavra(ParPalavraContador pc)
        {
            pc.Linhas = new List<int>();
            int pos = 1;
            foreach (string linha in Texto)
            {
                if (linha.IndexOf(pc.Palavra) > -1)
                {
                    pc.Linhas.Add(pos);
                }
                pos++;
            }
        }

        public void Imprime()
        {

            Console.WriteLine("Indice Remissivo");

            TotalizarPalavras();

            Console.WriteLine();

            foreach (ParPalavraContador palavraContador in PalavrasContador)
                if (palavraContador != null && palavraContador.Contador > 1)
                {
                    Console.Write(String.Format("{0} ({1}) ", palavraContador.Palavra.ToUpper(), palavraContador.Contador));
                    foreach (int linha in palavraContador.Linhas)
                    {
                        Console.Write(String.Format(", {0}", linha));
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }


            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
