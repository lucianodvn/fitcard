using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fitcard_Teste.site
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrayList arrDados = Estabelecimento.Select(CampoEstabelecimento.ID_ESTABELECIMENTO, Ordem.Crescente, 0, 0);
                rptDados.DataSource = arrDados;
                rptDados.DataBind();
            }

        }


        protected void rptDados_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Estabelecimento objEstabelecimento = (Estabelecimento)e.Item.DataItem;
            ((Literal)e.Item.FindControl("ltrRazaoSocial")).Text = objEstabelecimento.RAZAO_SOCIAL;
            ((Literal)e.Item.FindControl("ltrNome")).Text = objEstabelecimento.NOME_FANTASIA;
            ((Literal)e.Item.FindControl("ltrCNPJ")).Text = objEstabelecimento.CNPJ;
            ((Literal)e.Item.FindControl("ltrCidade")).Text = objEstabelecimento.CIDADE;
            ((Literal)e.Item.FindControl("ltrEstado")).Text = objEstabelecimento.ESTADO;
            ((Button)e.Item.FindControl("btnEditar")).CommandArgument = objEstabelecimento.ID_ESTABELECIMENTO.ToString();
            ((Button)e.Item.FindControl("btnExcluir")).CommandArgument = objEstabelecimento.ID_ESTABELECIMENTO.ToString();
            
            ArrayList arrCategoria = Categoria.Select(objEstabelecimento.ID_CATEGORIA, null, 0, 0);
            if (arrCategoria.Count > 0)
            {
                Categoria objCategoria = (Categoria)arrCategoria[0];
                ((Literal)e.Item.FindControl("ltrCategoria")).Text = objCategoria.CATEGORIA;
            }
            else
            {
                ((Literal)e.Item.FindControl("ltrCategoria")).Text = "";
            }
            ArrayList arrStatus = Status.Select(objEstabelecimento.ID_STATUS, null, 0, 0);
            if (arrStatus.Count > 0)
            {
                Status objStatus = (Status)arrStatus[0];
                ((Literal)e.Item.FindControl("ltrStatus")).Text = objStatus.STATUS;
            }
            else
            {
                ((Literal)e.Item.FindControl("ltrStatus")).Text = "";
            }
        }

        protected void btnEditar_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("/editar/"+id);
        }

        protected void btnExcluir_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Estabelecimento objEstabelecimento = new Estabelecimento(id);
            objEstabelecimento.Delete();

            ArrayList arrDados = Estabelecimento.Select(CampoEstabelecimento.ID_ESTABELECIMENTO, Ordem.Crescente, 0, 0);
            rptDados.DataSource = arrDados;
            rptDados.DataBind();
        }
    }
}