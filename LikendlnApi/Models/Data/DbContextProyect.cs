using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.Data
{
    public class DbContextProyect : DbContext
    {
        public DbContextProyect() : base("name=DbContextProyect")
        {
        }

    }
}