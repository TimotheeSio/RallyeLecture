using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using métier;
using MySql.Data.MySqlClient;

namespace Connection
{
    class TableEleve
    {
        private MySqlConnection cnx;
        public TableEleve(string h, string u, string db, string p)
        {
            ConnectionMysql cn = new ConnectionMysql(h, u, db, p);
            cnx = cn.GetConnection;
        }
        public void insert(Eleve eleve)
        {
            cnx.Open();
            MySqlCommand insertAuth = new MySqlCommand("INSERT INTO aauth_users(email,pass,username,banned,last_login,last_activity,date_created,forgot_exp,remember_time,remember_exp,verification_code,totp_secret,ip_address) " +
                "VALUES(@email,@pass,NULL,0,NULL,NULL,NOW(),NULL,NULL,NULL,NULL,NULL,0)", cnx);
            insertAuth.Parameters.Add(new MySqlParameter("@email", eleve.GetLogin));
            insertAuth.Parameters.Add(new MySqlParameter("@pass", eleve.GetPassword));
            insertAuth.ExecuteNonQuery();
            long lastidAuth = insertAuth.LastInsertedId;

            MySqlCommand insert = new MySqlCommand("INSERT INTO Eleve(nom,prenom,login,idAuth) VALUES(@nom,@prenom,@login,@idAuth)", cnx);
            insert.Parameters.Add(new MySqlParameter("@nom", eleve.Getnom));
            insert.Parameters.Add(new MySqlParameter("@prenom", eleve.GetPrenom));
            insert.Parameters.Add(new MySqlParameter("@login", eleve.GetLogin));
            insert.Parameters.Add(new MySqlParameter("@idAuth", lastidAuth));

            cnx.Open();
            insert.ExecuteNonQuery();
            cnx.Close();

            MySqlCommand insertAuthToGroup = new MySqlCommand("INSERT INTO  aauth_user_to_group(user_id,group_id)VALUES (@lastidAuth,4) ", cnx);
            insertAuthToGroup.Parameters.Add(new MySqlParameter("@lastidAuth", lastidAuth));
            cnx.Open();
            insertAuthToGroup.ExecuteNonQuery();
            cnx.Close();
        }
    }
}
