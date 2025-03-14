USE [master]
GO
/****** Object:  Database [Libreria]    Script Date: 20/02/2025 04:11:04 p. m. ******/
CREATE DATABASE [Libreria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Libreria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER02\MSSQL\DATA\Libreria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Libreria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER02\MSSQL\DATA\Libreria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Libreria] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Libreria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Libreria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Libreria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Libreria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Libreria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Libreria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Libreria] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Libreria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Libreria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Libreria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Libreria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Libreria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Libreria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Libreria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Libreria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Libreria] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Libreria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Libreria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Libreria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Libreria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Libreria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Libreria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Libreria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Libreria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Libreria] SET  MULTI_USER 
GO
ALTER DATABASE [Libreria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Libreria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Libreria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Libreria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Libreria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Libreria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Libreria] SET QUERY_STORE = ON
GO
ALTER DATABASE [Libreria] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Libreria]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 20/02/2025 04:11:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[correo] [varchar](100) NULL,
	[telefono] [varchar](15) NULL,
	[direccion] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Ventas]    Script Date: 20/02/2025 04:11:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Ventas](
	[id_detalle_venta] [int] IDENTITY(1,1) NOT NULL,
	[id_venta] [int] NULL,
	[id_producto] [int] NULL,
	[cantidad] [int] NOT NULL,
	[precio_unitario] [decimal](10, 2) NOT NULL,
	[subtotal] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_detalle_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 20/02/2025 04:11:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[isbn] [varchar](20) NOT NULL,
	[titulo] [varchar](100) NOT NULL,
	[autor] [varchar](100) NULL,
	[editorial] [varchar](100) NULL,
	[precio_menudeo] [decimal](10, 2) NOT NULL,
	[precio_mayoreo] [decimal](10, 2) NULL,
	[cantidad_mayoreo] [int] NULL,
	[fecha_registro] [datetime] NULL,
	[id_ubicacion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[isbn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promociones]    Script Date: 20/02/2025 04:11:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promociones](
	[id_promocion] [int] IDENTITY(1,1) NOT NULL,
	[id_producto] [int] NULL,
	[fecha_inicio] [date] NOT NULL,
	[fecha_fin] [date] NULL,
	[descuento] [decimal](10, 2) NOT NULL,
	[indefinida] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_promocion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 20/02/2025 04:11:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[id_proveedor] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[correo] [varchar](100) NULL,
	[telefono] [varchar](15) NULL,
	[direccion] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reportes]    Script Date: 20/02/2025 04:11:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reportes](
	[id_reporte] [int] IDENTITY(1,1) NOT NULL,
	[tipo_reporte] [varchar](50) NOT NULL,
	[fecha_inicio] [date] NULL,
	[fecha_fin] [date] NULL,
	[detalles] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_reporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 20/02/2025 04:11:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[id_stock] [int] IDENTITY(1,1) NOT NULL,
	[id_producto] [int] NULL,
	[cantidad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_stock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ubicaciones]    Script Date: 20/02/2025 04:11:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ubicaciones](
	[id_ubicacion] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_ubicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 20/02/2025 04:11:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id_empleado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[correo] [varchar](100) NULL,
	[telefono] [varchar](15) NULL,
	[rol] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 20/02/2025 04:11:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[id_venta] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NULL,
	[id_empleado] [int] NULL,
	[fecha_venta] [datetime] NULL,
	[total] [decimal](10, 2) NOT NULL,
	[modo_pago] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Productos] ADD  DEFAULT (getdate()) FOR [fecha_registro]
GO
ALTER TABLE [dbo].[Promociones] ADD  DEFAULT ((0)) FOR [indefinida]
GO
ALTER TABLE [dbo].[Ventas] ADD  DEFAULT (getdate()) FOR [fecha_venta]
GO
ALTER TABLE [dbo].[Detalle_Ventas]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([id_producto])
GO
ALTER TABLE [dbo].[Detalle_Ventas]  WITH CHECK ADD FOREIGN KEY([id_venta])
REFERENCES [dbo].[Ventas] ([id_venta])
GO
ALTER TABLE [dbo].[Detalle_Ventas]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVentas_Productos] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([id_producto])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detalle_Ventas] CHECK CONSTRAINT [FK_DetalleVentas_Productos]
GO
ALTER TABLE [dbo].[Detalle_Ventas]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVentas_Ventas] FOREIGN KEY([id_venta])
REFERENCES [dbo].[Ventas] ([id_venta])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detalle_Ventas] CHECK CONSTRAINT [FK_DetalleVentas_Ventas]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([id_ubicacion])
REFERENCES [dbo].[Ubicaciones] ([id_ubicacion])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Ubicaciones] FOREIGN KEY([id_ubicacion])
REFERENCES [dbo].[Ubicaciones] ([id_ubicacion])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Ubicaciones]
GO
ALTER TABLE [dbo].[Promociones]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([id_producto])
GO
ALTER TABLE [dbo].[Promociones]  WITH CHECK ADD  CONSTRAINT [FK_Promociones_Productos] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([id_producto])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Promociones] CHECK CONSTRAINT [FK_Promociones_Productos]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([id_producto])
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Productos] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([id_producto])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Productos]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Clientes] ([id_cliente])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([id_empleado])
REFERENCES [dbo].[Usuarios] ([id_empleado])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Clientes] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Clientes] ([id_cliente])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Clientes]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Empleados] FOREIGN KEY([id_empleado])
REFERENCES [dbo].[Usuarios] ([id_empleado])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Empleados]
GO
USE [master]
GO
ALTER DATABASE [Libreria] SET  READ_WRITE 
GO
