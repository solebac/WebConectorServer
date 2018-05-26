using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
        dsResultado = new DataSet();
        result = -1;
    }
    //#####################################################Variaveis Encapsuladas##################################################
    private DataSet dsResultado;
    private int result;
    //#####################################################End Variaveis Encapsuladas##############################################
    //[WebMethod(Description = "Number of times this service has been accessed",
    //CacheDuration = 60, MessageName = "ServiceUsage")]


    [WebMethod]
    public int ObterResultCheque(string conta, string serie, string agencia, string banco, string numeroCheque)
    {
        pepleo objPessoa = new pepleo();
        return objPessoa.conector_verifica_cheque(conta, serie, agencia, banco, numeroCheque);
    }

    [WebMethod]
    public DataSet ObterPedido(string pedido, string store, string tipo)
    {
        pedido objPedido = new pedido();
        if (tipo == "0")
        {
            dsResultado = objPedido.conector_find_pedido_dav(pedido, store);
        }
        else
        {
            dsResultado = objPedido.conector_find_pedido_Prevenda(pedido, store);
        }
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterPedidoLog(string pedido, string store)
    {
        pedido objPedidoLog = new pedido();
        dsResultado = objPedidoLog.conector_find_pedido_log(pedido, store);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterPedidoExpire(string pedido, string store,string dmais1, string dmais2)
    {
        if (dmais2 == "")
        {
            dmais2 = 1.ToString();
        }
        pedido objPedidoEx = new pedido();
        dsResultado = objPedidoEx.conector_find_pedido_expire(pedido, store,dmais1, dmais2);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterPedidoItens(string pedido, string store)
    {
        pedido objPedido = new pedido();
        dsResultado = objPedido.conector_find_pedidoItens(pedido, store);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterPedidoFinanceiro(string pedido, string store)
    {
        pedido objPedido = new pedido();
        dsResultado = objPedido.conector_find_pedidoFinanceiro(pedido, store);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterPedidoParcelamento(int escolha, string pedido, string store)
    {
        DataSet dsResultado = new DataSet();
        pedido objPedido = new pedido();

        switch (escolha)
        {
            case 1:
                break;
            case 2:
                dsResultado = objPedido.conector_find_pedidoCheque(pedido, store);
                break;
            case 3:
                dsResultado = objPedido.conector_find_pedidoCrediario(pedido, store);
                break;
            case 4:
                dsResultado = objPedido.conector_find_pedidoConvenio(pedido, store);
                break;
            case 5:
                dsResultado = objPedido.conector_find_pedidoCartao(pedido, store);
                break;
            case 6:
                dsResultado = objPedido.conector_find_pedidoCartao(pedido, store);
                break;
            case 7:
                dsResultado = objPedido.conector_find_pedidoBoleto(pedido, store);
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            default:
                break;
        }
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterPedidoEntrega(string pedido, string store)
    {
        pedido objPedido = new pedido();
        dsResultado = objPedido.conector_find_pedidoEntrega(pedido, store);
        return dsResultado;
    }

    [WebMethod]
    public void AlteraStatusPedido(string pedido, string store)
    {
        pedido objPedido = new pedido();
        objPedido.conector_between_financeiroXitens(pedido, store);
    }

    [WebMethod]
    public void AlteraStatusPedidoFinal(string reserva, string store, string final, string status, string sinal)
    {
        pedido objPedido = new pedido();
        objPedido.conector_alt_statusPedido(reserva, store, final, status, sinal);
    }

    [WebMethod]
    public int VerificaStatusPedido(string pedido, string store)
    {
        pedido objPedido = new pedido();
        result = objPedido.conector_verifica_status_pedido(pedido, store);
        return result;
    }

    [WebMethod]
    public int VerificaFinalPedido(string pedido, string store)
    {
        pedido objPedido = new pedido();
        result = objPedido.conector_verifica_final_pedido(pedido, store);
        return result;
    }

    [WebMethod]
    public int VerificaFinalizadoraPedido(string pedido, string store)
    {
        pedido objPedido = new pedido();
        result = objPedido.conector_verifica_finalizadora_pedido(pedido, store);
        return result;
    }

    [WebMethod]
    public DataSet ObterCrediario(string crediario, string store)
    {
        crediario objCrediario = new crediario();
        dsResultado = objCrediario.conector_find_crediario(crediario, store);
        return dsResultado;
    }
    [WebMethod]
    public DataSet ObterParcelamento(string crediario, string store)
    {
        crediario objCrediario = new crediario();
        dsResultado = objCrediario.conector_find_parcelamento(crediario, store);
        return dsResultado;
    }
    [WebMethod]
    public DataSet ObterParcela(string crediario, string store, string parcela)
    {
        crediario objCrediario = new crediario();
        dsResultado = objCrediario.conector_find_parcela(crediario, store, parcela);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterDividento(string pessoa, string store, string carne, string prestacao, string tipo)
    {
        crediario objCrediario = new crediario();
        dsResultado = objCrediario.conector_consulta_dividento(pessoa, store, carne, prestacao, tipo);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterHistoricoFull(string tipo, string store, string pessoa, string auxFiltraDate, string di, string df)
    {
        crediario objCrediario = new crediario();
        dsResultado = objCrediario.conector_consulta_historico(tipo, store, pessoa, auxFiltraDate, di, df);
        return dsResultado;
    }

    [WebMethod]
    public void AlteraStatusParcelaCrediario(string crediario, string store, string parcela, string status)
    {
        crediario objCrediario = new crediario();
        objCrediario.conector_altera_status(crediario,store,parcela,status);
    }
    [WebMethod]
    public int verificaStatusParcelaCrediario(string crediario, string store, string parcela)
    {
        crediario objCrediario = new crediario();
        result = objCrediario.conector_verifica_status_parcela(crediario, store, parcela);
        return result;
    }
    [WebMethod]
    public int verificaStatusCrediario(string crediario, string store)
    {
        crediario objCrediario = new crediario();
        result = objCrediario.conector_verifica_status_crediario(crediario, store);
        return result;
    }
    [WebMethod]
    public int verificaExitsPepleo(string pepleo)
    {
        pepleo objPepleo = new pepleo();
        result = objPepleo.conector_verifica_exits_pepleo(pepleo);
        return result;
    }
    [WebMethod]
    public DataSet ObterPepleoSingle(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conectorPDV_consulta_pessoaSingle(pessoa);
        return dsResultado;
    }
    [WebMethod]
    public DataSet ObterMainPepleo(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_cliente(pessoa);
        return dsResultado;
    }
    [WebMethod]
    public DataSet ObterMainPepleoWorking(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_funcionarioFull(pessoa);
        return dsResultado;
    }
    [WebMethod]
    public DataSet ObterMainPepleoFisica(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_fisica(pessoa);
        return dsResultado;
    }
    [WebMethod]
    public DataSet ObterMainPepleoRural(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_rural(pessoa);
        return dsResultado;
    }
    [WebMethod]
    public DataSet ObterMainPepleoJuridica(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_juridica(pessoa);
        return dsResultado;
    }
    [WebMethod]
    public DataSet ObterFone(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_fone(pessoa);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterFoneFuncionario(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_foneWorking(pessoa);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterStore(string store)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_store(store);
        return dsResultado;
    }


    [WebMethod]
    public DataSet fornecedor_comercial(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_fornecedor_comercial(pessoa);
        return dsResultado;
    }

    [WebMethod]
    public DataSet fornecedorFiscal(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_fornecedor_fiscal(pessoa);
        return dsResultado;
    }

    [WebMethod]
    public DataSet fornecedorInfo(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_fornecedor_infor(pessoa);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterEndereco(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_endereco(pessoa);
        return dsResultado;
    }
    [WebMethod]
    public DataSet ObterEnderecoFuncionario(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_enderecoWorking(pessoa);
        return dsResultado;
    }
    [WebMethod]
    public DataSet ObterPepleoCobranca(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_clientecobranca(pessoa);
        return dsResultado;
    }
    [WebMethod]
    public DataSet ObterPepleoEntrega(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_clienteentrega(pessoa);
        return dsResultado;
    }
    [WebMethod]
    public DataSet ObterPepleoProfissional(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_clienteprofissional(pessoa);
        return dsResultado;
    }
    [WebMethod]
    public DataSet ObterPepleoReferencia(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_clientereferencia(pessoa);
        return dsResultado;
    }
    [WebMethod]
    public DataSet ObterPepleoRisco(string pessoa)
    {
        pepleo objPepleo = new pepleo();
        dsResultado = objPepleo.conector_find_clienteRisco(pessoa);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterNumNr(string store, string tipo)
    {
        pedido objPedido = new pedido();
        dsResultado = objPedido.conector_avanca_nota(store, tipo);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterEstoque(string find_produto, string tipo, string store)
    {
        estoque objEstoque = new estoque();
        dsResultado = objEstoque.conector_find_consultaProduto(find_produto, tipo, store);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterTerminal(string find_store, string find_terminal)
    {
        pepleo objPessoa = new pepleo();
        dsResultado = objPessoa.conector_find_terminal(find_store, find_terminal);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterCep(string find_cep)
    {
        pepleo objPessoa = new pepleo();
        dsResultado = objPessoa.conector_find_cep(find_cep);
        return dsResultado;
    }

        [WebMethod]
    public DataSet ObterMainTerminalWorking(string find_store, string find_terminal)
    {
        pepleo objPessoa = new pepleo();
        dsResultado = objPessoa.conector_find_terminalFull(find_store, find_terminal);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterFuncionarioDocumento(string find_doc)
    {
        pepleo objPessoa = new pepleo();
        dsResultado = objPessoa.conector_find_funcionario(find_doc);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterUsuario(string find)
    {
        pepleo objPessoa = new pepleo();
        dsResultado = objPessoa.conector_find_usuario(find);
        return dsResultado;
    }

    [WebMethod]
    public DataSet ObterPessoaDocumento(string find_doc, string tipo)
    {
        pepleo objPessoa = new pepleo();
        dsResultado = objPessoa.conector_find_pessoa(find_doc, tipo);
        return dsResultado;
    }

    [WebMethod]
    public int InserirFornecedorComercial(string replace_idComercial,
          string replace_idcliente,
          string replace_visita,
          string replace_analiseCompra,
          string replace_minVolume,
          string replace_valueBay,
          string replace_comprador,
          string replace_prazoEntrega,
          string replace_formaPgto,
          string replace_banco,
          string replace_agencia,
          string replace_contaCorrente)
    {
        pepleo objPessoa = new pepleo();
        int aux = objPessoa.conectorWeb_replace_paramentro_fornecedor_comercial(replace_idComercial,
                                                                                  replace_idcliente,
                                                                                  replace_visita,
                                                                                  replace_analiseCompra,
                                                                                  replace_minVolume,
                                                                                  replace_valueBay,
                                                                                  replace_comprador,
                                                                                  replace_prazoEntrega,
                                                                                  replace_formaPgto,
                                                                                  replace_banco,
                                                                                  replace_agencia,
                                                                                  replace_contaCorrente);

        return aux;
    }

    [WebMethod]
    public int InserirFornecedorFiscal(string replace_idfiscal,
                                        string replace_idcliente,
                                        string replace_forceIcms,
                                        string replace_forcePis,
                                        string replace_forceCofins,
                                        string replace_descatadaSt,
                                        string replace_typeGrade)
    {
        pepleo objPessoa = new pepleo();
        int aux = objPessoa.conectorWEB_replace_paramentro_fornecedor_fiscal(replace_idfiscal,
                                                                                    replace_idcliente,
                                                                                    replace_forceIcms,
                                                                                    replace_forcePis,
                                                                                    replace_forceCofins,
                                                                                    replace_descatadaSt,
                                                                                    replace_typeGrade);

        return aux;
    }

    [WebMethod]
    public int InserirFornecedorInfo(string replace_idInformacao,
                                                                         string replace_idcliente,
                                                                         string replace_typeTroca,
                                                                         string replace_typeFrete,
                                                                         string replace_porcentagemFrete,
                                                                         string replace_lastVisita,
                                                                         string replace_nextVisita,
                                                                         string replace_devPagar,
                                                                         string replace_bloquearEntregaFiscal,
                                                                         string replace_representante,
                                                                         string replace_idoperacao,
                                                                         string replace_forceCompra,
                                                                         string replace_nameSugestao,
                                                                         string replace_passwdSugestao,
                                                                         string replace_observacao,
                                                                         string replace_typeFornecedor)
    {
        pepleo objPessoa = new pepleo();
        int aux = objPessoa.conectorWEB_replace_paramentro_fornecedor_informacao(replace_idInformacao,
                                                                         replace_idcliente,
                                                                         replace_typeTroca,
                                                                         replace_typeFrete,
                                                                         replace_porcentagemFrete,
                                                                         replace_lastVisita,
                                                                         replace_nextVisita,
                                                                         replace_devPagar,
                                                                         replace_bloquearEntregaFiscal,
                                                                         replace_representante,
                                                                         replace_idoperacao,
                                                                         replace_forceCompra,
                                                                         replace_nameSugestao,
                                                                         replace_passwdSugestao,
                                                                         replace_observacao,
                                                                         replace_typeFornecedor);

        return aux;
    }

    [WebMethod]
    public int InserirPessoa(string idCliente,
                string idLoja,
                string idTipoPessoa,
                string idUsuario,
                string idAtividade,
                string observacao,
                string dataEmissao,
                string dataAlteracao,
                string idEstado,
                string uf,
                string status,
                string idSpedMunicipio,
                string idPais,
                string liberacao)
    {
        pepleo objPessoa = new pepleo();
        int aux = objPessoa.conectorPDV_replace_cliente(idCliente,
                idLoja,
                idTipoPessoa,
                idUsuario,
                idAtividade,
                observacao,
                dataEmissao,
                dataAlteracao,
                idEstado,
                uf,
                status,
                idSpedMunicipio,
                idPais,
                liberacao);

        return aux;
    }


    [WebMethod]
    public void AlteraPessoa(string auxIdCliente, string auxIdLoja, string flagTipopessoa, string Usuario, string flagAtividade, string obs, string dataEmissao, string inclusao, string auxIdEstado, string auxuf, string codMun, string status, string auxIdEndereco, string newGridcepCliente, string auxIdCepCliente, string bairro, string logradouro, string complemento, string city, string ufcliente, string number)
    {
        pepleo objPessoa = new pepleo();
        objPessoa.conector_alt_cliente(auxIdCliente, auxIdLoja, flagTipopessoa, Usuario, flagAtividade, obs, dataEmissao, inclusao, auxIdEstado, auxuf, codMun, status, auxIdEndereco, newGridcepCliente, auxIdCepCliente, bairro, logradouro, complemento, city, ufcliente, number);
    }

    [WebMethod]
    public void AlteraFisica(string alt_idcliente, string alt_cpf, string alt_idatividade, string alt_nome, string alt_nascimento, string alt_idsexo, string alt_identidade, string alt_idcivil)
    {
        pepleo objPessoa = new pepleo();
        objPessoa.conector_alt_fisica(alt_idcliente, alt_cpf, alt_idatividade, alt_nome, alt_nascimento, alt_idsexo, alt_identidade, alt_idcivil);
    }

    [WebMethod]
    public void AlteraJuridica(string alt_idcliente, string alt_cnpj, string alt_idatividade, string alt_razao, string alt_fantasia, string alt_ie, string alt_dataAbertura, string alt_idTipoFornecedor)
    {
        pepleo objPessoa = new pepleo();
        objPessoa.conector_alt_fisica(alt_idcliente, alt_cnpj, alt_idatividade, alt_razao, alt_fantasia, alt_ie, alt_dataAbertura, alt_idTipoFornecedor);
    }

    [WebMethod]
    public void AlteraRural(string alt_idcliente, string alt_cpf, string alt_idatividade, string alt_nome, string alt_identidade, string alt_ie, string alt_nascimento, string alt_idsexo, string alt_idcivil)
    {
        pepleo objPessoa = new pepleo();
        objPessoa.conector_alt_rural(alt_idcliente,  alt_cpf, alt_idatividade, alt_nome, alt_identidade, alt_ie, alt_nascimento, alt_idsexo, alt_idcivil);
    }

    [WebMethod]
    public int InserirFisica(string idCliente,
                string cpf,
                string idAtividade,
                string nome,
                string nascimento,
                string idSexo,
                string idEntidade,
                string idCivil)
    {
        pepleo objPessoa = new pepleo();
        int aux = objPessoa.conectorPDV_replace_fisica(idCliente,
                cpf,
                idAtividade,
                nome,
                nascimento,
                idSexo,
                idEntidade,
                idCivil);

        return aux;
    }

    [WebMethod]
    public int InserirRural(string idCliente,
                            string cpf,
                            string idAtividade,
                            string nome,
                            string ie,
                            string idEntidade,
                            string nascimento,
                            string idSexo,
                            string idCivil)
    {
        pepleo objPessoa = new pepleo();
        int aux = objPessoa.conectorPDV_replace_rural( idCliente,
                             cpf,
                             idAtividade,
                             nome,
                             ie,
                             idEntidade,
                             nascimento,
                             idSexo,
                             idCivil);

        return aux;
    }

    [WebMethod]
    public int InserirJuridica(string idCliente,
                        string cnpj,
                        string idAtividade,
                        string razao,
                        string fantasia,
                        string ie,
                        string dataAbertura,
                        string idTipofornecedor)
    {
        pepleo objPessoa = new pepleo();
        int aux = objPessoa.conectorPDV_replace_juridica(idCliente,
                         cnpj,
                         idAtividade,
                         razao,
                         fantasia,
                         ie,
                         dataAbertura,
                         idTipofornecedor);

        return aux;
    }

    [WebMethod]
    public int InserirEndereco(string idEndereco,
                        string idCliente,
                        string sequencia,
                        string cep,
                        string idcepbairro,
                        string idEnderecoType,
                        string bairro,
                        string logradouro,
                        string complemento,
                        string municipio,
                        string estado,
                        string numero)
    {
        pepleo objPessoa = new pepleo();
        int aux = objPessoa.conectorPDV_replace_endereco(idEndereco,
                        idCliente,
                        sequencia,
                        cep,
                        idcepbairro,
                        idEnderecoType,
                        bairro,
                        logradouro,
                        complemento,
                        municipio,
                        estado,
                        numero);

        return aux;
    }

    [WebMethod]
    public int InserirEnderecoFuncionario(string replace_idFuncionarioEndereco,
                                            string replace_idFuncionario,
        string replace_sequencia,
                                            string replace_cep,
                                            string replace_idcepbairro,
                                            string replace_idenderecoType,
                                            string replace_bairro,
                                            string replace_logradouro,
                                            string replace_complemento,
                                            string replace_municipio,
                                            string replace_estado,
                                            string replace_numero)
    {
        pepleo objPessoa = new pepleo();
        int aux = objPessoa.conectorWeb_replace_funcionarioEndereco(replace_idFuncionarioEndereco,
                                            replace_idFuncionario, replace_sequencia,
                                            replace_cep,
                                            replace_idcepbairro,
                                            replace_idenderecoType,
                                            replace_bairro,
                                            replace_logradouro,
                                            replace_complemento,
                                            replace_municipio,
                                            replace_estado,
                                            replace_numero);

        return aux;
    }

    [WebMethod]
    public int conector_passwd(string newPasswd, string hash, string idFuncionario)
    {
        pepleo objPessoa = new pepleo();
        int aux = objPessoa.conector_passwd(newPasswd, hash, idFuncionario);

        return aux;
    }

    [WebMethod]
    public void InserirSpedNcm(string ncm, string descricao, string mva, string interestadual, string interna, string ajuste)
    {
        produto objProduto = new produto();
        objProduto.conector_inc_spedncm(ncm, descricao, mva, interestadual, interna, ajuste);
    }


    [WebMethod]
    public string InserirProduto(string auxTipoCodigo, string descricao)
    {
        produto objProduto = new produto();
        string test = objProduto.conector_inc_produto(auxTipoCodigo, descricao);

        return test;
    }

    [WebMethod]
    public void AlterarSpedNcm(string ncm, string descricao, string mva, string interestadual, string interna, string ajuste)
    {
        produto objProduto = new produto();
        objProduto.conector_alt_spedncm(ncm, descricao, mva, interestadual, interna, ajuste);
    }

    [WebMethod]
    public void AlterarProdutoPrice(string chave,
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
        produto objProduto = new produto();
        objProduto.conector_alt_price(chave,
                                      store,
        custo,
        price,
        status,
        lucroliquido,
        lucroBruto,
        margem,
        margemLiquida,
        margemBruta,
        sugestao,
        pendente);
    }

    [WebMethod]
    public void AlterarProduto(string new_idProduto,
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
        produto objProduto = new produto();
        objProduto.conector_alt_produto(new_idProduto,
                                    new_idloja,
                                    new_nome,
                                    new_nomePdv,
                                    new_nomeFull,
                                    new_observacao,
                                    new_status,
                                    new_dataAlteracao,
                                    new_idSetor,
                                    new_idGrupo,
                                    new_idCategoria,
                                    new_idfornecedor,
                                    new_idUsuarioAlt,
                                    new_qttyObrigatoria,
                                    new_qttyMaximaVenda,
                                    new_descontoIndividual,
                                    new_restrito,
                                    new_idunidade,
                                    new_tipo,
                                    new_incideIpi,
                                    new_inputCfop,
                                    new_outputCfop,
                                    new_permitiMultiplicacao,
                                    new_marca, new_referencia);
    }

    [WebMethod]
    public void AlterarProdutoImpostos(string newImpidProduto,
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
        produto objProduto = new produto();
        objProduto.conector_alt_produtoImpostos(newImpidProduto,
                     newImpidloja,
                     newImptributacao,
                     newImptributacao1,
                     newImptributacao2,
                     newImpidpisCofins,
                     newImpcst,
                     newImpcstSaida,
                     newImpcstEntrada,
                     newImppauta,
                     newImpipi,
                     newImpipiValor,
                     newImpspedNcm,
                     newImpimpMercadoInterno,
                     newImpcsosn,
                     newImpidtypeItem,
                     newImpidGenero,
                     newreducaoCalcEspecial,
                     newippt);
    }

    [WebMethod]
    public void AlterarProdutoPriceFull(string newidProduto,
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
        produto objProduto = new produto();
        objProduto.conector_alt_produtoPrice(newidProduto,
             newidloja,
             newpriceFull,
             newpriceVenda,
             newpricePendente,
             newcreditoIcms,
             newcreditoRedIcms,
             newcreditoPis,
             newcreditoCofins,
             newcreditoOutros,
             newprimeiroDesconto,
             newsegundoDesconto,
             newterceiroDesconto,
             newdebitoIcms,
             newdebitoRedIcms,
             newlucroLiquido,
             newlucroBruto,
             newcustoBruto,
             newcustoliquido,
             newcustoMedio,
             newIpiPorcentagem,
             newmoedaIpi,
             newmoedaFrete,
             newfretePorcentagem,
             newcomissao,
             newpriceSugestao,
             newsubstituicaoPorcetagem,
             newacrescimoSubstituicao,
             newmoedaSubstituicao,
             newbonificacaoDesconto,
             newmoedaBonificacao,
             newmargem,
             newdescontoMaximo,
             newdespesasTributadas,
             newdespesaNaoTributadas,
             newcontribuicao,
             newvendo,
             newfinanceiro,
             newdespesaFixa,
             newstatusPrice,
             newdescontoValor,
             newMargemBruta,
             newMargemLiquida,
             newtrunca);
    }

    [WebMethod]
    public void AlterarEAN(string newIdProduto, string newBarra, string oldBarra, string newIdUnidadeMedida, string newquantidade, string newDefaultVenda, string newDefaultCompra, string newDefaultTransferencia, string newTypeEan)
    {
        produto objProduto = new produto();
        objProduto.conector_alt_ean(newIdProduto, newBarra, oldBarra, newIdUnidadeMedida, newquantidade, newDefaultVenda, newDefaultCompra, newDefaultTransferencia, newTypeEan);
    }

    [WebMethod]
    public void InserirEAN(string inc_idproduto, string inc_barra, string inc_idunidadeMedida, string inc_quantidade, string inc_defaultVenda, string inc_defaultCompra, string inc_defaultTransferencia, string inc_typeEan)
    {
        produto objProduto = new produto();
        objProduto.conector_inc_ean(inc_idproduto, inc_barra, inc_idunidadeMedida, inc_quantidade, inc_defaultVenda, inc_defaultCompra, inc_defaultTransferencia, inc_typeEan);
    }

    [WebMethod]
    public int InserirUsuario(string replace_idusuario,
              string replace_descricao,
              string replace_login,
              string replace_passwd,
              string replace_terminalVenda,
              string replace_terminalConsulta,
              string replace_terminalECF,
              string replace_terminalAnaliseCredito,
              string replace_terminalMataBurro,
              string replace_status,
              string replace_supervisor,
              string replace_cadastro,
              string replace_onlyLogon,
              string replace_defaultLoja)
    {
        pepleo objPessoa = new pepleo();
        int aux = objPessoa.conectorWeb_replace_usuario(replace_idusuario,
              replace_descricao,
              replace_login,
              replace_passwd,
              replace_terminalVenda,
              replace_terminalConsulta,
              replace_terminalECF,
              replace_terminalAnaliseCredito,
              replace_terminalMataBurro,
              replace_status,
              replace_supervisor,
              replace_cadastro,
              replace_onlyLogon,
              replace_defaultLoja);

        return aux;
    }
    [WebMethod]
    public void AlterarUsuario(string auxIdUsuario, string descricao,
                                                string login,
                                                string passwd,
                                                string terminalVenda,
                                                string terminalConsulta,
                                                string terminalECF,
                                                string terminalAnaliseCredito,
                                                string terminalMataBurro,
                                                string status,
                                                string supervisor,
                                                string onlyLogon,
                                                string defaultLoja, string key)
    {
        pepleo objPessoa = new pepleo();
        objPessoa.conector_alt_usuario(auxIdUsuario, descricao,    login,
                                                passwd,
                                                terminalVenda,
                                                terminalConsulta,
                                                terminalECF,
                                                terminalAnaliseCredito,
                                                terminalMataBurro,
                                                status,
                                                supervisor,
                                                onlyLogon,
                                                defaultLoja);
    }

    [WebMethod]
    public void AlterarConfiguracaoUsuario(string auxIdUsuarioConfig, string auxidconfiguracao,
                                                            string auxidusuario,
                                                            string auxadministradoraCartao,
                                                            string auxbanco,
                                                            string auxcaixa,
                                                            string auxcargo,
                                                            string auxcep,
                                                            string auxconvenios,
                                                            string auxcodicaoPgto,
                                                            string auxcontaCorrente,
                                                            string auxcomplementoFiscal,
                                                            string auxcliente,
                                                            string auxescolaridade,
                                                            string auxferiados,
                                                            string auxfinalizadoras,
                                                            string auxfornecedor,
                                                            string auxfuncionario,
                                                            string auxloja,
                                                            string auxmetodos,
                                                            string auxprofissao,
                                                            string auxrepresentante,
                                                            string auxtelefone,
                                                            string auxterminal,
                                                            string auxtransportadora,
                                                            string auxusuario,
                                                            string auxveiculo,
                                                            string auxproduto,
                                                            string auxsetor,
                                                            string auxgrupo,
                                                            string auxcategoria,
                                                            string auxcompra,
                                                            string auxmaximo,
                                                            string auxentrada,
                                                            string auxprecificacao,
                                                            string auxtransferencia,
                                                            string auxmovimentacaoEstoque,
                                                            string auxsaldoEstoque,
                                                            string auxzeraEstoque,
                                                            string auxoperacaoEntrada,
                                                            string auxtipoProduto,
                                                            string auxtrocaProduto,
                                                            string auxcontasReceber,
                                                            string auxcartaoCredito,
                                                            string auxcheque,
                                                            string auxcrediario,
                                                            string auxdevolucao,
                                                            string auxcaixaCadastro,
                                                            string auxsitegra,
                                                            string auxnotaFiscal,
                                                            string auxsped,
                                                            string auxapuracaoImposto,
                                                            string auxmapaResumo,
                                                            string auxcfop,
                                                            string auxaliquotaFiscal,
                                                            string auxoperacaoFaturamento,
                                                            string auxmataBurro,
                                                            string auxconfiguraNotaFiscal,
                                                            string auxprocessamento,
                                                            string auxtesouraria,
                                                            string auxcupomFiscal,
                                                            string auxcontroleReservas,
                                                            string auxanaliseCredito,
                                                            string auxpdvSingle,
                                                            string auxcontasPagar,
                                                            string auxtrocaSenha,
                                                            string auxliberacao,
                                                            string auxcargas,
                                                            string auxinterfacePdv,
                                                            string auxdre,
                                                            string auxfluxoCaixa,
                                                            string auxflashReserva,
                                                            string auxflashVenda,
                                                            string auxrelatorios,
                                                            string auxchequeDevolvido,
                                                            string auxconvenio,
                                                            string auxlog,
                                                            string auxinclusao,
                                                            string auxalteracao,
                                                            string auxmenuCadastro,
                                                            string auxmenuProduto,
                                                            string auxmenuFinanceiro,
                                                            string auxmenuFiscal,
                                                            string auxmenuFaturamento,
                                                            string auxmenuPagar,
                                                            string auxmenuUtilitario,
                                                            string auxmenuContabil,
                                                            string auxmenuVenda,
                                                            string auxmenuRelatorio,
                                                            string auxinventario,
                                                            string auxestoqueRede,
                                                            string auxsaldoCrediario,
                                                            string auxCrediarioContrato,
                                                            string auxCrediarioResumoContabil,
                                                            string auxCrediarioInadimplencia,
                                                            string auxCrediarioConfiguracao,
                                                            string auxmenuBoletos,
                                                            string auxtableFiscal,
                                                            string auxprecoIndividual,
                                                            string auxcomposto,
                                                            string auxmovimentoEstoque,
                                                            string auxtipoPromocao,
                                                            string auxpromocao,
                                                            string auxprecoGrupo,
                                                            string auxrota,
                                                            string auxboletoBancario)
    {
        pepleo objPessoa = new pepleo();
        objPessoa.conector_alt_configuracao(auxIdUsuarioConfig, auxidconfiguracao,
                                                            auxidusuario,
                                                            auxadministradoraCartao,
                                                            auxbanco,
                                                            auxcaixa,
                                                            auxcargo,
                                                            auxcep,
                                                            auxconvenios,
                                                            auxcodicaoPgto,
                                                            auxcontaCorrente,
                                                            auxcomplementoFiscal,
                                                            auxcliente,
                                                            auxescolaridade,
                                                            auxferiados,
                                                            auxfinalizadoras,
                                                            auxfornecedor,
                                                            auxfuncionario,
                                                            auxloja,
                                                            auxmetodos,
                                                            auxprofissao,
                                                            auxrepresentante,
                                                            auxtelefone,
                                                            auxterminal,
                                                            auxtransportadora,
                                                            auxusuario,
                                                            auxveiculo,
                                                            auxproduto,
                                                            auxsetor,
                                                            auxgrupo,
                                                            auxcategoria,
                                                            auxcompra,
                                                            auxmaximo,
                                                            auxentrada,
                                                            auxprecificacao,
                                                            auxtransferencia,
                                                            auxmovimentacaoEstoque,
                                                            auxsaldoEstoque,
                                                            auxzeraEstoque,
                                                            auxoperacaoEntrada,
                                                            auxtipoProduto,
                                                            auxtrocaProduto,
                                                            auxcontasReceber,
                                                            auxcartaoCredito,
                                                            auxcheque,
                                                            auxcrediario,
                                                            auxdevolucao,
                                                            auxcaixaCadastro,
                                                            auxsitegra,
                                                            auxnotaFiscal,
                                                            auxsped,
                                                            auxapuracaoImposto,
                                                            auxmapaResumo,
                                                            auxcfop,
                                                            auxaliquotaFiscal,
                                                            auxoperacaoFaturamento,
                                                            auxmataBurro,
                                                            auxconfiguraNotaFiscal,
                                                            auxprocessamento,
                                                            auxtesouraria,
                                                            auxcupomFiscal,
                                                            auxcontroleReservas,
                                                            auxanaliseCredito,
                                                            auxpdvSingle,
                                                            auxcontasPagar,
                                                            auxtrocaSenha,
                                                            auxliberacao,
                                                            auxcargas,
                                                            auxinterfacePdv,
                                                            auxdre,
                                                            auxfluxoCaixa,
                                                            auxflashReserva,
                                                            auxflashVenda,
                                                            auxrelatorios,
                                                            auxchequeDevolvido,
                                                            auxconvenio,
                                                            auxlog,
                                                            auxinclusao,
                                                            auxalteracao,
                                                            auxmenuCadastro,
                                                            auxmenuProduto,
                                                            auxmenuFinanceiro,
                                                            auxmenuFiscal,
                                                            auxmenuFaturamento,
                                                            auxmenuPagar,
                                                            auxmenuUtilitario,
                                                            auxmenuContabil,
                                                            auxmenuVenda,
                                                            auxmenuRelatorio,
                                                            auxinventario,
                                                            auxestoqueRede,
                                                            auxsaldoCrediario,
                                                            auxCrediarioContrato,
                                                            auxCrediarioResumoContabil,
                                                            auxCrediarioInadimplencia,
                                                            auxCrediarioConfiguracao,
                                                            auxmenuBoletos,
                                                            auxtableFiscal,
                                                            auxprecoIndividual,
                                                            auxcomposto,
                                                            auxmovimentoEstoque,
                                                            auxtipoPromocao,
                                                            auxpromocao,
                                                            auxprecoGrupo,
                                                            auxrota,
                                                            auxboletoBancario);
    }

    [WebMethod]
    public void AlterarConfiguracaoUsuarioAll(string replace_idconfiguracao,
                string replace_idusuario,
                string replace_administradoraCartao,
                string replace_banco,
                string replace_caixa,
                string replace_cargo,
                string replace_cep,
                string replace_convenios,
                string replace_codicaoPgto,
                string replace_contaCorrente,
                string replace_complementoFiscal,
                string replace_cliente,
                string replace_escolaridade,
                string replace_feriados,
                string replace_finalizadoras,
                string replace_fornecedor,
                string replace_funcionario,
                string replace_loja,
                string replace_metodos,
                string replace_profissao,
                string replace_representante,
                string replace_telefone,
                string replace_terminal,
                string replace_transportadora,
                string replace_usuario,
                string replace_veiculo,
                string replace_produto,
                string replace_setor,
                string replace_grupo,
                string replace_categoria,
                string replace_compra,
                string replace_maximo,
                string replace_entrada,
                string replace_precificacao,
                string replace_transferencia,
                string replace_movimentacaoEstoque,
                string replace_saldoEstoque,
                string replace_zeraEstoque,
                string replace_operacaoEntrada,
                string replace_tipoProduto,
                string replace_trocaProduto,
                string replace_contasReceber,
                string replace_cartaoCredito,
                string replace_cheque,
                string replace_crediario,
                string replace_devolucao,
                string replace_caixaCadastro,
                string replace_sitegra,
                string replace_notaFiscal,
                string replace_sped,
                string replace_apuracaoImposto,
                string replace_mapaResumo,
                string replace_cfop,
                string replace_aliquotaFiscal,
                string replace_operacaoFaturamento,
                string replace_mataBurro,
                string replace_configuraNotaFiscal,
                string replace_processamento,
                string replace_tesouraria,
                string replace_cupomFiscal,
                string replace_controleReservas,
                string replace_analiseCredito,
                string replace_pdvSingle,
                string replace_contasPagar,
                string replace_trocaSenha,
                string replace_liberacao,
                string replace_cargas,
                string replace_interfacePdv,
                string replace_dre,
                string replace_fluxoCaixa,
                string replace_flashReserva,
                string replace_flashVenda,
                string replace_relatorios,
                string replace_chequeDevolvido,
                string replace_convenio,
                string replace_log,
                string replace_inclusao,
                string replace_alteracao,
                string replace_menuCadastro,
                string replace_menuProduto,
                string replace_menuFinanceiro,
                string replace_menuFiscal,
                string replace_menuFaturamento,
                string replace_menuPagar,
                string replace_menuUtilitario,
                string replace_menuContabil,
                string replace_menuVenda,
                string replace_menuRelatorio,
                string replace_inventario,
                string replace_estoqueRede,
                string replace_saldoCrediario,
                string replace_CrediarioContrato,
                string replace_CrediarioResumoContabil,
                string replace_CrediarioInadimplencia,
                string replace_CrediarioConfiguracao,
                string replace_menuBoletos,
                string replace_tableFiscal,
                string replace_precoIndividual,
                string replace_composto,
                string replace_movimentoEstoque,
                string replace_tipoPromocao,
                string replace_promocao,
                string replace_precoGrupo,
                string replace_rota,
                string replace_boletoBancario)
    {
        pepleo objPessoa = new pepleo();
        objPessoa.conectorWeb_replace_configuracao(
            replace_idconfiguracao,
                replace_idusuario,
                replace_administradoraCartao,
                replace_banco,
                replace_caixa,
                replace_cargo,
                replace_cep,
                replace_convenios,
                replace_codicaoPgto,
                replace_contaCorrente,
                replace_complementoFiscal,
                replace_cliente,
                replace_escolaridade,
                replace_feriados,
                replace_finalizadoras,
                replace_fornecedor,
                replace_funcionario,
                replace_loja,
                replace_metodos,
                replace_profissao,
                replace_representante,
                replace_telefone,
                replace_terminal,
                replace_transportadora,
                replace_usuario,
                replace_veiculo,
                replace_produto,
                replace_setor,
                replace_grupo,
                replace_categoria,
                replace_compra,
                replace_maximo,
                replace_entrada,
                replace_precificacao,
                replace_transferencia,
                replace_movimentacaoEstoque,
                replace_saldoEstoque,
                replace_zeraEstoque,
                replace_operacaoEntrada,
                replace_tipoProduto,
                replace_trocaProduto,
                replace_contasReceber,
                replace_cartaoCredito,
                replace_cheque,
                replace_crediario,
                replace_devolucao,
                replace_caixaCadastro,
                replace_sitegra,
                replace_notaFiscal,
                replace_sped,
                replace_apuracaoImposto,
                replace_mapaResumo,
                replace_cfop,
                replace_aliquotaFiscal,
                replace_operacaoFaturamento,
                replace_mataBurro,
                replace_configuraNotaFiscal,
                replace_processamento,
                replace_tesouraria,
                replace_cupomFiscal,
                replace_controleReservas,
                replace_analiseCredito,
                replace_pdvSingle,
                replace_contasPagar,
                replace_trocaSenha,
                replace_liberacao,
                replace_cargas,
                replace_interfacePdv,
                replace_dre,
                replace_fluxoCaixa,
                replace_flashReserva,
                replace_flashVenda,
                replace_relatorios,
                replace_chequeDevolvido,
                replace_convenio,
                replace_log,
                replace_inclusao,
                replace_alteracao,
                replace_menuCadastro,
                replace_menuProduto,
                replace_menuFinanceiro,
                replace_menuFiscal,
                replace_menuFaturamento,
                replace_menuPagar,
                replace_menuUtilitario,
                replace_menuContabil,
                replace_menuVenda,
                replace_menuRelatorio,
                replace_inventario,
                replace_estoqueRede,
                replace_saldoCrediario,
                replace_CrediarioContrato,
                replace_CrediarioResumoContabil,
                replace_CrediarioInadimplencia,
                replace_CrediarioConfiguracao,
                replace_menuBoletos,
                replace_tableFiscal,
                replace_precoIndividual,
                replace_composto,
                replace_movimentoEstoque,
                replace_tipoPromocao,
                replace_promocao,
                replace_precoGrupo,
                replace_rota,
                replace_boletoBancario
            );
    }

    [WebMethod]
    public void InserirConfiguracaoUsuario(string auxidconfiguracao,
                                                        string auxidusuario,
                                                        string auxadministradoraCartao,
                                                        string auxbanco,
                                                        string auxcaixa,
                                                        string auxcargo,
                                                        string auxcep,
                                                        string auxconvenios,
                                                        string auxcodicaoPgto,
                                                        string auxcontaCorrente,
                                                        string auxcomplementoFiscal,
                                                        string auxcliente,
                                                        string auxescolaridade,
                                                        string auxferiados,
                                                        string auxfinalizadoras,
                                                        string auxfornecedor,
                                                        string auxfuncionario,
                                                        string auxloja,
                                                        string auxmetodos,
                                                        string auxprofissao,
                                                        string auxrepresentante,
                                                        string auxtelefone,
                                                        string auxterminal,
                                                        string auxtransportadora,
                                                        string auxusuario,
                                                        string auxveiculo,
                                                        string auxproduto,
                                                        string auxsetor,
                                                        string auxgrupo,
                                                        string auxcategoria,
                                                        string auxcompra,
                                                        string auxmaximo,
                                                        string auxentrada,
                                                        string auxprecificacao,
                                                        string auxtransferencia,
                                                        string auxmovimentacaoEstoque,
                                                        string auxsaldoEstoque,
                                                        string auxzeraEstoque,
                                                        string auxoperacaoEntrada,
                                                        string auxtipoProduto,
                                                        string auxtrocaProduto,
                                                        string auxcontasReceber,
                                                        string auxcartaoCredito,
                                                        string auxcheque,
                                                        string auxcrediario,
                                                        string auxdevolucao,
                                                        string auxcaixaCadastro,
                                                        string auxsitegra,
                                                        string auxnotaFiscal,
                                                        string auxsped,
                                                        string auxapuracaoImposto,
                                                        string auxmapaResumo,
                                                        string auxcfop,
                                                        string auxaliquotaFiscal,
                                                        string auxoperacaoFaturamento,
                                                        string auxmataBurro,
                                                        string auxconfiguraNotaFiscal,
                                                        string auxprocessamento,
                                                        string auxtesouraria,
                                                        string auxcupomFiscal,
                                                        string auxcontroleReservas,
                                                        string auxanaliseCredito,
                                                        string auxpdvSingle,
                                                        string auxcontasPagar,
                                                        string auxtrocaSenha,
                                                        string auxliberacao,
                                                        string auxcargas,
                                                        string auxinterfacePdv,
                                                        string auxdre,
                                                        string auxfluxoCaixa,
                                                        string auxflashReserva,
                                                        string auxflashVenda,
                                                        string auxrelatorios,
                                                        string auxchequeDevolvido,
                                                        string auxconvenio,
                                                        string auxlog,
                                                        string auxinclusao,
                                                        string auxalteracao,
                                                        string auxmenuCadastro,
                                                        string auxmenuProduto,
                                                        string auxmenuFinanceiro,
                                                        string auxmenuFiscal,
                                                        string auxmenuFaturamento,
                                                        string auxmenuPagar,
                                                        string auxmenuUtilitario,
                                                        string auxmenuContabil,
                                                        string auxmenuVenda,
                                                        string auxmenuRelatorio,
                                                        string auxinventario,
                                                        string auxestoqueRede,
                                                        string auxsaldoCrediario,
                                                        string auxCrediarioContrato,
                                                        string auxCrediarioResumoContabil,
                                                        string auxCrediarioInadimplencia,
                                                        string auxCrediarioConfiguracao,
                                                        string auxmenuBoletos,
                                                        string auxtableFiscal,
                                                        string auxprecoIndividual,
                                                        string auxcomposto,
                                                        string auxmovimentoEstoque,
                                                        string auxtipoPromocao,
                                                        string auxpromocao,
                                                        string auxprecoGrupo,
                                                        string auxrota,
                                                        string auxboletoBancario)
    {
        pepleo objPessoa = new pepleo();
        objPessoa.conector_inc_configuracao(auxidconfiguracao,
                                                        auxidusuario,
                                                        auxadministradoraCartao,
                                                        auxbanco,
                                                        auxcaixa,
                                                        auxcargo,
                                                        auxcep,
                                                        auxconvenios,
                                                        auxcodicaoPgto,
                                                        auxcontaCorrente,
                                                        auxcomplementoFiscal,
                                                        auxcliente,
                                                        auxescolaridade,
                                                        auxferiados,
                                                        auxfinalizadoras,
                                                        auxfornecedor,
                                                        auxfuncionario,
                                                        auxloja,
                                                        auxmetodos,
                                                        auxprofissao,
                                                        auxrepresentante,
                                                        auxtelefone,
                                                        auxterminal,
                                                        auxtransportadora,
                                                        auxusuario,
                                                        auxveiculo,
                                                        auxproduto,
                                                        auxsetor,
                                                        auxgrupo,
                                                        auxcategoria,
                                                        auxcompra,
                                                        auxmaximo,
                                                        auxentrada,
                                                        auxprecificacao,
                                                        auxtransferencia,
                                                        auxmovimentacaoEstoque,
                                                        auxsaldoEstoque,
                                                        auxzeraEstoque,
                                                        auxoperacaoEntrada,
                                                        auxtipoProduto,
                                                        auxtrocaProduto,
                                                        auxcontasReceber,
                                                        auxcartaoCredito,
                                                        auxcheque,
                                                        auxcrediario,
                                                        auxdevolucao,
                                                        auxcaixaCadastro,
                                                        auxsitegra,
                                                        auxnotaFiscal,
                                                        auxsped,
                                                        auxapuracaoImposto,
                                                        auxmapaResumo,
                                                        auxcfop,
                                                        auxaliquotaFiscal,
                                                        auxoperacaoFaturamento,
                                                        auxmataBurro,
                                                        auxconfiguraNotaFiscal,
                                                        auxprocessamento,
                                                        auxtesouraria,
                                                        auxcupomFiscal,
                                                        auxcontroleReservas,
                                                        auxanaliseCredito,
                                                        auxpdvSingle,
                                                        auxcontasPagar,
                                                        auxtrocaSenha,
                                                        auxliberacao,
                                                        auxcargas,
                                                        auxinterfacePdv,
                                                        auxdre,
                                                        auxfluxoCaixa,
                                                        auxflashReserva,
                                                        auxflashVenda,
                                                        auxrelatorios,
                                                        auxchequeDevolvido,
                                                        auxconvenio,
                                                        auxlog,
                                                        auxinclusao,
                                                        auxalteracao,
                                                        auxmenuCadastro,
                                                        auxmenuProduto,
                                                        auxmenuFinanceiro,
                                                        auxmenuFiscal,
                                                        auxmenuFaturamento,
                                                        auxmenuPagar,
                                                        auxmenuUtilitario,
                                                        auxmenuContabil,
                                                        auxmenuVenda,
                                                        auxmenuRelatorio,
                                                        auxinventario,
                                                        auxestoqueRede,
                                                        auxsaldoCrediario,
                                                        auxCrediarioContrato,
                                                        auxCrediarioResumoContabil,
                                                        auxCrediarioInadimplencia,
                                                        auxCrediarioConfiguracao,
                                                        auxmenuBoletos,
                                                        auxtableFiscal,
                                                        auxprecoIndividual,
                                                        auxcomposto,
                                                        auxmovimentoEstoque,
                                                        auxtipoPromocao,
                                                        auxpromocao,
                                                        auxprecoGrupo,
                                                        auxrota,
                                                        auxboletoBancario);
    }

    [WebMethod]
    public int InserirFuncionario(string replace_idfuncionario,
                                   string replace_nome,
                                   string replace_apelido,
                                   string replace_nascimento,
                                   string replace_idloja,
                                   string replace_idfuncao,
                                   string replace_passwd,
                                   string replace_idcivil,
                                   string replace_idsexo,
                                   string replace_inclusao,
                                 string replace_comissaoAvista,
                                 string replace_comissaoAprazo,
                                 string replace_cpf,
                                 string replace_identidade,
                                 string replace_email,
                                 string replace_pis,
                                 string replace_idusuario,
                                 string replace_admissao,
                                 string replace_demissao,
                                 string replace_carteira,
                                 string replace_obs,
                                 string replace_idPremiacao,
                                 string replace_idMetaVenda,
                                 string replace_idprofissao,
                                 string replace_idEscolaridade,
                                 string replace_status,
                                 string replace_acessoFiscal,
                                 string replace_acessoMenuFiscal,
                                 string replace_crc,
                                 string replace_contador_cnpj)
    {
        pepleo objPessoa = new pepleo();
        int aux = objPessoa.conectorWeb_replace_funcionario(replace_idfuncionario,
                                   replace_nome,
                                   replace_apelido,
                                   replace_nascimento,
                                   replace_idloja,
                                   replace_idfuncao,
                                   replace_passwd,
                                   replace_idcivil,
                                   replace_idsexo,
                                   replace_inclusao,
                                 replace_comissaoAvista,
                                 replace_comissaoAprazo,
                                 replace_cpf,
                                 replace_identidade,
                                 replace_email,
                                 replace_pis,
                                 replace_idusuario,
                                 replace_admissao,
                                 replace_demissao,
                                 replace_carteira,
                                 replace_obs,
                                 replace_idPremiacao,
                                 replace_idMetaVenda,
                                 replace_idprofissao,
                                 replace_idEscolaridade,
                                 replace_status,
                                 replace_acessoFiscal,
                                 replace_acessoMenuFiscal,
                                 replace_crc,
                                 replace_contador_cnpj);
        return aux;
    }

    [WebMethod]
    public void AlterarFuncionario(string auxidfuncionario,
                                                    string auxnome,
                                                    string auxapelido,
                                                    string auxnascimento,
                                                    string auxidloja,
                                                    string auxidfuncao,
                                                    string auxpasswd,
                                                    string auxidcivil,
                                                    string auxidsexo,
                                                    string auxinclusao,
                                                    string auxcomissaoAvista,
                                                    string auxcomissaoAprazo,
                                                    string auxcpf,
                                                    string auxidentidade,
                                                    string auxemail,
                                                    string auxpis,
                                                    string auxidusuario,
                                                    string auxAdmissao,
                                                    string auxdemissao,
                                                    string auxcarteira,
                                                    string auxobservacao,
                                                    string auxidPremiacao,
                                                    string auxidMetaVenda,
                                                    string auxidprofissao,
                                                    string auxidEscolaridade,
                                                    string auxstatus,
                                                    string auxacessoFiscal,
                                                    string auxacessoMenuFiscal,
                                                    string auxcrc,
                                                    string auxcontador_cnpj, string CnpjFuncionario,
                                                            string dataNascimento, string inclusaoFuncionario, string admissaoFuncionario, string auxidendereco, string auxCep, string idcepBairro, string bairro, string complemento, string municipio, string estado, string numero, string logradouro)
    {
        pepleo objPessoa = new pepleo();
        objPessoa.conector_alt_funcionario(auxidfuncionario,
                                                    auxnome,
                                                    auxapelido,
                                                    auxnascimento,
                                                    auxidloja,
                                                    auxidfuncao,
                                                    auxpasswd,
                                                    auxidcivil,
                                                    auxidsexo,
                                                    auxinclusao,
                                                    auxcomissaoAvista,
                                                    auxcomissaoAprazo,
                                                    auxcpf,
                                                    auxidentidade,
                                                    auxemail,
                                                    auxpis,
                                                    auxidusuario,
                                                    auxAdmissao,
                                                    auxdemissao,
                                                    auxcarteira,
                                                    auxobservacao,
                                                    auxidPremiacao,
                                                    auxidMetaVenda,
                                                    auxidprofissao,
                                                    auxidEscolaridade,
                                                    auxstatus,
                                                    auxacessoFiscal,
                                                    auxacessoMenuFiscal,
                                                    auxcrc,
                                                    auxcontador_cnpj, CnpjFuncionario,
                                                            dataNascimento, inclusaoFuncionario, admissaoFuncionario, auxidendereco, auxCep, idcepBairro, bairro, complemento, municipio, estado, numero, logradouro);
    }

    [WebMethod]
    public int InserirTerminal(string replace_idterminal,
                                                string replace_idloja,
                                                string replace_idtypeTerminal,
                                                string replace_descricao,
                                                string replace_flagDesconto,
                                                string replace_status,
                                                string replace_operacao,
                                                string replace_multiTarefa)
    {
        pepleo objPessoa = new pepleo();
        int aux = objPessoa.conectorWeb_replace_terminal(replace_idterminal,
                                                replace_idloja,
                                                replace_idtypeTerminal,
                                                replace_descricao,
                                                replace_flagDesconto,
                                                replace_status,
                                                replace_operacao,
                                                replace_multiTarefa);
        return aux;
    }

    [WebMethod]
    public int InserirCep(string replace_idcepbairro,
                               string replace_cep,
                               string replace_idcepCity,
                               string replace_idestado,
                               string replace_bairro,
                               string replace_logradouro,
                               string replace_complemento,
                               string replace_uf)
    {
        pepleo objPessoa = new pepleo();
        int aux = objPessoa.conectorWEB_replace_cepbairro( replace_idcepbairro,
                                                            replace_cep,
                                                            replace_idcepCity,
                                                            replace_idestado,
                                                            replace_bairro,
                                                            replace_logradouro,
                                                            replace_complemento,
                                                            replace_uf);
        return aux;
    }

    [WebMethod]
    public void AlterarTerminal(string auxidterminal,
                                            string auxidloja,
                                            string auxidtypeTerminal,
                                            string auxdescricao,
                                            string auxflagDesconto,
                                            string auxstatus,
                                            string auxoperacao,
                                            string auxmultiTarefa)
    {
        pepleo objPessoa = new pepleo();
        objPessoa.conector_alt_terminal(auxidterminal,
                                            auxidloja,
                                            auxidtypeTerminal,
                                            auxdescricao,
                                            auxflagDesconto,
                                            auxstatus,
                                            auxoperacao,
                                            auxmultiTarefa);
    }
    [WebMethod]
    public void AlterarTerminalConfigEcf(string auxterminal,
                                            string auxcaixa,
                                            string auxipCaixa,
                                            string auxabeturaTroco,
                                            string auximprimiCheque,
                                            string auxtimeBlock,
                                            string auxblockTime,
                                            string auxtrocaMercadoria,
                                            string auxcarneRecebe,
                                            string auxcodigoEmpresaTef,
                                            string auxtrocoMax,
                                            string auxserie,
                                            string auxutilizaTeclado,
                                            string auxutilizaTef,
                                            string auxutilizaBalanca,
                                            string auxutilizaEcf,
                                            string auxportTef,
                                            string auxportBalanca,
                                            string auxportEcf,
                                            string auxfuncaoProgramada,
                                            string auxmsgTef,
                                            string auxidModeloEcf,
                                            string auxstatusPdv,
                                            string auxautentica,
                                            string auxemiteVinculo,
                                            string auxvinculoCrediario,
                                            string auxvinculoConvenio,
                                            string auxvinculoCartaoCredito,
                                            string auxvinculoCartaoDebito,
                                            string auxtypeTef,
                                            string auxalertaSangria,
                                            string auxvalueSangria, string auxIdTypeTerminal)
    {
        pepleo objPessoa = new pepleo();
        objPessoa.conector_alt_terminalecfconfig(
                                            auxterminal,
                                            auxcaixa,
                                            auxipCaixa,
                                            auxabeturaTroco,
                                            auximprimiCheque,
                                            auxtimeBlock,
                                            auxblockTime,
                                            auxtrocaMercadoria,
                                            auxcarneRecebe,
                                            auxcodigoEmpresaTef,
                                            auxtrocoMax,
                                            auxserie,
                                            auxutilizaTeclado,
                                            auxutilizaTef,
                                            auxutilizaBalanca,
                                            auxutilizaEcf,
                                            auxportTef,
                                            auxportBalanca,
                                            auxportEcf,
                                            auxfuncaoProgramada,
                                            auxmsgTef,
                                            auxidModeloEcf,
                                            auxstatusPdv,
                                            auxautentica,
                                            auxemiteVinculo,
                                            auxvinculoCrediario,
                                            auxvinculoConvenio,
                                            auxvinculoCartaoCredito,
                                            auxvinculoCartaoDebito,
                                            auxtypeTef,
                                            auxalertaSangria,
                                            auxvalueSangria, auxIdTypeTerminal);
    }

}

    public enum financeiro
    {
        Dinheiro = 1,
        Cheque = 2,
        Crediario = 3,
        Convenio = 4,
        Cartao_Debito = 5,
        Cartao_Credito = 6,
        Boleto = 7,
        Duplicata = 8,
        Recebimento = 9,
        Vale = 10
    }