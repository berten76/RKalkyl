using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RKalkyl.Domain;
using RKalkyl.Persistance;

namespace Application.Ingredients
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Ingredient Ingredient { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<Edit> _logger;

            public Handler(DataContext context, IMapper mapper, ILogger<Edit> logger)
            {
                _mapper = mapper;
                _logger = logger;
                _context = context;
            }
            public async Task<Unit> Handle(Command cmd, CancellationToken cancellationToken)
            {
                try
                {
                     var ingredient = await _context.Ingredient
                                            .Include(r => r.foodItem)
                                            .FirstOrDefaultAsync(r => r.Id == cmd.Ingredient.Id);

                                            //.FirstOrDefaultAsync(r => r.MealId == cmd.Meal.MealId);
                
                if(ingredient.foodItem.FoodItemId != cmd.Ingredient.foodItem.FoodItemId)
                {
                    ingredient.foodItem =  cmd.Ingredient.foodItem;
                }
                   // ingredient.FoodItemId = cmd.Ingredient.foodItem.FoodItemId;
                    ingredient.AmountInGram =  cmd.Ingredient.AmountInGram;
                   // _mapper.Map(cmd.Ingredient, ingredient); 

                    await _context.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("gggtttttttttttttttttttt");
                    Console.WriteLine(ex);
                _logger.LogError(ex, "An error occured durig migrations");
                }
                return Unit.Value;
            }

        }
    }
}