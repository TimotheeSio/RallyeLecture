using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace métier
{
    public class Eleve
    {
        private string nom;
        private string prenom;
        private string login;
        private string passWord;
        static Random rnd = new Random();

        public Eleve(string nom, string prenom, string login,PassWordType type)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.login = login;
            this.passWord = GetNewPassword(type);
        }

        static private string GetPasswordAleatoire()
        {
            string chaine = "";
            string[] MajAlphabet = { "A", "B", "C", "D", "E", "F", "G", "H",  "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z"};
            string[] minAlphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z"};
            string[] SpecialChar = { "&", "*", "°", "@" };

            // Generate random indexes.
            int Min1Index = rnd.Next(minAlphabet.Length);
            int Min2Index = rnd.Next(minAlphabet.Length);
            int Min3Index = rnd.Next(minAlphabet.Length);
            int Min4Index = rnd.Next(minAlphabet.Length);
            int Min5Index = rnd.Next(minAlphabet.Length);
            int Min6Index = rnd.Next(minAlphabet.Length);
            int MajIndex = rnd.Next(MajAlphabet.Length);
            int chiffre = rnd.Next(10);
            int SpecialIndex = rnd.Next(SpecialChar.Length);
            // Display the result.
            chaine = MajAlphabet[MajIndex] + minAlphabet[Min1Index] + minAlphabet[Min2Index] + minAlphabet[Min3Index] + minAlphabet[Min4Index] + minAlphabet[Min5Index] + minAlphabet[Min6Index] + Convert.ToString(chiffre) + SpecialChar[SpecialIndex];
            return chaine;
        }

        private string GetPasswordConstruit()
        {
            string chaine = prenom.ToUpper()[0] + nom.ToLower();
            return chaine;
        }

        public string GetNewPassword(PassWordType type)
        {
            string chaine = "";
            if (type == PassWordType.aleatoire)
            {
                chaine = GetPasswordAleatoire();
            }
            else
            {
                chaine = GetPasswordConstruit();
            }
            return chaine;
        }

        public string GetPassword
        {
            get
            {
                return this.passWord;
            }
        }

        public string GetLogin
        {
            get
            {
                return this.login;
            }
        }

        public string Getnom
        {
            get
            {
                return this.login;
            }
        }

        public string GetPrenom
        {
            get
            {
                return this.login;
            }
        }
    }
}
