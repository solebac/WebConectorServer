using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for produto
/// </summary>
public class produto : dados
{
    public produto()
    {
        dsResultado = new DataSet();
    }
    //##############################################################Variaveis#############################################################
    private DataSet dsResultado;
    private int auxConsistencia = 0;
    private int result = -1;
    //##############################################################End Variaveis#########################################################

    //########################################################Procedimento de Banco#######################################################

    public void conector_alt_ean(string newIdProduto, string newBarra, string oldBarra, string newIdUnidadeMedida, string newquantidade, string newDefaultVenda, string newDefaultCompra, string newDefaultTransferencia, string newTypeEan)
    {
        try
        {
            auxConsistencia = 0;
            abreConexao();
            iniciarTransacao();
            startTransaction("conector_alt_ean");
            addParametro("newIdProduto", newIdProduto);
            addParametro("newBarra", newBarra);
            addParametro("oldBarra", oldBarra);
            addParametro("newIdUnidadeMedida", newIdUnidadeMedida);
            addParametro("newquantidade", newquantidade);
            addParametro("newDefaultVenda", newDefaultVenda);
            addParametro("newDefaultCompra", newDefaultCompra);
            addParametro("newDefaultTransferencia", newDefaultTransferencia);
            addParametro("newStatus", "1");
            addParametro("newTypeEan", newTypeEan);
            procedimentoRead();
            fechaRead();
            commit();
        }
        catch (Exception e)
        {
            rollback();
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            fechaConexao();
        }
    }
    public void conector_inc_ean(string inc_idproduto,string inc_barra,string inc_idunidadeMedida, string inc_quantidade, string inc_defaultVenda, string inc_defaultCompra, string inc_defaultTransferencia, string inc_typeEan)
    {
        try
        {
            abreConexao();
            iniciarTransacao();
            startTransaction("conector_inc_ean");
            addParametro("inc_idproduto", inc_idproduto);
            addParametro("inc_barra", inc_barra);
            addParametro("inc_idunidadeMedida", inc_idunidadeMedida);
            addParametro("inc_quantidade", inc_quantidade);
            addParametro("inc_defaultVenda", inc_defaultVenda);
            addParametro("inc_defaultCompra", inc_defaultCompra);
            addParametro("inc_defaultTransferencia", inc_defaultTransferencia);
            addParametro("inc_status", "1");
            addParametro("inc_typeEan", inc_typeEan);
            procedimentoRead();
            fechaRead();
            commit();
        }
        catch (Exception e)
        {
            rollback();
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            fechaConexao();
        }
    }

    public string conector_inc_produto(string auxTipoCodigo, string descricao)
    {
        auxConsistencia = 0;
        string newCodigoProduto = "0";
        try
        {
            abreConexao();
            iniciarTransacao();
            startTransaction("conector_inc_produto");
            addParametro("aux", Convert.ToString(auxTipoCodigo));
            addParametro("inc_nome", descricao);
            addParametro("inc_dataInclusao", String.Format("{0:yyyyMMdd}", DateTime.Now));
            addParametro("inc_dataAlteracao", String.Format("{0:yyyyMMdd}", DateTime.Now));
            addParametro("inc_tipo", auxTipoCodigo.ToString());
            procedimentoRead();
            if (retornaRead().Read() == true)
            {
                newCodigoProduto = retornaRead().GetString(0);
            }
            fechaRead();
            commit();
        }
        catch (Exception e)
        {
            rollback();
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            fechaConexao();
            // controle_objetos();
            if (auxConsistencia == 0)
            {
            }
            else
            {
                newCodigoProduto = "0";
            }
        }
        return newCodigoProduto;
    }

    /// <summary>
    /// DESENVOLVEDOR : Flavio
    /// FUNCAO {conector_inc_spedncm} com parametros(string)
    /// DATA : 11/10/13
    /// ENFOQUE : reutilizar metodo para incluir ncm usando procedure do banco de dados. 
    /// </summary>      
    public void conector_inc_spedncm(string ncm, string descricao, string mva, string interestadual, string interna, string ajuste)
    {
        auxConsistencia = 0;
        try
        {
            abreConexao();
            iniciarTransacao();
            startTransaction("conector_inc_spedncm");
            addParametro("ncm", ncm);
            addParametro("inc_descricao", descricao);
            addParametro("inc_mvaMain", mva);
            addParametro("inc_aliquotaInterestadual", interestadual);
            addParametro("inc_aliquotaInterna", interna);
            addParametro("inc_mvaAjustada", ajuste);
            procedimentoSet();
            /*procedimentoRead();
            if (retornaRead().Read() == true)
            {

            }*/
            fechaRead();
            commit();
        }
        catch (Exception e)
        {
            rollback();
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            fechaConexao();
            if (auxConsistencia == 0)
            {
            }
        }
    }
    /// <summary>
    /// DESENVOLVEDOR : Flavio
    /// FUNCAO {conector_alt_spedncm} com 6 parametros(string)
    /// DATA : 11/10/13
    /// ENFOQUE : reutilizar metodo para alterar ncm usando procedure do banco de dados 
    /// </summary>
    public void conector_alt_spedncm(string ncm, string descricao, string mva, string interestadual, string interna, string ajuste)
    {
        auxConsistencia = 0;
        try
        {
            abreConexao();
            iniciarTransacao();
            startTransaction("conector_alt_spedncm");
            addParametro("ncm", ncm);
            addParametro("newdescricao", descricao);
            addParametro("newmvaMain", mva);
            addParametro("newaliquotaInterestadual", interestadual);
            addParametro("newaliquotaInterna", interna);
            addParametro("newmvaAjustada", ajuste);
            procedimentoSet();
            /*procedimentoRead();
            if (retornaRead().Read() == true)
            {

            }*/
            //fechaRead();
            commit();
        }
        catch (Exception e)
        {
            rollback();
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            fechaConexao();
            if (auxConsistencia == 0)
            {

            }
        }
    }
    /// <summary>
    /// DESENVOLVEDOR : Flavio
    /// FUNCAO {conector_alt_price} sem parametros
    /// DATA : 11/10/13
    /// ENFOQUE : reutilizar metodo para alterar preco usando procedure do banco de dados 
    /// </summary>
    public void conector_alt_price(string chave,
                                      string store,
        string custo,
        string price,
        string status,
        string lucroliquido,
        string lucroBruto,
        string margem,
        string margemLiquida,
        string margemBruta,
        string sugestao,
        string pendente)
    {
        auxConsistencia = 0;
        try
        {
            abreConexao();
            iniciarTransacao();
            startTransaction("conector_alt_price");
            addParametro("find_produto", chave);
            addParametro("find_loja", store);
            addParametro("new_custo", custo.Replace(",", "."));
            addParametro("new_Price", price.Replace(",", "."));
            addParametro("new_status", "0");
            addParametro("new_lucroLiquido", lucroliquido.Replace(",", "."));
            addParametro("new_lucroBruto", lucroBruto.Replace(",", "."));
            addParametro("new_margem", margem);
            addParametro("new_margemLiquida", margemLiquida.Replace(",", "."));
            addParametro("new_margemBruta", margemBruta.Replace(",", "."));
            addParametro("new_sugestao", sugestao.Replace(",", "."));
            addParametro("new_pendente", "n");
            procedimentoSet();
            //fechaRead();
            commit();
        }
        catch (Exception e)
        {
            rollback();
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
          
        }
        finally
        {
            fechaConexao();
            if (auxConsistencia == 0)
            {
            }
        }
    }
    /// <summary>
    /// DESENVOLVEDOR : Flavio
    /// FUNCAO {conector_alt_produto} sem parametros
    /// DATA : 11/10/13
    /// ENFOQUE : reutilizar metodo para alterar produto usando procedure do banco de dados 
    /// </summary>
    public void conector_alt_produto(string new_idProduto,
                                    string new_idloja,
                                    string new_nome,
                                    string new_nomePdv,
                                    string new_nomeFull,
                                    string new_observacao,
                                    string new_status,
                                    string new_dataAlteracao,
                                    string new_idSetor,
                                    string new_idGrupo,
                                    string new_idCategoria,
                                    string new_idfornecedor,
                                    string new_idUsuarioAlt,
                                    string new_qttyObrigatoria,
                                    string new_qttyMaximaVenda,
                                    string new_descontoIndividual,
                                    string new_restrito,
                                    string new_idunidade,
                                    string new_tipo,
                                    string new_incideIpi,
                                    string new_inputCfop,
                                    string new_outputCfop,
                                    string new_permitiMultiplicacao,
                                    string new_marca, string new_referencia)
    {
        auxConsistencia = 0;
        try
        {
            abreConexao();
            iniciarTransacao(); 
            startTransaction("conector_alt_produto");
            addParametro("new_idProduto", new_idProduto);
            addParametro("new_idloja", new_idloja);
            addParametro("new_nome", new_nome);
            addParametro("new_nomePdv", new_nomePdv);
            addParametro("new_nomeFull", new_nomeFull);
            addParametro("new_observacao", new_observacao);
            addParametro("new_status", new_status);
            addParametro("new_dataAlteracao", new_dataAlteracao);
            addParametro("new_idSetor", new_idSetor);
            addParametro("new_idGrupo", new_idGrupo);
            addParametro("new_idCategoria", new_idCategoria == "" ? "0" : new_idCategoria);
            addParametro("new_idfornecedor", new_idfornecedor == "" ? "0" : new_idfornecedor);
            addParametro("new_idUsuarioAlt", new_idUsuarioAlt);
            addParametro("new_qttyObrigatoria", new_qttyObrigatoria);
            addParametro("new_qttyMaximaVenda", new_qttyMaximaVenda);
            addParametro("new_descontoIndividual", new_descontoIndividual == "" ? "0" : new_descontoIndividual);
            addParametro("new_restrito", new_restrito);
            addParametro("new_idunidade", new_idunidade);
            addParametro("new_tipo", new_tipo);
            addParametro("new_incideIpi", new_incideIpi);
            addParametro("new_inputCfop", new_inputCfop);
            addParametro("new_outputCfop", new_outputCfop);
            addParametro("new_permitiMultiplicacao", new_permitiMultiplicacao);
            addParametro("new_marca", new_marca == "" ? "0" : new_marca);
            addParametro("new_referencia", new_referencia == "" ? "0" : new_referencia);
            procedimentoSet();
            commit();
        }
        catch (Exception e)
        {
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            fechaConexao();
            if (auxConsistencia == 0)
            {
            }
        }
    }
    /// <summary>
    /// DESENVOLVEDOR : Flavio
    /// FUNCAO {conector_alt_produtoImpostos} sem parametros
    /// DATA : 11/10/13
    /// ENFOQUE : reutilizar metodo para alterar impostos dos produtos usando procedure do banco de dados 
    /// </summary>
    public void conector_alt_produtoImpostos(string newImpidProduto,
                     string newImpidloja,
                     string newImptributacao,
                     string newImptributacao1,
                     string newImptributacao2,
                     string newImpidpisCofins,
                     string newImpcst,
                     string newImpcstSaida,
                     string newImpcstEntrada,
                     string newImppauta,
                     string newImpipi,
                     string newImpipiValor,
                     string newImpspedNcm,
                     string newImpimpMercadoInterno,
                     string newImpcsosn,
                     string newImpidtypeItem,
                     string newImpidGenero,
                     string newreducaoCalcEspecial,
                     string newippt)
    {
        auxConsistencia = 0;
        try
        {
            abreConexao();
            iniciarTransacao();
            startTransaction("conector_alt_produtoImpostos");
            addParametro("newImpidProduto", newImpidProduto);
            addParametro("newImpidloja", newImpidloja);
            addParametro("newImptributacao", newImptributacao);
            addParametro("newImptributacao1", newImptributacao1);
            addParametro("newImptributacao2", newImptributacao2);
            addParametro("newImpidpisCofins", newImpidpisCofins == "" ? "0" : newImpidpisCofins); //Rever
            addParametro("newImpcst", newImpcst);
            addParametro("newImpcstSaida", newImpcstSaida);//CST DEFAULT PARA SAIDA DE IPI
            addParametro("newImpcstEntrada", newImpcstEntrada);//CST DEFAULT PARA ENTRADA DE IPI
            addParametro("newImppauta", "0");
            addParametro("newImpipi", newImpipi);
            addParametro("newImpipiValor", newImpipiValor);
            addParametro("newImpspedNcm", newImpspedNcm);
            addParametro("newImpimpMercadoInterno", "0");
            addParametro("newImpcsosn", "0");
            addParametro("newImpidtypeItem", newImpidtypeItem == "" ? "00" : newImpidtypeItem);
            addParametro("newImpidGenero", newImpidGenero == "" ? "98" : newImpidGenero);
            addParametro("newreducaoCalcEspecial", newreducaoCalcEspecial);
            addParametro("newippt", newippt);
            if (newImpidProduto != null)
            {
                procedimentoSet();
            }

            commit();

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
    /// <summary>
    /// DESENVOLVEDOR : Flavio
    /// FUNCAO {conector_alt_produtoPrice} sem parametros
    /// DATA : 11/10/13
    /// ENFOQUE : reutilizar metodo para alterar preco do produto de acordo com a loja usando procedure do banco de dados 
    /// </summary>
    public void conector_alt_produtoPrice(string newidProduto,
            string newidloja,
            string newpriceFull,
            string newpriceVenda,
            string newpricePendente,
            string newcreditoIcms,
            string newcreditoRedIcms,
            string newcreditoPis,
            string newcreditoCofins,
            string newcreditoOutros,
            string newprimeiroDesconto,
            string newsegundoDesconto,
            string newterceiroDesconto,
            string newdebitoIcms,
            string newdebitoRedIcms,
            string newlucroLiquido,
            string newlucroBruto,
            string newcustoBruto,
            string newcustoliquido,
            string newcustoMedio,
            string newIpiPorcentagem,
            string newmoedaIpi,
            string newmoedaFrete,
            string newfretePorcentagem,
            string newcomissao,
            string newpriceSugestao,
            string newsubstituicaoPorcetagem,
            string newacrescimoSubstituicao,
            string newmoedaSubstituicao,
            string newbonificacaoDesconto,
            string newmoedaBonificacao,
            string newmargem,
            string newdescontoMaximo,
            string newdespesasTributadas,
            string newdespesaNaoTributadas,
            string newcontribuicao,
            string newvendo,
            string newfinanceiro,
            string newdespesaFixa,
            string newstatusPrice,
            string newdescontoValor,
            string newMargemBruta,
            string newMargemLiquida,
            string newtrunca)
    {
        auxConsistencia = 0;
        try
        {
            abreConexao();
            iniciarTransacao();
            startTransaction("conector_alt_produtoPrice");
            addParametro("newidProduto", newidProduto);
            addParametro("newidloja", newidloja);
            addParametro("newpriceFull", newpriceFull.Replace(",", "."));
            addParametro("newpriceVenda", newpriceVenda.Replace(",", "."));
            addParametro("newpricePendente", newpricePendente.Replace(",", "."));
            addParametro("newcreditoIcms", newcreditoIcms.Replace(",", "."));
            addParametro("newcreditoRedIcms", newcreditoRedIcms.Replace(",", "."));
            addParametro("newcreditoPis", "1.74"); //Provisorio
            addParametro("newcreditoCofins", "8.75");//Provisorio
            addParametro("newcreditoOutros", newcreditoOutros.Replace(",", "."));
            addParametro("newprimeiroDesconto", newprimeiroDesconto.Replace(",", "."));
            addParametro("newsegundoDesconto", newsegundoDesconto.Replace(",", "."));
            addParametro("newterceiroDesconto", newterceiroDesconto.Replace(",", "."));
            addParametro("newdebitoIcms", newdebitoIcms.Replace(",", "."));
            addParametro("newdebitoRedIcms", newdebitoRedIcms.Replace(",", "."));
            addParametro("newlucroLiquido", newlucroLiquido.Replace(",", "."));
            addParametro("newlucroBruto", newlucroBruto.Replace(",", "."));
            addParametro("newcustoBruto", newpriceFull.Replace(",", ".")); //provisorio falta soma
            addParametro("newcustoliquido", newcustoliquido.Replace(",", "."));
            addParametro("newcustoMedio", newcustoMedio.Replace(",", "."));
            addParametro("newIpiPorcentagem", newIpiPorcentagem.Replace(",", "."));
            addParametro("newmoedaIpi", newmoedaIpi.Replace(",", "."));
            addParametro("newmoedaFrete", newmoedaFrete.Replace(",", "."));
            addParametro("newfretePorcentagem", newfretePorcentagem.Replace(",", "."));
            addParametro("newcomissao", newcomissao.Replace(",", "."));
            addParametro("newpriceSugestao", newpriceSugestao.Replace(",", "."));
            addParametro("newsubstituicaoPorcetagem", newsubstituicaoPorcetagem.Replace(",", "."));
            addParametro("newacrescimoSubstituicao", "0"); //Provisorio
            addParametro("newmoedaSubstituicao", newmoedaSubstituicao.Replace(",", "."));
            addParametro("newbonificacaoDesconto", newbonificacaoDesconto.Replace(",", "."));
            addParametro("newmoedaBonificacao", newmoedaBonificacao.Replace(",", "."));
            addParametro("newmargem", newMargemBruta.Replace(",", "."));
            addParametro("newdescontoMaximo", newdescontoMaximo == "" ? "0" : newdescontoMaximo);
            addParametro("newdespesasTributadas", "0");//provisorio
            addParametro("newdespesaNaoTributadas", "0");//provisorio
            addParametro("newcontribuicao", newcontribuicao.Replace(",", "."));
            addParametro("newvendo", newvendo.Replace(",", "."));
            addParametro("newfinanceiro", newfinanceiro.Replace(",", "."));
            addParametro("newdespesaFixa", newdespesaFixa.Replace(",", "."));
            addParametro("newstatusPrice", newstatusPrice);
            addParametro("newdescontoValor", String.Format("{0:F2}", (Convert.ToDecimal(newprimeiroDesconto.Replace(",", ".")) + Convert.ToDecimal(newsegundoDesconto.Replace(",", ".")) + Convert.ToDecimal(newterceiroDesconto.Replace(",", "."))).ToString()));
            addParametro("newMargemBruta", newMargemBruta.Replace(",", "."));
            addParametro("newMargemLiquida", newMargemLiquida.Replace(",", "."));
            addParametro("newtrunca", newtrunca);
            //newmargem != txtMargemVendaProduto.Text
            procedimentoSet();
            commit();
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
}
