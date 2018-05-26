using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for crediario
/// </summary>
public class crediario : dados
{
	public crediario()
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
    
    //##############################################################Metodos e Funções#####################################################
    public DataSet conector_find_crediario(string crediario, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from crediario where idCrediario=?crediario and idLoja=?store");
            addParametro("?crediario", crediario);
            addParametro("?store", store);
            procedimentoSet();
            dsResultado = retornaSet();
        }
        catch (Exception e)
        {
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            fechaConexao();
        }
        return dsResultado;
    }
    public DataSet conector_find_parcelamento(string crediario, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from parcela where idCrediario=?crediario and idLoja=?store");
            addParametro("?crediario", crediario);
            addParametro("?store", store);
            procedimentoSet();
            dsResultado = retornaSet();
        }
        catch (Exception e)
        {
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            fechaConexao();
        }
        return dsResultado;
    }
    public DataSet conector_find_parcela(string crediario, string store, string parcela)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from parcela where idCrediario=?crediario and idLoja=?store and nr_parcela=?parcela");
            addParametro("?crediario", crediario);
            addParametro("?store", store);
            addParametro("?parcela", parcela);
            procedimentoSet();
            dsResultado = retornaSet();
        }
        catch (Exception e)
        {
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            fechaConexao();
        }
        return dsResultado;
    }

    public DataSet conector_consulta_dividento(string pessoa, string store, string carne, string prestacao, string tipo)
    {
        try
        {
            auxConsistencia = 0;
            abreConexao();
            startTransaction("conector_exe_parcela");
            addParametro("tipo", tipo);
            addParametro("store", store);//0 todas
            addParametro("contrato", carne);//0 todas
            addParametro("prestacao", prestacao);//0 todas
            addParametro("pessoa", pessoa);
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

    public DataSet conector_consulta_historico(string tipo, string store, string pessoa, string auxFiltraDate, string di, string df)
    {
        try
        {
            auxConsistencia = 0;
            abreConexao();
            startTransaction("conector_historico_client");
            addParametro("tipo", tipo);
            addParametro("find_loja", store);
            addParametro("find_cliente", pessoa);
            addParametro("escolha", auxFiltraDate);
            addParametro("di", di);
            addParametro("df", df);
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

    public void conector_altera_status(string crediario, string store, string parcela, string status)
    {
        try
        {
            abreConexao();
            singleTransaction("update parcela set status=?status where idCrediario=?crediario and idLoja=?store and nr_parcela=?parcela");
            addParametro("?crediario", crediario);
            addParametro("?store", store);
            addParametro("?parcela", parcela);
            addParametro("?status", status);
            procedimentoText();
        }
        catch (Exception e)
        {
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            fechaConexao();
        }
    }
    public int conector_verifica_status_parcela(string crediario, string store, string parcela)
    {
        auxConsistencia = 0;
        result = -1;
        try
        {
            abreConexao();
            singleTransaction("select status from parcela where idCrediario=?crediario and idLoja=?store and nr_parcela=?parcela");
            addParametro("?crediario", crediario);
            addParametro("?store", store);
            addParametro("?parcela", parcela);
            procedimentoRead();
            if (retornaRead().Read() == true)
            {
                result = Convert.ToInt32(retornaRead().GetString(0));
            }
        }
        catch (Exception e)
        {
            auxConsistencia = 1;
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            fechaConexao();
            if (auxConsistencia == 1)
            {
                result = -1;
            }
        }
        return result;
    }
    public int conector_verifica_status_crediario(string crediario, string store)
    {
        auxConsistencia = 0;
        result = -1;
        try
        {
            abreConexao();
            singleTransaction("select status from crediario where idCrediario=?crediario and idLoja=?store");
            addParametro("?crediario", crediario);
            addParametro("?store", store);
            procedimentoRead();
            if (retornaRead().Read() == true)
            {
                result = Convert.ToInt32(retornaRead().GetString(0));
            }
        }
        catch (Exception e)
        {
            auxConsistencia = 1;
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            fechaConexao();
            if (auxConsistencia == 1)
            {
                result = -1;
            }
        }
        return result;
    }
    public void conector_altera_quitacao_parcela(string crediario, string store, string parcela, string status, DateTime datePgto, string acrescimo, string desconto)
    {
        try
        {
            abreConexao();
            singleTransaction("update parcela set status=?status, pagamento=?datePgto, acrescimo=?acrescimo, desconto=?desconto where idCrediario=?crediario and idLoja=?store and nr_parcela=?parcela");
            addParametro("?crediario", crediario);
            addParametro("?store", store);
            addParametro("?parcela", parcela);
            addParametro("?status", status);
            addParametro("?datePgto", String.Format("{0:yyyyMMdd}", datePgto));
            addParametro("?acrescimo", acrescimo);
            addParametro("?desconto", desconto);
            procedimentoText();
        }
        catch (Exception e)
        {
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            fechaConexao();
        }
    }
    //##############################################################End Metodos e Funções#################################################

}
