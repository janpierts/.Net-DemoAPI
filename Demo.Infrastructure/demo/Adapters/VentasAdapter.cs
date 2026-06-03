using Demo.Application.Common;
using Demo.Domain.Demo.model;
using System.Data;
using System.Collections.Generic;

namespace Demo.Infrastructure.demo.Adapters;

public interface IVentasAdapter
{
    IEnumerable<ReadVentasModel> Map(IDataReader reader);
}

public class VentasAdapter : IVentasAdapter, IScopedDependency
{
    public IEnumerable<ReadVentasModel> Map(IDataReader reader)
    {
        var ventas = new List<ReadVentasModel>();

        while (reader.Read())
        {
            var ventaId = reader["VentaId"] != DBNull.Value ? Convert.ToInt32(reader["VentaId"]) : 0;
            var cliente = reader["Cliente"]?.ToString() ?? string.Empty;
            var producto = reader["Producto"]?.ToString() ?? string.Empty;
            var fecha = reader["Fecha"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha"]) : DateTime.UtcNow;
            var cantidad = reader["Cantidad"] != DBNull.Value ? Convert.ToInt32(reader["Cantidad"]) : 0;

            ventas.Add(new ReadVentasModel(
                ventaId,
                cliente,
                producto,
                fecha,
                cantidad
            ));
        }

        return ventas;
    }
}

/*
 ---Parte 1

Prueba de Consulta de SQL Server
https://docs.google.com/forms/d/e/1FAIpQLSeuzS8rfe46ISG_k7rPRGgWVET1A3517HTA1O63556jo0gONQ/viewform?usp=dialog

Script de Estructura de base de datos:
CREATE TABLE Clientes (
    ClienteId INT PRIMARY KEY,
    Nombre VARCHAR(100),
    FechaRegistro DATE
);

CREATE TABLE Categorias (
    CategoriaId INT PRIMARY KEY,
    Nombre VARCHAR(100)
);

CREATE TABLE Productos (
    ProductoId INT PRIMARY KEY,
    Nombre VARCHAR(100),
    CategoriaId INT,
    Precio DECIMAL(10,2),
    FOREIGN KEY (CategoriaId) REFERENCES Categorias(CategoriaId)
);

CREATE TABLE Ventas (
    VentaId INT PRIMARY KEY,
    ClienteId INT,
    ProductoId INT,
    Fecha DATE,
    Cantidad INT,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId),
    FOREIGN KEY (ProductoId) REFERENCES Productos(ProductoId)
);

-- Insertar datos
INSERT INTO Clientes VALUES
(1,'Ana','2024-01-10'),
(2,'Luis','2024-02-15'),
(3,'Carla','2024-03-01');

INSERT INTO Categorias VALUES
(1,'Electrónica'),
(2,'Ropa'),
(3,'Hogar');

INSERT INTO Productos VALUES
(1,'Laptop',1,3500),
(2,'Mouse',1,50),
(3,'Camisa',2,80),
(4,'Silla',3,300),
(5,'Teclado',1,120);

INSERT INTO Ventas VALUES
(1,1,1,'2025-01-01',1),
(2,1,2,'2025-01-02',2),
(3,1,5,'2025-01-05',1),
(4,2,3,'2025-01-03',3),
(5,2,1,'2025-01-10',1),
(6,3,4,'2025-01-02',2),
(7,3,2,'2025-01-04',5),
(8,1,3,'2025-01-15',4),
(9,2,2,'2025-01-20',10),
(10,3,1,'2025-01-25',1);


---Parte 2

Formulario con estos campos que permita agregar:
Cliente (Solicitar)
Producto (Solicitar)
Categoria (Autollenado)
Precio (Autollenado)
Cantidad (Solicitar)
Boton de Agregar

Y una tabla sencilla que contenga esta columnas
Fecha Cliente Producto Categoria Cantidad Precio Total

Debe ser en 2 proyectos:
1.- Backend: Generar un api con dos metodos para agregar y listar las ventas
2.- Forntend: Solo html y js genera el formulario y tabla y consumir los servicios utlizando fetch de javascript.

 */