using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFatura.Classes
{
    [Serializable]
    public class Fornecedor : PessoaJuridica, IComparable<Fornecedor>
    {
        public List<Produto> produtos;
        public Fornecedor(
            String razaoSocial,
            String nomeFantasia,
            String CNPJ,
            String contato) : base(
                razaoSocial,
                nomeFantasia,
                CNPJ,
                contato)
        {
            produtos = new List<Produto>();
        }

        public int CompareTo(Fornecedor f)
        {
            return CNPJ.CompareTo(f.CNPJ);
        }

        public void add(Produto produto)
        {
           produtos.Add(produto);
        }



    }
}