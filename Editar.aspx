<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Fitcard_Teste.site.Editar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <div class="jumbotron">
        <button type="button" id="btnVoltar" class="btn btn-success btn-lg" style="margin-left: 200px;" onclick="voltar()">
            <i class="glyphicon glyphicon-step-backward
"></i>Voltar</button>
        <h1 class="text-center">EDITAR</h1>
        <div class="container">
            <form id="form1" runat="server">
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label for="txbRazaoSocial">Razão Social</label>
                        <asp:TextBox ID="txbRazaoSocial" runat="server" class="form-control" placeholder="Razão Social"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txbNome">Nome Fantasia</label>
                        <asp:TextBox ID="txbNome" runat="server" class="form-control" placeholder="Nome Fantasia"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txbCnpj">CNPJ</label>
                        <asp:TextBox ID="txbCnpj" runat="server" class="form-control" placeholder="CNPJ"></asp:TextBox>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label for="txbEmail">Email</label>
                        <asp:TextBox ID="txbEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txbEndereco">Endereço</label>
                        <asp:TextBox ID="txbEndereco" runat="server" class="form-control" placeholder="Endereço"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txbCidade">Cidade</label>
                        <asp:TextBox ID="txbCidade" runat="server" class="form-control" placeholder="Cidade"></asp:TextBox>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label for="txbEstado">Estado</label>
                        <asp:TextBox ID="txbEstado" runat="server" class="form-control" placeholder="Estado"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txbTelefone">Telefone</label>
                        <asp:TextBox ID="txbTelefone" runat="server" class="form-control" placeholder="Telefone" onchange="validar()"></asp:TextBox>
                        <span id="erroTelefone" runat="server" style="color:red; font-size:12px; font-family:Arial"></span>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="txbDataCadastro">Data de Cadastro</label>
                        <asp:TextBox ID="txbDataCadastro" runat="server" class="form-control" placeholder="Data"></asp:TextBox>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-3">
                        <label for="ddlCategoria">Categoria</label>
                        <asp:DropDownList ID="ddlCategoria" runat="server" class="form-control" placeholder="Razão Social" onchange="validar()">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="ddlStatus">Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" class="form-control" placeholder="Status">
                        </asp:DropDownList>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <label for="txbAgencia">Agência</label>
                            <asp:TextBox ID="txbAgencia" runat="server" class="form-control" placeholder="Agência"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3">
                            <label for="txbConta">Conta</label>
                            <asp:TextBox ID="txbConta" runat="server" class="form-control" placeholder="Conta"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <div class="form-group col-lg-12">
                        <asp:Button ID="btnEditar" runat="server" class="btn btn-primary" OnClick="btnEditar_Click" Text="Salvar" />
                    </div>
                </div>
            </form>
            <div class="modal" tabindex="-1" role="dialog" id="cadastroSucesso" runat="server" style="display: none;">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">CADASTRO</h5>
                        </div>
                        <div class="modal-body">
                            <p>Registro alterado com Sucesso.</p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-success" data-dismiss="modal" onclick="document.getElementById('cadastroSucesso').style.display = 'none'; window.location.href = '/listar';">OK</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
<script src="/Scripts/jquery-3.3.1.js"></script>
<script src="/Scripts/jquery-3.3.1.min.js"></script>
<script src="/Scripts/jquery.mask.js"></script>

<script>
    $("#txbCnpj").keydown(function () {
        try {
            $("#txbCnpj").unmask();
        } catch (e) { }

        $("#txbCnpj").mask("99.999.999/9999-99");
        // ajustando foco
        var elem = this;
        setTimeout(function () {
            // mudo a posição do seletor
            elem.selectionStart = elem.selectionEnd = 10000;
        }, 0);
        // reaplico o valor para mudar o foco
        var currentValue = $(this).val();
        $(this).val('');
        $(this).val(currentValue);
    });
    
    $("#txbDataCadastro").mask("##/##/####");
    $("#txbAgencia").mask("999-9");
    $("#txbConta").mask("99.999-9");
    $("#txbTelefone").mask("(99)99999-9999");

    function voltar() {
        history.go(-1);
    }

    function validar() {
        var categoria = document.getElementById('ddlCategoria').value;
        var telefone = document.getElementById('txbTelefone').value;
        if (categoria == "1" && telefone != "") {
            document.getElementById("erroTelefone").style.display = "none";
            btnSalvar.disabled = false;
        }
        else if (categoria != "1") {
            document.getElementById("erroTelefone").style.display = "none";
            btnSalvar.disabled = false;
        }
        else {
            document.getElementById("erroTelefone").style.display = "block";
            btnSalvar.disabled = true;
        }
    }

</script>
