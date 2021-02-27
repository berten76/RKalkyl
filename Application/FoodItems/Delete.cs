using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistance;

namespace Application.FoodItems
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
                var foodItem = await _context.FoodItems.FindAsync(cmd.Id);
                _context.FoodItems.Remove(foodItem);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }

        }
    }
}