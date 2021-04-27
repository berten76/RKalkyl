using System.Threading;
using System.Threading.Tasks;
using Core.Application;
using FluentValidation;
using Meals.Domain;
using Meals.Persistence;
using MediatR;

namespace Meals.Application.Meals
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Meal Meal { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                var v = new MealValidator();
                RuleFor(x => x.Meal).SetValidator(new MealValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly MealsDataContext _context;
            public Handler(MealsDataContext context)
            {
                _context = context;
            }
            public async Task<Result<Unit>> Handle(Command cmd, CancellationToken cancellationToken)
            {
                _context.Meals.Add(cmd.Meal);
                bool result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create meal");

                return Result<Unit>.CreateResult(Unit.Value);
            }
        }
    }
}
