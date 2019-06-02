<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Lista.aspx.cs" Inherits="Fitcard_Teste.site.Lista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Lista Estabelecimento</title>
    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <link href="/Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="/Content/Site.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server" style="margin-top: -70px;" >
        <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="jumbotron" >
                    <button type="button" id="btnVoltar" class="btn btn-success btn-lg" style="margin-left: 200px;" onclick="voltar();">
                        <i class="glyphicon glyphicon-step-backward
"></i>Voltar</button>
                    <h1 class="text-center">Lista de Estabelecimento</h1>
                    <div class="container">
                    </div>
                </div>
                <table class="table table-hover" >
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col">Razão Social</th>
                            <th scope="col">Nome Fantasia</th>
                            <th scope="col">CNPJ</th>
                            <th scope="col">Cidade</th>
                            <th scope="col">Estado</th>
                            <th scope="col">Categoria</th>
                            <th scope="col">Status</th>
                            <th scope="col">Editar</th>
                            <th scope="col">Excluir</th>
                        </tr>
                    </thead>
                    <tbody>

                        <asp:Repeater ID="rptDados" runat="server" OnItemDataBound="rptDados_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltrRazaoSocial" runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltrNome" runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltrCNPJ" runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltrCidade" runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltrEstado" runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltrCategoria" runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltrStatus" runat="server"></asp:Literal></td>
                                    <td>
                                        <div>
                                            <asp:Button runat="server" ID="btnEditar" CssClass="btn btn-warning" Text="Editar" OnCommand="btnEditar_Command" />
                                        </div>
                                    </td>
                                    <td>
                                        <div>
                                            <asp:Button runat="server" ID="btnExcluir" CssClass="btn btn-danger" Text="Excluir" OnCommand="btnExcluir_Command" data-toggle="modal" data-target="#modalExcluir" />
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>


                <div class="modal fade" id="modalExcluir" runat="server" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h2 class="modal-title text-danger text-center" id="exampleModalLabel"><b>Exclusão</b></h2>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <h4 class="text-center text-danger">Efetuado a exclusão com sucesso.</h4>
                            </div>

                            <div class="modal-footer">
                                <asp:Button ID="modalFechar" runat="server" CssClass="btn btn-danger" Text="OK" data-dismiss="modal" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal fade" id="modalSucesso" runat="server" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel2" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h3 class="modal-title" id="exampleModalLabel2"><b>Dados excluído com Sucesso.</b></h3>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnSucesso" runat="server" CssClass="btn btn-primary" Text="OK" data-dismiss="modal" />
                            </div>
                        </div>
                    </div>
                </div>


            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

<script src="/Scripts/jquery-3.3.1.js"></script>
<script src="/Scripts/bootstrap.js"></script>


<script>
    function voltar() {
        history.go(-1);
    }

</script>
