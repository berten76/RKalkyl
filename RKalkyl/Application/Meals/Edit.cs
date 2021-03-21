using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using RKalkyl.Domain;
using MediatR;
using RKalkyl.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;
using Application.Dtos;
using System.Linq;

namespace RKalkyl.Application.Meals
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Meal Meal { get; set; }
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
                var meal = await _context.Meals
                                            .Include(r => r.Ingredients)
                                            .ThenInclude(r => r.foodItem)
                                            .FirstOrDefaultAsync(r => r.MealId == cmd.Meal.MealId);
                

                _mapper.Map(cmd.Meal, meal); 
               //meal.Ingredients.First().AmountInGram = 567;

                //var updatedMeal = new Meal();
               // foreach(var ingred in cmd.Meal.Ingredients)
               // {
                 //   _context.Entry(ingred).State = EntityState.Modified;     
                //}                       
                //_mapper.Map(cmd.Meal, meal);
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