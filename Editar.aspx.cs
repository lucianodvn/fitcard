using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fitcard_Teste.site
{
    public partial class Editar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string ID_OCORRENCIA = Convert.ToString(Page.RouteData.Values["idEstabelecimento"]);
                Estabelecimento objEstabelecimento = new Estabelecimento(Convert.ToInt32(Page.RouteData.Values["idEstabelecimento"]));
                if (objEstabelecimento.ID_ESTABELECIMENTO != null)
                {
                    ddlCategoria.DataSource = Categoria.Select(CampoCategoria.CATEGORIA, Ordem.Crescente, 0, 0);
                    ddlCategoria.DataTextField = "CATEGORIA";
                    ddlCategoria.DataValueField = "ID_CATEGORIA";
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Insert(0, new ListItem("Selecione a Categoria", "0"));

                    ddlStatus.DataSource = Status.Select(CampoStatus.STATUS, Ordem.Crescente, 0, 0);
                    ddlStatus.DataTextField = "STATUS";
                    ddlStatus.DataValueField = "ID_STATUS";
                    ddlStatus.DataBind();
                    ddlStatus.Items.Insert(0, new ListItem("Selecione o Status", "0"));

                    txbRazaoSocial.Text = objEstabelecimento.RAZAO_SOCIAL;
                    txbNome.Text = objEstabelecimento.NOME_FANTASIA;
                    txbCnpj.Text = objEstabelecimento.CNPJ;
                    txbEmail.Text = objEstabelecimento.EMAIL;
                    txbDataCadastro.Text = objEstabelecimento.DATA_CADASTRADO.ToString("dd/MM/yyyy");
                    txbEndereco.Text = objEstabelecimento.ENDERECO;
                    txbCidade.Text = objEstabelecimento.CIDADE;
                    txbEstado.Text = objEstabelecimento.ESTADO;
                    txbTelefone.Text = objEstabelecimento.TELEFONE;
                    txbAgencia.Text = objEstabelecimento.AGENCIA;
                    txbConta.Text = objEstabelecimento.CONTA;

                    ArrayList arrCategoria = Categoria.Select(objEstabelecimento.ID_CATEGORIA, null, 0, 0);
                    if (arrCategoria.Count > 0)
                    {
                        Categoria objCategoria = (Categoria)arrCategoria[0];
                        ddlCategoria.SelectedValue = objCategoria.ID_CATEGORIA.ToString();
                    }
                    else
                    {
                        ddlCategoria.SelectedValue = "";
                    }
                    ArrayList arrStatus = Status.Select(objEstabelecimento.ID_STATUS, null, 0, 0);
                    if (arrStatus.Count > 0)
                    {
                        Status objStatus = (Status)arrStatus[0];
                        ddlStatus.SelectedValue = objStatus.ID_STATUS.ToString();
                    }
                    else
                    {
                        ddlStatus.SelectedValue = "";
                    }


                }
                else
                {
                    Response.Redirect("/listar");
                }
            }

        }


        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string telefone = txbTelefone.Text;
            Estabelecimento objEstabelecimento = new Estabelecimento(Convert.ToInt32(Page.RouteData.Values["idEstabelecimento"]));
            DateTime data;
            if (txbDataCadastro.Text.Equals(""))
            {
                data = DateTime.Now;
            }
            else
            {
                data = Convert.ToDateTime(txbDataCadastro.Text);
            }

            objEstabelecimento.RAZAO_SOCIAL = txbRazaoSocial.Text;
            objEstabelecimento.NOME_FANTASIA = txbNome.Text;
            objEstabelecimento.CNPJ = txbCnpj.Text;
            objEstabelecimento.EMAIL = txbEmail.Text;
            objEstabelecimento.ENDERECO = txbEndereco.Text;
            objEstabelecimento.CIDADE = txbCidade.Text;
            objEstabelecimento.ESTADO = txbEstado.Text;
            objEstabelecimento.TELEFONE = telefone;
            objEstabelecimento.DATA_CADASTRADO = data;
            objEstabelecimento.ID_CATEGORIA = Convert.ToInt32(ddlCategoria.SelectedValue);
            objEstabelecimento.ID_STATUS = Convert.ToInt32(ddlStatus.SelectedValue);
            objEstabelecimento.AGENCIA = txbAgencia.Text;
            objEstabelecimento.CONTA = txbConta.Text;

            objEstabelecimento.Update();
            cadastroSucesso.Style.Add("display", "block");
        }
    }
}