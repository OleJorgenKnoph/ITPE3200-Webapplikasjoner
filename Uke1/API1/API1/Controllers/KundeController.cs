using System;
using System.Collections.Generic;
using API1.Models;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    [Route("[Controller]/[action]")]
    public class KundeController : ControllerBase
    {
        public List<Kunde> HentAlle()
        {
            var kundene = new List<Kunde>();

            var kunde1 = new Kunde();
            kunde1.navn = "Ole Hansen";
            kunde1.adresse = "Osloveien 1";

            var kunde2 = new Kunde
            {
                navn = "Line Olsen",
                adresse = "Karl Johan 69"
            };

            kundene.Add(kunde1);
            kundene.Add(kunde2);

            return kundene;
        }
    }
}

