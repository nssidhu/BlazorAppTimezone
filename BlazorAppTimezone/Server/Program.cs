
using Microsoft.AspNetCore.Authentication;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.ResponseCompression;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
//builder.Services.AddRazorPages(); //not needed for Blazor Wasm


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TimeZoneAPI", Version = "v1" });
    
    
});



builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient("default", client =>
{
    //client.BaseAddress = new Uri("");
    client.DefaultRequestHeaders.Add("Accept", "");
    client.DefaultRequestHeaders.Add("User-Agent", "API");
});


var app = builder.Build();



app.UseWebAssemblyDebugging();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TimeZoneAPI"));

//https://edi.wang/post/2020/4/29/my-aspnet-core-route-debugger-middleware
app.UseRouteDebugger(); // to use /route-debugger

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    //app.UseWebAssemblyDebugging();
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TimeZoneAPI"));
   
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();



app.UseBlazorFrameworkFiles();
app.UseStaticFiles();


app.UseRouting();


app.UseEndpoints(endpoints =>
{
   
    endpoints.MapControllers(); //This will map the Attribute Routing that is decorated inside the controller
   
    //endpoints.MapControllerRoute(
    //   name: "default",
    //   pattern: "api/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapFallbackToFile("index.html");
    
});

app.Run();








