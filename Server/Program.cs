var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddLogging();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(ep =>
{
  ep.MapGet("/", () => "Start server");
  ep.MapHub<ChatRoom<ConsoleUserModel>>("/notify");
});

app.Run();