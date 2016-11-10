using GRUDShield.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GRUDShield.DAO
{
    public class VilaoRepository
    {

        StringConnectionRepository connection = new StringConnectionRepository();

        public void Insert(Vilao vilao)
        {
            using (SqlConnection con = new SqlConnection(connection.StringConnection()))
            {
                con.Open();

                SqlTransaction transaction = con.BeginTransaction();
                
                try
                {

                    SqlCommand cmmd = new SqlCommand("INSERT INTO Viloes (nome, nivel, funcao , inumano, equipe, poderes, arquirrival) VALUES (@Nome, @Nivel, @Funcao, @Inumano, @Equipe, @Poderes, @Arquirrival)", con);

                    cmmd.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = vilao.nome;
                    cmmd.Parameters.Add("@Nivel", SqlDbType.VarChar, 15).Value = vilao.nivel;
                    cmmd.Parameters.Add("@Funcao", SqlDbType.VarChar, 50).Value = vilao.funcao;
                    cmmd.Parameters.Add("@Inumano", SqlDbType.VarChar, 15).Value = vilao.inumano;
                    cmmd.Parameters.Add("@Equipe", SqlDbType.VarChar, 20).Value = vilao.equipe;
                    cmmd.Parameters.Add("@Poderes", SqlDbType.VarChar, 30).Value = vilao.poderes;
                    cmmd.Parameters.Add("@Arquirrival", SqlDbType.VarChar, 50).Value = vilao.arquirrival;

                    cmmd.Transaction = transaction;
                    //executa comando sql que não retornam dados
                    cmmd.ExecuteNonQuery();
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }

                finally
                {
                    con.Close();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connection.StringConnection()))
            {
                con.Open();

                SqlTransaction transaction = con.BeginTransaction();
                
                try
                {
                    SqlCommand cmmd = new SqlCommand("delete from Viloes where id = @Id", con);
                    cmmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    cmmd.Transaction = transaction;
                    // ExecuteNonQuery = executa declarações SQL que não retornam dados, tais como INSERT, UPDATE, DELETE e SET.
                    cmmd.ExecuteNonQuery();
                    transaction.Commit();
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                }

                finally
                {
                    con.Close();
                }

            }
        }

        public List<Vilao> Listar(string nome)
        {
            using (SqlConnection con = new SqlConnection(connection.StringConnection()))
            {

                SqlCommand cmmd;
                con.Open();

                if (nome == null || nome == "")
                {
                    cmmd = new SqlCommand("select * from Viloes", con);

                }
                else
                {
                    cmmd = new SqlCommand("select*from Viloes where nome Like @Nome", con);
                    cmmd.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = "%" + nome + "%";

                }

                List<Vilao> lista = new List<Vilao>();
                Vilao vilao = null;

                //ExecuteReader = executa declarações SQL que retornan linhas de dados, tais como no SELECT...
                using (var listaSql = cmmd.ExecuteReader())
                {
                    while (listaSql.Read())
                    {
                        vilao = new Vilao();
                        vilao.id = (int)listaSql["id"];
                        vilao.nome = listaSql["Nome"].ToString();
                        vilao.nivel = listaSql["Nivel"].ToString();
                        vilao.funcao = listaSql["Funcao"].ToString();
                        vilao.inumano = listaSql["Inumano"].ToString();
                        vilao.equipe = listaSql["Equipe"].ToString();
                        vilao.poderes = listaSql["Poderes"].ToString();
                        vilao.arquirrival = listaSql["Arquirrival"].ToString();
                        lista.Add(vilao);
                    }

                    con.Close();

                    return lista;
                }

            }

        }

        public Vilao ListarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(connection.StringConnection()))
            {
                SqlCommand cmmd = new SqlCommand("select * from Viloes where id= @Id", con);
                cmmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                Vilao vilao = null;

                con.Open();

                //ExecuteReader = executa declarações SQL que retornan linhas de dados, tais como no SELECT...
                using (var listaSql = cmmd.ExecuteReader())
                {
                    if (listaSql.Read())
                    {
                        vilao = new Vilao();
                        vilao.id = (int)listaSql["id"];
                        vilao.nome = listaSql["Nome"].ToString();
                        vilao.nivel = listaSql["Nivel"].ToString();
                        vilao.funcao = listaSql["Funcao"].ToString();
                        vilao.inumano = listaSql["Inumano"].ToString();
                        vilao.equipe = listaSql["Equipe"].ToString();
                        vilao.poderes = listaSql["Poderes"].ToString();
                        vilao.arquirrival = listaSql["Arquirrival"].ToString();

                    }

                    con.Close();

                    return vilao;
                }
            }

        }

        public void Update(Vilao vilao)
        {
            using (SqlConnection con = new SqlConnection(connection.StringConnection()))
            {
                con.Open();

                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    SqlCommand cmmd = new SqlCommand("Update Viloes set nome = @Nome, nivel =  @Nivel, funcao = @Funcao, inumano = @Inumano, equipe = @Equipe , poderes = @Poderes, arquirrival = @Arquirrival  where id = @Id", con);

                    cmmd.Parameters.Add("@Id", SqlDbType.Int).Value = vilao.id;
                    cmmd.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = vilao.nome;
                    cmmd.Parameters.Add("@Nivel", SqlDbType.VarChar, 15).Value = vilao.nivel;
                    cmmd.Parameters.Add("@Funcao", SqlDbType.VarChar, 50).Value = vilao.funcao;
                    cmmd.Parameters.Add("@Inumano", SqlDbType.VarChar, 15).Value = vilao.inumano;
                    cmmd.Parameters.Add("@Equipe", SqlDbType.VarChar, 20).Value = vilao.equipe;
                    cmmd.Parameters.Add("@Poderes", SqlDbType.VarChar, 30).Value = vilao.poderes;
                    cmmd.Parameters.Add("@Arquirrival", SqlDbType.VarChar, 50).Value = vilao.arquirrival;

                    cmmd.Transaction = transaction;
                    cmmd.ExecuteNonQuery();
                    transaction.Commit();
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    
                }

                finally
                {
                    con.Close();
                }
            }
        }

    }
}