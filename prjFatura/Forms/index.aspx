<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="index.aspx.cs" 
    Inherits="prjFatura.Forms.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100..900;1,100..900&display=swap" rel="stylesheet">

    <title>Fatura XPTO</title>

    <style>
        body {
            font-family: 'Montserrat', sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            color: #260101;
        }
        
        /* Estilo do Form */
        form {
            max-width: 900px;
            margin: 40px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 4px 10px rgba(0,0,0,0.1);
        }

        h3 {
            color: #BF1725;
            text-align: center;
            font-weight: bold;
        }

        hr {
            border: 1px solid #BF1725;
            margin: 15px 0;
        }

        .form-control, .form-control select, .form-control input {
            width: 100%;
            padding: 12px;
            font-size: 16px;
            border-radius: 5px;
            border: 1px solid #BF8563;
            margin-bottom: 10px;
            box-sizing: border-box;
        }

        .form-control:focus {
            border-color: #8C1111;
            outline: none;
        }

        .btn {
            padding: 10px 15px;
            background-color: #A65F37;
            color: white;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn:hover {
            background-color: #8C1111;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
            background-color: #fff;
            border-radius: 8px;
            overflow: hidden;
        }

        .table th, .table td {
            text-align: center;
            padding: 12px;
            border: 1px solid #BF8563;
            color: #260101;
        }

        .table th {
            background-color: #BF1725;
            color: #fff;
            font-weight: bold;
        }

        .table-striped tbody tr:nth-child(odd) {
            background-color: #f9f9f9;
        }

        .table-hover tbody tr:hover {
            background-color: #f0e2e2;
        }

        .panel {
            margin-top: 20px;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 10px rgba(0,0,0,0.1);
        }

        textarea {
            width: 100%;
            padding: 12px;
            font-size: 16px;
            border-radius: 5px;
            border: 1px solid #BF8563;
            box-sizing: border-box;
            resize: none;
        }

        #mensagem {
            font-size: 18px;
            text-align: center;
            color: #8C1111;
            font-weight: bold;
        }

        select:focus {
          color: #BF8563;
          transition:0s;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h3>Fatura XPTO</h3>

            <hr />

            
            <div style="display: flex; justify-content: space-between; gap: 20px;">
                <div>
                    <label for="comboCliente">Cliente:</label>
                    <asp:DropDownList ID="comboCliente" runat="server" CssClass="form-control" />
                </div>
                <div>
                    <label for="txtNumero">Número:</label>
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" />
                </div>
                <div>
                    <label for="txtVencimento">Vencimento:</label>
                    <asp:TextBox ID="txtVencimento" runat="server" CssClass="form-control" />
                </div>
                <div>
                    <asp:Button ID="btOk" runat="server" Text=" OK " CssClass="btn" OnClick="btOk_Click" />
                </div>
            </div>

            <hr />

            
            <asp:Panel ID="pnFatura" runat="server" Visible="false" CssClass="panel">
                <div>
                    <label>Cliente: </label><asp:Label ID="lbCliente" runat="server" style="font-weight: 700; color:#8C1111;" />
                    <label>No Fatura: </label><asp:Label ID="lbNumeroFatura" runat="server" style="font-weight: 700; color:#8C1111;"/>
                    <label>Vencimento: </label><asp:Label ID="lbVencimento" runat="server" style="font-weight: 700; color:#8C1111;" />
                </div>

                <hr />

                <div>
                    <label for="comboProduto">Produto:</label>
                    <asp:DropDownList ID="comboProduto" runat="server" CssClass="form-control" />

                    <label for="quantidade">Quantidade:</label>
                    <asp:TextBox ID="quantidade" runat="server" CssClass="form-control" />

                    <asp:Button ID="btOkItem" runat="server" Text=" OK " CssClass="btn" OnClick="btOkItem_Click" />
                </div>

                <!-- itens da fatura -->
                <asp:Table ID="tblItensFatura" runat="server" CssClass="table table-striped table-hover table-bordered">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>Produto</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Quantidade</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Preço</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Total</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>

                <hr />

                
                <div style="text-align: right;">
                    Total: <asp:Label ID="lbTotal" runat="server" style="font-weight:800; font-size:1.5rem; color:#8C1111;"/>
                </div>
            </asp:Panel>

            
            <div id="mensagem" style="margin-top: 2rem;">
                <asp:Label ID="mensagem" runat="server" />
            </div>

        </div>
    </form>
</body>
</html>
