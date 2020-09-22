﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WApp.Service.Controllers
{
    public class FinanceiroController : Controller
    {

        public List<FinanceiroView> lista = ListaFinanceira();

        // GET: Financeiro
        public ActionResult Index()
        {

            return View(lista);
        }

        public ActionResult Create()
        {
            return View();
        }

        private static List<FinanceiroView> ListaFinanceira()
        {
            FinanceiroView f1 = new FinanceiroView()
            {
                Id = 1,
                Data = DateTime.Now,
                Descricao = "PagSeguro",
                Valor = 49.80,
                CobrancaId = 1,
                Parcelamento = "4/6",
                Observacao = "Tio Zé",
                CategoriaId = 1,
                StatusId = 1,
                Create = DateTime.Now,
                Modified = DateTime.Now

            };

            FinanceiroView f2 = new FinanceiroView()
            {
                Id = 2,
                Data = DateTime.Now,
                Descricao = "Anuidade",
                Valor = 49.80,
                CobrancaId = 1,
                Parcelamento = "À Vista",
                Observacao = "",
                CategoriaId = 1,
                StatusId = 1,
                Create = DateTime.Now,
                Modified = DateTime.Now

            };

            FinanceiroView f3 = new FinanceiroView()
            {
                Id = 3,
                Data = DateTime.Now,
                Descricao = "DL Google",
                Valor = 49.80,
                CobrancaId = 1,
                Parcelamento = "À Vista",
                Observacao = "Armazenamento em Nuvem",
                CategoriaId = 1,
                StatusId = 1,
                Create = DateTime.Now,
                Modified = DateTime.Now

            };
            List<FinanceiroView> list = new List<FinanceiroView>();

            list.Add(f1);
            list.Add(f2);
            list.Add(f3);






            return list;
        }

    }

    public class FinanceiroView
    {
        public int Id { get; set; }
        [DisplayName("Data Compra")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public double Valor { get; set; }
        [DisplayName("Cobrança")]
        public int CobrancaId { get; set; }
        public string Parcelamento { get; set; }
        [DisplayName("Categoria")]
        public int CategoriaId { get; set; }
        [DisplayName("Observação")]
        public string Observacao { get; set; }
        [DisplayName("Status")]
        public int StatusId { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modified { get; set; }
    }

    public class FinanceiroBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Status { get; set; }
        public DateTime Create { get; set; }
        public DateTime Modified { get; set; }
    }

    public class CategoriaView : FinanceiroBase
    {

    }

    public class StatusView : FinanceiroBase
    {

    }

    public class CobrancaView : FinanceiroBase
    {

    }
}