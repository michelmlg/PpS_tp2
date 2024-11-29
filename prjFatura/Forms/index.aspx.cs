using prjFatura.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjFatura.Forms
{
    public partial class index : System.Web.UI.Page
    {
        private static Fatura fatura;

        private static Emissor emissor = 
            new Emissor(
            "Loja do Tio Rangel LTDA",
            "Tio Rangel",
            "234.567.0001/87",
            "Dona Joana", 
            "Rua da casa da mãe Joana No 666");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (comboCliente.Items.Count == 0)
            {
                populaComboCliente(comboCliente);
                populaComboProduto(comboProduto);
            }
        }
        private void populaComboCliente(DropDownList combo)
        {
             

            PopulaCliente p = new PopulaCliente();
            PopulaCliente.clientes.Sort();
            ListItem abre = new ListItem();
            abre.Text = "Selecione Cliente";
            abre.Value = "0";
            combo.Items.Add(abre);

            foreach (Cliente c in PopulaCliente.clientes)
            {
                ListItem item = new ListItem();
                item.Text = c.nomeFantasia;
                item.Value = c.CNPJ;
                combo.Items.Add(item);
            }
        }

        private void populaComboProduto(DropDownList combo)
        {
           

            PopulaProduto p = new PopulaProduto();
            PopulaProduto.produtos.Sort();
            ListItem abre = new ListItem();
            abre.Text = "Selecione Produto";
            abre.Value = "0";
            combo.Items.Add(abre);

            foreach (Produto c in PopulaProduto.produtos)
            {
                ListItem item = new ListItem();
                item.Text = c.nome;
                item.Value = c.sequencial.ToString();
                combo.Items.Add(item);
            }
        }

        protected void btOk_Click(object sender, EventArgs e)
        {
            if (comboCliente.SelectedValue == "0")
            {
                mensagem.Text = "Selecione o cliente";
                return;
            }

            if (txtNumero.Text.Trim().Length < 8)
            {
                mensagem.Text = "Digite o número da Fatura (Oito dígitos)";
                return;
            }

            DateTime dataVencimento;

            if (!DateTime.TryParse(txtVencimento.Text,out dataVencimento))
            {
                mensagem.Text = "Data de vencimento inválida";
                return;
            }

            Cliente busca = new Cliente(comboCliente.SelectedValue);

            int pos = PopulaCliente.clientes.BinarySearch(busca);

            if (pos >= 0)
            {
                fatura = 
                    new Fatura(emissor, 
                    PopulaCliente.clientes[pos],
                    txtNumero.Text, 
                    DateTime.Now, 
                    dataVencimento);

                lbCliente.Text = fatura.cliente.razaoSocial;
                lbNumeroFatura.Text = fatura.numeroDaFatura;
                lbVencimento.Text = fatura.dataVencimento.ToString("dd/MM/yyyy");

                pnFatura.Visible = true;
            } 
            else
            {
                mensagem.Text = "Erro ao criar fatura";
            }
        }

        protected void btOkItem_Click(object sender, EventArgs e)
        {
            PopulaProduto p = new PopulaProduto();
            PopulaProduto.produtos.Sort();

            Produto procura = new Produto(comboProduto.SelectedValue);

            int pos = PopulaProduto.produtos.BinarySearch(procura);
            if (pos >= 0)
            {
                Produto prod = PopulaProduto.produtos[pos];

                int quant;
                if (int.TryParse(quantidade.Text, out quant))
                {
       
                    ItemFatura i = new ItemFatura(prod, quant);
                    fatura.add(i);

                    AtualizarTabelaFatura();

    
                    lbTotal.Text = "R$ " + String.Format("{0:###,###,##0.00}", fatura.totaliza());

                }
                else
                {
                    AtualizarTabelaFatura();
                    mensagem.Text = "Digitação de quantidade inválida!";
                }
            }
            else
            {
                mensagem.Text = "Erro inesperado. Produto não cadastrado!";
            }
        }

        private void AtualizarTabelaFatura()
        {
            tblItensFatura.Rows.Clear();

            if (tblItensFatura.Rows.Count == 0)
            {
                TableHeaderRow headerRow = new TableHeaderRow();
                headerRow.Cells.Add(new TableHeaderCell() { Text = "Produto" });
                headerRow.Cells.Add(new TableHeaderCell() { Text = "Quantidade" });
                headerRow.Cells.Add(new TableHeaderCell() { Text = "Preço" });
                headerRow.Cells.Add(new TableHeaderCell() { Text = "Total" });
                tblItensFatura.Rows.Add(headerRow);
            }

            foreach (ItemFatura item in fatura.itens)
            {
                TableRow row = new TableRow();

                TableCell cellProduto = new TableCell { Text = item.produto.nome }; 
                TableCell cellQuantidade = new TableCell { Text = item.quantidade.ToString() };
                TableCell cellPreco = new TableCell { Text = item.produto.preco.ToString("C") };
                TableCell cellTotal = new TableCell { Text = (item.quantidade * item.produto.preco).ToString("C") };

                row.Cells.Add(cellProduto);
                row.Cells.Add(cellQuantidade);
                row.Cells.Add(cellPreco);
                row.Cells.Add(cellTotal);

                tblItensFatura.Rows.Add(row);
            }
        }


        // Função de evento da tabela antiga
        //protected void btOkItem_Click(object sender, EventArgs e)
        //{
        //    PopulaProduto p = new PopulaProduto();
        //    PopulaProduto.produtos.Sort();

        //    Produto procura = new Produto(comboProduto.SelectedValue);

        //    int pos = PopulaProduto.produtos.BinarySearch(procura);
        //    if (pos >= 0)
        //    {
        //        Produto prod = PopulaProduto.produtos[pos];

        //        int quant;
        //        if (int.TryParse(quantidade.Text, out quant))
        //        {
        //            ItemFatura i = new ItemFatura(prod, quant);
        //            fatura.add(i);

        //            StringBuilder str = new StringBuilder();

        //            foreach (ItemFatura item in fatura.itens)
        //            {
        //                str.AppendLine(item.ToString());
        //            }

        //            relatorio.Text = str.ToString();

        //            lbTotal.Text = String.Format("{0:###,###,##0.00}", 
        //                fatura.totaliza());
        //        } else
        //        {
        //            mensagem.Text = "Digitação de quantidade inválida!";
        //        }
        //    } else
        //    {
        //        mensagem.Text = "Erro inesperado. Produto não cadastrado!";
        //    }

        //}
    }
}


