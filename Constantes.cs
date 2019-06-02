using System;

namespace Fitcard_Teste
{
public struct Constantes
{
public static DateTime EmptyDate
{
get { return new DateTime(1753, 1, 1, 12, 0, 0); }
}
public static bool isEmptyDate(DateTime data)
{
return (data == EmptyDate);
}
}
public enum Ordem 
{
Randomico = -1,
Decrescente = 0,
Crescente = 1
}

public enum TipoBusca
{
ComecaCom,
Contem,
TerminaCom,
Igual
}

public enum CampoStatus
{

ID_STATUS, 
STATUS}
public enum CampoCategoria
{

ID_CATEGORIA, 
CATEGORIA}
public enum CampoEstabelecimento
{

ID_ESTABELECIMENTO, 
RAZAO_SOCIAL, 
NOME_FANTASIA, 
CNPJ, 
EMAIL, 
ENDERECO, 
CIDADE, 
ESTADO, 
TELEFONE, 
DATA_CADASTRADO, 
ID_CATEGORIA, 
ID_STATUS, 
AGENCIA, 
CONTA}
}
