using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFatura.Classes
{
    [Serializable]
    public class Emissor : PessoaJuridica
    {
        public String endereco { get; set; }    
        public Emissor (
           String razaoSocial,
           String nomeFantasia,
           String CNPJ,
           String contato,
           String endereco) : base(
               razaoSocial,
               nomeFantasia,
               CNPJ,
               contato)
        {
            this.endereco = endereco;
        }
    }
}