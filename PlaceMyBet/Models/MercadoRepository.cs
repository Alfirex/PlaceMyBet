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
        internal Mercado RetrieveM(int id)
        {
            //Class1 c = new Class1(1, "aaa", 1995, 2);
            MySql.Data.MySqlClient.MySqlConnection c = Connect();
            MySql.Data.MySqlClient.MySqlCommand cmd = c.CreateCommand();
            
            cmd.CommandText = " select * from mercado where id = @A";
            cmd.Parameters.AddWithValue("@A", id);
            c.Open();
            MySql.Data.MySqlClient.MySqlDataReader res = cmd.ExecuteReader();

            Mercado c1 = null;
            if (res.Read())
            {
                Debug.WriteLine("Recupera: " + res.GetInt32(0) + " " + res.GetString(1) + " " +
                    res.GetString(2) + " " + res.GetString(3) + " ");
                c1 = new Mercado(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetInt32(4), res.GetInt32(5));
            }

            c.Close();

            return c1;
        }
        // Visibilidad para que sea visto por otras clases internal - como protected.
        internal List<Mercado> Retrieve()
        {
            MySql.Data.MySqlClient.MySqlConnection conexion = Connect();
            MySql.Data.MySqlClient.MySqlCommand cmd = conexion.CreateCommand();
            cmd.CommandText = " select * from mercado";

            try
            {
                conexion.Open();
                MySql.Data.MySqlClient.MySqlDataReader res = cmd.ExecuteReader();

                Mercado mercado = null;
                List<Mercado> lMercados = new List<Mercado>();
                while (res.Read())
                {
                    Debug.WriteLine("Mercado: " + res.GetInt32(0) + " " + res.GetString(1) + " " +
                    res.GetString(2) + " " + res.GetString(3) + " ");
                    mercado = new Mercado(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5));
                    lMercados.Add(mercado);
                }

                conexion.Close();
                return lMercados;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }

        }

        internal void Save(Mercado m)
        {
            MySql.Data.MySqlClient.MySqlConnection con = Connect();
            MySql.Data.MySqlClient.MySqlCommand command = con.CreateCommand();

            String u = m.cUnder().ToString();
            String o = m.cOver().ToString();

            Debug.WriteLine("Register under:" + m.cuota_under);
            Debug.WriteLine("Register over:" + m.cuota_over);

            command.CommandText = "insert into mercado(constante, cuota_over, cuota_under,dinero_over,dinero_under) values ('"+m.constante +"','"+ o + "','"+ u +"','"+m.dinero_over+"','"+ m.dinero_under + "');";
            Debug.WriteLine("Comando " + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch(MySql.Data.MySqlClient.MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error ");
            }

        }

        internal List<Mercado> RetrievebyConst(int id)
        {

            MySql.Data.MySqlClient.MySqlConnection con = Connect();
            MySql.Data.MySqlClient.MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado where id = @A";
            command.Parameters.AddWithValue("@A", id);


            try
            {
                con.Open();
                MySql.Data.MySqlClient.MySqlDataReader res = command.ExecuteReader();

                Mercado d = null;
                List<Mercado> mercados = new List<Mercado>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetInt32(2) + " " + res.GetString(3));
                    d = new Mercado(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetInt32(4), res.GetInt32(5));
                    mercados.Add(d);
                }

                con.Close();
                return mercados;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }

        }
    }
}