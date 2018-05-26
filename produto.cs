using Sytsem;
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
            if (banco.retornaRead().Read() == true)
            {
                newCodigoProduto = banco.retornaRead().GetString(0);
            }
            banco.fechaRead();
            banco.commit();
        }
        catch (Exception erro)
        {
            banco.rollback();
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
            auxConsistencia = 1;
        }
        finally
        {
            banco.fechaConexao();
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
            banco.abreConexao();
            banco.iniciarTransacao();
            banco.startTransaction("conector_inc_spedncm");
            banco.addParametro("ncm", ncm);
            banco.addParametro("inc_descricao", descricao);
            banco.addParametro("inc_mvaMain", mva);
            banco.addParametro("inc_aliquotaInterestadual", interestadual);
            banco.addParametro("inc_aliquotaInterna", interna);
            banco.addParametro("inc_mvaAjustada", ajuste);
            banco.procedimentoRead();
            if (banco.retornaRead().Read() == true)
            {

            }
            banco.fechaRead();
            banco.commit();
        }
        catch (Exception erro)
        {
            banco.rollback();
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
            auxConsistencia = 1;
        }
        finally
        {
            banco.fechaConexao();
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
            banco.abreConexao();
            banco.iniciarTransacao();
            banco.startTransaction("conector_alt_spedncm");
            banco.addParametro("ncm", ncm);
            banco.addParametro("newdescricao", descricao);
            banco.addParametro("newmvaMain", mva);
            banco.addParametro("newaliquotaInterestadual", interestadual);
            banco.addParametro("newaliquotaInterna", interna);
            banco.addParametro("newmvaAjustada", ajuste);
            banco.procedimentoRead();
            if (banco.retornaRead().Read() == true)
            {

            }
            banco.fechaRead();
            banco.commit();
        }
        catch (Exception erro)
        {
            banco.rollback();
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
            auxConsistencia = 1;
        }
        finally
        {
            banco.fechaConexao();
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
    protected void conector_alt_price(string chave,
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
            banco.abreConexao();
            banco.iniciarTransacao();
            banco.startTransaction("conector_alt_price");
            banco.addParametro("find_produto", chave);
            banco.addParametro("find_loja", store);
            banco.addParametro("new_custo", custo.Replace(",", "."));
            banco.addParametro("new_Price", price.Replace(",", "."));
            banco.addParametro("new_status", "0");
            banco.addParametro("new_lucroLiquido", lucroliquido.Replace(",", "."));
            banco.addParametro("new_lucroBruto", lucroBruto.Replace(",", "."));
            banco.addParametro("new_margem", margem);
            banco.addParametro("new_margemLiquida", margemLiquida.Replace(",", "."));
            banco.addParametro("new_margemBruta", margemBruta.Replace(",", "."));
            banco.addParametro("new_sugestao", sugestao.Replace(",", "."));
            banco.addParametro("new_pendente", "n");
            banco.procedimentoRead();
            banco.fechaRead();
            banco.commit();
        }
        catch (Exception erro)
        {
            banco.rollback();
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
            auxConsistencia = 1;
        }
        finally
        {
            banco.fechaConexao();
            if (auxConsistencia == 0)
            {
                flagSemaforo = 1;
            }
        }
    }
    /// <summary>
    /// DESENVOLVEDOR : Flavio
    /// FUNCAO {conector_alt_produto} sem parametros
    /// DATA : 11/10/13
    /// ENFOQUE : reutilizar metodo para alterar produto usando procedure do banco de dados 
    /// </summary>
    protected void conector_alt_produto(                        string new_idProduto,           
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
                                    string new_marca)
    {
        auxConsistencia = 0;
        try
        {
            banco.abreConexao();
            banco.iniciarTransacao();
            banco.startTransaction("conector_alt_produto");
            banco.addParametro("new_idProduto", new_idProduto);
            banco.addParametro("new_idloja", new_idloja);
            banco.addParametro("new_nome", new_nome);
            banco.addParametro("new_nomePdv", new_nomePdv);
            banco.addParametro("new_nomeFull", new_nomeFull);
            banco.addParametro("new_observacao", new_observacao);
            banco.addParametro("new_status", new_status);
            banco.addParametro("new_dataAlteracao", new_dataAlteracao);
            banco.addParametro("new_idSetor", new_idSetor);
            banco.addParametro("new_idGrupo", new_idGrupo);
            banco.addParametro("new_idCategoria", new_idCategoria == "" ? "0" : new_idCategoria);
            banco.addParametro("new_idfornecedor", new_idfornecedor == "" ? "0" : new_idfornecedor);
            banco.addParametro("new_idUsuarioAlt", new_idUsuarioAlt);
            banco.addParametro("new_qttyObrigatoria", new_qttyObrigatoria);
            banco.addParametro("new_qttyMaximaVenda", new_qttyMaximaVenda);
            banco.addParametro("new_descontoIndividual", new_descontoIndividual == "" ? "0" : new_descontoIndividual);
            banco.addParametro("new_restrito", new_restrito);
            banco.addParametro("new_idunidade", new_idunidade);
            banco.addParametro("new_tipo", new_tipo);
            banco.addParametro("new_incideIpi", new_incideIpi);
            banco.addParametro("new_inputCfop", new_inputCfop);
            banco.addParametro("new_outputCfop", new_outputCfop);
            banco.addParametro("new_permitiMultiplicacao", new_permitiMultiplicacao);
            banco.addParametro("new_marca", new_marca == "" ? "0" : new_marca);
            banco.procedimentoRead();
            banco.fechaRead();
            banco.commit();
        }
        catch (Exception erro)
        {
            banco.rollback();
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
            auxConsistencia = 1;
        }
        finally
        {
            banco.fechaConexao();
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
    protected void conector_alt_produtoImpostos(string newImpidProduto,
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
            banco.abreConexao();
            banco.iniciarTransacao();
            banco.startTransaction("conector_alt_produtoImpostos");
            banco.addParametro("newImpidProduto", newImpidProduto);
            banco.addParametro("newImpidloja", newImpidloja);
            banco.addParametro("newImptributacao", newImptributacao);
            banco.addParametro("newImptributacao1", newImptributacao1);
            banco.addParametro("newImptributacao2", newImptributacao2);
            banco.addParametro("newImpidpisCofins", newImpidpisCofins == "" ? "0" : newImpidpisCofins); //Rever
            banco.addParametro("newImpcst", newImpcst);
            banco.addParametro("newImpcstSaida", newImpcstSaida);//CST DEFAULT PARA SAIDA DE IPI
            banco.addParametro("newImpcstEntrada", newImpcstEntrada);//CST DEFAULT PARA ENTRADA DE IPI
            banco.addParametro("newImppauta", "0");
            banco.addParametro("newImpipi", newImpipi);
            banco.addParametro("newImpipiValor", newImpipiValor);
            banco.addParametro("newImpspedNcm", newImpspedNcm);
            banco.addParametro("newImpimpMercadoInterno", "0");
            banco.addParametro("newImpcsosn", "0");
            banco.addParametro("newImpidtypeItem", newImpidtypeItem == "" ? "00" : newImpidtypeItem);
            banco.addParametro("newImpidGenero", newImpidGenero == "" ? "98" : newImpidGenero);
            banco.addParametro("newreducaoCalcEspecial", newreducaoCalcEspecial);
            banco.addParametro("newippt", newippt);
            if (newIdTipoProduto != null)
            {
                banco.procedimentoRead();
            }
            banco.fechaRead();
            banco.commit();

        }
        catch (Exception erro)
        {
            banco.rollback();
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            banco.fechaConexao();
            if (auxConsistencia == 0)
            {
                
            }
        }
    }
    /// <summary>
    /// DESENVOLVEDOR : Flavio
    /// FUNCAO {conector_alt_produtoPrice} sem parametros
    /// DATA : 11/10/13
    /// ENFOQUE : reutilizar metodo para alterar preco do produto de acordo com a loja usando procedure do banco de dados 
    /// </summary>
    protected void conector_alt_produtoPrice(string newidProduto,
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
            banco.abreConexao();
            banco.iniciarTransacao();
            banco.startTransaction("conector_alt_produtoPrice");
            banco.addParametro("newidProduto", newidProduto);
            banco.addParametro("newidloja", newidloja);
            banco.addParametro("newpriceFull", newpriceFull.Replace(",", "."));
            banco.addParametro("newpriceVenda", newpriceVenda.Replace(",", "."));
            banco.addParametro("newpricePendente", newpricePendente.Replace(",", "."));
            banco.addParametro("newcreditoIcms", newcreditoIcms.Replace(",", "."));
            banco.addParametro("newcreditoRedIcms", newcreditoRedIcms.Replace(",", "."));
            banco.addParametro("newcreditoPis", "1.74"); //Provisorio
            banco.addParametro("newcreditoCofins", "8.75");//Provisorio
            banco.addParametro("newcreditoOutros", newcreditoOutros.Replace(",", "."));
            banco.addParametro("newprimeiroDesconto", newprimeiroDesconto.Replace(",", "."));
            banco.addParametro("newsegundoDesconto", newsegundoDesconto.Replace(",", "."));
            banco.addParametro("newterceiroDesconto", newterceiroDesconto.Replace(",", "."));
            banco.addParametro("newdebitoIcms", newdebitoIcms.Replace(",", "."));
            banco.addParametro("newdebitoRedIcms", newdebitoRedIcms.Replace(",", "."));
            banco.addParametro("newlucroLiquido", newlucroLiquido.Replace(",", "."));
            banco.addParametro("newlucroBruto", newlucroBruto.Replace(",", "."));
            banco.addParametro("newcustoBruto", newpriceFull.Replace(",", ".")); //provisorio falta soma
            banco.addParametro("newcustoliquido", newcustoliquido.Replace(",", "."));
            banco.addParametro("newcustoMedio", newcustoMedio.Replace(",", "."));
            banco.addParametro("newIpiPorcentagem", newIpiPorcentagem.Replace(",", "."));
            banco.addParametro("newmoedaIpi", newmoedaIpi.Replace(",", "."));
            banco.addParametro("newmoedaFrete", newmoedaFrete.Replace(",", "."));
            banco.addParametro("newfretePorcentagem", newfretePorcentagem.Replace(",", "."));
            banco.addParametro("newcomissao", newcomissao.Replace(",", "."));
            banco.addParametro("newpriceSugestao", newpriceSugestao.Replace(",", "."));
            banco.addParametro("newsubstituicaoPorcetagem", newsubstituicaoPorcetagem.Replace(",", "."));
            banco.addParametro("newacrescimoSubstituicao", "0"); //Provisorio
            banco.addParametro("newmoedaSubstituicao", newmoedaSubstituicao.Replace(",", "."));
            banco.addParametro("newbonificacaoDesconto", newbonificacaoDesconto.Replace(",", "."));
            banco.addParametro("newmoedaBonificacao", newmoedaBonificacao.Replace(",", "."));
            banco.addParametro("newmargem", newMargemBruta.Replace(",", "."));
            banco.addParametro("newdescontoMaximo", newdescontoMaximo == "" ? "0" : newdescontoMaximo);
            banco.addParametro("newdespesasTributadas", "0");//provisorio
            banco.addParametro("newdespesaNaoTributadas", "0");//provisorio
            banco.addParametro("newcontribuicao", newcontribuicao.Replace(",", "."));
            banco.addParametro("newvendo", newvendo.Replace(",", "."));
            banco.addParametro("newfinanceiro", newfinanceiro.Replace(",", "."));
            banco.addParametro("newdespesaFixa", newdespesaFixa.Replace(",", "."));
            banco.addParametro("newstatusPrice", newstatusPrice);
            banco.addParametro("newdescontoValor", String.Format("{0:F2}", (Convert.ToDecimal(newprimeiroDesconto.Replace(",", ".")) + Convert.ToDecimal(newsegundoDesconto.Replace(",", ".")) + Convert.ToDecimal(newterceiroDesconto.Replace(",", "."))).ToString()));
            banco.addParametro("newMargemBruta", newMargemBruta.Replace(",", "."));
            banco.addParametro("newMargemLiquida", newMargemLiquidaProduto.Replace(",", "."));
            banco.addParametro("newtrunca", auxIATProduto);
            //newmargem != txtMargemVendaProduto.Text
            banco.procedimentoRead();
            banco.fechaRead();
            banco.commit();
        }
        catch (Exception erro)
        {
            banco.rollback();
            throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
        }
        finally
        {
            banco.fechaConexao();
            if (auxConsistencia == 0)
            {
            }
        }
    }
}
