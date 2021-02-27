using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.FoodItems
{
    public class Details
    {
         public class Query : IRequest<FoodItem> 
         { 
             public Guid Id { get; set; }
         }

        public class Handler : IRequestHandler<Query, FoodItem>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<FoodItem> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.FoodItems.FindAsync(request.Id);
            }
        }
    }
}