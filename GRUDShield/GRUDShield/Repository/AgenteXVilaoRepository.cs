using GRUDShield.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GRUDShield.DAO
{
    public class AgenteXVilaoRepository 
    {
        StringConnectionRepository connections = new StringConnectionRepository();

        AgenteRepository agenteConn = new AgenteRepository();
        VilaoRepository vilaoConn = new VilaoRepository();

        public IList<AgentesXViloes> AgenteXVilaoJoin()
        {
            using (SqlConnection con = new SqlConnection(connections.StringConnection()))
            {
                con.Open();

                SqlCommand cmmd = new SqlCommand();

                cmmd = new SqlCommand("select a.nome [Nome], v.nome [Vilao] from Agentes as a inner join Viloes as v on a.nome =  v.arquirrival and a.arquirrival = v.nome", con);

                List<AgentesXViloes> lista = new List<AgentesXViloes>();
                AgentesXViloes agenteXvilao = null;

                //ExecuteReader = executa declarações SQL que retornan linhas de dados, tais como no SELECT...
                using (var listaSql = cmmd.ExecuteReader())
                {
                    while (listaSql.Read())
                    {
                        agenteXvilao = new AgentesXViloes();

                        agenteXvilao.nome = listaSql["Nome"].ToString();
                        agenteXvilao.arquirrival = listaSql["Vilao"].ToString();

                        lista.Add(agenteXvilao);
                    }

                    con.Close();
                    return lista;
                }

            }
           
        }

    }
}