using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace prjFatura.Classes
{
    [Serializable]
    public class ItemFatura : IComparable<ItemFatura>
    {
      

        private static int contador = 0;
        public int sequencial { get; }
        public Produto produto { get; }
        public int quantidade { get; }
        public bool stCancelado { get; set; }
        public ItemFatura(Produto produto, int quantidade)
        {
            this.produto = produto; 
            this.quantidade = quantidade;
            sequencial = ++contador;
            stCancelado = false; 
            
            if (produto.estoque - quantidade < 0)
            {
                throw new Exception("Estoque do produto insuficiente! (" + 
                    produto.ToString() + ")");
            }

        }
        public int CompareTo(ItemFatura outro)
        {
            return sequencial.CompareTo(outro.sequencial);
        }

        public override String ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append(sequencial);
            str.Append('\t');
            str.Append(produto.codigoFornecedor) ;
            str.Append('\t');
            str.Append(produto.nome);
            str.Append('\t');
            str.Append(produto.preco);
            str.Append('\t');
            str.Append(quantidade);
            str.Append('\t');
            str.Append(produto.preco * quantidade);

            return str.ToString();
        }
    }
}