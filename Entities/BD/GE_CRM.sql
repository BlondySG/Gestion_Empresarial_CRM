DROP DATABASE IF EXISTS GE_CRM;

CREATE DATABASE GE_CRM;
USE GE_CRM;

/**
*  Creacion de tablas
*/

CREATE TABLE tbRol(
	IdRol INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	NombreRol  VARCHAR(15) NOT NULL,
    Activo BIT NOT NULL,
    CONSTRAINT AK_NombreRol UNIQUE (NombreRol)
);

CREATE TABLE tbEmpleado (
    IdEmpleado INT NOT NULL IDENTITY(1,1),
    Cedula VARCHAR(15) NOT NULL,
    RutaFoto varchar(MAX) NULL,
    Nombre VARCHAR(60) NOT NULL,
    Apellido1 VARCHAR(60) NOT NULL,
    Apellido2 VARCHAR(60) NOT NULL,
    TelefonoEmpleado VARCHAR(11) NOT NULL,
    CorreoEmpleado VARCHAR(75) NOT NULL,
    Direccion VARCHAR(255) NOT NULL,
    NombreContacto VARCHAR(255) NOT NULL,
    TelefonoContacto VARCHAR(11) NOT NULL,
    Activo BIT NOT NULL,
    IdRol INT NOT NULL,
    CONSTRAINT PK_IdEmpleado PRIMARY KEY (IdEmpleado),
    CONSTRAINT AK_Cedula UNIQUE (Cedula),
    CONSTRAINT FK_Empleado_Rol FOREIGN KEY (IdRol) REFERENCES tbRol(IdRol)
 );

CREATE TABLE tbBitacora (
    IdBitacora INT NOT NULL IDENTITY(1,1),
    CodError INT NOT NULL,
    Descripcion VARCHAR(2500) NOT NULL,
    FechaHora DATETIME NOT NULL,
    Origen VARCHAR(500) NOT NULL,
    IdEmpleado INT NOT NULL,
    CONSTRAINT PK_IdBitacora PRIMARY KEY (IdBitacora),
    CONSTRAINT FK_Empleado FOREIGN KEY (IdEmpleado) REFERENCES tbEmpleado(IdEmpleado)
);

CREATE TABLE tbCliente (
    IdCliente INT NOT NULL IDENTITY(1,1),
    NombreCliente VARCHAR(70) NOT NULL,
    CorreoCliente VARCHAR(75) NOT NULL,
    PersonaContacto VARCHAR(100) NOT NULL,
    DireccionCliente VARCHAR(255) NOT NULL,
    TelefonoCliente VARCHAR(12) NOT NULL,
    Activo BIT NOT NULL,
    CONSTRAINT PK_IdCliente PRIMARY KEY (IdCliente)
);

CREATE TABLE tbProveedor(
    IdProveedor INT NOT NULL IDENTITY(1,1),
    NombreProveedor  VARCHAR(70) NOT NULL,
    CorreoProveedor VARCHAR(75) NOT NULL,
    NombreContacto VARCHAR(100) NOT NULL,
    DireccionProveedor VARCHAR(255) NOT NULL,
    TelefonoProveedor VARCHAR(14) NOT NULL,
    ProductoProveedor VARCHAR(300) NOT NULL,
    Activo BIT NOT NULL,
    CONSTRAINT PK_IdProveedor PRIMARY KEY (IdProveedor)
);

CREATE TABLE tbProducto (
    IdProducto INT NOT NULL IDENTITY(1,1),
    NombreProducto  VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(500) NOT NULL,
    Cantidad INT NOT NULL,
    CostoProducto DECIMAL(12,2) NOT NULL,
    PuntoReorden INT NOT NULL,
    NumParte VARCHAR(20) NOT NULL,
    NumSerie VARCHAR(20),
    FechaFinGarantia DATETIME NOT NULL,
	IdProveedor INT NOT NULL,
    Activo BIT NOT NULL,
    CONSTRAINT PK_IdProducto PRIMARY KEY (IdProducto),
    CONSTRAINT AK_NumSerie_NumParte UNIQUE (NumSerie,NumParte),
    CONSTRAINT FK_Proveedor FOREIGN KEY (IdProveedor) REFERENCES tbProveedor(IdProveedor)
);

CREATE TABLE tbVentas(
IdVenta INT NOT NULL IDENTITY(1,1),
FechaVenta DATETIME NOT NULL,
MontoTotal DECIMAL(12,2) NOT NULL,
Estado VARCHAR(50) NOT NULL,
IdCliente_v INT NOT NULL,
CONSTRAINT PK_tbVentas PRIMARY KEY (IdVenta),
CONSTRAINT FK_Venta_Cliente FOREIGN KEY (IdCliente_v) REFERENCES tbCliente(IdCliente),
);

CREATE TABLE tbDetalleVentas(
    IdDetalleVenta INT NOT NULL IDENTITY(1,1),
    NumFacturaVenta VARCHAR(50) NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario Decimal(10,2) NOT NULL,
    ImpuestoVenta Decimal(8,2) NOT NULL,
    SubTotalVenta Decimal(10,2) NOT NULL,
    TotalVenta Decimal(10,2) NOT NULL,
	IdVenta_c INT NOT NULL,
    IdProducto_c INT NOT NULL,
    CONSTRAINT PK_IdDetalleVenta PRIMARY KEY (IdDetalleVenta),
    CONSTRAINT FK_DetalleVentas_Ventas FOREIGN KEY (IdVenta_c) REFERENCES tbVentas(IdVenta),
    CONSTRAINT FK_DetalleVentas_Producto FOREIGN KEY (IdProducto_c) REFERENCES tbProducto(IdProducto)
);

CREATE TABLE tbCompras(
IdCompra INT NOT NULL IDENTITY(1,1),
FechaCompra DATETIME NOT NULL,
MontoTotal DECIMAL(12,2) NOT NULL,
Estado VARCHAR(50) NOT NULL,
IdProveedor_c INT NOT NULL,
CONSTRAINT PK_tbCompras PRIMARY KEY (IdCompra),
CONSTRAINT FK_Compra_Proveedor FOREIGN KEY (IdProveedor_c) REFERENCES tbProveedor(IdProveedor),
);

CREATE TABLE tbDetalleCompras(
    IdDetalleCompra INT NOT NULL IDENTITY(1,1),
    NumFacturaCompra VARCHAR(50) NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario Decimal(10,2) NOT NULL,
    ImpuestoCompra Decimal(8,2) NOT NULL,
    SubTotalCompra Decimal(10,2) NOT NULL,
    TotalCompra Decimal(10,2) NOT NULL,
    IdCompra_p INT NOT NULL,
    IdProducto_p INT NOT NULL,
    CONSTRAINT PK_IdDetalleCompra PRIMARY KEY (IdDetalleCompra),
    CONSTRAINT FK_DetalleCompras_Compras FOREIGN KEY (IdCompra_p) REFERENCES tbCompras(IdCompra),
    CONSTRAINT FK_DetalleCompras_Producto FOREIGN KEY (IdProducto_p) REFERENCES tbProducto(IdProducto)
);

CREATE TABLE tbTipoSoporte(
    IdTipo INT NOT NULL IDENTITY(1,1),
    NombreSoporte  VARCHAR(50) NOT NULL,
    CONSTRAINT PK_IdTipo PRIMARY KEY (IdTipo),
    CONSTRAINT AK_IdNombreSoporte UNIQUE (NombreSoporte),
);

CREATE TABLE tbSoporte(
    IdSoporte INT NOT NULL IDENTITY(1,1),
    DescripcionSoporte VARCHAR(5000) NOT NULL,
    FechaAgendada DATETIME NOT NULL,
    FechaCierreSoporte DATETIME NULL,
    Estatus VARCHAR(30) NOT NULL,
    IdTipo_s INT NOT NULL,
    CONSTRAINT PK_IdSoporte PRIMARY KEY (IdSoporte),
    CONSTRAINT PK_Soporte_Tipo FOREIGN KEY (IdTipo_s) REFERENCES tbTipoSoporte(IdTipo)
);

CREATE TABLE tbEmpleadoSoporte(
    IdEmpleadoSoporte INT NOT NULL IDENTITY(1,1),
    IdEmpleado_es INT NOT NULL,
    IdSoporte_es INT NOT NULL,
    CONSTRAINT PK_IdEmpleadoSoporte PRIMARY KEY (IdEmpleadoSoporte),
    CONSTRAINT PK_EmpleadoSoporte_Empleado FOREIGN KEY (IdEmpleado_es) REFERENCES tbEmpleado(IdEmpleado),
    CONSTRAINT PK_EmpleadoSoporte_Soporte FOREIGN KEY (IdSoporte_es) REFERENCES tbSoporte(IdSoporte)
);

CREATE TABLE tbSoporteCliente(
    IdSoporteCliente INT NOT NULL IDENTITY(1,1),
    IdSoporte_sc INT NOT NULL,
    IdCliente_sc INT NOT NULL,
    CONSTRAINT PK_IdSoporteCliente PRIMARY KEY (IdSoporteCliente),
    CONSTRAINT FK_SoporteCliente_Soporte FOREIGN KEY (IdSoporte_sc) REFERENCES tbSoporte(IdSoporte),
    CONSTRAINT FK_SoporteCliente_Cliente FOREIGN KEY (IdCliente_sc) REFERENCES tbCliente(IdCliente)
);

--insert into tbRol(NombreRol,Activo)
--values ('Administrador',1);

--insert into tbEmpleado(Cedula,Foto,Nombre,Apellido1,Apellido2,TelefonoEmpleado,CorreoEmpleado,Direccion,NombreContacto,TelefonoContacto,Activo,IdRol)
--values ('109050203',NULL,'Blondy','Soto','Garita','83160767','blondysg@gmail.com','Cartago','Mari','88888888',1,1);

--insert into tbProveedor(NombreProveedor,CorreoProveedor,NombreContacto,DireccionProveedor,TelefonoProveedor,ProductoProveedor,Activo)
--values ('Intel','info@intel.com','Efrain Suarez','Singapore','83160767','Procesadores',1);

--insert into tbProducto(NombreProducto,Descripcion,Cantidad,CostoProducto,PuntoReorden,NumParte,NumSerie,FechaFinGarantia,IdProveedor,Activo)
--values ('Core I7','Procesador 11Gen 4200MHz',5,350000,3,'PRO0052','ijwso1574',18/07/2023,1,1);

----insert into tbDatosCompra(NumFacturaCompra,Cantidad,PrecioUnitario,ImpuestoCompra,SubTotalCompra,TotalCompra,FechaCompra,IdProveedor,IdArticulo)
----values ('50000',10,10000,13,13000,1300000,13/05/2021,1,1);

----insert into tbEmpleado(Cedula,Foto,Nombre,Apellido1,Apellido2,TelefonoEmpleado,CorreoEmpleado,Direccion,Contrasena,NombreContacto,TelefonoContacto,NombreRol,Activo,IdRol)
----values ('109050208',NULL,'Blondy','Soto','Garita','83160767','blondysg@gmail.com','Cartago','123','Mari','88888888',NULL,1,1);

----insert into AspNetRoles(Id,Name,NormalizedName,ConcurrencyStamp)
----values('1','Administrador',null,null);

----insert into AspNetRoles(Id,Name,NormalizedName,ConcurrencyStamp)
----values('2','Tecnico',null,null);

select * from tbRol;
select * from tbEmpleado;
--select * from tbBitacora;
--select * from tbCliente;
--select * from tbProveedor;
--select * from tbProducto;
--select * from tbDatosVenta;
--select * from tbDatosCompra;
--select * from tbTipoSoporte;
--select * from tbSoporte;
--select * from tbEmpleadoSoporte;
--select * from tbSoporteCliente;
