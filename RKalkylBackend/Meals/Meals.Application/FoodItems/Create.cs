using System.Threading;
using System.Threading.Tasks;
using Meals.Domain;
using Meals.Persistence;
using MediatR;

namespace Meals.Application.FoodItems
{
    public class Create
    {
        public class Command : IRequest
        {
            public FoodItem FoodItem { get; set; }
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
                _context.FoodItems.Add(cmd.FoodItem);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
