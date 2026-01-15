using System.Threading.Channels;

namespace ChannelWepApi;

public sealed class MyQueeServices
{
    public readonly Channel<EmailDto> _emailChannel;
    public MyQueeServices()
    {
        _emailChannel = Channel.CreateBounded<EmailDto>(
            new BoundedChannelOptions(1)
            {
                SingleReader = true,
                SingleWriter =true,
                FullMode= BoundedChannelFullMode.Wait
            });
    }
}
public sealed record EmailDto(string To, string Body);
