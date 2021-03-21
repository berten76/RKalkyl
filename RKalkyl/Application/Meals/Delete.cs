using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RKalkyl.Persistance;

namespace RKalkyl.Application.Meals
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id {get; set;}
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
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