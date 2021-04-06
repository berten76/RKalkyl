using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using MediatR;
using RKalkyl.Domain;
using RKalkyl.Persistance;

namespace Application.Ingredients
{
    public class Create
    {
        public class Command : IRequest
        {
            public IngredientDto Ingredient { get; set; }
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
                try{
                
                var ingredient  = new Ingredient() 
                                    {
                                        MealId = cmd.Ingredient.MealId,
                                        FoodItemId = cmd.Ingredient.foodItem.FoodItemId,
                                        AmountInGram = cmd.Ingredient.AmountInGram
                                    };
                                    
               // = _mapper.Map<IngredientDto, Ingredient>(cmd.Ingredient);
                _context.Ingredient.Add(ingredient);
                await _context.SaveChangesAsync();
                }
                catch(Exception e)
                {
                    
                }
                return Unit.Value;
            }
        }
    }
}