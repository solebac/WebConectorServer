using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for estoque
/// </summary>
public class estoque : dados
{
	public estoque()
	{
		//
		// TODO: Add constructor logic here
		//
        dsResultado = new DataSet();
	}

    //##############################################################Variaveis#############################################################
    private DataSet dsResultado;
    private int auxConsistencia = 0;
    private int result = -1;
    //##############################################################End Variaveis#########################################################

    //########################################################Procedimento de Banco#######################################################
    public DataSet conector_find_consultaProduto(string find_produto, string tipo, string store)
    {
        try
        {
            auxConsistencia = 0;
            abreConexao();
            startTransaction("conector_find_consultaProduto");
            addParametro("find_produto", find_produto);
            addParametro("tipo", tipo);
            addParametro("store", store);
            procedimentoSet();
        }
        catch (Exception e)
        {
            auxConsistencia = 1;
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            if (auxConsistencia == 0)
            {
                dsResultado = retornaSet();
            }
            fechaConexao();
        }
        return dsResultado;
    }
    //########################################################End Procedimento de Banco###################################################
}