using System;
using System.Threading;
using System.Threading.Tasks;
using Meals.Persistence;
using MediatR;

namespace Meals.Application.FoodItems
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
                var foodItem = await _context.FoodItems.FindAsync(cmd.Id);
                _context.FoodItems.Remove(foodItem);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }

        }
    }
}

