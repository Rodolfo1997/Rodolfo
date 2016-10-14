using NegociacaoMerca.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NegociacaoMerca.Repository
{
    public class LojaNegociacaoContext : DbContext
    {
        public DbSet<Mercadoria> Mercadoria { get; set; }
    }
}