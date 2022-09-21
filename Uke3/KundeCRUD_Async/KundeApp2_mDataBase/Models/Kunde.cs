using System;
namespace KundeApp2_mDataBase.Models
{
    public class Kunde
    {
        public int id { get; set; }

        public string forNavn { get; set; }

        public string etterNavn { get; set; }

        public string adresse { get; set; }

        public string postNr { get; set; }

        public string postSted { get; set; }
    }
}

