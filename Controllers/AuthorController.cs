using DAS.BAL.Interface;
using DAS.Domain.Responses.Author;
using DAS.Domain.Resquests.Author;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS.API.Controllers
{
    [ApiController]
    public class AuthorController:Controller
    {
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        [Route("/author/gets")]
        public async Task<IEnumerable<Author>> Gets()
        {
            return await authorService.Gets();
        }
        [HttpGet]
        [Route("/author/get/{id}")]
        public async Task<Author> Get(int id)
        {
            return await authorService.Get(id);
        }
        [HttpPost]
        [Route("/author/save")]
        public async Task<SaveAuthorResult> Save(SaveAuthorResquest save)
        {
            return await authorService.Save(save);
        }
        [HttpDelete]
        [Route("/author/delete/{id}")]
        public async Task<DeleteAuthorResult> Delete(int id)
        {
            return await authorService.Delete(id);
        }
    }
}
