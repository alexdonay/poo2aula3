using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula2
{
    public class Pedido
    {
        public int Codigo { get; set; }
        public List<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();

        public void AddProduto(ItemPedido item)
        {
            ItemPedidos.Add(item);
        }
        public Pedido(int codigo)
        {
            this.Codigo = codigo;
        }
    }

}
