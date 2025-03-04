using MassTransit;

namespace MailConsumer;

public class RabbitMqConsumerHostedService: IHostedService
{
    private readonly IBusControl _busControl;

    public RabbitMqConsumerHostedService(IBusControl busControl)
    {
        _busControl = busControl;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _busControl.StartAsync(cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _busControl.StopAsync(cancellationToken);
    }
}