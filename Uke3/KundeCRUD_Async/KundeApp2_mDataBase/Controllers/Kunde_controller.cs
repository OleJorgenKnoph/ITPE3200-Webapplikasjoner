using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using KundeApp2_mDataBase.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Kunde>> HentAlle()
        {
            try
            {
                List<Kunde> alleKunder = await _kundeDB.Kunder.Select(k => new Kunde
                {
                    id = k.id,
                    forNavn = k.forNavn,
                    etterNavn = k.etterNavn,
                    adresse = k.adresse,
                    postNr = k.postSted.postNr,
                    postSted = k.postSted.postSted
                }).ToListAsync();

                return alleKunder;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Slett(int id)
        {
            try
            { 
                Kunder enKunde = await _kundeDB.Kunder.FindAsync(id);
                _kundeDB.Kunder.Remove(enKunde);
                await _kundeDB.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> lagreKunde(Kunde kunde)
        {
            try
            {
                var nyKundeRaad = new Kunder();
                nyKundeRaad.forNavn = kunde.forNavn;
                nyKundeRaad.etterNavn = kunde.etterNavn;
                nyKundeRaad.adresse = kunde.adresse;

                var sjekkPoststed = _kundeDB.Poststed.Find(kunde.postNr);

                if(sjekkPoststed == null)
                {
                    var nyPoststedRaad = new Poststed();
                    nyPoststedRaad.postNr = kunde.postNr;
                    nyPoststedRaad.postSted = kunde.postSted;

                    nyKundeRaad.postSted = nyPoststedRaad;
                }
                else
                {
                    nyKundeRaad.postSted = sjekkPoststed;
                }

                _kundeDB.Kunder.Add(nyKundeRaad);

                await _kundeDB.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Kunde> HentEnKunde(int id)
        {
            try
            {
                Kunder enKunde = await _kundeDB.Kunder.FindAsync(id);

                var hentetKunde = new Kunde()
                {
                    id = enKunde.id,
                    forNavn = enKunde.forNavn,
                    etterNavn = enKunde.etterNavn,
                    adresse = enKunde.adresse,
                    postNr = enKunde.postSted.postNr,
                    postSted = enKunde.postSted.postSted
                };

                return hentetKunde;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> oppdaterKunde(Kunde innKunde)
        {
            try
            {
                Kunder enKunde = await _kundeDB.Kunder.FindAsync(innKunde.id);

                if(enKunde.postSted.postNr != innKunde.postNr)
                {
                    var sjekkPoststed = _kundeDB.Poststed.Find(innKunde.postNr);

                    if (sjekkPoststed == null)
                    {
                        var nyPoststedRaad = new Poststed();
                        nyPoststedRaad.postNr = innKunde.postNr;
                        nyPoststedRaad.postSted = innKunde.postSted;

                        enKunde.postSted = nyPoststedRaad;
                    }
                    else
                    {
                        enKunde.postSted = sjekkPoststed;
                    }
                }



                enKunde.forNavn = innKunde.forNavn;
                enKunde.etterNavn = innKunde.etterNavn;
                enKunde.adresse = innKunde.adresse;

                await _kundeDB.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

