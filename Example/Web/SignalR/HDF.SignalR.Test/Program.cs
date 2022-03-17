using HDF.SignalR.Test;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();


builder.Services.AddSignalR();

builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();



//app.UseCors(builder =>
//{
//    builder.AllowAnyOrigin()
//        .AllowAnyHeader()
//        .AllowAnyMethod();
//});


app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<TestHub>("/test");

});

app.Run();




