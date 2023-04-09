using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aula2
{
    public class ProdutoDigital : Produto
    {
        public int TamanhoArquivo { get; set; }
        public string VersaoProduto { get; set; }

        public ProdutoDigital(int codigo, string descricao, double valor, int tamanhoArquivo, string versaoProduto):base(codigo,descricao, valor)
        {
            TamanhoArquivo = tamanhoArquivo;
            VersaoProduto = versaoProduto;
        }
        public override string ToString()
        {
            return $"{base.ToString()} - Tamanho do arquivo: {TamanhoArquivo} - Versão do produto: {VersaoProduto}";
        }
    }
}