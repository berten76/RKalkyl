using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Meals.Domain;
using Meals.Persistence;
using MediatR;

namespace Meals.Application.FoodItems
{
    public class Edit
    {
        public class Command : IRequest
        {
            public FoodItem FoodItem { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly MealsDataContext _context;
            private readonly IMapper _mapper;
            public Handler(MealsDataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<Unit> Handle(Command cmd, CancellationToken cancellationToken)
            {
                var foodItem = await _context.FoodItems.FindAsync(cmd.FoodItem.FoodItemId);
                _mapper.Map(cmd.FoodItem, foodItem);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }

        }
    }
}
