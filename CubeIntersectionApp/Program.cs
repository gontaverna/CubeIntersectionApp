using Application.Factories;
using Application.Services;
using CubeIntersectionApp.Presentation;
using Domain.Entities;
using Domain.Services;
using Helpers;
using Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

class Program
{
    static async Task Main()
    {
        // AQUI REGISTRAMOS LOS SERVICIOS Y EJECUTAMOS LA APLICACION

        var serviceProvider = ConfigureServices();
        //var cubeService = serviceProvider.GetRequiredService<ICubeService>();
        var cubeIntersectionApp = serviceProvider.GetRequiredService<CubeIntersection>();

        await cubeIntersectionApp.Calculate(); 

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();  

    }

    public static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // REGISTRAMOS LOS SERVICIOS COMO SI FUESE EL STARTUP EN CASO DE APP WEB
        services.AddScoped<ICubeService, CubeService>();
        services.AddScoped<ICubeAppService, CubeAppService>();
        services.AddScoped<ICubeFactory, CubeFactory>();
        services.AddScoped<ICubeRepository, CubeRepository>();
        services.AddScoped<CubeIntersection>();

        return services.BuildServiceProvider();
    }


}