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
using FluentValidation;
using Core.Application;

namespace Meals.Application.Meals
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Meal Meal { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Meal).SetValidator(new MealValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
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
            public async Task<Result<Unit>> Handle(Command cmd, CancellationToken cancellationToken)
            {
                try
                {
                    var meal = await _context.Meals
                                                .Include(r => r.Ingredients)
                                                .ThenInclude(r => r.foodItem)
                                                .FirstOrDefaultAsync(r => r.MealId == cmd.Meal.MealId);

                    if (meal == null) return Result<Unit>.NotFound();

                    _mapper.Map(cmd.Meal, meal);
                   
                    bool result = await _context.SaveChangesAsync() > 0;

                    if (!result) return Result<Unit>.Failure("Failed to safe meal");

                    return Result<Unit>.CreateResult(Unit.Value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("gggtttttttttttttttttttt");
                    Console.WriteLine(ex);
                    _logger.LogError(ex, "An error occured durig migrations");
                }
                return Result<Unit>.Failure("failed to edit meal");
            }

        }
    }
    }
