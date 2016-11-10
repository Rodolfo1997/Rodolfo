using GRUDShield.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace GRUDShield.DAO
{
    public class AgenteRepository
    {

        StringConnectionRepository connections = new StringConnectionRepository();

        public void Insert(Agente agente)
        {
            using (SqlConnection con = new SqlConnection(connections.StringConnection()))
            {
                con.Open();

                SqlTransaction transaction = con.BeginTransaction();
               
                try
                {
                    SqlCommand cmmd = new SqlCommand("INSERT INTO Agentes (nome, nivel, funcao , inumano, equipe, poderes, arquirrival) VALUES (@Nome, @Nivel, @Funcao, @Inumano, @Equipe, @Poderes, @Arquirrival)", con);
                    cmmd.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = agente.nome;
                    cmmd.Parameters.Add("@Nivel", SqlDbType.VarChar, 15).Value = agente.nivel;
                    cmmd.Parameters.Add("@Funcao", SqlDbType.VarChar, 50).Value = agente.funcao;
                    cmmd.Parameters.Add("@Inumano", SqlDbType.VarChar, 15).Value = agente.inumano;
                    cmmd.Parameters.Add("@Equipe", SqlDbType.VarChar, 20).Value = agente.equipe;
                    cmmd.Parameters.Add("@Poderes", SqlDbType.VarChar, 30).Value = agente.poderes;
                    cmmd.Parameters.Add("@Arquirrival", SqlDbType.VarChar, 50).Value = agente.arquirrival;

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

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connections.StringConnection()))
            {
                con.Open();

                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    SqlCommand cmmd = new SqlCommand("delete from Agentes where id = @Id", con);
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

        public List<Agente> Listar(string nome)
        {

            using (SqlConnection con = new SqlConnection(connections.StringConnection()))
            {
                con.Open();

                SqlCommand cmmd = new SqlCommand();

                if (nome == null || nome == "")
                {
                    cmmd = new SqlCommand("select * from Agentes", con);

                }
                else
                {
                    cmmd = new SqlCommand("select*from Agentes where nome Like @Nome", con);
                    cmmd.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = "%" + nome + "%";

                }

                List<Agente> lista = new List<Agente>();
                Agente agente = null;

                //ExecuteReader = executa declarações SQL que retornan linhas de dados, tais como no SELECT...
                using (var listaSql = cmmd.ExecuteReader())
                {
                    while (listaSql.Read())
                    {
                        agente = new Agente();
                        agente.id = (int)listaSql["id"];
                        agente.nome = listaSql["Nome"].ToString();
                        agente.nivel = listaSql["Nivel"].ToString();
                        agente.funcao = listaSql["Funcao"].ToString();
                        agente.inumano = listaSql["Inumano"].ToString();
                        agente.equipe = listaSql["Equipe"].ToString();
                        agente.poderes = listaSql["Poderes"].ToString();
                        agente.arquirrival = listaSql["Arquirrival"].ToString();
                        lista.Add(agente);

                    }

                    con.Close();
                    return lista;
                }
            }
        }

        public Agente ListarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(connections.StringConnection()))
            {
                SqlCommand cmmd = new SqlCommand("select * from Agentes where id= @Id", con);
                cmmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                Agente agente = null;

                con.Open();

                //ExecuteReader = executa declarações SQL que retornan linhas de dados, tais como no SELECT...
                using (var listaSql = cmmd.ExecuteReader())
                {
                    if (listaSql.Read())
                    {
                        agente = new Agente();
                        agente.id = (int)listaSql["id"];
                        agente.nome = listaSql["Nome"].ToString();
                        agente.nivel = listaSql["Nivel"].ToString();
                        agente.funcao = listaSql["Funcao"].ToString();
                        agente.inumano = listaSql["Inumano"].ToString();
                        agente.equipe = listaSql["Equipe"].ToString();
                        agente.poderes = listaSql["Poderes"].ToString();
                        agente.arquirrival = listaSql["Arquirrival"].ToString();

                    }

                    con.Close();
                    return agente;
                }
            }
        }

        public void Update(Agente agente)
        {
            using (SqlConnection con = new SqlConnection(connections.StringConnection()))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
               
                try
                {
                    SqlCommand cmmd = new SqlCommand("Update Agentes set nome = @Nome, nivel =  @Nivel, funcao = @Funcao, inumano = @Inumano, equipe = @Equipe , poderes = @Poderes, arquirrival = @Arquirrival  where id = @Id", con);
                    cmmd.Parameters.Add("@Id", SqlDbType.Int).Value = agente.id;
                    cmmd.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = agente.nome;
                    cmmd.Parameters.Add("@Nivel", SqlDbType.VarChar, 15).Value = agente.nivel;
                    cmmd.Parameters.Add("@Funcao", SqlDbType.VarChar, 50).Value = agente.funcao;
                    cmmd.Parameters.Add("@Inumano", SqlDbType.VarChar, 15).Value = agente.inumano;
                    cmmd.Parameters.Add("@Equipe", SqlDbType.VarChar, 20).Value = agente.equipe;
                    cmmd.Parameters.Add("@Poderes", SqlDbType.VarChar, 30).Value = agente.poderes;
                    cmmd.Parameters.Add("@Arquirrival", SqlDbType.VarChar, 50).Value = agente.arquirrival;

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