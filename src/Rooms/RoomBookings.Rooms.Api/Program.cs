using RoomBookings.Rooms.Api;
using RoomBookings.Rooms.SqlServer;
using RoomBookings.Rooms.Application;
using RoomBookings.Rooms.Queries;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCommonApplicationServices();
builder.Services.AddCommonEntityFrameworkServices();

builder.Services.AddApplicationServices();
builder.Services.AddQueryServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebUIServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();

    // Initialise and seed database
    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<RoomsDbContextInitialiser>();
        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
    }
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
//app.UseStaticFiles();

app.UseSwaggerUi3(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.UseAuthentication();
//app.UseIdentityServer();
app.UseAuthorization();


app.MapControllers();

app.Run();