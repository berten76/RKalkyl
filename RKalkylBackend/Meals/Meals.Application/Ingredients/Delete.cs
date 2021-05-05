using System;
using System.Threading;
using System.Threading.Tasks;
using Meals.Persistence;
using MediatR;

namespace Meals.Application.Ingredients
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
                var ingredient = await _context.Ingredient.FindAsync(cmd.Id);
                if (ingredient == null) return Unit.Value;
                _context.Ingredient.Remove(ingredient);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }

        }
    }
}
