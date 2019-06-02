using System;
using System.Collections;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using NacaoUtils.Web;

namespace Fitcard_Teste
{

[Serializable]

public  class Categoria
{

#region "Atributes"
private int _ID_CATEGORIA;
private string _CATEGORIA;
#endregion

#region "Property"
public int ID_CATEGORIA
{
get { return _ID_CATEGORIA; }
set { _ID_CATEGORIA = value; }
}
public string CATEGORIA
{
get { return _CATEGORIA; }
set { _CATEGORIA = value; }
}
#endregion

#region "Constructor"
/// <summary>/// Construtor do objeto, instancia todos os atributos como (default) /// </summary>"
public Categoria()
{
	Load();
}

/// <summary>/// Construtor do objeto , popula os dados da classe atual /// </summary>"
/// <param name="p_id">ID do Objeto a ser instanciado</param>"
public Categoria(int p_id)
{
SqlDataReader dr;
dr = SqlHelper.ExecuteReader(Configuration.ConnectionString, "P_SEL_FITCARD_CATEGORIA", p_id);
if (dr.Read())
{
Load(dr);
}
dr.Close();
}
public Categoria(SqlDataReader dr)
{
Load(dr);
}

#endregion

#region "Load"
public void Load()
{
_ID_CATEGORIA = 0;
_CATEGORIA = "";
}

public void Load(SqlDataReader dr)
{
_ID_CATEGORIA = (dr.GetValue(dr.GetOrdinal("ID_CATEGORIA")) == System.DBNull.Value) ? _ID_CATEGORIA : dr.GetInt32(dr.GetOrdinal("ID_CATEGORIA"));
_CATEGORIA = (dr.GetValue(dr.GetOrdinal("CATEGORIA")) == System.DBNull.Value) ? _CATEGORIA : dr.GetString(dr.GetOrdinal("CATEGORIA"));
}
#endregion

#region "Insert"
public int Insert()
{
_ID_CATEGORIA = Int32.Parse("0" + SqlHelper.ExecuteScalar(Configuration.ConnectionString, "P_INS_FITCARD_CATEGORIA", _CATEGORIA));
return _ID_CATEGORIA;
}
#endregion

#region "Update"
public void Update()
{
SqlHelper.ExecuteNonQuery(Configuration.ConnectionString, "P_UPD_FITCARD_CATEGORIA",_ID_CATEGORIA, _CATEGORIA);
}
#endregion

#region "Delete"
public void Delete()
{
SqlHelper.ExecuteNonQuery(Configuration.ConnectionString, "P_DEL_FITCARD_CATEGORIA", _ID_CATEGORIA);
}
#endregion

#region "Count"
public static int Count()
{
return Int32.Parse("0" + SqlHelper.ExecuteScalar(Configuration.ConnectionString, "P_COUNT_FITCARD_CATEGORIA"));
}
#endregion
#region "Select Campo"
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (object ID_CATEGORIA, object CATEGORIA, CampoCategoria campo, Ordem ordem)
{
return Select(ID_CATEGORIA, CATEGORIA, (int) campo, (int) ordem);
}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (object ID_CATEGORIA, object CATEGORIA, CampoCategoria campo, Ordem ordem, int skip, int take)
{
return Select(ID_CATEGORIA, null, CATEGORIA, (int) campo, (int) ordem, skip, take);
}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (CampoCategoria campo, Ordem ordem, int skip, int take)
{
return Select((int) campo, (int) ordem, skip, take);
}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (int campo, int ordem, int skip, int take)
{
return Select(null, null, null, campo, ordem, skip, take);
}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList SelectAll (){
return Select(0, 1, 0, 0);}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (object ID_CATEGORIA, object CATEGORIA, int campo, int ordem)
{
return Select(ID_CATEGORIA, null, CATEGORIA, (int) campo, (int) ordem, 0, 0);
}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (object ID_CATEGORIA, object Tipo_CATEGORIA, object CATEGORIA, int campo, int ordem, int skip, int take)
{
ArrayList retorno = new ArrayList();
SqlDataReader dr;
object campo0 = ID_CATEGORIA;
object tipo1 = Tipo_CATEGORIA;
object campo1 = CATEGORIA;
dr = SqlHelper.ExecuteReader(Configuration.ConnectionString, "P_SEL_CAMPO_FITCARD_CATEGORIA", campo0, tipo1, campo1, campo, ordem, skip, take);
while (dr.Read())
{
Categoria n = new Categoria(dr);
retorno.Add(n);
}
dr.Close();
return retorno;
}
#endregion


#region "Select Campo COUNT"
public static int SelectCount (object ID_CATEGORIA, object Tipo_CATEGORIA, object CATEGORIA)
{
SqlDataReader dr;
object campo0 = ID_CATEGORIA;
object tipo1 = Tipo_CATEGORIA;
object campo1 = CATEGORIA;
dr = SqlHelper.ExecuteReader(Configuration.ConnectionString, "P_SEL_CAMPO_COUNT_FITCARD_CATEGORIA"  ,campo0  ,tipo1  ,campo1 );
dr.Read();
int retorno = (int)dr[0];
dr.Close();
return retorno;
}
#endregion

#region RELATÓRIOS
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList SelectRange(object ID_CATEGORIA, object ID_CATEGORIA_ATE, object Tipo_CATEGORIA, object CATEGORIA, int campo, int ordem, int skip, int take)
{
ArrayList retorno = new ArrayList();
SqlDataReader dr;
object campo0 = ID_CATEGORIA;
object campo1 = ID_CATEGORIA_ATE;
object tipo2 = Tipo_CATEGORIA;
object campo2 = CATEGORIA;
dr = SqlHelper.ExecuteReader(Configuration.ConnectionString, "P_SEL_CAMPO_RELATORIO_RANGE_FITCARD_CATEGORIA", campo0, campo1, tipo2, campo2, campo, ordem, skip, take);
while (dr.Read())
{
Categoria n = new Categoria(dr);
retorno.Add(n);
}
dr.Close();
return retorno;
}

#endregion

#region "Json"
public object ToJson()
{
return new { id_categoria = this.ID_CATEGORIA, categoria = this.CATEGORIA, };
}
#endregion


}
}
