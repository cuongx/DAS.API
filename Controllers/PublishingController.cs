using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAS.BAL.Interface;
using DAS.Domain.Responses.Author;
using DAS.Domain.Responses.Publishing;
using DAS.Domain.Resquests.Publishing;
using Microsoft.AspNetCore.Mvc;

namespace DAS.API.Controllers
{
    public class PublishingController : Controller
    {
        private readonly IPublishingService publishingService;

        public PublishingController(IPublishingService publishingService)
        {
            this.publishingService = publishingService;
        }

        [HttpGet]
        [Route("/publishing/gets")]
        public async Task<IEnumerable<Publishing>> Gets()
        {
            return await publishingService.Gets();
        }


        [HttpGet]
        [Route("/publishing/get/{id}")]
        public async Task<Publishing> Get(int id)
        {
            return await publishingService.Get(id);
        }


        [HttpPost]
        [Route("/publishing/save")]
        public async Task<SavePublishingResult> Save([FromBody] SavePublishingResquest save)
        {
            return await publishingService.Save(save);
        }


        [HttpDelete]
        [Route("/publishing/delete/{id}")]
        public async Task<DeletePublishingResult> Delete(int id)
        {
            return await publishingService.Delete(id);
        }
    }
}