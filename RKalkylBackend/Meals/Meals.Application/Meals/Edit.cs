using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;
using System.Linq;
using Meals.Domain;
using Meals.Persistence;

namespace Meals.Application.Meals
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Meal Meal { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly MealsDataContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<Edit> _logger;

            public Handler(MealsDataContext context, IMapper mapper, ILogger<Edit> logger)
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
                   
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
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
