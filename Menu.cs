using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


//media
//aumentar em xx os produtos acima da media
//ordenar pela descrição
//listar os produtos que estão abaixo da média

namespace Aula2
{
    public class Menu
    {
        Produto produto;
        BancoDados bd = BancoDados.getInstance();
        Leitor leitor = new Leitor();
        private void Opcoes()
        {
            
            Console.WriteLine("1- Inserir dados");
            Console.WriteLine("2 - Escrever dados");
            Console.WriteLine("3 - Calcula média");
            Console.WriteLine("4 - Aumenta os produtos abaixo da média");
            Console.WriteLine("5 - Lista pela descrição");
            Console.WriteLine("6 - Listar os produtos que estão abaixo da média");
            Console.WriteLine("7 - Excluir produto pelo código");
            Console.WriteLine("8 - Editar Produto");
            Console.WriteLine("9 - Cadastrar Pedido");
            Console.WriteLine("10 - Listar Pedidos");
            Console.WriteLine("11 - Excluir produto do Pedido");
            Console.WriteLine("12 - Editar produto");
            Console.WriteLine("13 - Editar quantidade de produto no pedido");
            Console.WriteLine("14 - Cadastrar Produto Alimentar");
            Console.WriteLine("15 - Cadastrar Produto Digital");
            Console.WriteLine("0 - Sair");
        }
        public void MenuOpcoes()
        {
            int opc = 0;
            Opcoes();
            opc = leitor.Inteiro("Informe a sua opção");
            
            while(opc != 0 )
            {
                Console.Clear();
                switch(opc)
                {
                    case 1:
                        pedeDados();
                        Console.Clear();
                        break;
                    
                    case 2:
                        escreveDados();
                        limparConsole();
                        break;
                    
                    case 3:
                        Console.WriteLine($"A média é {calculaMedia()}");
                        limparConsole();
                        break;

                    case 4:
                        double valorAjuste;
                        valorAjuste = leitor.PontoFlutuante("Digite o valor a ser ajustada");
                        abaixoMedia(valorAjuste);
                        break;
                    
                    case 5:
                        bd.OrdenarProdutos();
                        foreach(Produto produto in bd.Produtos)
                        {
                            Console.WriteLine(produto.ToString());
                        }
                        limparConsole();
                        break;

                    case 6:
                        foreach(Produto produto in produtosAcimaMedia())
                        {
                            Console.WriteLine(produto.ToString());
                        }
                        limparConsole();
                        break;
                    case 7:
                        int codigo = leitor.Inteiro("Digite o código do produto para excluir");
                        if(bd.ExcluirProduto(codigo) == true)
                        {
                            Console.WriteLine("Dados excluídos com sucesso");
                        }
                        else
                        {
                            Console.WriteLine("Produto não encontrado");
                        }
                        limparConsole();
                        break;
                    case 8:
                        codigo = leitor.Inteiro("Digite o código do produto para editar");
                        string descricao = leitor.Caracteres("Digite a descricao a ser alterada");
                        double valor = leitor.PontoFlutuante("Digite o novo valor");
                        if (bd.EditarProduto(codigo, descricao, valor) == true)
                        {
                            Console.WriteLine("Dados alterados com sucesso");
                        }
                        else
                        {
                            Console.WriteLine("Produto não encontrado");
                        }
                        limparConsole();
                        break;

                    case 9:
                        codigo = leitor.Inteiro("Digite o código do pedido");
                        Pedido pedido = new Pedido(codigo);


                        int codProduto = 1;
                        int quantidade = 1;
                        int tipoProduto = 1;

                        
                        
                        while (true)
                        {

                            tipoProduto  = leitor.Inteiro("Digite 1 para incluir um produto, 2 para incluir um produto digital. 3, para incluir um produto alimentar");
                            codProduto = 0;
                            ItemPedido itemPedido;
                            switch (tipoProduto)
                            {
                                case 1:
                                    while (bd.Produtos.Find(x => x.Codigo == codProduto) == null)
                                    {
                                        codProduto = leitor.Inteiro("Digite o codigo do produto para incluir no pedido");
                                    }
                                    quantidade = leitor.Inteiro("Digite a quantidade do produto para incluir");
                                    Produto produto = bd.Produtos.Find(x => x.Codigo == codProduto);
                                    itemPedido = new ItemPedido(quantidade, produto);

                                    pedido.AddProduto(itemPedido);
                                    break;
                                case 2:
                                    while (bd.ProdutosDigitais.Find(x => x.Codigo == codProduto) == null)
                                    {
                                        codProduto = leitor.Inteiro("Digite o codigo do produto para incluir no pedido");
                                    }
                                    quantidade = leitor.Inteiro("Digite a quantidade do produto para incluir");
                                    ProdutoDigital produtoDigital2 = bd.ProdutosDigitais.Find(x => x.Codigo == codProduto);
                                    itemPedido = new ItemPedido(quantidade,produtoDigital2);
                                    pedido.AddProduto(itemPedido);
                                    break;
                                    
                                
                                case 3:
                                    while (bd.ProdutosAlimentares.Find(x => x.Codigo == codProduto) == null)
                                    {
                                        codProduto = leitor.Inteiro("Digite o codigo do produto para incluir no pedido");
                                    }
                                    quantidade = leitor.Inteiro("Digite a quantidade do produto para incluir");
                                    ProdutoAlimentar produtoAlimentar = bd.ProdutosAlimentares.Find(x => x.Codigo == codProduto);
                                    itemPedido = new ItemPedido(quantidade, produtoAlimentar);
                                    pedido.AddProduto(itemPedido);
                                    break;

                                default:
                                    Console.WriteLine("Valor inválido");
                                    break;
                            }

                            
                            

                            limparConsole();
                            string sair = leitor.Caracteres("Digite qualquer tecla para continuar ou S para sair");
                            if(sair == "S")
                            {
                                break;
                            }

                        }
                        bd.AdicionaPedido(pedido);
                        limparConsole();
                        break;
                        case 10:
                        double totalPedido = 0;
                            foreach(Pedido p in bd.Pedido)
                            {
                                Console.WriteLine("Codigo do pedido " + p.Codigo);
                            
                            
                                foreach(ItemPedido i in p.ItemPedidos)
                                {
                                    totalPedido += i.TotalProduto;
                                    Console.WriteLine(i.ToString());
                                }
                                Console.WriteLine("Total do pedido:  " + totalPedido);
                            totalPedido = 0;
                        }

                        limparConsole();
                        break;
                        case 11:
                            codigo = leitor.Inteiro("Digite o código do pedido");
                            codProduto = leitor.Inteiro("Digite o código do item");
                            if (bd.Pedido.Find(x=>x.Codigo == codigo) == null)
                            {
                                Console.WriteLine("Pedio inválido, tente novamente");
                            }
                            else
                            {
                                Pedido ped = bd.Pedido.Find(x => x.Codigo == codigo);
                                if(ped.ItemPedidos.Find(x => x.Produto.Codigo == codProduto)==null)
                                {
                                    Console.WriteLine("Produto não encontrado");
                                }
                                else
                                {
                                  bd.RemoveProdutoPedido(codigo, codProduto);
                                }
                            }
                        
                        break;
                    case 12:
                        while (true)
                        {
                            codProduto = leitor.Inteiro("Digite o código do produto para editar");
                            if(bd.Produtos.Find(x=> x.Codigo == codProduto) != null)
                            {
                                break;
                            }
                        }
                        
                        descricao = leitor.Caracteres("Digite a nova descricao ou enter para continuar");
                        valor = leitor.Inteiro("Digite o valor ou 0 para continuar");
                        if(descricao == "")
                        {
                            descricao = bd.Produtos.Find(x => x.Codigo == codProduto).Descricao;
                        }
                        if(valor == 0)
                        {
                            valor = bd.Produtos.Find(x => x.Codigo == codProduto).Valor;
                        }
                        bd.EditarProduto(codProduto,descricao,valor);
                        limparConsole();
                        break;
                    case 13:
                        int codigoPedido;
                        int codigoProduto;
                        while (true)
                        {
                            codigoPedido = leitor.Inteiro("Digite o codigo do pedido");
                            if (bd.Pedido.Find(x => x.Codigo == codigoPedido) != null)
                            {
                                break;
                            }
                        }
                        pedido = bd.Pedido.Find(x => x.Codigo == codigoPedido);
                        while (true)
                        {
                            codigoProduto = leitor.Inteiro("digite o código do produto");
                            if(pedido.ItemPedidos.Find(x=> x.Produto.Codigo == codigoProduto) != null)
                            {
                                break;
                            }
                        }
                        quantidade = leitor.Inteiro("Digite a quantidade");
                        bd.editarItemPedido(codigoPedido, codigoProduto, quantidade);
                        limparConsole();
                        break;
                    case 14:
                        codigo = leitor.Inteiro("Digite o codigo do produto");
                        descricao = leitor.Caracteres("Digite uma descricao para o produto");
                        double valorProduto = leitor.PontoFlutuante("Digite o valor do produto");
                        Data data;
                        while (true)
                        {
                            string validade = leitor.Caracteres("Digite a validade do produto (dd/mm/aaaa");
                            string[] datavalidade = validade.Split('/');
                            int dia = int.Parse(datavalidade[0]);
                            int mes = int.Parse(datavalidade[1]);
                            int ano = int.Parse(datavalidade[2]);
                            data = new Data(dia, mes, ano);
                            if(data.DataValida() == true)
                            {
                                break;
                            }
                            Console.WriteLine("Digite uma data valida");
                        }
                        ProdutoAlimentar alimentar = new ProdutoAlimentar(codigo, data, valorProduto, descricao);
                        bd.adicionarProdutoAlimentar(alimentar);

                         limparConsole();
                        break;
                    

                    case 15:
                        codigo = leitor.Inteiro("Digite o código do produto:");
                        string nome = leitor.Caracteres("Digite o nome do produto:");
                        double preco = leitor.PontoFlutuante("Digite o preço do produto:");
                        int tamanhoArquivo = leitor.Inteiro("Digite o tamanho do arquivo:");
                        string versaoProduto = leitor.Caracteres("Digite a versão do produto:");

                        ProdutoDigital produtoDigital = new ProdutoDigital(codigo, nome, preco, tamanhoArquivo, versaoProduto);
                        bd.adiconarProdutoDigital(produtoDigital);

                        limparConsole();
                        break;
                    case 16:
                        int codPedido = 0;
                        //finaliza pedido
                        while (true)
                        {
                            codPedido = leitor.Inteiro("Digite o código do Pedido");
                            if(bd.Pedido.Find(x=>x.Codigo == codPedido) != null)
                            {
                                break;
                            }
                            
                        }
                        pedido = bd.Pedido.Find(x => x.Codigo == codPedido);
                        foreach (ItemPedido ped in pedido.ItemPedidos)
                        {
                            Console.WriteLine(ped.ToString());
                        }
                        limparConsole();
                        break;
                    default: 
                        Console.WriteLine("Opção inválida");
                        break;
                }
                Opcoes();
                
                opc = leitor.Inteiro("informe sua opcao");
            }
        }
        private void limparConsole()

        {
            Console.WriteLine("Digite algo para continuar");
            Console.ReadKey();
            Console.Clear();
        }
        private void pedeDados()
        {
            produto = new Produto();
            produto.Codigo = leitor.Inteiro("Digite o código do ítem");
            produto.Descricao = leitor.Caracteres("Digite a descrição");
            produto.Valor = leitor.Inteiro("Digite o valor do produto");
            bd.IncluirProduto(produto);
        }
        private void escreveDados()
        {
            foreach (Produto produtos in bd.Produtos)
            {
                Console.WriteLine(produtos.ToString());
            }
            foreach(ProdutoAlimentar produtoAlmentar in bd.ProdutosAlimentares)
            {
                Console.WriteLine(produtoAlmentar.ToString());
            }
            foreach (ProdutoDigital produtoDigital in bd.ProdutosDigitais)
            {
                Console.WriteLine(produtoDigital.ToString());
            }
        }
        private double calculaMedia()
        {
            int count = 0;
            double soma = 0;
            double media = 0;
            foreach(Produto produtos in bd.Produtos)
            {
                count ++;
                soma += produtos.Valor;
                media = (double) soma / count;

            }
            return media;
        }
        private void abaixoMedia(double percentual)
        {
            double media = calculaMedia();
            foreach (Produto produtos in bd.Produtos)
            {
             if(produtos.Valor<media)
                {
                    produtos.Reajuste(percentual);
                }
             
            }

        }
        private List<Produto> produtosAcimaMedia()
        {
            List<Produto> produtosAcima = new List<Produto>();
            foreach(Produto produtos in bd.Produtos)
            {
                if (produtos.Valor < calculaMedia())
                {
                    
                    produtosAcima.Add(produtos);
                }
            }
            return produtosAcima;
        } 

    }
}
