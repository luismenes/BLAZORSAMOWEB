using Blazored.Toast;
using BlazorServer.Business;
using BlazorServer.Common.Helpers.SweetAlert;
using BlazorServer.Presentation.Modules.AutoMapper;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBusinessServices(builder.Configuration);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMapper();
builder.Services.AddControllers();
builder.Services.AddMudBlazorDialog();
builder.Services.AddMudServices();
builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<SwaAlerts>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
});


app.Run();
