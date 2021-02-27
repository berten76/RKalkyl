using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.FoodItems
{
    public class Create
    {
        public class Command : IRequest
        {
            public FoodItem FoodItem {get; set;}
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
                _context.FoodItems.Add(cmd.FoodItem);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}