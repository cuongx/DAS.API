using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DAS.API.Models;
using DAS.BAL.Interface;
using DAS.Domain.Resquests;
using DAS.Domain.Responses;
using DAS.Domain.Responses.Books;

namespace DAS.API.Controllers
{
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        [HttpGet]
        [Route("/book/gets/{id}")]
        public async Task<IEnumerable<Bookss>> Gets(int id)
        {
            return await bookService.Gets(id);
        }
        [HttpGet]
        [Route("/book/get/{id}")]
        public async Task<Bookss>Get(int id)
        {
            return await bookService.Get(id);
        }
        [HttpPost]
        [Route("/book/save")]
        public async Task<SaveBooksResult> Save(SaveBooksRequest save)
        {
            return await bookService.Save(save);
        }
        [HttpDelete]
        [Route("/book/delete/{id}")]
        public async Task<DeleteBooksResult>Delete(int id)
        {
            return await bookService.Delete(id);
        }
    }
}
