using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data.Contexts;
using Domain.Interfaces.Models;
using Domain.Interfaces.Services;
using Newtonsoft.Json;
using FluentValidation.Results;
using MoreLinq;

namespace TestePMWeb.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelService _interfaceHotel;
        private readonly IFotoService _interfaceFoto;
        public readonly IQuartoService _interfaceQuarto;

        public HotelsController(IHotelService InterfaceHotel, IFotoService InterfaceFoto, IQuartoService InterfaceQuarto)
        {
            _interfaceHotel = InterfaceHotel;
            _interfaceFoto = InterfaceFoto;
            _interfaceQuarto = InterfaceQuarto;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult List()
        {
            return Json(_interfaceHotel.List());
        }

        [HttpPost]
        public JsonResult SaveChange(Hotel hotel)
        {
            List<ValidationFailure> Errors = new List<ValidationFailure>();

            if(hotel.ID == 0)
            {
                Errors = _interfaceHotel.Add(hotel);
            }
            else
            {
                Errors = _interfaceHotel.Update(hotel);
            }


            if (hotel.ID != 0 && hotel.Fotos != null)
            {
                if(hotel.Fotos.Count > 0)
                {
                    hotel.Fotos.ForEach(x => x.Tipo = "Hotel");
                    hotel.Fotos.ForEach(x => x.Codigo = hotel.ID);

                    _interfaceFoto.Update(hotel.Fotos);
                }
            }
            
            return Json(Errors);
        }

        [HttpPost]
        public void Delete(int id)
        {
            var hotel = _interfaceHotel.GetEntityById(id);

            _interfaceHotel.Delete(hotel);
        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveQuarto(Quarto quarto)
        {
            List<ValidationFailure> Errors = new List<ValidationFailure>();

            if (quarto.ID == 0)
            {
                Errors = _interfaceQuarto.Add(quarto);
            }
            else
            {
                Errors = _interfaceQuarto.Update(quarto);
            }

           

            if (quarto.ID != 0 && quarto.Fotos != null)
            {
                if(quarto.Fotos.Count > 0)
                {
                    quarto.Fotos.ForEach(x => x.Tipo = "Quarto");
                    quarto.Fotos.ForEach(x => x.Codigo = quarto.ID);

                    _interfaceFoto.Update(quarto.Fotos);
                }
                
            }

            return Json(Errors);
        }

        public IActionResult Save(int? id)
        {
            return View();
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var hotel = _interfaceHotel.GetEntityById(id);

            hotel.Fotos = _interfaceFoto.GetPhotos(hotel.ID, "Hotel");

            hotel.Quartos = _interfaceQuarto.GetQuartos(hotel.ID);

            hotel.Quartos.ForEach(x => x.Fotos = _interfaceFoto.GetPhotos(x.ID, "Quarto"));

            return Json(hotel);
        }

        [HttpPost]
        public void DeleteQuarto(int id)
        {
            var quarto = _interfaceQuarto.GetEntityById(id);

            _interfaceQuarto.Delete(quarto);
        }
    }
}
