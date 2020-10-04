using Core.Financeiro;
using System.Data.Entity;
using System;
using System.Linq;
using Repository.DAL.Padrao;
using System.Data.Entity.Migrations;

namespace Repository.DAL.Financeiro
{
    public class CobrancaDAL : PadraoContext
    {
        public IQueryable GetCobrancasList()
        {
            return _context.Cobrancas.Where(c => c.Status < 99).OrderBy(c => c.Nome) ;
        }

        public IQueryable GetAllCobrancas()
        {
            return _context.Cobrancas.OrderBy(c => c.Id);
        }

        public Cobranca GetCobrancaById(int id)
        {
            Cobranca cobranca = _context.Cobrancas.Where(c => c.Id == id).FirstOrDefault();

            return cobranca;
        }

        public void SaveCobranca(Cobranca cobranca)
        {
            if(cobranca.Id == null)
            {
                cobranca.Create = DateTime.Now;
                _context.Cobrancas.Add(cobranca);
            }
            else
            {
                Cobranca cob = GetCobrancaById((int)cobranca.Id);
                cobranca.Create = cob.Create;
                cobranca.Modified = DateTime.Now;
                _context.Cobrancas.AddOrUpdate<Cobranca>(cobranca);
            }

            _context.SaveChanges();
        }
    }
}
