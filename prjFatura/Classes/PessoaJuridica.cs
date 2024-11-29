using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFatura.Classes
{
    [Serializable]
    public abstract class PessoaJuridica : IComparable<PessoaJuridica>
    {
        public String razaoSocial { get; private set; }
        public String nomeFantasia { get; private set; }
        public String CNPJ { get; private set; }
        public String contato { get; private set; }

        public int CompareTo (PessoaJuridica u)
        {
            return CNPJ.CompareTo(u.CNPJ);
        }

        public PessoaJuridica (String razaoSocial,
                               String nomeFantasia,
                               String CNPJ,
                               String contato)
        {
            this.razaoSocial = razaoSocial;
            this.nomeFantasia = nomeFantasia;
            this.contato = contato;
            this.CNPJ = CNPJ;
        }

    }
}