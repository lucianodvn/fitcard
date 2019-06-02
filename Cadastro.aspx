<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Fitcard_Teste.site.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastro</title>
    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <div class="jumbotron">
        <button type="button" id="btnVoltar" class="btn btn-success btn-lg" style="margin-left: 200px;" onclick="voltar()">
            <i class="glyphicon glyphicon-step-backward
"></i>Voltar</button>
        <h1 class="text-center">CADASTRO</h1>
        <div class="container">
            <form id="form1" runat="server">
                <div class="form-row">
                    <div class="form-group col-md-4 mb-3">
                        <label for="txbRazaoSocial">Razão Social</label>
                        <asp:TextBox ID="txbRazaoSocial" runat="server" class="form-control validate[required, funcCall[validateCNPJ]]" placeholder="Razão Social"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 mb-3">
                        <label for="txbNome">Nome Fantasia</label>
                        <asp:TextBox ID="txbNome" runat="server" class="form-control" placeholder="Nome Fantasia"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 mb-3">
                        <label for="txbCnpj">CNPJ</label>
                        <asp:TextBox ID="txbCnpj" runat="server" class="form-control" placeholder="CNPJ"></asp:TextBox>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-4 mb-3">
                        <label for="txbEmail">Email</label>
                        <asp:TextBox ID="txbEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 mb-3">
                        <label for="txbEndereco">Endereço</label>
                        <asp:TextBox ID="txbEndereco" runat="server" class="form-control" placeholder="Endereço"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 mb-3">
                        <label for="txbCidade">Cidade</label>
                        <asp:TextBox ID="txbCidade" runat="server" class="form-control" placeholder="Cidade"></asp:TextBox>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-4 mb-3">
                        <label for="txbEstado">Estado</label>
                        <asp:TextBox ID="txbEstado" runat="server" class="form-control" placeholder="Estado"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 mb-3">
                        <label for="txbTelefone">Telefone</label>
                        <asp:TextBox ID="txbTelefone" runat="server" class="form-control" placeholder="Telefone" onchange="validar()"></asp:TextBox>
                        <div id="erroTelefone" style="color: red; display: none; position: absolute;">
                            Por favor, insira o telefone.
                        </div>
                    </div>
                    <div class="form-group col-md-4 mb-3">
                        <label for="txbDataCadastro">Data de Cadastro</label>
                        <asp:TextBox ID="txbDataCadastro" type="date" runat="server" class="form-control" placeholder="Data"></asp:TextBox>
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


                    <div class="form-group col-md-3">
                        <label for="txbAgencia">Agência</label>
                        <asp:TextBox ID="txbAgencia" runat="server" class="form-control" placeholder="Agência"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="txbConta">Conta</label>
                        <asp:TextBox ID="txbConta" runat="server" class="form-control" placeholder="Conta"></asp:TextBox>
                    </div>

                </div>

                <div class="form-group">
                    <div class="form-group col-lg-12">
                        <asp:Button ID="btnSalvar" runat="server" class="btn btn-primary btn-lg" OnClick="btnSalvar_Click" Text="Salvar" />
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
                            <p>Cadastro Efetuado com Sucesso.</p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-success" data-dismiss="modal" onclick="document.getElementById('cadastroSucesso').style.display = 'none'">OK</button>
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
<script src="/Scripts/validationEngine-pt_BR.js"></script>


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
    $("#txbTelefone").keydown(function () {
        try {
            $("#txbTelefone").unmask();
        } catch (e) { }

        var tamanho = $("#txbTelefone").val().length;

        if (tamanho != 10) {
            $("#txbTelefone").mask("(99)9999-9999");
        } else {
            $("#txbTelefone").mask("(99)99999-9999");
        }
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
    $("#txbAgencia").mask("999-9");
    $("#txbConta").mask("99.999-9");

    function validateCNPJ(field, rules, i, options) {
        var valido = isCNPJValid(field.val()); //implementar a validação
        if (!valido) {
            //internacionalização
            return options.allrules.cnpj.alertText;
        }
    }

    function isCNPJValid(cnpj) {
        cnpj = cnpj.replace(/[^\d]+/g, '');
        if (cnpj == '') return false;
        if (cnpj.length != 14)
            return false;
        // Elimina CNPJs invalidos conhecidos
        if (cnpj == "00000000000000" ||
            cnpj == "11111111111111" ||
            cnpj == "22222222222222" ||
            cnpj == "33333333333333" ||
            cnpj == "44444444444444" ||
            cnpj == "55555555555555" ||
            cnpj == "66666666666666" ||
            cnpj == "77777777777777" ||
            cnpj == "88888888888888" ||
            cnpj == "99999999999999")
            return false;

        // Valida DVs
        tamanho = cnpj.length - 2
        numeros = cnpj.substring(0, tamanho);
        digitos = cnpj.substring(tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2)
                pos = 9;
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(0))
            return false;

        tamanho = tamanho + 1;
        numeros = cnpj.substring(0, tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2)
                pos = 9;
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(1))
            return false;

        return true;
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

    function voltar() {
        history.go(-1);
    }

</script>
