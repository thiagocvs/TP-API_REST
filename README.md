# TP API REST - Mascotas

Trabajo practico de API REST hecho con ASP.NET Core (.NET 10).
La API permite administrar una lista de mascotas en memoria, usando herencia y encapsulamiento.

## Requisitos

- .NET SDK 10.0 o superior

## Swagger

Una vez levantada la aplicacion, se abre el navegador en:

```
http://localhost:5257/swagger
```

Desde ahi se pueden probar todos los endpoints sin necesidad de otra herramienta.

## Estructura del proyecto

```
TP API-REST/
├── Controllers/
│   ├── MascotaController.cs        <- endpoints de la API
│   └── WeatherForecastController.cs
├── entities/
│   ├── Mascota.cs                  <- clase abstracta (clase padre)
│   ├── Perro.cs                    <- hereda de Mascota
│   └── Gato.cs                     <- hereda de Mascota
├── Properties/
│   ├── launchSettings.json
│   └── WeatherForecast.cs
├── Program.cs                      <- configuracion de la aplicacion
└── TP-API_REST.http                
```
