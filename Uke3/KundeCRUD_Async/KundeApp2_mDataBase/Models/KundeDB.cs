using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KundeApp2_mDataBase.Models
{

    public class Kunder
    {
        public int id { get; set; }

        public string forNavn { get; set; }

        public string etterNavn { get; set; }

        public string adresse { get; set; }

        virtual public Poststed postSted { get; set; }
    }

    public class Poststed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string postNr { get; set; }

        public string postSted { get; set; }
    }

    public class KundeDB : DbContext
    {
        public KundeDB(DbContextOptions<KundeDB> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Kunder> Kunder { get; set; }

        public DbSet<Poststed> Poststed { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            opt.UseLazyLoadingProxies();
        }
    }
}

