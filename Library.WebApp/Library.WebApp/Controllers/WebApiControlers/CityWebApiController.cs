using AutoMapper;
using Library.Entities;
using Library.LogicContracts;
using Library.WebApp.Models.MapperProfile;
using Library.WebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.WebApp.Controllers.WebApiControlers
{
    public class CityWebApiController : ApiController
    {
        private readonly ICityLogic cities;
        private readonly MapperConfiguration config;
        private readonly IMapper mapper;

        public CityWebApiController(ICityLogic cityLogic)
        {
            this.cities = cityLogic;
            this.config = new MapperConfiguration(cfg => {
                cfg.AddProfile<CityAutoMapperProfile>();
            });
            this.mapper = config.CreateMapper();
        }

        public IHttpActionResult GetAllCities()
        {
            var model = mapper.Map<ICollection<CityViewModel>>(cities.GetAll());
            if (model.Count == 0)
            {
                return NotFound();
            }
            return Ok(model.ToList());
        }
        public City GetCity(int id)
        {
            return cities.GetById(id);
        }

        public bool PostCity(City author)
        {
            return cities.Add(author);
        }

        public bool PutCity(City author)
        {
            return cities.Edit(author);
        }

        public bool DeleteCity(int id)
        {
            return cities.Delete(id);
        }
    }
}
