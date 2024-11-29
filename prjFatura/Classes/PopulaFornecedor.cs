using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFatura.Classes
{
    public class PopulaFornecedor
    {
        public static List<Fornecedor> fornecedores = new List<Fornecedor>();

        public PopulaFornecedor()
        {
            Fornecedor[] f = new Fornecedor[6];

            f[0] = new Fornecedor("Nova Cosméticos S/A", "Cosméticos Nova", "19.243.487/1001-11", "Beatriz Martins");
            f[1] = new Fornecedor("Aromas do Vale", "Aromas do Vale", "28.783.634/0002-32", "Ricardo Alves");
            f[2] = new Fornecedor("Limpadora Brasileira", "Limpadora Brasil", "43.234.821/0001-75", "Luciana Costa");
            f[3] = new Fornecedor("Higiexpert", "Higiexpert", "14.432.978/0291-56", "Carlos Henrique");
            f[4] = new Fornecedor("Perfumaria Encanto", "Encanto Perfumaria", "32.978.546/0001-43", "Juliana Ferreira");
            f[5] = new Fornecedor("Higiene Total", "Higiene Total LTDA", "36.123.657/0601-98", "Fábio Rocha");


            foreach (Fornecedor fo in f)
            {
                fornecedores.Add(fo);   
            }
        }         
    }
}