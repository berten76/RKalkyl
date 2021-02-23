using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers
{
    public class FoodItemsController : BaseApiController
    {
        private readonly DataContext _context;
        public FoodItemsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FoodItem>>> GetFoodItems()
        {
            return await _context.FoodItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItem>> GetFoodItem(Guid id)
        {
            return await _context.FoodItems.FindAsync(id);
        }
    }
}