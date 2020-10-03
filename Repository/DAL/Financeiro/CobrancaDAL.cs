using Core.Financeiro;
using System.Data.Entity;
using System;
using System.Linq;
using Repository.DAL.Padrao;

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
                cobranca.Modified = DateTime.Now;
                _context.Entry(cobranca).State = EntityState.Modified;
            }

            _context.SaveChanges();
        }
    }
}
