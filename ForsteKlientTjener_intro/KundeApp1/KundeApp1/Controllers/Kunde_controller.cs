using System;
using System.Collections.Generic;
using KundeApp1.Models;
using Microsoft.AspNetCore.Mvc;

namespace KundeApp1.Controllers
{
    [Route("[controller]/[action]")]
    public class Kunde_controller : ControllerBase
    {

        public List<Kunde> HentAlle()
        {
            var kundene = new List<Kunde>();

            var kunde1 = new Kunde();
            kunde1.navn = "Ole Hansen";
            kunde1.adresse = "Haneborgveien 32";

            var kunde2 = new Kunde
            {
                navn = "Line Hansen",
                adresse = "Osloveien 69"
            };

            kundene.Add(kunde1);
            kundene.Add(kunde2);

            return kundene;
        }
    }
}

