using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAS.BAL.Interface;
using DAS.Domain.Responses;
using DAS.Domain.Resquests;
using Microsoft.AspNetCore.Mvc;

namespace DAS.API.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        [Route("/category/gets")]
        public async Task<IEnumerable<Category>> Gets()
        {
            return await categoryService.Gets();
        }
        [HttpGet]
        [Route("/category/get/{id}")]
        public async Task<Category>Get(int id)
        {

            return await categoryService.Get(id);
        }
        [HttpPost]
        [Route("/category/save")]
        public async Task<SaveCategoryResult>Save(Category category)
        {
            return await categoryService.Save(category);
        }
        [HttpDelete]
        [Route("/category/delete/{id}")]
        public async Task<DeleteCategoryResult>Delete(int id)
        {
            return await categoryService.Delete(id);
        }
    }
}