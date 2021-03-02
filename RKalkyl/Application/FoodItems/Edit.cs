using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using RKalkyl.Domain;
using MediatR;
using RKalkyl.Persistance;

namespace RKalkyl.Application.FoodItems
{
    public class Edit
    {
        public class Command : IRequest
        {
            public FoodItem FoodItem { get; set; }
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
                var foodItem = await _context.FoodItems.FindAsync(cmd.FoodItem.Id);
                _mapper.Map(cmd.FoodItem, foodItem);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }

        }
    }
}