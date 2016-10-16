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

        public void Excluir(Mercadoria mercadoria)
        {
            db.Mercadoria.Attach(mercadoria);
            var entry = db.Entry(mercadoria);
            entry.State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        public IList<Mercadoria> ListarMercadoriasFiltro(string nomeMercadoria, string codMercadoria)
        {
            var mercadoria = db.Mercadoria.ToList();

            if(!string.IsNullOrEmpty(nomeMercadoria))
                mercadoria = mercadoria.Where(a => a.NomeMercadoria.Contains(nomeMercadoria)).ToList();

            if (!string.IsNullOrEmpty(codMercadoria))
                mercadoria = mercadoria.Where(a => a.CodMercadoria.Contains(codMercadoria)).ToList();
            
            return mercadoria;
        }
    }
}