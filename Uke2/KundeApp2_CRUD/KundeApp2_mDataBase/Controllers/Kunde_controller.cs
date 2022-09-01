using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using KundeApp2_mDataBase.Models;
using System.Linq;

namespace KundeApp2_mDataBase.Controllers
{
    [Route("[Controller]/[action]")]
    public class KundeController : ControllerBase
    {

        private readonly KundeDB _kundeDB;

        public KundeController(KundeDB kundeDb)
        {
            _kundeDB = kundeDb;
        }

        public List<Kunde> HentAlle()
        {
            List<Kunde> alleKundene = _kundeDB.Kunder.ToList();

            return alleKundene;
        }

        public bool Slett(int id)
        {
            try
            { 
                Kunde enKunde = _kundeDB.Kunder.Find(id);
                _kundeDB.Kunder.Remove(enKunde);
                _kundeDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool lagreKunde(Kunde kunde)
        {
            try
            {
                _kundeDB.Kunder.Add(kunde);
                _kundeDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Kunde HentEnKunde(int id)
        {
            try
            {
                Kunde kunden = _kundeDB.Kunder.Find(id);
                return kunden;
            }
            catch
            {
                return null;
            }
        }

        public bool oppdaterKunde(Kunde innKunde)
        {
            try
            {
                Kunde enKunde = _kundeDB.Kunder.Find(innKunde.id);
                enKunde.navn = innKunde.navn;
                enKunde.adresse = innKunde.adresse;
                _kundeDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

