using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula2
{
   sealed class BancoDados
    {
        private static BancoDados _instance;
        public  List<Produto> Produtos = new List<Produto>();
        public List<Pedido> Pedido = new List<Pedido>();
        public List<ProdutoAlimentar> ProdutosAlimentares = new List<ProdutoAlimentar>();
        public List<ProdutoDigital> ProdutosDigitais = new List<ProdutoDigital>();

        public void adiconarProdutoDigital(ProdutoDigital produto)
        {
            ProdutosDigitais.Add(produto);
        }

        public void adicionarProdutoAlimentar(ProdutoAlimentar produto)
        {
            ProdutosAlimentares.Add(produto);
        }
        public void editarItemPedido(int codPedido, int codProduto, int quantidade)
        {
            Pedido pedidos = Pedido.Find(x => x.Codigo== codPedido);
            ItemPedido item = pedidos.ItemPedidos.Find(x => x.Produto.Codigo== codProduto);
            item.Quantidade= quantidade;
        }

        public void RemoveProdutoPedido(int codPedido, int codProduto)
        {
            Pedido pedido = Pedido.FirstOrDefault(p => p.Codigo == codPedido);
            ItemPedido item = pedido.ItemPedidos.Find(x => x.Produto.Codigo== codProduto);
            pedido.ItemPedidos.Remove(item);



        }
        public void AdicionaPedido(Pedido pedido)
        {
            this.Pedido.Add(pedido);
        }
        public void IncluirProduto(Produto produto)
        {
            
            this.Produtos.Add(produto);
                     
        }
        public bool ExcluirProduto(int codigo)
        {
            Produto produto = this.Produtos.Find(p => p.Codigo == codigo);
            if (produto != null)
            {
                this.Produtos.Remove(produto);
                return true;
            }
            return false;
        }
        public bool EditarProduto(int codigo, string novaDescricao, double novoValor)
        {
            Produto produto = this.Produtos.Find(p => p.Codigo == codigo);
            if (produto != null)
            {
                if(novaDescricao != "")
                {
                    produto.Descricao = novaDescricao;
                }
                if(novoValor!= 0)
                {
                    produto.Valor = novoValor;
                }
                
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
        public static BancoDados getInstance()
        {
            if (_instance == null)

            {
                _instance = new BancoDados();
            }
            return _instance;
        }
        public void OrdenarProdutos()
        {
            Produtos = Produtos.OrderBy(x => x.Descricao).ToList();
        }
    }
    
}
