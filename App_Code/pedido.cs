using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for pedido
/// </summary>
public class pedido : dados
{
	public pedido()
	{
		//
		// TODO: Add constructor logic here
		//

        dsResultado = new DataSet();
	}

    //##############################################################Variaveis#############################################################
    DataSet dsResultado;
    private int auxConsistencia = 0;
    private int result = -1;
    //##############################################################End Variaveis#########################################################

    //##############################################################Metodos e Funções#####################################################
    public DataSet conector_find_pedido_dav(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedido where sequenciaDav=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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

    public DataSet conector_find_pedido_Prevenda(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedido where sequenciaPreVenda=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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

    public DataSet conector_find_pedido_log(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedido_log where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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

    public DataSet conector_find_pedidoItens(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedidoItens where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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

    public DataSet conector_find_pedidoFinanceiro(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedidofinanceiro where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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
    public DataSet conector_find_pedidoCrediario(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedidoCrediario where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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

    public DataSet conector_find_pedidoConvenio(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedidoConvenio where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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
    public DataSet conector_find_pedidoCheque(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedidoCheque where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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
    public DataSet conector_find_pedidoBoleto(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedidoBoleto where idPedido=?pedido and cedente=?store");
            addParametro("?pedido", reserva);
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
    public DataSet conector_find_pedidoCartao(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedidoCartao where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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
    public DataSet conector_find_pedidoParcelaCartao(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedidoParcelaCartao where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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
    public DataSet conector_find_pedidoParcelaBoleto(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedidoParcelaBoleto where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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
    public DataSet conector_find_pedidoParcelaCheque(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedidoParcelaCheque where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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
    public DataSet conector_find_pedidoParcelaConvenio(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedidoParcelaConvenio where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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
    public DataSet conector_find_pedidoParcelaCrediario(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedidoParcelaCrediario where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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

    public DataSet conector_find_pedidoEntrega(string reserva, string store)
    {
        try
        {
            abreConexao();
            singleTransaction("select * from pedidoentrega where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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
    
    public void conector_between_financeiroXitens(string reserva, string store)
    {
        try
        {
            abreConexao();
            startTransaction("conector_between_financeiroXitens");
            addParametro("findPedido", reserva);
            addParametro("findLoja", store);
            procedimentoRead();
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

    public DataSet conector_avanca_nota(string store, string tipo)
    {
        try
        {
            abreConexao();
            startTransaction("conector_avanca_nota");
            addParametro("store", store);
            addParametro("tipo", tipo);
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

    public void conector_alt_statusPedido(string reserva, string store, string final, string status, string sinal)
    {
        try
        {
            abreConexao();
            singleTransaction("update pedido set status=?status, final=?final, sinal=?sinal where idPedido=?reserva and idLoja=?store");
            addParametro("?reserva", reserva);
            addParametro("?store", store);
            addParametro("?status", status);
            addParametro("?final", final);
            addParametro("?sinal", sinal);
            procedimentoRead();
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

    public int conector_verifica_status_pedido(string reserva, string store)
    {
        auxConsistencia = 0;
        result = -1;
        try
        {
            abreConexao();
            singleTransaction("select status from pedido where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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
    public int conector_verifica_final_pedido(string reserva, string store)
    {
        auxConsistencia = 0;
        result = -1;
        try
        {
            abreConexao();
            singleTransaction("select final from pedido where idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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
    public int conector_verifica_finalizadora_pedido(string reserva, string store)
    {
        auxConsistencia = 0;
        result = -1;
        try
        {
            abreConexao();
            singleTransaction("select tab1.idFinalizadora from pedido tab,metodo tab1 where tab.idMetodo=tab1.idMetodo and idPedido=?pedido and idLoja=?store");
            addParametro("?pedido", reserva);
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
    public DataSet conector_find_pedido_expire(string reserva, string store,string dmais1, string dmais2)
    {
        try
        {
            auxConsistencia = 0;
            abreConexao();
            //singleTransaction("select idPedido from pedido where flagFormaFinalizacao='P' and (idPedido=?pedido or ?pedido=0) and idLoja=?store and status=10 and emissao <= ADDDATE(now(), -" + dmais2 + ")"); OLD
            //singleTransaction("select sequenciaPreVenda from pedido where status in(10,3,4) and flagFormaFinalizacao='P' and (idPedido=?pedido or ?pedido=0) and idLoja=?store and emissao <= ADDDATE(now(), -" + dmais2 + ")");
            //Last singleTransaction("select sequenciaPreVenda from conector.pedido where status in(10,3,4) and flagFormaFinalizacao='P' and idLoja=1 and emissao between  ADDDATE(now(), -" + dmais1 + ") and ADDDATE(now(), -" + dmais2 + ")");
            singleTransaction("select coalesce(sequenciaPreVenda,0) from conector.pedido where status in(10,3,4) and flagFormaFinalizacao='P' and idLoja=" + store + " and emissao <= ADDDATE(now(), -" + dmais2 + ")");

            //singleTransaction("select sequenciaPreVenda,emissao from conector.pedido where status in(10,3,4) and flagFormaFinalizacao='P' and idLoja=1 and emissao < '20150703'");
            addParametro("?pedido", reserva);
            addParametro("?store", store);
            addParametro("?dmais1", dmais1);
            addParametro("?dmais2", dmais2);
            procedimentoSet();
        }
        catch (Exception e)
        {
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
            auxConsistencia = 1;
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
    //##############################################################End Metodos e Funções#################################################
}
