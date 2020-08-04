using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAS.BAL.Interface;
using DAS.Domain.Responses;
using DAS.Domain.Resquests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DAS.API.Controllers
{
    [ApiController]
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
        /// <summary>
        /// get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("/category/get/{id}")]
        public async Task<Category>Get(int id)
        {

            return await categoryService.Get(id);
        }
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/category/save")]
        public async Task<SaveCategoryResult> Save(Category category)
        {
            return await categoryService.Save(category);
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/category/delete/{id}")]
        public async Task<DeleteCategoryResult>Delete(int id)
        {
            return await categoryService.Delete(id);
        }
    }
}