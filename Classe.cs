using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace métier
{
    public class Classe
    {
        private int idEnseignant;
        private string anneeScolaire;
        private int niveau;

        public Classe(int idEnseignant, string anneeScolaire, int niveau)
        {
            this.idEnseignant = idEnseignant;
            this.anneeScolaire = anneeScolaire;
            this.niveau = niveau;
        }

        public int Getid
        {
            get
            {
                return idEnseignant;
            }
        }

        public string GetAnneeScolaire
        {
            get
            {
                return this.anneeScolaire;
            }
        }

        public int GetNiveau
        {
            get
            {
                return this.niveau;
            }
        }

    }
}
