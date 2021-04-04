using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meals.Application.RecepieToMeal
{
    class Class1
    {
    }
}
/*   public async void UpdateCustomerCommand_CustomerDataUpdatedOnDatabase()
    {
        //Arange
        var mediator = new  Mock<IMediator>();

        UpdateCustomerCommand command = new UpdateCustomerCommand();
        UpdateCustomerCommandHandler handler = new UpdateCustomerCommandHandler(mediator.Object);

        //Act
        Unit x = await handler.Handle(command, new System.Threading.CancellationToken());

        //Asert
        //Do the assertion

        //something like:
        mediator.Verify(x=>x.Publish(It.IsAny<CustomersChanged>()));
    }*/