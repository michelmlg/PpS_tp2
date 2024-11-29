using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFatura.Classes
{
    [Serializable]
    public class Fatura : IComparable<Fatura>
    {
        public Emissor emissor { get; set; }  
        public Cliente cliente { get; set; }
        public String numeroDaFatura { get; set; }
        public DateTime dataFaturamento { get; set; }
        public DateTime dataVencimento { get; set; }

        public List<ItemFatura> itens;

        public int CompareTo(Fatura u)
        {
            return numeroDaFatura.CompareTo(u.numeroDaFatura);
        }

        public float totaliza()
        {
            float total = 0;
            foreach (ItemFatura item in itens)
            {
                total += item.produto.preco * item.quantidade;
            }
            return total;   
        }

        public void add(ItemFatura item)
        {
            itens.Add(item);
        }
        public Fatura(Emissor emissor,
                      Cliente cliente,
                      String numeroDaFatura,
                      DateTime dataFaturamento,
                      DateTime dataVencimento)
        {
            this.emissor = emissor;
            this.numeroDaFatura = numeroDaFatura;
            this.dataVencimento = dataVencimento;
            this.dataFaturamento = dataFaturamento;
            this.cliente = cliente;
            this.itens = new List<ItemFatura>();           
        }        
    }
}