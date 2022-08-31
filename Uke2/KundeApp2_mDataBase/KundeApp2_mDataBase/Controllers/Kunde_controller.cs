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
    }
}

