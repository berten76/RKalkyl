using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Application;
using Meals.Persistence;
using MediatR;

namespace Meals.Application.Meals
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
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
                var meal = await _context.Meals.FindAsync(cmd.Id);
                if (meal == null) return Result<Unit>.NotFound();

                _context.Meals.Remove(meal);
                bool result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete meal");
                return Result<Unit>.CreateResult(Unit.Value);
            }

        }
    }
}
