# Demo API - Arquitectura Hexagonal & DDD

## 🏗️ Descripción
Este proyecto implementa una arquitectura Hexagonal (Puertos y Adaptadores) combinada con principios de Domain-Driven Design (DDD) y Clean Architecture. El objetivo es maximizar la mantenibilidad, escalabilidad y testabilidad, separando la lógica de negocio de las preocupaciones de infraestructura.



## 🛠️ Stack Tecnológico
- **Framework:** .NET 10.0
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

-> restauramos y construimos ::::

<img width="969" height="535" alt="image" src="https://github.com/user-attachments/assets/e2c1a194-0137-46cc-bead-d56ca6f00c61" />

-> por ultimo corremos el proyecto Demo.API
<img width="949" height="529" alt="image" src="https://github.com/user-attachments/assets/71cbbf0b-059e-4ae6-8e72-f0e1a4aafc81" />

-> Ingresamos al documentador ::::

<img width="1752" height="1028" alt="image" src="https://github.com/user-attachments/assets/1bd9af86-e9bd-4e05-b45a-e1c6dd50824b" />

-> Realizamos las operaciones correspondientes::::

<img width="1551" height="816" alt="image" src="https://github.com/user-attachments/assets/cf6675f3-8094-456c-88cc-2c8d75cdc117" />

<img width="1456" height="1013" alt="image" src="https://github.com/user-attachments/assets/6b0f4fdc-dfbc-4a02-bdb6-610bac39088a" />

<img width="1453" height="771" alt="image" src="https://github.com/user-attachments/assets/84caba70-64e0-4bd9-81c0-0f785e75b464" />

<img width="1449" height="1000" alt="image" src="https://github.com/user-attachments/assets/b55b7034-da9d-4450-ae6f-54dac1f1a1f1" />

<img width="1466" height="1001" alt="image" src="https://github.com/user-attachments/assets/c80b6d3c-13c7-4f3c-b48f-284c2f5f6291" />


## 📈 Características Implementadas
- **Desacoplamiento total:** La capa de `Application` ignora cómo se obtienen los datos.
- **Middleware de Monitoreo:** Registro automático de latencia de peticiones en `Demo.API/logs/request-times.txt`.
- **Servicios Externos:** Inyección de `HttpClient` con configuración centralizada.

## 🤝 Autor
Ruddy Janpierts Correa Grillo
