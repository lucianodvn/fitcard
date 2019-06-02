using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fitcard_Teste.site
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            }

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            DateTime data;
            if (txbDataCadastro.Text.Equals(""))
            {
                data = DateTime.Now;
            }
            else
            {
                data = Convert.ToDateTime(txbDataCadastro.Text);
            }

            Estabelecimento objEstabelecimento = new Estabelecimento();
            objEstabelecimento.RAZAO_SOCIAL = txbRazaoSocial.Text;
            objEstabelecimento.NOME_FANTASIA = txbNome.Text;
            objEstabelecimento.CNPJ = txbCnpj.Text;
            objEstabelecimento.EMAIL = txbEmail.Text;
            objEstabelecimento.ENDERECO = txbEndereco.Text;
            objEstabelecimento.CIDADE = txbCidade.Text;
            objEstabelecimento.ESTADO = txbEstado.Text;
            objEstabelecimento.TELEFONE = txbTelefone.Text;
            objEstabelecimento.DATA_CADASTRADO = data;
            objEstabelecimento.ID_CATEGORIA = Convert.ToInt32(ddlCategoria.SelectedValue);
            objEstabelecimento.ID_STATUS = Convert.ToInt32(ddlStatus.SelectedValue);
            objEstabelecimento.AGENCIA = txbAgencia.Text;
            objEstabelecimento.CONTA = txbConta.Text;

            int id = objEstabelecimento.Insert();
            if (id > 0)
            {
                cadastroSucesso.Style.Add("display", "block");
                txbRazaoSocial.Text = "";
                txbNome.Text = "";
                txbCnpj.Text = "";
                txbEmail.Text = "";
                txbEndereco.Text = "";
                txbTelefone.Text = "";
                txbCidade.Text = "";
                txbEstado.Text = "";
                txbDataCadastro.Text = "";
                ddlCategoria.SelectedValue = "0";
                ddlStatus.SelectedValue = "0";
                txbAgencia.Text = "";
                txbConta.Text = "";
            }
        }
    }
}