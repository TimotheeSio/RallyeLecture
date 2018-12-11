using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using métier;
using System.Data;

namespace Connection
{
    class TableNiveau
    {
        private MySqlConnection cnx;
        public TableNiveau(string h, string u, string db, string p)
        {
            ConnectionMysql cn = new ConnectionMysql(h, u, db, p);
            cnx = cn.GetConnection;
        }
        public List<Niveau> GetAll()
        {
            List<Niveau> LesNiveau=new List<Niveau>();
            Niveau Niveau;
            int Id;
            string NiveauScolaire;
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "select * from Niveau";
            cmdSql.CommandType = CommandType.Text;

            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                Id = Convert.ToInt32(reader[0]);
                NiveauScolaire = String.Format("{1}",reader[1]);
                Niveau = new Niveau(Id, NiveauScolaire);
                LesNiveau.Add(Niveau);
            }

            this.cnx.Close();
            return LesNiveau;
        }
    }
}
