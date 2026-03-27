# MiniCRM API

API REST desarrollada en C# con ASP.NET Core y SQLite como parte de mi proceso de aprendizaje backend.

## Funcionalidades actuales

- Obtener todos los clientes
- Obtener cliente por Id
- Crear cliente
- Actualizar cliente
- Persistencia con SQLite
- Pruebas con Swagger

## Tecnologías usadas

- C#
- ASP.NET Core Web API
- SQLite
- Microsoft.Data.Sqlite
- Swagger / OpenAPI

## Estructura del proyecto

- **Models**: representa las entidades del sistema
- **Data**: acceso a base de datos SQLite
- **Controllers**: endpoints de la API

## Estado actual

Actualmente el proyecto ya permite realizar operaciones básicas sobre clientes desde Swagger, conectando la API con una base SQLite local.

## Próximos pasos

- Eliminar clientes
- Mejorar validaciones
- Ordenar la arquitectura en capas más profesionales
- Seguir evolucionando el MiniCRM

## Cómo ejecutarlo

1. Clonar el repositorio
2. Abrir la solución en Visual Studio
3. Ejecutar el proyecto
4. Probar endpoints desde Swagger