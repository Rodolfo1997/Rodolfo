using NegociacaoMerca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NegociacaoMerca.Repository
{
    public class MercadoriaRepo
    {
        private LojaNegociacaoContext db;

        public MercadoriaRepo(LojaNegociacaoContext db)
        {
            this.db = db;
        }

        public IList<Mercadoria> ListarMercadorias()
        {
            var mercadorias = db.Mercadoria.ToList();
            return mercadorias;
        }

        public Mercadoria SelecionarMercadoriaId(int id)
        {
            var mercadoria = db.Mercadoria.Where(a => a.Id == id).FirstOrDefault();
            return mercadoria;
        }

        public void Inserir(Mercadoria mercadoria)
        {
            db.Mercadoria.Add(mercadoria);
            db.SaveChanges();
        }

        public void Editar(Mercadoria mercadoria)
        {
            db.Mercadoria.Attach(mercadoria);
            var entry = db.Entry(mercadoria);
            entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}