using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFatura.Classes
{
    public class PopulaCliente
    {
        public static List<Cliente> clientes = new List<Cliente>();

        public void add(Cliente cliente)
        {
            clientes.Add(cliente);
        }
        public PopulaCliente()
        {
            Cliente c1 = new Cliente("Supermercado Central", "Central Market", "19.765.432/1001-11", "Lucas Ribeiro");
            c1.limiteDeCredito = 12000F;
            c1.responsavel = c1.contato;
            add(c1);

            c1 = new Cliente("Eletrônicos do Bairro", "Bairro Eletrônico", "14.234.876/3401-22", "Juliana Costa");
            c1.limiteDeCredito = 5000F;
            c1.responsavel = c1.contato;
            add(c1);

            c1 = new Cliente("Lojas Estrela Dourada", "Estrela Dourada", "15.876.432/0111-33", "Marcos Pereira");
            c1.limiteDeCredito = 7000F;
            c1.responsavel = "Sandra Silva";
            add(c1);

            c1 = new Cliente("Mercado Verde e Cia", "Mercadinho Verde", "13.245.987/5001-99", "Fernanda Lima");
            c1.limiteDeCredito = 3000F;
            c1.responsavel = "Carlos Souza";
            add(c1);

            c1 = new Cliente("Relojoaria São Paulo", "Relógios SP", "18.654.321/1201-88", "Ricardo Martins");
            c1.limiteDeCredito = 8000F;
            c1.responsavel = "Eliana Rocha";
            add(c1);


            clientes.Sort();
        }


    }
}