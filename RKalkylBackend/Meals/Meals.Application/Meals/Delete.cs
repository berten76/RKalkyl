using System;
using System.Threading;
using System.Threading.Tasks;
using Meals.Persistence;
using MediatR;

namespace Meals.Application.Meals
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly MealsDataContext _context;
            public Handler(MealsDataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command cmd, CancellationToken cancellationToken)
            {
                var meal = await _context.Meals.FindAsync(cmd.Id);
                _context.Meals.Remove(meal);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }

        }
    }
}
