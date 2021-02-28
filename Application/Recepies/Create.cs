using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.Recepies
{
    public class Create
    {
        public class Command : IRequest
        {
            public Recepie Recepie {get; set;}
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
                _context.Recepies.Add(cmd.Recepie);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}