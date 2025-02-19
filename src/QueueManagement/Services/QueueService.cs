using System.Collections.Concurrent;
using QueueManagement.Dtos;

namespace QueueManagement.Services;

public interface IQueueService
{
    Task EnqueueAsync(QueueDto user);
    Task<QueueDto?> DequeueAsync();
    Task<List<QueueDto>> GetAllAsync();
    Task<QueueDto?> GetFirst();
}

public class QueueService: IQueueService
{
    private int Counter = 0;
    private readonly ConcurrentQueue<QueueDto> _queue = new ConcurrentQueue<QueueDto>();
    private readonly SemaphoreSlim _semaphore = new(1, 1);
    public async Task EnqueueAsync(QueueDto user)
    {
        await _semaphore.WaitAsync();
        try
        {
            user.Name = "A" + Counter;
            _queue.Enqueue(user);
            Counter++;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task<QueueDto?> DequeueAsync()
    {
        await _semaphore.WaitAsync();
        try
        {
            if (_queue.TryDequeue(out var dequeuedUser))
            {
                return dequeuedUser;
            }
            return null;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task<List<QueueDto>> GetAllAsync()
    {
        await _semaphore.WaitAsync();
        try
        {
            return _queue.ToList();
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task<QueueDto?> GetFirst()
    {
        await _semaphore.WaitAsync();
        try
        {
            return _queue.FirstOrDefault();
        }
        finally
        {
            _semaphore.Release();
        }
    }
}