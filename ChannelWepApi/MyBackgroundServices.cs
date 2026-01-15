namespace ChannelWepApi;

public class MyBackgroundServices(MyQueeServices myQueeServices):BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
       
        await foreach (var item in myQueeServices._emailChannel.Reader.ReadAllAsync(stoppingToken))
        {
         Console.WriteLine("TO:{0},BODY:{1}", item.To, item.Body);
         await Task.Delay(500);
        }
    }
}
