using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace métier
{
    public class Niveau
    {
        private int id;
        private string niveauScolaire;

        public Niveau(int id, string niveauScolaire)
        {
            this.id = id;
            this.niveauScolaire = niveauScolaire;
        }
    }
}
