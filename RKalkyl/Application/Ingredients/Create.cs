using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RKalkyl.Domain;
using RKalkyl.Persistance;

namespace Application.Ingredients
{
   public class Create
    {
        public class Command : IRequest
        {
            public Ingredient Ingredient {get; set;}
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
                _context.Ingredient.Add(cmd.Ingredient);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}