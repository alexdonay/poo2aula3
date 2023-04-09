using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula2
{
    public class ProdutoAlimentar : Produto
    {
        public Data  dataValidade;
        public ProdutoAlimentar(int codigo, Data dataValidade, double valor, string descricao):base(codigo,descricao,valor) { 
        
            this.dataValidade = dataValidade;
        
        }
        public override string ToString()
        {
            return  $"Cód: {Codigo} Desc: {Descricao} Valor: {Valor} Validade: {dataValidade.ToString()}" ;
        }
    }
    
}
