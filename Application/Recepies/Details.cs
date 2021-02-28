using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.Recepies
{
    public class Details
    {
         public class Query : IRequest<Recepie> 
         { 
             public Guid Id { get; set; }
         }

        public class Handler : IRequestHandler<Query, Recepie>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Recepie> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Recepies.FindAsync(request.Id);
            }
        } 
    }
}