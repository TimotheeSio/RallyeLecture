using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using métier;
using System.Data;

namespace Connection
{
    class TableClasse
    {
        private MySqlConnection cnx;
        public TableClasse(string h, string u, string db, string p)
        {
            ConnectionMysql cn = new ConnectionMysql(h, u, db, p);
            cnx = cn.GetConnection;
        }
        public void insert(Classe Classe)
        {
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "insert into classe(idEnseignant,anneeScolaire,idNiveau) values(@idEnseignant,@annee,@idNiveau)";
            cmdSql.CommandType = CommandType.Text;
            cmdSql.Parameters.Add("@idEnseignant", MySqlDbType.Int32);
            cmdSql.Parameters["@idEnseignant"].Value = Classe.Getid;
            cmdSql.Parameters.Add("@annee", MySqlDbType.String);
            cmdSql.Parameters["@anee"].Value = Classe.GetAnneeScolaire;
            cmdSql.Parameters.Add("@idNiveau", MySqlDbType.Int32);
            cmdSql.Parameters["@idNiveau"].Value = Classe.GetNiveau;
            cmdSql.ExecuteNonQuery();
            cnx.Close();
        }
    }
}
