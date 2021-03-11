using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using RKalkyl.Domain;
using MediatR;
using RKalkyl.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;

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
            private readonly ILogger<Edit> _logger;

            public Handler(DataContext context, IMapper mapper, ILogger<Edit> logger)
            {
                _mapper = mapper;
                _logger = logger;
                _context = context;
            }
            public async Task<Unit> Handle(Command cmd, CancellationToken cancellationToken)
            {
                try
                {
                var recepie = await _context.Recepies
                                            .Include(r => r.Ingredients)
                                            .ThenInclude(r => r.foodItem)
                                            .FirstOrDefaultAsync(r => r.Id == cmd.Recepie.Id);
                _mapper.Map(cmd.Recepie, recepie);
                await _context.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("gggtttttttttttttttttttt");
                    Console.WriteLine(ex);
                _logger.LogError(ex, "An error occured durig migrations");
                }
                return Unit.Value;
            }

        }
    }
}