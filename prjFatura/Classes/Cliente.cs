using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFatura.Classes
{
    [Serializable]
    public class Cliente : PessoaJuridica, IComparable<Cliente>
    {
        public String responsavel { get; set; }
        public float limiteDeCredito { get; set; }
        public int CompareTo(Cliente c)
        {
            return CNPJ.CompareTo(c.CNPJ);
        }
        public Cliente(
            String razaoSocial, 
            String nomeFantasia,
            String CNPJ, 
            String contato) : base (
                razaoSocial,
                nomeFantasia,
                CNPJ, 
                contato)
            {
            } 
        
        // construtor para busca BinarySearch()
        public Cliente (String cnpj) : base("", "", cnpj, "")
        {
           //
        }

        public override string ToString()
        {
            return razaoSocial + ", " + Utilitarios.formataCnpj(CNPJ);
        }

    }
}