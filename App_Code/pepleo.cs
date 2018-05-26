using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for pepleo
/// </summary>
public class pepleo : dados
{
	public pepleo()
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
        public DataSet conector_find_funcionario(string doc)
        {
            try
            {
                abreConexao();
                singleTransaction("select tab.idFuncionario, tab.cpf, tab.nome, tab.nascimento, ifnull(tab1.cep,'00000000') as cep_1, ifnull(tab2.descricao,'Outros'), ifnull(tab3.descricao,'Outros'), ifnull(tab1.numero,'0')    from funcionario tab left join endereco tab1 on(tab.idFuncionario=tab1.idCliente) left join sexo tab2 on(tab.idSexo = tab2.idSexo) left join Civil tab3 on(tab.idCivil = tab3.idCivil) where  tab.cpf=?id and (tab1.sequencia=1 or 1=1) limit 1");
                addParametro("?id", doc);
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

        public DataSet conector_find_usuario(string chave)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from usuario where idUsuario=?id");
                addParametro("?id", chave);
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
        public DataSet conector_find_terminal(string store, string pdv)
        {
            try
            {
                abreConexao();

                //singleTransaction("select tab.idterminal,tab.idloja,tab.idtypeTerminal,tab.descricao,tab.flagDesconto,tab.status,tab.operacao,tab.multitarefa from terminal tab inner join loja tab1 on(tab.idLoja = tab1.idLoja) where tab.idLoja=?store and tab.idTerminal=?id");
                singleTransaction("select tab.idterminal,tab.idloja,tab.idtypeTerminal,tab.descricao,tab.flagDesconto,tab.status,tab.operacao,tab.multitarefa from terminal tab inner join loja tab1 on(tab.idLoja = tab1.idLoja) where  tab.idTerminal=?id");
                addParametro("?store", store);
                addParametro("?id", pdv);
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

        public DataSet conector_find_cep(string id)
        {
            try
            {
                abreConexao();

                //singleTransaction("select tab.idterminal,tab.idloja,tab.idtypeTerminal,tab.descricao,tab.flagDesconto,tab.status,tab.operacao,tab.multitarefa from terminal tab inner join loja tab1 on(tab.idLoja = tab1.idLoja) where tab.idLoja=?store and tab.idTerminal=?id");
                singleTransaction("select * from cepBairro where cep=?id limit 1");
                addParametro("?id", id);
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

        public DataSet conector_find_terminalFull(string store, string pdv)
        {
            try
            {
                abreConexao();
                singleTransaction("select tab.* from terminal tab inner join loja tab1 on(tab.idLoja = tab1.idLoja) where  tab.idTerminal=?id");
                addParametro("?store", store);
                addParametro("?id", pdv);
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
        public DataSet conector_find_pessoa(string doc, string tipo)
        {
            try
            {
                abreConexao();
                switch (tipo)
                {
                    case "1":
                        singleTransaction("select tab.idCliente, tab.cpf, tab.nome, tab.nascimento, ifnull(tab1.cep,'00000000') as cep_1, ifnull(tab2.descricao,'Outros'), ifnull(tab3.descricao,'Outros'), ifnull(tab1.numero,'0')    from fisica tab left join endereco tab1 on(tab.idCliente=tab1.idCliente) left join sexo tab2 on(tab.idSexo = tab2.idSexo) left join Civil tab3 on(tab.idCivil = tab3.idCivil) where tab.cpf=?id and (tab1.sequencia=1 or 1=1) limit 1");
                        break;
                    case "3":
                        singleTransaction("select tab.idCliente, tab.cpf, tab.nome, tab.nascimento, ifnull(tab1.cep,'00000000') as cep_1, ifnull(tab2.descricao,'Outros'), ifnull(tab3.descricao,'Outros'), ifnull(tab1.numero,'0')  from rural tab left join endereco tab1 on(tab.idCliente=tab1.idCliente) left join sexo tab2 on(tab.idSexo = tab2.idSexo) left join Civil tab3 on(tab.idCivil = tab3.idCivil) where tab.cpf=?id and (tab1.sequencia=1 or 1=1) limit 1");
                        break;
                    case "2":
                        singleTransaction("select tab.idCliente, tab.cnpj, tab.razao, tab.dataAbertura, ifnull(tab1.cep,'00000000') as cep_1, ifnull(tab1.numero,'0')  from juridica tab left join endereco tab1 on(tab.idCliente=tab1.idCliente) where tab.cnpj=?id and (tab1.sequencia=1 or 1=1) limit 1");
                        break;
                    default:
                        singleTransaction("select tab.idCliente, tab.cpf, tab.nome, tab.nascimento, ifnull(tab1.cep,'00000000') as cep_1, ifnull(tab2.descricao,'Outros'), ifnull(tab3.descricao,'Outros'), ifnull(tab1.numero,'0')  from fisica tab left join endereco tab1 on(tab.idCliente=tab1.idCliente) where tab.cpf=?id and (tab1.sequencia=1 or 1=1) limit 1");
                        break;
                }
                addParametro("?id", doc);
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
        public DataSet conectorPDV_consulta_pessoaSingle(string pessoa)
        {
            try
            {
                auxConsistencia = 0;
                abreConexao();
                startTransaction("conector_find_cliente");
                addParametro("tipo", "1");
                addParametro("find_cliente", pessoa);
                addParametro("tipo_cliente", "x");
                addParametro("find_atividade", "1");
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

        public DataSet conector_find_cliente(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from cliente where idCliente=?id");
                addParametro("?id", id);
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

        public DataSet conector_find_funcionarioFull(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from funcionario where idfuncionario=?id");
                addParametro("?id", id);
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
        public DataSet conector_find_fisica(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from fisica where (idCliente=?id or cpf=?id)");
                addParametro("?id", id);
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
        public int conector_verifica_cheque(string conta, string serie, string agencia, string banco, string numeroCheque)
        {
            auxConsistencia = 0;
            result = -1;
            try
            {
                abreConexao();
                singleTransaction("select count(*) from cheque tab where  tab.contaCorrente = ?inc_contaCorrente and (tab.serie = ?inc_serie || 1=1) and  tab.agencia = ?inc_agencia and tab.banco = ?inc_banco and tab.numberCheque = ?inc_numberCheque");
                addParametro("?inc_contaCorrente", conta);
                addParametro("?inc_serie", serie);
                 addParametro("?inc_agencia", agencia);
                addParametro("?inc_banco", banco);
                addParametro("?inc_numberCheque", numeroCheque);
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
        public DataSet conector_find_rural(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from rural where (idCliente=?id or cpf=?id)");
                addParametro("?id", id);
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
        public DataSet conector_find_juridica(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from juridica where (idCliente=?id or cnpj=?id)");
                addParametro("?id", id);
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
        public DataSet conector_find_store(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from loja where idLoja=?id");
                addParametro("?id", id);
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
        public DataSet conector_find_foneWorking(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from conector.funcionario_fone where idFuncionario=?id and priori='v'");
                addParametro("?id", id);
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
        public DataSet conector_find_fone(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from conector.fone where idCliente=?id");
                addParametro("?id", id);
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
        public DataSet conector_find_endereco(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from conector.endereco where idCliente=?id limit 1");
                addParametro("?id", id);
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

        public DataSet conector_find_fornecedor_infor(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from conector.paramentro_fornecedor_informacao where idCliente=?id limit 1");
                addParametro("?id", id);
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

        public DataSet conector_find_fornecedor_fiscal(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from conector.paramentro_fornecedor_fiscal where idCliente=?id limit 1");
                addParametro("?id", id);
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

        public DataSet conector_find_fornecedor_comercial(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from conector.paramentro_fornecedor_comercial where idCliente=?id limit 1");
                addParametro("?id", id);
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
        public DataSet conector_find_enderecoWorking(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from conector.funcionario_endereco where idFuncionario=?id");
                addParametro("?id", id);
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
        public int conector_verifica_exits_pepleo(string pepleo)
        {
            auxConsistencia = 0;
            result = -1;
            try
            {
                abreConexao();
                singleTransaction("select count(*) as exits from conector.cliente where idCliente=?pepleo");
                addParametro("?pepleo", pepleo);
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
        public DataSet conector_find_clienteRisco(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from clienterisco where idCliente=?id");
                addParametro("?id", id);
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
        public DataSet conector_find_clientereferencia(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from clientereferencia where idCliente=?id");
                addParametro("?id", id);
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
        public DataSet conector_find_clienteprofissional(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from clienteprofissional where idCliente=?id");
                addParametro("?id", id);
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
        public DataSet conector_find_clienteentrega(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from clienteentrega where idCliente=?id");
                addParametro("?id", id);
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
        public DataSet conector_find_clientecobranca(string id)
        {
            try
            {
                abreConexao();
                singleTransaction("select * from clientecobranca where idCliente=?id");
                addParametro("?id", id);
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

        public int conectorPDV_replace_cliente(string idCliente,
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
            try
            {
                auxConsistencia = 0;
                abreConexao();
                startTransaction("conectorPDV_replace_cliente");
                addParametro("replace_idcliente", idCliente);
                addParametro("replace_idloja", idLoja);
                addParametro("replace_idtipoPessoa", idTipoPessoa);
                addParametro("replace_idusuario", idUsuario);
                addParametro("replace_idatividade", idAtividade);
                addParametro("replace_observacao", observacao);
                addParametro("replace_dataEmissao", String.Format("{0:yyyyMMdd}", Convert.ToDateTime(dataEmissao)));
                addParametro("replace_dataAlteracao", String.Format("{0:yyyyMMdd}", Convert.ToDateTime(dataAlteracao)));
                addParametro("replace_idestado", idEstado);
                addParametro("replace_uf", uf);
                addParametro("replace_status", status);
                addParametro("replace_idSpedMunicipio", idSpedMunicipio);
                addParametro("replace_idPais", idPais);
                addParametro("replace_liberacao", liberacao);
                procedimentoRead();
                if (retornaRead().Read() == true)
                {
                    auxConsistencia = Convert.ToInt32(retornaRead().GetString(0));
                }
            }
            catch (Exception e)
            {
                throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
            }
            finally
            {
                fechaConexao();
            }
            return auxConsistencia;
        }

        public int conectorPDV_replace_fisica(string idCliente,
                string cpf,
                string idAtividade,
                string nome,
                string nascimento,
                string idSexo,
                string idEntidade,
                string idCivil)
        {
            try
            {
                auxConsistencia = 0;
                abreConexao();
                startTransaction("conectorPDV_replace_fisica");
                addParametro("replace_idcliente", idCliente);
                addParametro("replace_cpf", cpf);
                addParametro("replace_idAtividade", idAtividade);
                addParametro("replace_nome", nome);
                addParametro("replace_nascimento", String.Format("{0:yyyyMMdd}", Convert.ToDateTime(nascimento)));
                addParametro("replace_idSexo", idSexo);
                addParametro("replace_idEntidade", idEntidade);
                addParametro("replace_idCivil", idCivil);
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
            return auxConsistencia;
        }


        public int conectorPDV_replace_rural(string idCliente,
                            string cpf,
                            string idAtividade,
                            string nome,
                            string ie,
                            string idEntidade,
                            string nascimento,
                            string idSexo,
                            string idCivil)
        {
            try
            {
                auxConsistencia = 0;
                abreConexao();
                startTransaction("conectorPDV_replace_rural");
                addParametro("replace_idcliente", idCliente);
                addParametro("replace_cpf", cpf);
                addParametro("replace_idAtividade", idAtividade);
                addParametro("replace_nome", nome);
                addParametro("replace_ie", ie);
                addParametro("replace_idEntidade", idEntidade);
                addParametro("replace_nascimento", String.Format("{0:yyyyMMdd}", Convert.ToDateTime(nascimento)));
                addParametro("replace_idSexo", idSexo);
                addParametro("replace_idCivil", idCivil);
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
            return auxConsistencia;
        }
        public int conectorPDV_replace_juridica(string idCliente,
                        string cnpj,
                        string idAtividade,
                        string razao,
                        string fantasia,
                        string ie,
                        string dataAbertura,
                        string idTipofornecedor)
        {
            try
            {
                auxConsistencia = 0;
                abreConexao();
                startTransaction("conectorPDV_replace_juridica");
                addParametro("replace_idcliente", idCliente);
                addParametro("replace_cnpj", cnpj);
                addParametro("replace_idAtividade", idAtividade);
                addParametro("replace_razao", razao);
                addParametro("replace_fantasia", fantasia);
                addParametro("replace_ie", ie);
                addParametro("replace_dataAbertura", String.Format("{0:yyyyMMdd}", Convert.ToDateTime(dataAbertura)));
                addParametro("replace_idTipoFornecedor", idTipofornecedor);
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
            return auxConsistencia;
        }

        public int conectorPDV_replace_endereco(string idEndereco,
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
            try
            {
                auxConsistencia = 0;
                abreConexao();
                startTransaction("conectorPDV_replace_endereco");
                addParametro("replace_idEndereco", idEndereco);
                addParametro("replace_idcliente", idCliente);
                addParametro("replace_sequencia", sequencia);
                addParametro("replace_cep", cep);
                addParametro("replace_idcepbairro", idcepbairro);
                addParametro("replace_idEnderecoType", idEnderecoType);
                addParametro("replace_bairro", bairro);
                addParametro("replace_logradouro", logradouro);
                addParametro("replace_complemento", complemento);
                addParametro("replace_municipio", municipio);
                addParametro("replace_estado", estado);
                addParametro("replace_numero", numero);
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
            return auxConsistencia;
        }

        public int conectorWeb_replace_funcionarioEndereco(string replace_idFuncionarioEndereco,
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
            try
            {
                auxConsistencia = 0;
                abreConexao();
                startTransaction("conectorWeb_replace_funcionarioEndereco");
                addParametro("replace_idFuncionarioEndereco", replace_idFuncionarioEndereco);
                addParametro("replace_idFuncionario", replace_idFuncionario);
                addParametro("replace_sequencia", replace_sequencia);
                addParametro("replace_cep", replace_cep);
                addParametro("replace_idcepbairro", replace_idcepbairro);
                addParametro("replace_idEnderecoType", replace_idenderecoType);
                addParametro("replace_bairro", replace_bairro);
                addParametro("replace_logradouro", replace_logradouro);
                addParametro("replace_complemento", replace_complemento);
                addParametro("replace_municipio", replace_municipio);
                addParametro("replace_estado", replace_estado);
                addParametro("replace_numero", replace_numero);
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
            return auxConsistencia;
        }
        public void conector_alt_cliente(string auxIdCliente,string auxIdLoja,string flagTipopessoa,string Usuario,string flagAtividade,string obs,string dataEmissao,string inclusao,string auxIdEstado,string auxuf,string codMun,string status,string auxIdEndereco,string newGridcepCliente,string auxIdCepCliente,string bairro,string logradouro,string complemento,string city,string ufcliente,string number)
        {
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conector_alt_cliente");
                addParametro("alt_idcliente", auxIdCliente);
                addParametro("alt_idloja", auxIdLoja);
                addParametro("alt_idtipoPessoa", Convert.ToString(flagTipopessoa));
                addParametro("alt_idusuario", Usuario);
                addParametro("alt_idatividade", Convert.ToString(flagAtividade));
                addParametro("alt_observacao", obs);
                addParametro("alt_dataEmissao", dataEmissao);
                addParametro("alt_dataAlteracao", inclusao);
                addParametro("alt_idestado", auxIdEstado);
                addParametro("alt_uf", auxuf);
                addParametro("alt_codMun", codMun);
                addParametro("alt_status", status);
                addParametro("send_id", auxIdEndereco);
                addParametro("send_cep", newGridcepCliente);
                addParametro("send_idcepbairro", auxIdCepCliente);
                addParametro("send_idenderecoType", "1");
                addParametro("send_bairro", bairro);
                addParametro("send_logradouro", logradouro);
                addParametro("send_complemento", complemento);
                addParametro("send_municipio", city);
                addParametro("send_estado", ufcliente);
                addParametro("send_numero", number);
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

        public void conector_alt_fisica(string alt_idcliente, string alt_cpf, string alt_idatividade, string alt_nome, string alt_nascimento, string alt_idsexo, string alt_identidade, string alt_idcivil)
        {
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conector_alt_fisica");
                addParametro("alt_idcliente", alt_idcliente);
                addParametro("alt_cpf", alt_cpf);
                addParametro("alt_idatividade", alt_idatividade);
                addParametro("alt_nome", alt_nome);
                addParametro("alt_nascimento", alt_nascimento);
                addParametro("alt_idsexo", alt_idsexo);
                addParametro("alt_identidade", alt_identidade);
                addParametro("alt_idcivil", alt_idcivil);
                addParametro("alt_idTipoFornecedor", "8");
                procedimentoSet();
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
        /// FUNCAO {conector_alt_juridica} Sem Parametro
        /// DATA : 30/10/13
        /// ENFOQUE : reutilizar metodo para alterar pessoa juridica usando procedure do banco de dados. 
        /// </summary>
        public void conector_alt_juridica(string alt_idcliente, string alt_cnpj, string alt_idatividade, string alt_razao, string alt_fantasia, string alt_ie, string alt_dataAbertura, string alt_idTipoFornecedor)
        {
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conector_alt_juridica");
                addParametro("alt_idcliente", alt_idcliente);
                addParametro("alt_cnpj", alt_cnpj);
                addParametro("alt_idatividade", alt_idatividade);
                addParametro("alt_razao", alt_razao);
                addParametro("alt_fantasia", alt_fantasia);
                addParametro("alt_ie", alt_ie);
                addParametro("alt_dataAbertura", alt_dataAbertura);
                addParametro("alt_idTipoFornecedor", alt_idTipoFornecedor);
                procedimentoSet();
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
        /// FUNCAO {conector_alt_rural} Sem Parametro
        /// DATA : 30/10/13
        /// ENFOQUE : reutilizar metodo para alterar pessoa rural usando procedure do banco de dados. 
        /// </summary>
        public void conector_alt_rural(string alt_idcliente,string alt_cpf, string alt_idatividade, string alt_nome, string alt_identidade, string alt_ie, string alt_nascimento,string alt_idsexo, string alt_idcivil)
        {
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conector_alt_rural");
                addParametro("alt_idcliente", alt_idcliente);
                addParametro("alt_cpf", alt_cpf);
                addParametro("alt_idatividade", alt_idatividade);
                addParametro("alt_nome", alt_nome);
                addParametro("alt_identidade", alt_identidade);
                addParametro("alt_ie", alt_ie);
                addParametro("alt_nascimento", alt_nascimento);
                addParametro("alt_idsexo", alt_idsexo);
                addParametro("alt_idcivil", alt_idcivil);
                procedimentoSet();
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
        public string conector_inc_usuario(
                                                string descricao,
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
                                                string defaultLoja, string key
                                        )
        {
            string auxIdUsuario = "0";
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conector_inc_usuario");
                addParametro("inc_descricao", descricao);
                addParametro("inc_login", login);
                addParametro("inc_passwd", passwd);
                addParametro("inc_terminalVenda", terminalVenda.ToString());
                addParametro("inc_terminalConsulta", terminalConsulta.ToString());
                addParametro("inc_terminalECF", terminalECF.ToString());
                addParametro("inc_terminalAnaliseCredito", terminalAnaliseCredito.ToString());
                addParametro("inc_terminalMataBurro", terminalMataBurro.ToString());
                addParametro("inc_status", status.ToString());
                addParametro("inc_supervisor", supervisor.ToString());
                addParametro("inc_cadastro", String.Format("{0:yyyyMMdd}", DateTime.Now));
                addParametro("inc_key", key);
                addParametro("inc_onlyLogon", onlyLogon);
                addParametro("inc_defaultLoja", defaultLoja.ToString());
                procedimentoRead();
                if (retornaRead().Read() == true)
                {
                    auxIdUsuario = retornaRead().GetString(0);
                }
                fechaRead();
                commit();
            }
            catch (Exception e)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
                auxConsistencia = 1;

            }
            finally
            {
                fechaConexao();
                
            }
            if (auxConsistencia == 0)
            {
                return auxIdUsuario;
            }
            else
            {
                return "0";
            }
        }
        public int conector_alt_usuario(
                                                string auxIdUsuario,
                                                string descricao,
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
                                                string defaultLoja
                                            )
        {
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conector_alt_usuario");
                addParametro("newid", auxIdUsuario);
                addParametro("newdescricao", descricao);
                addParametro("newlogin", login);
                addParametro("newterminalVenda", terminalVenda);
                addParametro("newterminalConsulta", terminalConsulta);
                addParametro("newterminalECF", terminalECF);
                addParametro("newterminalAnaliseCredito", terminalAnaliseCredito);
                addParametro("newterminalMataBurro", terminalMataBurro);
                addParametro("newstatus", status);
                addParametro("newsupervisor", supervisor);
                addParametro("newcadastro", String.Format("{0:yyyyMMdd}", DateTime.Now));
                addParametro("newonlyLogon", onlyLogon);
                addParametro("newdefaultLoja", defaultLoja);
                procedimentoRead();
                fechaRead();
                commit();
            }
            catch (Exception erro)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + erro.Message.ToString());
                auxConsistencia = 1;
            }
            finally
            {
                fechaConexao();

            }
            if (auxConsistencia == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int conectorWeb_replace_usuario(
            string replace_idusuario,
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
              string replace_defaultLoja
                                    )
        {
            try
            {
                auxConsistencia = 0;
                abreConexao();
                iniciarTransacao();
                startTransaction("conectorWeb_replace_usuario");
                addParametro("replace_idusuario", replace_idusuario);
                addParametro("replace_descricao", replace_descricao);
                addParametro("replace_login", replace_login);
                addParametro("replace_passwd", replace_passwd);
                addParametro("replace_terminalVenda", replace_terminalVenda);
                addParametro("replace_terminalConsulta", replace_terminalConsulta);
                addParametro("replace_terminalECF", replace_terminalECF);
                addParametro("replace_terminalAnaliseCredito", replace_terminalAnaliseCredito);
                addParametro("replace_terminalMataBurro", replace_terminalMataBurro);
                addParametro("replace_status", replace_status);
                addParametro("replace_supervisor", replace_supervisor);
                addParametro("replace_cadastro", replace_cadastro);
                addParametro("replace_onlyLogon", replace_onlyLogon);
                addParametro("replace_defaultLoja", replace_defaultLoja);
                procedimentoRead();
                if (retornaRead().Read() == true)
                {
                    auxConsistencia = Convert.ToInt32(retornaRead().GetString(0));
                }
                fechaRead();
                commit();
            }
            catch (Exception e)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
                auxConsistencia = 1;

            }
            finally
            {
                fechaConexao();

            }
            return auxConsistencia;
        }

        public void conector_inc_configuracao(string auxidconfiguracao,
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
                                                        string auxboletoBancario
            )
        {
            string auxIdUsuarioConfig = "0";
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conector_inc_configuracao");
                addParametro("inc_idusuario", auxidusuario);
                addParametro("inc_administradoraCartao", auxadministradoraCartao);
                addParametro("inc_banco", auxbanco);
                addParametro("inc_caixa", auxcaixa);
                addParametro("inc_cargo", auxcargo);
                addParametro("inc_cep", auxcep);
                addParametro("inc_convenios", auxconvenio);
                addParametro("inc_codicaoPgto", auxcodicaoPgto);
                addParametro("inc_contaCorrente", auxcontaCorrente);
                addParametro("inc_cliente", auxcliente);
                addParametro("inc_escolaridade", auxescolaridade);
                addParametro("inc_feriados", auxferiados);
                addParametro("inc_finalizadoras", auxfinalizadoras);
                addParametro("inc_fornecedor", auxfornecedor);
                addParametro("inc_funcionario", auxfuncionario);
                addParametro("inc_loja", auxloja);
                addParametro("inc_metodos", auxmetodos);
                addParametro("inc_profissao", auxprofissao);
                addParametro("inc_representante", auxrepresentante);
                addParametro("inc_telefone", auxtelefone);
                addParametro("inc_terminal", auxterminal);
                addParametro("inc_transportadora", auxtransportadora);
                addParametro("inc_usuario", auxusuario);
                addParametro("inc_veiculo", auxveiculo);
                addParametro("inc_produto", auxproduto);
                addParametro("inc_setor", auxsetor);
                addParametro("inc_grupo", auxgrupo);
                addParametro("inc_categoria", auxcategoria);
                addParametro("inc_compra", auxcompra);
                addParametro("inc_maximo", auxmaximo);
                addParametro("inc_entrada", auxentrada);
                addParametro("inc_precificacao", auxprecificacao);
                addParametro("inc_transferencia", auxtransferencia);
                addParametro("inc_movimentacaoEstoque", auxmovimentacaoEstoque);
                addParametro("inc_saldoEstoque", auxsaldoEstoque);
                addParametro("inc_zeraEstoque", auxzeraEstoque);
                addParametro("inc_operacaoEntrada", auxoperacaoEntrada);
                addParametro("inc_tipoProduto", auxtipoProduto);
                addParametro("inc_trocaProduto", auxtrocaProduto);
                addParametro("inc_contasReceber", auxcontasReceber);
                addParametro("inc_cartaoCredito", auxcartaoCredito);
                addParametro("inc_cheque", auxcheque);
                addParametro("inc_crediario", auxcrediario);
                addParametro("inc_devolucao", auxdevolucao);
                addParametro("inc_caixaCadastro", auxcaixaCadastro);
                addParametro("inc_sitegra", auxsitegra);
                addParametro("inc_notaFiscal", auxnotaFiscal);
                addParametro("inc_sped", auxsped);
                addParametro("inc_apuracaoImposto", auxapuracaoImposto);
                addParametro("inc_mapaResumo", auxmapaResumo);
                addParametro("inc_cfop", auxcfop);
                addParametro("inc_aliquotaFiscal", auxaliquotaFiscal);
                addParametro("inc_operacaoFaturamento", auxoperacaoFaturamento);
                addParametro("inc_controleReservas", auxcontasReceber);
                addParametro("inc_analiseCredito", auxanaliseCredito);
                addParametro("inc_pdvSingle", "s");
                addParametro("inc_contasPagar", auxcontasPagar);
                addParametro("inc_trocaSenha", auxtrocaSenha);
                addParametro("inc_liberacao", auxliberacao);
                addParametro("inc_cargas", auxcargas);
                addParametro("inc_interfacePdv", auxinterfacePdv);
                addParametro("inc_dre", auxdre);
                addParametro("inc_fluxoCaixa", auxfluxoCaixa);
                addParametro("inc_flashReserva", auxflashReserva);
                addParametro("inc_flashVenda", auxflashVenda);
                addParametro("inc_relatorios", auxrelatorios);
                addParametro("inc_chequeDevolvido", auxchequeDevolvido);
                addParametro("inc_convenio", auxconvenio);
                addParametro("inc_log", auxlog);
                addParametro("inc_inclusao", String.Format("{0:yyyyMMdd}", DateTime.Now));
                addParametro("inc_alteracao", String.Format("{0:yyyyMMdd}", DateTime.Now));
                addParametro("inc_menuCadastro", auxmenuCadastro);
                addParametro("inc_menuProduto", auxmenuProduto);
                addParametro("inc_menuFinanceiro", auxmenuFinanceiro);
                addParametro("inc_menuFiscal", auxmenuFiscal);
                addParametro("inc_menuFaturamento", auxmenuFaturamento);
                addParametro("inc_menuPagar", auxmenuPagar);
                addParametro("inc_menuUtilitario", auxmenuUtilitario);
                addParametro("inc_menuContabil", auxmenuContabil);
                addParametro("inc_menuVenda", auxmenuVenda);
                addParametro("inc_menuRelatorio", "1");
                addParametro("inc_inventario", auxinventario);
                addParametro("inc_estoqueRede", auxestoqueRede);
                addParametro("inc_saldoCrediario", auxsaldoCrediario);
                addParametro("inc_CrediarioContrato", auxCrediarioContrato);
                addParametro("inc_CrediarioResumoContabil", auxCrediarioResumoContabil);
                addParametro("inc_CrediarioInadimplencia", auxCrediarioInadimplencia);
                addParametro("inc_CrediarioConfiguracao", auxCrediarioConfiguracao);
                addParametro("inc_menuBoletos", auxmenuBoletos);
                addParametro("inc_tableFiscal", auxtableFiscal);
                addParametro("inc_precoIndividual", auxprecoIndividual);
                procedimentoRead();
                if (retornaRead().Read() == true)
                {
                    auxIdUsuarioConfig = retornaRead().GetString(0);
                }
                fechaRead();
                commit();
            }
            catch (Exception e)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
                auxConsistencia = 1;
            }
            finally
            {
                fechaConexao();
                if (auxConsistencia == 0)
                {
                }
            }
        }

        public void conector_alt_configuracao(string auxIdUsuarioConfig, 
                                                            string auxidconfiguracao,
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
                                                            string auxboletoBancario
            )
        {
            try
            {
                auxConsistencia = 0;
                abreConexao();
                iniciarTransacao();
                startTransaction("conector_alt_configuracao");
                addParametro("newidconfiguracao", auxIdUsuarioConfig);
                addParametro("newidusuario", auxidusuario);
                addParametro("newadministradoraCartao", auxadministradoraCartao);
                addParametro("newbanco", auxbanco);
                addParametro("newcaixa", auxcaixa);
                addParametro("newcargo", auxcargo);
                addParametro("newcep", auxcep);
                addParametro("newconvenios", auxconvenio);
                addParametro("newcodicaoPgto", auxcodicaoPgto);
                addParametro("newcontaCorrente", auxcontaCorrente);
                addParametro("newcliente", auxcliente);
                addParametro("newescolaridade", auxescolaridade);
                addParametro("newferiados", auxferiados);
                addParametro("newfinalizadoras", auxfinalizadoras);
                addParametro("newfornecedor", auxfornecedor);
                addParametro("newfuncionario", auxfuncionario);
                addParametro("newloja", auxloja);
                addParametro("newmetodos", auxmetodos);
                addParametro("newprofissao", auxprofissao);
                addParametro("newrepresentante", auxrepresentante);
                addParametro("newtelefone", auxtelefone);
                addParametro("newterminal", auxterminal);   
                addParametro("newtransportadora", auxtransportadora);
                addParametro("newusuario", auxusuario);
                addParametro("newveiculo", auxveiculo);
                addParametro("newproduto", auxproduto);
                addParametro("newsetor", auxsetor);
                addParametro("newgrupo", auxgrupo);
                addParametro("newcategoria", auxcategoria);
                addParametro("newcompra", auxcompra);
                addParametro("newmaximo", auxmaximo);
                addParametro("newentrada", auxentrada);
                addParametro("newprecificacao", auxprecificacao);
                addParametro("newtransferencia", auxtransferencia);
                addParametro("newmovimentacaoEstoque", auxmovimentacaoEstoque);
                addParametro("newsaldoEstoque", auxsaldoEstoque);
                addParametro("newzeraEstoque", auxzeraEstoque);
                addParametro("newoperacaoEntrada", auxoperacaoEntrada);
                addParametro("newtipoProduto", auxtipoProduto);
                addParametro("newtrocaProduto", auxtrocaProduto);
                addParametro("newcontasReceber", auxcontasReceber);
                addParametro("newcartaoCredito", auxcartaoCredito);
                addParametro("newcheque", auxcheque);
                addParametro("newcrediario", auxcrediario);
                addParametro("newdevolucao", auxdevolucao);
                addParametro("newcaixaCadastro", auxcaixaCadastro);
                addParametro("newsitegra", auxsitegra);
                addParametro("newnotaFiscal", auxnotaFiscal);
                addParametro("newsped", auxsped);
                addParametro("newapuracaoImposto", auxapuracaoImposto);
                addParametro("newmapaResumo", auxmapaResumo);
                addParametro("newcfop", auxcfop);
                addParametro("newaliquotaFiscal", auxaliquotaFiscal);
                addParametro("newoperacaoFaturamento", auxoperacaoFaturamento);
                addParametro("newcontroleReservas", auxcontasReceber);
                addParametro("newanaliseCredito", auxanaliseCredito);
                addParametro("newpdvSingle", "s");
                addParametro("newcontasPagar", auxcontasPagar);
                addParametro("newtrocaSenha", auxtrocaSenha);
                addParametro("newliberacao", auxliberacao);
                addParametro("newcargas", auxcargas);
                addParametro("newinterfacePdv", auxinterfacePdv);
                addParametro("newdre", auxdre);
                addParametro("newfluxoCaixa", auxfluxoCaixa);
                addParametro("newflashReserva", auxflashReserva);
                addParametro("newflashVenda", auxflashVenda);
                addParametro("newrelatorios", auxrelatorios);
                addParametro("newchequeDevolvido", auxchequeDevolvido);
                addParametro("newconvenio", auxconvenio);
                addParametro("newlog", auxlog);
                addParametro("newinclusao", String.Format("{0:yyyyMMdd}", DateTime.Now));
                addParametro("newalteracao", String.Format("{0:yyyyMMdd}", DateTime.Now));
                addParametro("newmenuCadastro", auxmenuCadastro);
                addParametro("newmenuProduto", auxmenuProduto);
                addParametro("newmenuFinanceiro", auxmenuFinanceiro);
                addParametro("newmenuFiscal", auxmenuFiscal);
                addParametro("newmenuFaturamento", auxmenuFaturamento);
                addParametro("newmenuPagar", auxmenuPagar);
                addParametro("newmenuUtilitario", auxmenuUtilitario);
                addParametro("newmenuContabil", auxmenuContabil);
                addParametro("newmenuVenda", auxmenuVenda);
                addParametro("newmenuRelatorio", "1");
                addParametro("newinventario", auxinventario);
                addParametro("newestoqueRede", auxestoqueRede);
                addParametro("newsaldoCrediario", auxsaldoCrediario);
                addParametro("newCrediarioContrato", auxCrediarioContrato);
                addParametro("newCrediarioResumoContabil", auxCrediarioResumoContabil);
                addParametro("newCrediarioInadimplencia", auxCrediarioInadimplencia);
                addParametro("newCrediarioConfiguracao", auxCrediarioConfiguracao);
                addParametro("newmenuBoletos", auxmenuBoletos);
                addParametro("newtableFiscal", auxtableFiscal);
                addParametro("newprecoIndividual", auxprecoIndividual);
                procedimentoRead();
                fechaRead();
                commit();
            }
            catch (Exception e)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
                auxConsistencia = 1;
            }
            finally
            {
                fechaConexao();
                if (auxConsistencia == 0)
                {
                }
            }
        }


        public void conectorWeb_replace_configuracao(string replace_idconfiguracao,
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
            try
            {
                auxConsistencia = 0;
                abreConexao();
                iniciarTransacao();
                startTransaction("conectorWeb_replace_configuracao");
                addParametro("replace_idconfiguracao", replace_idconfiguracao);
                addParametro("replace_idusuario", replace_idusuario);
                addParametro("replace_administradoraCartao", replace_administradoraCartao);
                addParametro("replace_banco", replace_banco);
                addParametro("replace_caixa", replace_caixa);
                addParametro("replace_cargo", replace_cargo);
                addParametro("replace_cep", replace_cep);
                addParametro("replace_convenios", replace_convenios);
                addParametro("replace_codicaoPgto", replace_codicaoPgto);
                addParametro("replace_contaCorrente", replace_contaCorrente);
                addParametro("replace_complementoFiscal", replace_complementoFiscal);
                addParametro("replace_cliente", replace_cliente);
                addParametro("replace_escolaridade", replace_escolaridade);
                addParametro("replace_feriados", replace_feriados);
                addParametro("replace_finalizadoras", replace_finalizadoras);
                addParametro("replace_fornecedor", replace_fornecedor);
                addParametro("replace_funcionario", replace_funcionario);
                addParametro("replace_loja", replace_loja);
                addParametro("replace_metodos", replace_metodos);
                addParametro("replace_profissao", replace_profissao);
                addParametro("replace_representante", replace_representante);
                addParametro("replace_telefone", replace_telefone);
                addParametro("replace_terminal", replace_terminal);
                addParametro("replace_transportadora", replace_transportadora);
                addParametro("replace_usuario", replace_usuario);
                addParametro("replace_veiculo", replace_veiculo);
                addParametro("replace_produto", replace_produto);
                addParametro("replace_setor", replace_setor);
                addParametro("replace_grupo", replace_grupo);
                addParametro("replace_categoria", replace_categoria);
                addParametro("replace_compra", replace_compra);
                addParametro("replace_maximo", replace_maximo);
                addParametro("replace_entrada", replace_entrada);
                addParametro("replace_precificacao", replace_precificacao);
                addParametro("replace_transferencia", replace_transferencia);
                addParametro("replace_movimentacaoEstoque", replace_movimentacaoEstoque);
                addParametro("replace_saldoEstoque", replace_saldoEstoque);
                addParametro("replace_zeraEstoque", replace_zeraEstoque);
                addParametro("replace_operacaoEntrada", replace_operacaoEntrada);
                addParametro("replace_tipoProduto", replace_tipoProduto);
                addParametro("replace_trocaProduto", replace_trocaProduto);
                addParametro("replace_contasReceber", replace_contasReceber);
                addParametro("replace_cartaoCredito", replace_cartaoCredito);
                addParametro("replace_cheque", replace_cheque);
                addParametro("replace_crediario", replace_crediario);
                addParametro("replace_devolucao", replace_devolucao);
                addParametro("replace_caixaCadastro", replace_caixaCadastro);
                addParametro("replace_sitegra", replace_sitegra);
                addParametro("replace_notaFiscal", replace_notaFiscal);
                addParametro("replace_sped", replace_sped);
                addParametro("replace_apuracaoImposto", replace_apuracaoImposto);
                addParametro("replace_mapaResumo", replace_mapaResumo);
                addParametro("replace_cfop", replace_cfop);
                addParametro("replace_aliquotaFiscal", replace_aliquotaFiscal);
                addParametro("replace_operacaoFaturamento", replace_operacaoFaturamento);
                addParametro("replace_mataBurro", replace_mataBurro);
                addParametro("replace_configuraNotaFiscal", replace_configuraNotaFiscal);
                addParametro("replace_processamento", replace_processamento);
                addParametro("replace_tesouraria", replace_tesouraria);
                addParametro("replace_cupomFiscal", replace_cupomFiscal);
                addParametro("replace_controleReservas", replace_controleReservas);
                addParametro("replace_analiseCredito", replace_analiseCredito);
                addParametro("replace_pdvSingle", replace_pdvSingle);
                addParametro("replace_contasPagar", replace_contasPagar);
                addParametro("replace_trocaSenha", replace_trocaSenha);
                addParametro("replace_liberacao", replace_liberacao);
                addParametro("replace_cargas", replace_cargas);
                addParametro("replace_interfacePdv", replace_interfacePdv);
                addParametro("replace_dre", replace_dre);
                addParametro("replace_fluxoCaixa", replace_fluxoCaixa);
                addParametro("replace_flashReserva", replace_flashReserva);
                addParametro("replace_flashVenda", replace_flashVenda);
                addParametro("replace_relatorios", replace_relatorios);
                addParametro("replace_chequeDevolvido", replace_chequeDevolvido);
                addParametro("replace_convenio", replace_convenio);
                addParametro("replace_log", replace_log);
                addParametro("replace_inclusao", replace_inclusao);
                addParametro("replace_alteracao", replace_alteracao);
                addParametro("replace_menuCadastro", replace_menuCadastro);
                addParametro("replace_menuProduto", replace_menuProduto);
                addParametro("replace_menuFinanceiro", replace_menuFinanceiro);
                addParametro("replace_menuFiscal", replace_menuFiscal);
                addParametro("replace_menuFaturamento", replace_menuFaturamento);
                addParametro("replace_menuPagar", replace_menuPagar);
                addParametro("replace_menuUtilitario", replace_menuUtilitario);
                addParametro("replace_menuContabil", replace_menuContabil);
                addParametro("replace_menuVenda", replace_menuVenda);
                addParametro("replace_menuRelatorio", replace_menuRelatorio);
                addParametro("replace_inventario", replace_inventario);
                addParametro("replace_estoqueRede", replace_estoqueRede);
                addParametro("replace_saldoCrediario", replace_saldoCrediario);
                addParametro("replace_CrediarioContrato", replace_CrediarioContrato);
                addParametro("replace_CrediarioResumoContabil", replace_CrediarioResumoContabil);
                addParametro("replace_CrediarioInadimplencia", replace_CrediarioInadimplencia);
                addParametro("replace_CrediarioConfiguracao", replace_CrediarioConfiguracao);
                addParametro("replace_menuBoletos", replace_menuBoletos);
                addParametro("replace_tableFiscal", replace_tableFiscal);
                addParametro("replace_precoIndividual", replace_precoIndividual);
                addParametro("replace_composto", replace_composto);
                addParametro("replace_movimentoEstoque", replace_movimentoEstoque);
                addParametro("replace_tipoPromocao", replace_tipoPromocao);
                addParametro("replace_promocao", replace_promocao);
                addParametro("replace_precoGrupo", replace_precoGrupo);
                addParametro("replace_rota", replace_rota);
                addParametro("replace_boletoBancario", replace_boletoBancario);
                procedimentoRead();
                fechaRead();
                commit();
            }
            catch (Exception e)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
                auxConsistencia = 1;
            }
            finally
            {
                fechaConexao();
                if (auxConsistencia == 0)
                {
                }
            }
        }

        public int conectorWEB_replace_paramentro_fornecedor_fiscal(string replace_idfiscal,
                                                                string replace_idcliente,
                                                                string replace_forceIcms,
                                                                string replace_forcePis,
                                                                string replace_forceCofins,
                                                                string replace_descatadaSt,
                                                                string replace_typeGrade)
        {
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conectorWEB_replace_paramentro_fornecedor_fiscal");
                addParametro("replace_idfiscal", replace_idfiscal);
                addParametro("replace_idcliente", replace_idcliente);
                addParametro("replace_forceIcms", replace_forceIcms);
                addParametro("replace_forcePis", replace_forcePis);
                addParametro("replace_forceCofins", replace_forceCofins);
                addParametro("replace_descatadaSt", replace_descatadaSt);
                addParametro("replace_typeGrade", replace_typeGrade);
                procedimentoRead();
                if (retornaRead().Read() == true)
                {
                    auxConsistencia = Convert.ToInt32(retornaRead().GetString(0));
                }
                fechaRead();
                commit();
            }
            catch (Exception e)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
                auxConsistencia = 1;
            }
            finally
            {
                fechaConexao();
                if (auxConsistencia == 0)
                {
                }
            }
            return auxConsistencia;
        }
        public int conectorWEB_replace_paramentro_fornecedor_informacao(string replace_idInformacao,
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
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conectorWEB_replace_paramentro_fornecedor_informacao");
                addParametro("replace_idInformacao", replace_idInformacao);
                addParametro("replace_idcliente", replace_idcliente);
                addParametro("replace_typeTroca", replace_typeTroca);
                addParametro("replace_typeFrete", replace_typeFrete);
                addParametro("replace_porcentagemFrete", replace_porcentagemFrete);
                addParametro("replace_lastVisita", replace_lastVisita);
                addParametro("replace_nextVisita", replace_nextVisita);
                addParametro("replace_devPagar", replace_devPagar);
                addParametro("replace_bloquearEntregaFiscal", replace_bloquearEntregaFiscal);
                addParametro("replace_representante", replace_representante);
                addParametro("replace_idoperacao", replace_idoperacao);
                addParametro("replace_forceCompra", replace_forceCompra);
                addParametro("replace_nameSugestao", replace_nameSugestao);
                addParametro("replace_passwdSugestao", replace_passwdSugestao);
                addParametro("replace_observacao", replace_observacao);
                addParametro("replace_typeFornecedor", replace_typeFornecedor);
                procedimentoRead();
                if (retornaRead().Read() == true)
                {
                    auxConsistencia = Convert.ToInt32(retornaRead().GetString(0));
                }
                fechaRead();
                commit();
            }
            catch (Exception e)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
                auxConsistencia = 1;
            }
            finally
            {
                fechaConexao();
                if (auxConsistencia == 0)
                {
                }
            }
            return auxConsistencia;
        }
        public int conectorWeb_replace_paramentro_fornecedor_comercial(string replace_idComercial,
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
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conectorWeb_replace_paramentro_fornecedor_comercial");
                addParametro("replace_idComercial", replace_idComercial);
                addParametro("replace_idcliente", replace_idcliente);
                addParametro("replace_visita", replace_visita);
                addParametro("replace_analiseCompra", replace_analiseCompra);
                addParametro("replace_minVolume", replace_minVolume);
                addParametro("replace_valueBay", replace_valueBay);
                addParametro("replace_comprador", replace_comprador);
                addParametro("replace_prazoEntrega", replace_prazoEntrega);
                addParametro("replace_formaPgto", replace_formaPgto);
                addParametro("replace_banco", replace_banco);
                addParametro("replace_agencia", replace_agencia);
                addParametro("replace_contaCorrente", replace_contaCorrente);
                procedimentoRead();
                if (retornaRead().Read() == true)
                {
                    auxConsistencia = Convert.ToInt32(retornaRead().GetString(0));
                }
                fechaRead();
                commit();
            }
            catch (Exception e)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
                auxConsistencia = 1;
            }
            finally
            {
                fechaConexao();
                if (auxConsistencia == 0)
                {
                }
            }
            return auxConsistencia;
        }
        public int conectorWeb_replace_funcionario(string replace_idfuncionario,
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
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conectorWeb_replace_funcionario");
                addParametro("replace_idfuncionario", replace_idfuncionario);
                addParametro("replace_nome",replace_nome);
                addParametro("replace_apelido", replace_apelido);
                addParametro("replace_nascimento", replace_nascimento);
                addParametro("replace_idloja", replace_idloja);
                addParametro("replace_idfuncao", replace_idfuncao);
                addParametro("replace_passwd", replace_passwd);
                addParametro("replace_idcivil", replace_idcivil);
                addParametro("replace_idsexo", replace_idsexo);
                addParametro("replace_inclusao", replace_inclusao);
                addParametro("replace_comissaoAvista",replace_comissaoAvista);
                addParametro("replace_comissaoAprazo", replace_comissaoAprazo);
                addParametro("replace_cpf", replace_cpf);
                addParametro("replace_identidade",replace_identidade);
                addParametro("replace_email",replace_email);
                addParametro("replace_pis", replace_pis);
                addParametro("replace_idusuario",replace_idusuario);
                addParametro("replace_admissao", replace_admissao);
                addParametro("replace_demissao", replace_demissao);
                addParametro("replace_carteira", replace_carteira);
                addParametro("replace_obs", replace_obs);
                addParametro("replace_idPremiacao", replace_idPremiacao);
                addParametro("replace_idMetaVenda", replace_idMetaVenda);
                addParametro("replace_idprofissao", replace_idprofissao);
                addParametro("replace_idEscolaridade", replace_idEscolaridade);
                addParametro("replace_status",replace_status);
                addParametro("replace_acessoFiscal", replace_acessoFiscal);
                addParametro("replace_acessoMenuFiscal", replace_acessoFiscal);
                addParametro("replace_crc", replace_crc);
                addParametro("replace_contador_cnpj", replace_contador_cnpj);
                procedimentoRead();
                if (retornaRead().Read() == true)
                {
                    auxConsistencia = Convert.ToInt32(retornaRead().GetString(0));
                }
                fechaRead();
                commit();
            }
            catch (Exception e)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
                auxConsistencia = 1;
            }
            finally
            {
                fechaConexao();
                if (auxConsistencia == 0)
                {
                }
            }
            return auxConsistencia;
        }

        public int conector_alt_funcionario(string auxidfuncionario,
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
            auxConsistencia = 0;
            string flagCnpjFuncionario = CnpjFuncionario;
            flagCnpjFuncionario = flagCnpjFuncionario.Replace(".", "");
            flagCnpjFuncionario = flagCnpjFuncionario.Replace(",", "");
            flagCnpjFuncionario = flagCnpjFuncionario.Replace("-", "");
            flagCnpjFuncionario = flagCnpjFuncionario.Replace("/", "");
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conector_alt_funcionario");
                addParametro("alt_idFuncionario", auxidfuncionario);
                addParametro("alt_nome", auxnome);
                addParametro("alt_apelido", auxapelido);
                addParametro("alt_nascimento", dataNascimento);
                addParametro("alt_idloja", auxidloja);
                addParametro("alt_idfuncao", auxidfuncao);
                //addParametro("alt_passwd", txtNewSenha.Text);
                addParametro("alt_idcivil", auxidcivil);
                addParametro("alt_idsexo", auxidsexo);
                addParametro("alt_inclusao", inclusaoFuncionario);
                addParametro("alt_comissaoAvista", auxcomissaoAprazo);
                addParametro("alt_comissaoAprazo", auxcomissaoAvista);
                addParametro("alt_cpf", auxcpf);
                addParametro("alt_identidade", auxidentidade);
                addParametro("alt_email", auxemail);
                addParametro("alt_pis", auxpis);
                addParametro("alt_idusuario", auxidusuario);
                addParametro("alt_admissao", auxAdmissao);
                addParametro("alt_demissao", "00000000");
                addParametro("alt_carteira", auxcarteira);
                addParametro("alt_obs", auxobservacao);
                addParametro("alt_idPremiacao", auxidPremiacao);
                addParametro("alt_idMetaVenda", auxidMetaVenda);
                addParametro("alt_idprofissao", auxidPremiacao);
                addParametro("alt_idEscolaridade", auxidEscolaridade);
                addParametro("alt_AcessoFiscal", "1");//Rever
                addParametro("alt_AcessoMenuFiscal", "1");//Rever
                addParametro("alt_crc", auxcrc);
                addParametro("alt_contador_cnpj", flagCnpjFuncionario);
                addParametro("send_id", auxidendereco);
                addParametro("send_cep", auxCep);
                addParametro("send_idcepbairro", idcepBairro);
                addParametro("send_idenderecoType", "1");
                addParametro("send_bairro", bairro);
                addParametro("send_complemento", complemento);
                addParametro("send_municipio", municipio);
                addParametro("send_estado", estado);
                addParametro("send_numero", numero);
                addParametro("send_logradouro", logradouro);
                procedimentoRead();
                fechaRead();
                commit();
            }
            catch (Exception e)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
                auxConsistencia = 1;
            }
            finally
            {
                fechaConexao();
            }

            if (auxConsistencia == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int conectorWEB_replace_cepbairro(string replace_idcepbairro,
               string replace_cep,
               string replace_idcepCity,
               string replace_idestado,
               string replace_bairro,
               string replace_logradouro,
               string replace_complemento,
               string replace_uf)
        {
            int aux = 0;
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conectorWEB_replace_cepbairro");
                addParametro("replace_idcepbairro", replace_idcepbairro);
                addParametro("replace_cep", replace_cep);
                addParametro("replace_idcepCity", replace_idcepCity);
                addParametro("replace_idestado", replace_idestado);
                addParametro("replace_bairro", replace_bairro);
                addParametro("replace_logradouro", replace_logradouro);
                addParametro("replace_complemento", replace_complemento);
                addParametro("replace_uf", replace_uf);
                procedimentoRead();
                if (retornaRead().Read() == true)
                {
                    aux = 1;
                }
                fechaRead();
                commit();
            }
            catch (Exception erro)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + erro.Message.ToString());
                auxConsistencia = 1;
            }
            finally
            {
                fechaConexao();
                if (auxConsistencia == 0)
                {
                }
            }
            return aux;
        }
        public int conectorWeb_replace_terminal(string replace_idterminal,
                                                string replace_idloja,
                                                string replace_idtypeTerminal,
                                                string replace_descricao,
                                                string replace_flagDesconto,
                                                string replace_status,
                                                string replace_operacao,
                                                string replace_multiTarefa
            )
        {
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conectorWeb_replace_terminal");
                addParametro("replace_idterminal", replace_idterminal);
                addParametro("replace_idloja", replace_idloja);
                addParametro("replace_idtypeTerminal", replace_idtypeTerminal);
                addParametro("replace_descricao", replace_descricao);
                addParametro("replace_flagDesconto", replace_flagDesconto);
                addParametro("replace_status", replace_status);
                addParametro("replace_operacao", replace_operacao);
                addParametro("replace_multiTarefa", replace_multiTarefa);
                procedimentoRead();
                if (replace_idtypeTerminal != "5")
                {
                    if (retornaRead().Read() == true)
                    {
                        auxConsistencia = Convert.ToInt32(retornaRead().GetString(0));
                    }
                }
                fechaRead();
                commit();

            }
            catch (Exception erro)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + erro.Message.ToString());
                auxConsistencia = 1;
            }
            finally
            {
                fechaConexao();
                
            }
            return auxConsistencia;
        }

        public int conector_alt_terminal(string auxidterminal,
                                            string auxidloja,
                                            string auxidtypeTerminal,
                                            string auxdescricao,
                                            string auxflagDesconto,
                                            string auxstatus,
                                            string auxoperacao,
                                            string auxmultiTarefa)
        {
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conector_alt_terminal");
                addParametro("newIdTerminal", auxidterminal);
                addParametro("newIdloja", auxidloja);
                addParametro("newidtypeTerminal", auxidtypeTerminal);
                addParametro("newdescricao", auxdescricao);
                addParametro("newflagDesconto", auxflagDesconto);
                addParametro("newStatus", auxstatus);
                addParametro("newOperacao", auxoperacao);
                addParametro("newMultiTarefa", auxmultiTarefa);
                procedimentoRead();
                fechaRead();
                commit();
            }
            catch (Exception erro)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + erro.Message.ToString());
                auxConsistencia = 1;
            }
            finally
            {
                fechaConexao();
            }

            return auxConsistencia;
        }

        public void conector_alt_terminalecfconfig(
                                            string auxterminal,
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
                                            string auxvalueSangria, string auxIdTypeTerminal
    )
        {
            try
            {
                abreConexao();
                iniciarTransacao();
                startTransaction("conector_alt_terminalecfconfig");
                addParametro("newterminal", auxterminal);
                addParametro("newcaixa", auxcaixa);
                addParametro("newipCaixa", auxipCaixa);
                addParametro("newabeturaTroco", auxabeturaTroco);
                addParametro("newimprimiCheque", auximprimiCheque);
                addParametro("newtimeBlock", auxtimeBlock);
                addParametro("newblockTime", auxblockTime);
                addParametro("newtrocaMercadoria", auxtrocaMercadoria);
                addParametro("newcarneRecebe", auxcarneRecebe);
                addParametro("newcodigoEmpresaTef", auxcodigoEmpresaTef);
                addParametro("newtrocoMax", auxtrocoMax);
                // addParametro("newserie", cmbCodigoLicencaEcfTerminal.Text);
                addParametro("newutilizaTeclado", auxutilizaTeclado);
                addParametro("newutilizaTef", auxutilizaTef);
                addParametro("newutilizaBalanca", auxutilizaBalanca);
                // addParametro("newutilizaEcf", auxUtilizaPrinterFiscalEcfTerminal);
                addParametro("newportTef", auxportTef);
                addParametro("newportBalanca", auxportBalanca);
                addParametro("newportEcf", auxportEcf);
                addParametro("newfuncaoProgramada", auxfuncaoProgramada);
                addParametro("newmsgTef", auxmsgTef);
                addParametro("newidModeloEcf", auxidModeloEcf);
                addParametro("newautentica", auxautentica);
                addParametro("newEmiteVinculo", auxemiteVinculo);
                addParametro("newVinculoCrediario", auxvinculoCrediario);
                addParametro("newVinculoConvenio", auxvinculoConvenio);
                addParametro("newVinculoCartaoCredito", auxvinculoCartaoCredito);
                addParametro("newVinculoCartaoDebito", auxvinculoCartaoDebito);
                addParametro("newTypeTef", auxtypeTef);
                addParametro("newAlertaSangria", auxalertaSangria);
                addParametro("newValueSangria", auxvalueSangria);
                // addParametro("newstatusPdv", auxStatusEcfTerminal);
                if (auxIdTypeTerminal == "5")
                {
                    procedimentoRead();
                }
                fechaRead();
                commit();

            }
            catch (Exception e)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
                auxConsistencia = 1;
            }
            finally
            {
                fechaConexao();
                if (auxConsistencia == 0)
                {
                }
            }
        }
        public int conector_passwd(string newPasswd, string hash, string idFuncionario)
        {
            auxConsistencia = 0;
            try
            {
                abreConexao();
                iniciarTransacao();
                singleTransaction("update funcionario set passwd=AES_ENCRYPT(?str,?passwd) where idfuncionario=?Funcionario");
                addParametro("?str", newPasswd);
                addParametro("?passwd", hash);
                addParametro("?Funcionario", idFuncionario);
                procedimentoText();
                commit();
            }
            catch (Exception e)
            {
                rollback();
                throw new Exception("ERRO BANCO DE DADOS: " + e.Message.ToString());
                auxConsistencia = 1;

            }
            finally
            {
                fechaConexao();
                if (auxConsistencia == 0)
                {
                }
            }
            return auxConsistencia;
        }
    //########################################################End Procedimento de Banco###################################################
}
