using System;
using System.Collections;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using NacaoUtils.Web;

namespace Fitcard_Teste
{

[Serializable]

public  class Status
{

#region "Atributes"
private int _ID_STATUS;
private string _STATUS;
#endregion

#region "Property"
public int ID_STATUS
{
get { return _ID_STATUS; }
set { _ID_STATUS = value; }
}
public string STATUS
{
get { return _STATUS; }
set { _STATUS = value; }
}
#endregion

#region "Constructor"
/// <summary>/// Construtor do objeto, instancia todos os atributos como (default) /// </summary>"
public Status()
{
	Load();
}

/// <summary>/// Construtor do objeto , popula os dados da classe atual /// </summary>"
/// <param name="p_id">ID do Objeto a ser instanciado</param>"
public Status(int p_id)
{
SqlDataReader dr;
dr = SqlHelper.ExecuteReader(Configuration.ConnectionString, "P_SEL_FITCARD_STATUS", p_id);
if (dr.Read())
{
Load(dr);
}
dr.Close();
}
public Status(SqlDataReader dr)
{
Load(dr);
}

#endregion

#region "Load"
public void Load()
{
_ID_STATUS = 0;
_STATUS = "";
}

public void Load(SqlDataReader dr)
{
_ID_STATUS = (dr.GetValue(dr.GetOrdinal("ID_STATUS")) == System.DBNull.Value) ? _ID_STATUS : dr.GetInt32(dr.GetOrdinal("ID_STATUS"));
_STATUS = (dr.GetValue(dr.GetOrdinal("STATUS")) == System.DBNull.Value) ? _STATUS : dr.GetString(dr.GetOrdinal("STATUS"));
}
#endregion

#region "Insert"
public int Insert()
{
_ID_STATUS = Int32.Parse("0" + SqlHelper.ExecuteScalar(Configuration.ConnectionString, "P_INS_FITCARD_STATUS", _STATUS));
return _ID_STATUS;
}
#endregion

#region "Update"
public void Update()
{
SqlHelper.ExecuteNonQuery(Configuration.ConnectionString, "P_UPD_FITCARD_STATUS",_ID_STATUS, _STATUS);
}
#endregion

#region "Delete"
public void Delete()
{
SqlHelper.ExecuteNonQuery(Configuration.ConnectionString, "P_DEL_FITCARD_STATUS", _ID_STATUS);
}
#endregion

#region "Count"
public static int Count()
{
return Int32.Parse("0" + SqlHelper.ExecuteScalar(Configuration.ConnectionString, "P_COUNT_FITCARD_STATUS"));
}
#endregion
#region "Select Campo"
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (object ID_STATUS, object STATUS, CampoStatus campo, Ordem ordem)
{
return Select(ID_STATUS, STATUS, (int) campo, (int) ordem);
}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (object ID_STATUS, object STATUS, CampoStatus campo, Ordem ordem, int skip, int take)
{
return Select(ID_STATUS, null, STATUS, (int) campo, (int) ordem, skip, take);
}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (CampoStatus campo, Ordem ordem, int skip, int take)
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
public static ArrayList Select (object ID_STATUS, object STATUS, int campo, int ordem)
{
return Select(ID_STATUS, null, STATUS, (int) campo, (int) ordem, 0, 0);
}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (object ID_STATUS, object Tipo_STATUS, object STATUS, int campo, int ordem, int skip, int take)
{
ArrayList retorno = new ArrayList();
SqlDataReader dr;
object campo0 = ID_STATUS;
object tipo1 = Tipo_STATUS;
object campo1 = STATUS;
dr = SqlHelper.ExecuteReader(Configuration.ConnectionString, "P_SEL_CAMPO_FITCARD_STATUS", campo0, tipo1, campo1, campo, ordem, skip, take);
while (dr.Read())
{
Status n = new Status(dr);
retorno.Add(n);
}
dr.Close();
return retorno;
}
#endregion


#region "Select Campo COUNT"
public static int SelectCount (object ID_STATUS, object Tipo_STATUS, object STATUS)
{
SqlDataReader dr;
object campo0 = ID_STATUS;
object tipo1 = Tipo_STATUS;
object campo1 = STATUS;
dr = SqlHelper.ExecuteReader(Configuration.ConnectionString, "P_SEL_CAMPO_COUNT_FITCARD_STATUS"  ,campo0  ,tipo1  ,campo1 );
dr.Read();
int retorno = (int)dr[0];
dr.Close();
return retorno;
}
#endregion

#region RELATÓRIOS
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList SelectRange(object ID_STATUS, object ID_STATUS_ATE, object Tipo_STATUS, object STATUS, int campo, int ordem, int skip, int take)
{
ArrayList retorno = new ArrayList();
SqlDataReader dr;
object campo0 = ID_STATUS;
object campo1 = ID_STATUS_ATE;
object tipo2 = Tipo_STATUS;
object campo2 = STATUS;
dr = SqlHelper.ExecuteReader(Configuration.ConnectionString, "P_SEL_CAMPO_RELATORIO_RANGE_FITCARD_STATUS", campo0, campo1, tipo2, campo2, campo, ordem, skip, take);
while (dr.Read())
{
Status n = new Status(dr);
retorno.Add(n);
}
dr.Close();
return retorno;
}

#endregion

#region "Json"
public object ToJson()
{
return new { id_status = this.ID_STATUS, status = this.STATUS, };
}
#endregion


}
}
