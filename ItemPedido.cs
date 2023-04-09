using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula2
{
    public class ItemPedido
    {
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
        public ProdutoDigital ProdutoDigital { get; set; }
        public ProdutoAlimentar ProdutoAlimentar { get; set; }

        public double TotalProduto
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.Valor * this.Quantidade;
                }
                if (this.ProdutoDigital != null)
                {
                    return this.ProdutoDigital.Valor * this.Quantidade;
                }
                if (this.ProdutoAlimentar != null)
                {
                    int Datadif = ProdutoAlimentar.dataValidade.DiferencaDias();
                    Console.WriteLine(Datadif);
                    if (Datadif > 0 && Datadif <= 3)
                    {
                        return (this.ProdutoAlimentar.Valor * this.Quantidade) * 0.70f;
                    }
                    else if (Datadif > 3)
                    {
                        return this.ProdutoAlimentar.Valor * this.Quantidade;
                    }
                    else 
                    {
                        return 0;
                    }
                }
                return 0;
            }






        public ItemPedido(int quantidade, Produto produto)
        {
            this.Produto = produto;
            this.Quantidade = quantidade;
        }
        public ItemPedido(int quantidade, ProdutoDigital produto)
        {
            this.ProdutoDigital = produto;
            this.Quantidade = quantidade;
        }
        public ItemPedido(int quantidade, ProdutoAlimentar produto)
        {
            this.ProdutoAlimentar = produto;
            this.Quantidade = quantidade;

        }
        public ItemPedido()
        {

        }

        public override string ToString()
        {
            if (this.Produto != null)
            {
                return ("produto codigo - " + this.Produto.Codigo + " Descricao " + this.Produto.Descricao + " Quantidade " + this.Quantidade + " total " + this.TotalProduto);
            }
            if (this.ProdutoAlimentar != null)
            {
               return ("produto codigo - " + this.ProdutoAlimentar.Codigo + " Descricao " + this.ProdutoAlimentar.Descricao + " Quantidade " + this.Quantidade + " Validade " + this.ProdutoAlimentar.dataValidade.ToString() + "Total: " + this.TotalProduto);
            }
            if (this.ProdutoDigital != null)
            {
                return ("produto codigo - " + this.ProdutoDigital.Codigo + " Descricao " + this.ProdutoDigital.Descricao + " Quantidade " + this.Quantidade + " total " + this.TotalProduto);
            }
            return "Produto inexistente";
        }
    }
}
