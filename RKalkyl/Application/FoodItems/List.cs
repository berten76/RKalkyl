using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RKalkyl.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RKalkyl.Persistance;
using System;

namespace RKalkyl.Application.FoodItems
{
    public class List
    {
        public class Query : IRequest<List<FoodItem>> { }

        public class Handler : IRequestHandler<Query, List<FoodItem>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<FoodItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                var items =  await _context.FoodItems.AsNoTracking().ToListAsync();
                return items;
                }
                catch(Exception e)
                {
                     return await _context.FoodItems.ToListAsync();
                }
            }
        }
    }
}