using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace googlemapMVC.Models
{
    public class haritaCONTEXT : DbContext
    {
        public haritaCONTEXT() : base("sqlim")
        {

        }

        public DbSet<sehir> sehirler { get; set; }
        public DbSet<konum> konumlar { get; set; }
    }
}