using System;
using System.Collections;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using NacaoUtils.Web;

namespace Fitcard_Teste
{

[Serializable]

public  class Estabelecimento
{

#region "Atributes"
private int _ID_ESTABELECIMENTO;
private string _RAZAO_SOCIAL;
private string _NOME_FANTASIA;
private string _CNPJ;
private string _EMAIL;
private string _ENDERECO;
private string _CIDADE;
private string _ESTADO;
private string _TELEFONE;
private DateTime _DATA_CADASTRADO;
private int _ID_CATEGORIA;
private int _ID_STATUS;
private string _AGENCIA;
private string _CONTA;
#endregion

#region "Property"
public int ID_ESTABELECIMENTO
{
get { return _ID_ESTABELECIMENTO; }
set { _ID_ESTABELECIMENTO = value; }
}
public string RAZAO_SOCIAL
{
get { return _RAZAO_SOCIAL; }
set { _RAZAO_SOCIAL = value; }
}
public string NOME_FANTASIA
{
get { return _NOME_FANTASIA; }
set { _NOME_FANTASIA = value; }
}
public string CNPJ
{
get { return _CNPJ; }
set { _CNPJ = value; }
}
public string EMAIL
{
get { return _EMAIL; }
set { _EMAIL = value; }
}
public string ENDERECO
{
get { return _ENDERECO; }
set { _ENDERECO = value; }
}
public string CIDADE
{
get { return _CIDADE; }
set { _CIDADE = value; }
}
public string ESTADO
{
get { return _ESTADO; }
set { _ESTADO = value; }
}
public string TELEFONE
{
get { return _TELEFONE; }
set { _TELEFONE = value; }
}
public DateTime DATA_CADASTRADO
{
get { return _DATA_CADASTRADO; }
set { _DATA_CADASTRADO = value; }
}
public int ID_CATEGORIA
{
get { return _ID_CATEGORIA; }
set { _ID_CATEGORIA = value; }
}
public int ID_STATUS
{
get { return _ID_STATUS; }
set { _ID_STATUS = value; }
}
public string AGENCIA
{
get { return _AGENCIA; }
set { _AGENCIA = value; }
}
public string CONTA
{
get { return _CONTA; }
set { _CONTA = value; }
}
#endregion

#region "Constructor"
/// <summary>/// Construtor do objeto, instancia todos os atributos como (default) /// </summary>"
public Estabelecimento()
{
	Load();
}

/// <summary>/// Construtor do objeto , popula os dados da classe atual /// </summary>"
/// <param name="p_id">ID do Objeto a ser instanciado</param>"
public Estabelecimento(int p_id)
{
SqlDataReader dr;
dr = SqlHelper.ExecuteReader(Configuration.ConnectionString, "P_SEL_FITCARD_ESTABELECIMENTO", p_id);
if (dr.Read())
{
Load(dr);
}
dr.Close();
}
public Estabelecimento(SqlDataReader dr)
{
Load(dr);
}

#endregion

#region "Load"
public void Load()
{
_ID_ESTABELECIMENTO = 0;
_RAZAO_SOCIAL = "";
_NOME_FANTASIA = "";
_CNPJ = "";
_EMAIL = "";
_ENDERECO = "";
_CIDADE = "";
_ESTADO = "";
_TELEFONE = "";
_DATA_CADASTRADO = Constantes.EmptyDate;
_ID_CATEGORIA = 0;
_ID_STATUS = 0;
_AGENCIA = "";
_CONTA = "";
}

public void Load(SqlDataReader dr)
{
_ID_ESTABELECIMENTO = (dr.GetValue(dr.GetOrdinal("ID_ESTABELECIMENTO")) == System.DBNull.Value) ? _ID_ESTABELECIMENTO : dr.GetInt32(dr.GetOrdinal("ID_ESTABELECIMENTO"));
_RAZAO_SOCIAL = (dr.GetValue(dr.GetOrdinal("RAZAO_SOCIAL")) == System.DBNull.Value) ? _RAZAO_SOCIAL : dr.GetString(dr.GetOrdinal("RAZAO_SOCIAL"));
_NOME_FANTASIA = (dr.GetValue(dr.GetOrdinal("NOME_FANTASIA")) == System.DBNull.Value) ? _NOME_FANTASIA : dr.GetString(dr.GetOrdinal("NOME_FANTASIA"));
_CNPJ = (dr.GetValue(dr.GetOrdinal("CNPJ")) == System.DBNull.Value) ? _CNPJ : dr.GetString(dr.GetOrdinal("CNPJ"));
_EMAIL = (dr.GetValue(dr.GetOrdinal("EMAIL")) == System.DBNull.Value) ? _EMAIL : dr.GetString(dr.GetOrdinal("EMAIL"));
_ENDERECO = (dr.GetValue(dr.GetOrdinal("ENDERECO")) == System.DBNull.Value) ? _ENDERECO : dr.GetString(dr.GetOrdinal("ENDERECO"));
_CIDADE = (dr.GetValue(dr.GetOrdinal("CIDADE")) == System.DBNull.Value) ? _CIDADE : dr.GetString(dr.GetOrdinal("CIDADE"));
_ESTADO = (dr.GetValue(dr.GetOrdinal("ESTADO")) == System.DBNull.Value) ? _ESTADO : dr.GetString(dr.GetOrdinal("ESTADO"));
_TELEFONE = (dr.GetValue(dr.GetOrdinal("TELEFONE")) == System.DBNull.Value) ? _TELEFONE : dr.GetString(dr.GetOrdinal("TELEFONE"));
_DATA_CADASTRADO = (dr.GetValue(dr.GetOrdinal("DATA_CADASTRADO")) == System.DBNull.Value) ? _DATA_CADASTRADO : dr.GetDateTime(dr.GetOrdinal("DATA_CADASTRADO"));
_ID_CATEGORIA = (dr.GetValue(dr.GetOrdinal("ID_CATEGORIA")) == System.DBNull.Value)? 0 : dr.GetInt32(dr.GetOrdinal("ID_CATEGORIA"));
_ID_STATUS = (dr.GetValue(dr.GetOrdinal("ID_STATUS")) == System.DBNull.Value)? 0 : dr.GetInt32(dr.GetOrdinal("ID_STATUS"));
_AGENCIA = (dr.GetValue(dr.GetOrdinal("AGENCIA")) == System.DBNull.Value) ? _AGENCIA : dr.GetString(dr.GetOrdinal("AGENCIA"));
_CONTA = (dr.GetValue(dr.GetOrdinal("CONTA")) == System.DBNull.Value) ? _CONTA : dr.GetString(dr.GetOrdinal("CONTA"));
}
#endregion

#region "Insert"
public int Insert()
{
object tmpID_CATEGORIA = (_ID_CATEGORIA == 0)? (object)System.DBNull.Value : _ID_CATEGORIA;
object tmpID_STATUS = (_ID_STATUS == 0)? (object)System.DBNull.Value : _ID_STATUS;
_ID_ESTABELECIMENTO = Int32.Parse("0" + SqlHelper.ExecuteScalar(Configuration.ConnectionString, "P_INS_FITCARD_ESTABELECIMENTO", _RAZAO_SOCIAL, _NOME_FANTASIA, _CNPJ, _EMAIL, _ENDERECO, _CIDADE, _ESTADO, _TELEFONE, _DATA_CADASTRADO, tmpID_CATEGORIA, tmpID_STATUS, _AGENCIA, _CONTA));
return _ID_ESTABELECIMENTO;
}
#endregion

#region "Update"
public void Update()
{
SqlHelper.ExecuteNonQuery(Configuration.ConnectionString, "P_UPD_FITCARD_ESTABELECIMENTO",_ID_ESTABELECIMENTO, _RAZAO_SOCIAL, _NOME_FANTASIA, _CNPJ, _EMAIL, _ENDERECO, _CIDADE, _ESTADO, _TELEFONE, _DATA_CADASTRADO, ((_ID_CATEGORIA == 0)? (object)System.DBNull.Value: (object)_ID_CATEGORIA), ((_ID_STATUS == 0)? (object)System.DBNull.Value: (object)_ID_STATUS), _AGENCIA, _CONTA);
}
#endregion

#region "Delete"
public void Delete()
{
SqlHelper.ExecuteNonQuery(Configuration.ConnectionString, "P_DEL_FITCARD_ESTABELECIMENTO", _ID_ESTABELECIMENTO);
}
#endregion

#region "Count"
public static int Count()
{
return Int32.Parse("0" + SqlHelper.ExecuteScalar(Configuration.ConnectionString, "P_COUNT_FITCARD_ESTABELECIMENTO"));
}
#endregion
#region "Select Campo"
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (object ID_ESTABELECIMENTO, object RAZAO_SOCIAL, object NOME_FANTASIA, object CNPJ, object EMAIL, object ENDERECO, object CIDADE, object ESTADO, object TELEFONE, object DATA_CADASTRADO, object ID_CATEGORIA, object ID_STATUS, object AGENCIA, object CONTA, CampoEstabelecimento campo, Ordem ordem)
{
return Select(ID_ESTABELECIMENTO, RAZAO_SOCIAL, NOME_FANTASIA, CNPJ, EMAIL, ENDERECO, CIDADE, ESTADO, TELEFONE, DATA_CADASTRADO, ID_CATEGORIA, ID_STATUS, AGENCIA, CONTA, (int) campo, (int) ordem);
}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (object ID_ESTABELECIMENTO, object RAZAO_SOCIAL, object NOME_FANTASIA, object CNPJ, object EMAIL, object ENDERECO, object CIDADE, object ESTADO, object TELEFONE, object DATA_CADASTRADO, object ID_CATEGORIA, object ID_STATUS, object AGENCIA, object CONTA, CampoEstabelecimento campo, Ordem ordem, int skip, int take)
{
return Select(ID_ESTABELECIMENTO, null, RAZAO_SOCIAL, null, NOME_FANTASIA, null, CNPJ, null, EMAIL, null, ENDERECO, null, CIDADE, null, ESTADO, null, TELEFONE, DATA_CADASTRADO, ID_CATEGORIA, ID_STATUS, null, AGENCIA, null, CONTA, (int) campo, (int) ordem, skip, take);
}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (CampoEstabelecimento campo, Ordem ordem, int skip, int take)
{
return Select((int) campo, (int) ordem, skip, take);
}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (int campo, int ordem, int skip, int take)
{
return Select(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, campo, ordem, skip, take);
}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList SelectAll (){
return Select(0, 1, 0, 0);}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (object ID_ESTABELECIMENTO, object RAZAO_SOCIAL, object NOME_FANTASIA, object CNPJ, object EMAIL, object ENDERECO, object CIDADE, object ESTADO, object TELEFONE, object DATA_CADASTRADO, object ID_CATEGORIA, object ID_STATUS, object AGENCIA, object CONTA, int campo, int ordem)
{
return Select(ID_ESTABELECIMENTO, null, RAZAO_SOCIAL, null, NOME_FANTASIA, null, CNPJ, null, EMAIL, null, ENDERECO, null, CIDADE, null, ESTADO, null, TELEFONE, DATA_CADASTRADO, ID_CATEGORIA, ID_STATUS, null, AGENCIA, null, CONTA, (int) campo, (int) ordem, 0, 0);
}
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList Select (object ID_ESTABELECIMENTO, object Tipo_RAZAO_SOCIAL, object RAZAO_SOCIAL, object Tipo_NOME_FANTASIA, object NOME_FANTASIA, object Tipo_CNPJ, object CNPJ, object Tipo_EMAIL, object EMAIL, object Tipo_ENDERECO, object ENDERECO, object Tipo_CIDADE, object CIDADE, object Tipo_ESTADO, object ESTADO, object Tipo_TELEFONE, object TELEFONE, object DATA_CADASTRADO, object ID_CATEGORIA, object ID_STATUS, object Tipo_AGENCIA, object AGENCIA, object Tipo_CONTA, object CONTA, int campo, int ordem, int skip, int take)
{
ArrayList retorno = new ArrayList();
SqlDataReader dr;
object campo0 = ID_ESTABELECIMENTO;
object tipo1 = Tipo_RAZAO_SOCIAL;
object campo1 = RAZAO_SOCIAL;
object tipo2 = Tipo_NOME_FANTASIA;
object campo2 = NOME_FANTASIA;
object tipo3 = Tipo_CNPJ;
object campo3 = CNPJ;
object tipo4 = Tipo_EMAIL;
object campo4 = EMAIL;
object tipo5 = Tipo_ENDERECO;
object campo5 = ENDERECO;
object tipo6 = Tipo_CIDADE;
object campo6 = CIDADE;
object tipo7 = Tipo_ESTADO;
object campo7 = ESTADO;
object tipo8 = Tipo_TELEFONE;
object campo8 = TELEFONE;
object campo9 = DATA_CADASTRADO;
object campo10 = ID_CATEGORIA;
object campo11 = ID_STATUS;
object tipo12 = Tipo_AGENCIA;
object campo12 = AGENCIA;
object tipo13 = Tipo_CONTA;
object campo13 = CONTA;
dr = SqlHelper.ExecuteReader(Configuration.ConnectionString, "P_SEL_CAMPO_FITCARD_ESTABELECIMENTO", campo0, tipo1, campo1, tipo2, campo2, tipo3, campo3, tipo4, campo4, tipo5, campo5, tipo6, campo6, tipo7, campo7, tipo8, campo8, campo9, campo10, campo11, tipo12, campo12, tipo13, campo13, campo, ordem, skip, take);
while (dr.Read())
{
Estabelecimento n = new Estabelecimento(dr);
retorno.Add(n);
}
dr.Close();
return retorno;
}
#endregion


#region "Select Campo COUNT"
public static int SelectCount (object ID_ESTABELECIMENTO, object Tipo_RAZAO_SOCIAL, object RAZAO_SOCIAL, object Tipo_NOME_FANTASIA, object NOME_FANTASIA, object Tipo_CNPJ, object CNPJ, object Tipo_EMAIL, object EMAIL, object Tipo_ENDERECO, object ENDERECO, object Tipo_CIDADE, object CIDADE, object Tipo_ESTADO, object ESTADO, object Tipo_TELEFONE, object TELEFONE, object DATA_CADASTRADO, object ID_CATEGORIA, object ID_STATUS, object Tipo_AGENCIA, object AGENCIA, object Tipo_CONTA, object CONTA)
{
SqlDataReader dr;
object campo0 = ID_ESTABELECIMENTO;
object tipo1 = Tipo_RAZAO_SOCIAL;
object campo1 = RAZAO_SOCIAL;
object tipo2 = Tipo_NOME_FANTASIA;
object campo2 = NOME_FANTASIA;
object tipo3 = Tipo_CNPJ;
object campo3 = CNPJ;
object tipo4 = Tipo_EMAIL;
object campo4 = EMAIL;
object tipo5 = Tipo_ENDERECO;
object campo5 = ENDERECO;
object tipo6 = Tipo_CIDADE;
object campo6 = CIDADE;
object tipo7 = Tipo_ESTADO;
object campo7 = ESTADO;
object tipo8 = Tipo_TELEFONE;
object campo8 = TELEFONE;
object campo9 = DATA_CADASTRADO;
object campo10 = ID_CATEGORIA;
object campo11 = ID_STATUS;
object tipo12 = Tipo_AGENCIA;
object campo12 = AGENCIA;
object tipo13 = Tipo_CONTA;
object campo13 = CONTA;
dr = SqlHelper.ExecuteReader(Configuration.ConnectionString, "P_SEL_CAMPO_COUNT_FITCARD_ESTABELECIMENTO"  ,campo0  ,tipo1  ,campo1  ,tipo2  ,campo2  ,tipo3  ,campo3  ,tipo4  ,campo4  ,tipo5  ,campo5  ,tipo6  ,campo6  ,tipo7  ,campo7  ,tipo8  ,campo8  ,campo9  ,campo10  ,campo11  ,tipo12  ,campo12  ,tipo13  ,campo13 );
dr.Read();
int retorno = (int)dr[0];
dr.Close();
return retorno;
}
#endregion

#region RELATÓRIOS
/// <summary>/// Select por campo e ordenação/// </summary>/// <param name="campo">Campo para select</param>/// <param name="ordem">Decrescente, Crescente</param>/// <returns>Retorna resultado do select</returns>
public static ArrayList SelectRange(object ID_ESTABELECIMENTO, object ID_ESTABELECIMENTO_ATE, object Tipo_RAZAO_SOCIAL, object RAZAO_SOCIAL, object Tipo_NOME_FANTASIA, object NOME_FANTASIA, object Tipo_CNPJ, object CNPJ, object Tipo_EMAIL, object EMAIL, object Tipo_ENDERECO, object ENDERECO, object Tipo_CIDADE, object CIDADE, object Tipo_ESTADO, object ESTADO, object Tipo_TELEFONE, object TELEFONE, object DATA_CADASTRADO, object DATA_CADASTRADO_ATE, object ID_CATEGORIA, object ID_STATUS, object Tipo_AGENCIA, object AGENCIA, object Tipo_CONTA, object CONTA, int campo, int ordem, int skip, int take)
{
ArrayList retorno = new ArrayList();
SqlDataReader dr;
object campo0 = ID_ESTABELECIMENTO;
object campo1 = ID_ESTABELECIMENTO_ATE;
object tipo2 = Tipo_RAZAO_SOCIAL;
object campo2 = RAZAO_SOCIAL;
object tipo3 = Tipo_NOME_FANTASIA;
object campo3 = NOME_FANTASIA;
object tipo4 = Tipo_CNPJ;
object campo4 = CNPJ;
object tipo5 = Tipo_EMAIL;
object campo5 = EMAIL;
object tipo6 = Tipo_ENDERECO;
object campo6 = ENDERECO;
object tipo7 = Tipo_CIDADE;
object campo7 = CIDADE;
object tipo8 = Tipo_ESTADO;
object campo8 = ESTADO;
object tipo9 = Tipo_TELEFONE;
object campo9 = TELEFONE;
object campo10 = DATA_CADASTRADO;
object campo11 = DATA_CADASTRADO_ATE;
object campo12 = ID_CATEGORIA;
object campo13 = ID_STATUS;
object tipo14 = Tipo_AGENCIA;
object campo14 = AGENCIA;
object tipo15 = Tipo_CONTA;
object campo15 = CONTA;
dr = SqlHelper.ExecuteReader(Configuration.ConnectionString, "P_SEL_CAMPO_RELATORIO_RANGE_FITCARD_ESTABELECIMENTO", campo0, campo1, tipo2, campo2, tipo3, campo3, tipo4, campo4, tipo5, campo5, tipo6, campo6, tipo7, campo7, tipo8, campo8, tipo9, campo9, campo10, campo11, campo12, campo13, tipo14, campo14, tipo15, campo15, campo, ordem, skip, take);
while (dr.Read())
{
Estabelecimento n = new Estabelecimento(dr);
retorno.Add(n);
}
dr.Close();
return retorno;
}

#endregion

#region "Json"
public object ToJson()
{
return new { id_estabelecimento = this.ID_ESTABELECIMENTO, razao_social = this.RAZAO_SOCIAL, nome_fantasia = this.NOME_FANTASIA, cnpj = this.CNPJ, email = this.EMAIL, endereco = this.ENDERECO, cidade = this.CIDADE, estado = this.ESTADO, telefone = this.TELEFONE, data_cadastrado = this.DATA_CADASTRADO, id_categoria = this.ID_CATEGORIA, id_status = this.ID_STATUS, agencia = this.AGENCIA, conta = this.CONTA, };
}
#endregion


}
}
