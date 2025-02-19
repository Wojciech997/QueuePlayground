using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QueueManagement.Controllers;

public class QueueController(IMediator mediator): ControllerBase
{
    [HttpGet("testGet")]
    public async Task<int> TestGet()
    {
        //var customerDetails = await _mediator.Send(new GetCustomerRequest() { CustomerId = customerId});
        return 1;
    }

    // [HttpGet("GetQueue")]
    // public async Task<List<QueueDto>> GetQueue(GetQueueQuery query, CancellationToken cancellationToken)
    // {
    //     var result = await mediator.Send(query, cancellationToken);
    //     return result;
    // }

}