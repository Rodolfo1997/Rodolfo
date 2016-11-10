using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GRUDShield.DAO
{
    public class StringConnectionRepository 
    {

        static string StringConnection()
        {
            string conex = "Data Source=ESTAGIÁRIO1\\SQLEXPRESS;Initial Catalog=ShieldAvangerDB;Integrated Security=True";
            return conex;

        }

    }
}