using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFatura.Classes
{
    public class PopulaProduto
    { 
        public static List<Produto> produtos = new List<Produto>();
        public PopulaProduto()
        {
            PopulaFornecedor p = new PopulaFornecedor();

            Produto []prod = new Produto[6];

            prod[0] = new Produto("P1023", "Creme Hidratante Ultra", 15.20F, PopulaFornecedor.fornecedores[0]);
            prod[0].estoque = 1800;

            prod[1] = new Produto("P2345", "Desodorante Floral", 7.45F, PopulaFornecedor.fornecedores[1]);
            prod[1].estoque = 1200;

            prod[2] = new Produto("P6789", "Água Sanitária Ultra", 2.15F, PopulaFornecedor.fornecedores[2]);
            prod[2].estoque = 2200;

            prod[3] = new Produto("P1123", "Kit de Escova de Dentes", 9.90F, PopulaFornecedor.fornecedores[3]);
            prod[3].estoque = 2000;

            prod[4] = new Produto("P5678", "Perfume Encanto Floral", 25.50F, PopulaFornecedor.fornecedores[4]);
            prod[4].estoque = 800;

            prod[5] = new Produto("P3412", "Escova de Cabelos Profissional", 19.99F, PopulaFornecedor.fornecedores[5]);
            prod[5].estoque = 1400;


            foreach (Produto produto in prod)
            {
                produtos.Add(produto);
            }          

        }
        
    }
}