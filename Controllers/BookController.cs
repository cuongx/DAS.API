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

namespace DAS.API.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        [HttpGet]
        [Route("/bookss/gets")]
        public async Task<IEnumerable<Bookss>> Gets()
        {
            return await bookService.Gets();
        }
        [HttpGet]
        [Route("/bookss/get/{id}")]
        public async Task<Bookss>Get(int id)
        {
            return await bookService.Get(id);
        }
        [HttpPost]
        [Route("/bookss/savebookss/save")]
        public async Task<SaveBooksRequest> SaveBooks(SaveBooksResult save)
        {
            return await bookService.Save(save);
        }
        [HttpDelete]
        [Route("/bookss/delete/{id}")]
        public async Task<DeleteBooksResult>DeleteBookss(int id)
        {
            return await bookService.Delete(id);
        }
    }
}
