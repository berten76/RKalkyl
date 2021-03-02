using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using RKalkyl.Domain;
using MediatR;
using RKalkyl.Persistance;

namespace RKalkyl.Application.Recepies
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Recepie Recepie { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<Unit> Handle(Command cmd, CancellationToken cancellationToken)
            {
                var recepie = await _context.Recepies.FindAsync(cmd.Recepie.Id);
                _mapper.Map(cmd.Recepie, recepie);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }

        }
    }
}