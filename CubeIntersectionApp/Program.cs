using CubeIntersectionApp.Presentation;
using Domain.Entities;
using Domain.Services;
using Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;

class Program
{
    static void Main()
    {
        // AQUI REGISTRAMOS LOS SERVICIOS Y EJECUTAMOS LA APLICACION

        var serviceProvider = ConfigureServices();
        var cubeService = serviceProvider.GetRequiredService<ICubeService>();
        var cubeIntersectionApp = serviceProvider.GetRequiredService<CubeIntersection>();

        //EJECUTAMOS LA APP DESDE LA CLASE
        cubeIntersectionApp.Calculate();

    }

    public static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // REGISTRAMOS LOS SERVICIOS COMO SI FUESE EL STARTUP EN CASO DE APP WEB
        services.AddScoped<ICubeService, CubeService>();
        services.AddScoped<CubeIntersection>();

        return services.BuildServiceProvider();
    }


}