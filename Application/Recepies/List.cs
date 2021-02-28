using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Recepies
{
     public class List
    {
        public class Query : IRequest<List<Recepie>> { }

        public class Handler : IRequestHandler<Query, List<Recepie>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Recepie>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Recepies
                                     .Include(r => r.FoodItems)
                                     .ToListAsync();
            }
        }
    }
}


