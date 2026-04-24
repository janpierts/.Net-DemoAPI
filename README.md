# Demo API - Arquitectura Hexagonal & DDD

## 🏗️ Descripción
Este proyecto implementa una arquitectura Hexagonal (Puertos y Adaptadores) combinada con principios de Domain-Driven Design (DDD) y Clean Architecture. El objetivo es maximizar la mantenibilidad, escalabilidad y testabilidad, separando la lógica de negocio de las preocupaciones de infraestructura.



## 🛠️ Stack Tecnológico
- **Framework:** .NET 10.1
- **Arquitectura:** Hexagonal / Clean Architecture
- **Patrones:** DDD (Domain-Driven Design), Repository Pattern, Inyección de Dependencias y cqrs conceptual
- **Documentación:** Swagger (OpenAPI)
- **Logging:** Serilog (Log rotativo a archivos planos)
- **Middleware:** Monitoreo de tiempos de respuesta personalizado

## 📂 Estructura del Proyecto
- `Demo.Domain`: Entidades de negocio, Value Objects, interfaces de repositorio.
- `Demo.Application`: Casos de uso, interfaces de puertos (Outbound), lógica de aplicación.
- `Demo.Infrastructure`: Implementación de repositorios, clientes HTTP, persistencia en memoria, logging.
- `Demo.API`: Controladores, configuración de Inyección de Dependencias, Middleware.

## 🚀 Cómo Empezar
1. Clona el repositorio.
2. Configura el archivo `appsettings.json` con la URL de la API de descuentos.
3. Ejecuta la solución mediante `dotnet run` en el directorio de `Demo.API`.
4. Accede a la documentación en `/swagger/index.html`.

  <img width="960" height="552" alt="image" src="https://github.com/user-attachments/assets/ee142641-d0a1-49ee-a896-224b70b848db" />


## 📈 Características Implementadas
- **Desacoplamiento total:** La capa de `Application` ignora cómo se obtienen los datos.
- **Middleware de Monitoreo:** Registro automático de latencia de peticiones en `Demo.API/logs/request-times.txt`.
- **Servicios Externos:** Inyección de `HttpClient` con configuración centralizada.

## 🤝 Autor
Ruddy Janpierts Correa Grillo
