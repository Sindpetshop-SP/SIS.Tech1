using SIS.Tech.Domain.Model;
using SIS.Tech.IRepository;
using SISFramework.DataAccess.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Tech.Repository
{
    public class ConvencaoRepository : BaseRepository, IConvencaoRepository
    {
        public int InserirConvencao(Convencao convencao)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodTipoCCT", SqlDbType.Int){Value = convencao.TipoCCT.CodTipoCCT},
                new SqlParameter("@CodStatusCCT", SqlDbType.Int){Value = convencao.StatusCCT.CodStatusCCT},
                new SqlParameter("@NomeConvencao", SqlDbType.VarChar, 100){Value = convencao.NomeConvencao},
                new SqlParameter("@AnoVigenciaInicial", SqlDbType.VarChar, 4){Value = convencao.AnoVigenciaInicial},
                new SqlParameter("@AnoVigenciaFinal", SqlDbType.VarChar, 4){Value = convencao.AnoVigenciaFinal},
                new SqlParameter("@Observacao", SqlDbType.VarChar, 255){Value = convencao.Observacao},
                new SqlParameter("@CCTAssinada", SqlDbType.Bit){Value = convencao.CCTAssinada},
                new SqlParameter("@Ativo", SqlDbType.Bit){Value = convencao.Ativo},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value =  convencao.Quem },

            };

            var command = MontaCommand(parametros, "dbo.P_CONVENCAO_INSERIR", 600);

            var retorno = DbHelper.ExecuteScalar(command);

            return retorno == null || retorno == DBNull.Value ? 0 : int.Parse(retorno.ToString());
        }

        public int AlterarConvencao(Convencao convencao)
        {
            int retorno = 0;

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodConvencao", SqlDbType.Int){Value = convencao.CodConvencao},
                new SqlParameter("@CodTipoCCT", SqlDbType.Int){Value = convencao.TipoCCT.CodTipoCCT},
                new SqlParameter("@CodStatusCCT", SqlDbType.Int){Value = convencao.StatusCCT.CodStatusCCT},
                new SqlParameter("@NomeConvencao", SqlDbType.VarChar, 100){Value = convencao.NomeConvencao},
                new SqlParameter("@AnoVigenciaInicial", SqlDbType.VarChar, 4){Value = convencao.AnoVigenciaInicial},
                new SqlParameter("@AnoVigenciaFinal", SqlDbType.VarChar, 4){Value = convencao.AnoVigenciaFinal},
                new SqlParameter("@Observacao", SqlDbType.VarChar, 255){Value = convencao.Observacao},
                new SqlParameter("@CCTAssinada", SqlDbType.Bit){Value = convencao.CCTAssinada},
                new SqlParameter("@Ativo", SqlDbType.Bit){Value = convencao.Ativo},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value =  convencao.Quem },
            };

            var command = MontaCommand(parametros, "dbo.P_CONVENCAO_ALTERAR", 600);

            retorno = DbHelper.ExecuteNonQuery(command);

            return retorno;
        }

        public void ExcluirConvencao(int codConvencao, string quem)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodConvencao", SqlDbType.Int){Value = codConvencao},
                new SqlParameter("@Quem", SqlDbType.VarChar, 6) { Value = quem },
            };

            var command = MontaCommand(parametros, "dbo.P_CONVENCAO_EXCLUIR", 600);

            var retorno = DbHelper.ExecuteNonQuery(command);
        }
               

        public List<Convencao> ListarConvencao(string nomeConvencao, int codTipoCCT, int codStatusCCT, string anoVigenciaInicial, string anoVigenciaFinal)
        {
            var lstConvencao = new List<Convencao>();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@NomeConvencao", SqlDbType.VarChar, 100){Value = nomeConvencao},
                new SqlParameter("@CodTipoCCT", SqlDbType.Int){Value = codTipoCCT},
                new SqlParameter("@CodStatusCCT", SqlDbType.Int){Value = codStatusCCT},                
                new SqlParameter("@AnoVigenciaInicial", SqlDbType.VarChar, 4){Value = anoVigenciaInicial},
                new SqlParameter("@AnoVigenciaFinal", SqlDbType.VarChar, 4){Value = anoVigenciaFinal},
            };

            var command = MontaCommand(parametros, "dbo.P_CONVENCAO_LISTAR", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    var _item = new Convencao();
                    
                    _item.CodConvencao = (dReader["CodConvencao"] as int?).GetValueOrDefault();

                    _item.TipoCCT = new TipoCCT();
                    _item.TipoCCT.CodTipoCCT = (dReader["CodTipoCCT"] as int?).GetValueOrDefault();
                    _item.TipoCCT.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoCCT"); 

                    _item.StatusCCT = new StatusCCT();
                    _item.StatusCCT.CodStatusCCT = (dReader["CodStatusCCT"] as int?).GetValueOrDefault();
                    _item.StatusCCT.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescStatusCCT");

                    _item.NomeConvencao = Util.TrataCampos.GetStringSafe(dReader, "NomeConvencao");

                    _item.AnoVigenciaInicial = Util.TrataCampos.GetStringSafe(dReader, "AnoVigenciaInicial");

                    _item.AnoVigenciaFinal = Util.TrataCampos.GetStringSafe(dReader, "AnoVigenciaFinal");

                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");
                                        
                    _item.CCTAssinada = (dReader["CCTAssinada"] as bool?).GetValueOrDefault();

                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();

                    _item.Quem = Util.TrataCampos.GetStringSafe(dReader, "Quem");

                    lstConvencao.Add(_item);
                }
            }

            return lstConvencao;
        }

        public Convencao ObterConvencao(int codConvencao)
        {
            var _item = new Convencao();

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodConvencao", SqlDbType.Int) {Value = codConvencao},
            };

            var command = MontaCommand(parametros, "dbo.P_CONVENCAO_OBTER", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    _item.CodConvencao = (dReader["CodConvencao"] as int?).GetValueOrDefault();

                    _item.TipoCCT = new TipoCCT();
                    _item.TipoCCT.CodTipoCCT = (dReader["CodTipoCCT"] as int?).GetValueOrDefault();
                    _item.TipoCCT.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescTipoCCT");

                    _item.StatusCCT = new StatusCCT();
                    _item.StatusCCT.CodStatusCCT = (dReader["CodStatusCCT"] as int?).GetValueOrDefault();
                    _item.StatusCCT.Descricao = Util.TrataCampos.GetStringSafe(dReader, "DescStatusCCT");

                    _item.NomeConvencao = Util.TrataCampos.GetStringSafe(dReader, "NomeConvencao");

                    _item.AnoVigenciaInicial = Util.TrataCampos.GetStringSafe(dReader, "AnoVigenciaInicial");

                    _item.AnoVigenciaFinal = Util.TrataCampos.GetStringSafe(dReader, "AnoVigenciaFinal");

                    _item.Observacao = Util.TrataCampos.GetStringSafe(dReader, "Observacao");

                    _item.CCTAssinada = (dReader["CCTAssinada"] as bool?).GetValueOrDefault();

                    _item.Ativo = (dReader["Ativo"] as bool?).GetValueOrDefault();                                        
                }
            }

            return _item;
        }

        public List<string> ObterTotaisCCT()
        {
            List<string> listaTotais = new List<string>();
            listaTotais.Add(ObterTotalGeralCCT());
            listaTotais.Add(ObterTotalAssinadaCCT());
            listaTotais.Add(ObterTotalNegociacaoPacificaCCT());
            listaTotais.Add(ObterTotalNegociacaoJuridicaCCT());

            return listaTotais;
        }

        public string ObterTotalGeralCCT()
        {
            int retorno = 0;

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_CONVENCAO_LISTAR_TOTAL_GERAL", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    retorno = (dReader["TotalGeral"] as int?).GetValueOrDefault();

                }
            }

            return retorno.ToString();
        }

        public string ObterTotalAssinadaCCT()
        {
            int retorno = 0;

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_CONVENCAO_LISTAR_TOTAL_ASSINADAS", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    retorno = (dReader["TotalAssinadas"] as int?).GetValueOrDefault();

                }
            }

            return retorno.ToString();
        }

        public string ObterTotalNegociacaoPacificaCCT()
        {
            int retorno = 0;

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_CONVENCAO_LISTAR_TOTAL_PACIFICA", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    retorno = (dReader["TotalNegociacaoPacifica"] as int?).GetValueOrDefault();

                }
            }

            return retorno.ToString();
        }


        public string ObterTotalNegociacaoJuridicaCCT()
        {
            int retorno = 0;

            var parametros = new List<SqlParameter>();

            var command = MontaCommand(parametros, "dbo.P_CONVENCAO_LISTAR_TOTAL_JURIDICA", 600);

            using (var dReader = DbHelper.ExecuteReader(command))
            {
                while (dReader.Read())
                {
                    retorno = (dReader["TotalNegociacaoJuridica"] as int?).GetValueOrDefault();

                }
            }

            return retorno.ToString();
        }


    }
}
