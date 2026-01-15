using ChannelWepApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<MyQueeServices>();
builder.Services.AddHostedService<MyBackgroundServices>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapGet("/", async (MyQueeServices myQueeService) =>
{
    var info = new EmailDto("test@test.com", "Test enaili");
    await myQueeService._emailChannel.Writer.WriteAsync(info);
    return Results.Ok("is working");
});
app.Run();
