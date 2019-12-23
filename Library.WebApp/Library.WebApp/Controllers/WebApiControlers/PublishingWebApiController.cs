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
    public class PublishingWebApiController : ApiController
    {
        private readonly IPublishingLogic publishings;
        private readonly MapperConfiguration config;
        private readonly IMapper mapper;

        public PublishingWebApiController(IPublishingLogic publishingLogic)
        {
            this.publishings = publishingLogic;
            this.config = new MapperConfiguration(cfg => {
                cfg.AddProfile<PublishingAutoMapperProfile>();
            });
            this.mapper = config.CreateMapper();
        }

        public IHttpActionResult GetAllPublishings()
        {
            var model = mapper.Map<ICollection<PublishingViewModel>>(publishings.GetAll());
            if (model.Count == 0)
            {
                return NotFound();
            }
            return Ok(model.ToList());
        }
        public Publishing GetPublishing(int id)
        {
            return publishings.GetById(id);
        }
        public bool PostPublishing(Publishing publishing)
        {
            return publishings.Add(publishing);
        }

        public bool PutPublishing(Publishing publishing)
        {
            return publishings.Edit(publishing);
        }

        public bool DeletePublishing(int id)
        {
            return publishings.Delete(id);
        }
    }
}
