using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjFatura.Classes
{
    [Serializable]
    public class Produto : IComparable<Produto>   
    {
        // TP de 11/10/2024
        // 1. Instanciar um fornecedor
        // 2. Criar uma classe clamada PopulaProduto
        // 3. Instanciar pelo menos 6 produtos (pense  numa loja de produtos de higiene)
        //    Não esquecer de colocar o estoque do produto. (chuta alto)
        //    Considere o mesmo fornecedor para todos os produtos
        // 3. Copie e cole o fonte da classe PopulaProduto no corpo do email e enviar para:
        //    halrangel@yahoo.com.br, Assunto: POPULA-PRODUTO - Nome do aluno

        public String codigoFornecedor { get; }
        public String nome { get; }
        public float preco { get; set; }
        public Fornecedor fornecedor { get; }
        public int estoque { get; set; }

        private static int contador = 0;
        public int sequencial { get; }


        public int CompareTo(Produto outro)
        {
            return sequencial.CompareTo(outro.sequencial);
        }

        public Produto(String sequencial)
        {
            int seq;
            int.TryParse(sequencial, out seq);
            this.sequencial = seq;
        }
        public Produto(
            string codigoFornecedor, 
            string nome, 
            float preco, 
            Fornecedor fornecedor)
        {
            this.codigoFornecedor = codigoFornecedor;
            this.nome = nome;
            this.preco = preco;
            this.fornecedor = fornecedor;
            sequencial = ++contador;
        }
    }  
}