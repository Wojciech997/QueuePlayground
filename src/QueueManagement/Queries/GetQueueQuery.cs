using MediatR;
using QueueManagement.Dtos;
using QueueManagement.Services;

namespace QueueManagement.Queries;

public class GetQueueQuery : IRequest<List<QueueDto>>
{
}

public class GetQueueQueryHandler(IQueueService queueService) : IRequestHandler<GetQueueQuery, List<QueueDto>>
{
    public async Task<List<QueueDto>> Handle(GetQueueQuery request, CancellationToken cancellationToken)
    {
        return await queueService.GetAllAsync();
    }
}