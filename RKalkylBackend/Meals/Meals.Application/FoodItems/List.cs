using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Meals.Domain;
using Meals.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Meals.Application.FoodItems
{
    public class List
    {
        public class Query : IRequest<List<FoodItem>> { }

        public class Handler : IRequestHandler<Query, List<FoodItem>>
        {
            private readonly MealsDataContext _context;
            public Handler(MealsDataContext context)
            {
                _context = context;
            }

            public async Task<List<FoodItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var items = await _context.FoodItems.AsNoTracking().ToListAsync();
                    return items;
                }
                catch (Exception e)
                {
                    return await _context.FoodItems.ToListAsync();
                }
            }
        }
    }
}
