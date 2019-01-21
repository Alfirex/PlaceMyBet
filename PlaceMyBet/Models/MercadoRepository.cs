using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class MercadoRepository
    {
        private MySql.Data.MySqlClient.MySqlConnection Connect()
        {
            string con = "Server=localhost;Port=3306;Database=placemybet;Uid=root;SslMode=none";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(con);
            return conn;
        }

        // Visibilidad para que sea visto por otras clases internal - como protected.
        internal Mercado Retrieve()
        {
            //Class1 c = new Class1(1, "aaa", 1995, 2);
            MySql.Data.MySqlClient.MySqlConnection c = Connect();
            MySql.Data.MySqlClient.MySqlCommand cmd = c.CreateCommand();
            cmd.CommandText = " select * from mercado";

            c.Open();
            MySql.Data.MySqlClient.MySqlDataReader res = cmd.ExecuteReader();

            Mercado c1 = null;
            if (res.Read())
            {
                Debug.WriteLine("Recupera: " + res.GetInt32(0) + " " + res.GetString(1) + " " +
                    res.GetString(2) + " " + res.GetString(3) + " ");
                c1 = new Mercado(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetInt32(3), res.GetInt32(4));
            }

            c.Close();

            return c1;
        }
    }
}