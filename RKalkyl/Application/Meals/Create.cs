using System.Threading;
using System.Threading.Tasks;
using RKalkyl.Domain;
using MediatR;
using RKalkyl.Persistance;

namespace RKalkyl.Application.Meals
{
    public class Create
    {
        public class Command : IRequest
        {
            public Meal Meal {get; set;}
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
                _context.Meals.Add(cmd.Meal);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}