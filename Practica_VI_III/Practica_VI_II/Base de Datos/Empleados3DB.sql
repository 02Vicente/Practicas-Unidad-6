USE [master]
GO
/****** Object:  Database [Empleados3DB]    Script Date: 09/12/2019 11:41:03 ******/
CREATE DATABASE [Empleados3DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Empleados3DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Empleados3DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Empleados3DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Empleados3DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Empleados3DB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Empleados3DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Empleados3DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Empleados3DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Empleados3DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Empleados3DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Empleados3DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Empleados3DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Empleados3DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Empleados3DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Empleados3DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Empleados3DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Empleados3DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Empleados3DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Empleados3DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Empleados3DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Empleados3DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Empleados3DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Empleados3DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Empleados3DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Empleados3DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Empleados3DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Empleados3DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Empleados3DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Empleados3DB] SET RECOVERY FULL 
GO
ALTER DATABASE [Empleados3DB] SET  MULTI_USER 
GO
ALTER DATABASE [Empleados3DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Empleados3DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Empleados3DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Empleados3DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Empleados3DB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Empleados3DB', N'ON'
GO
ALTER DATABASE [Empleados3DB] SET QUERY_STORE = OFF
GO
USE [Empleados3DB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Empleados3DB]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 09/12/2019 11:41:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[EmpleadoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[Estado_Civil] [varchar](50) NULL,
	[Pais] [varchar](50) NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[EmpleadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 09/12/2019 11:41:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Usuario]    Script Date: 09/12/2019 11:41:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Buscar_Usuario]
@Id int
AS
BEGIN
	SELECT * FROM Usuario WHERE UsuarioId = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmpleado]    Script Date: 09/12/2019 11:41:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteEmpleado] (@Id Integer)
as 
	begin
	Delete Empleado
	where EmpleadoID = @Id;
end;
GO
/****** Object:  StoredProcedure [dbo].[DeleteUsuario]    Script Date: 09/12/2019 11:41:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUsuario]
@UsuarioId int
AS

BEGIN
	DELETE FROM Usuario WHERE UsuarioId = @UsuarioId;
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertupdateEmpleado]    Script Date: 09/12/2019 11:41:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertupdateEmpleado]
(
@Id				int,
@Nombres		varchar(50),
@Apellidos		varchar(50),
@Edad			int,
@Estado_Civil	varchar(15),
@Pais			varchar(50),
@Action			varchar(10)
)
as
begin
if @Action = '1'
begin
insert into Empleado
				(
				Nombres,
				Apellidos,
				Edad,
				Estado_Civil,
				Pais
				)
		values	(
				@Nombres,
				@Apellidos,
				@Edad,
				@Estado_Civil,
				@Pais
				);
		end
	if @Action = '2'
		begin
			update	Empleado
			set		Nombres = @Nombres,
					Apellidos = @Apellidos,
					Edad = @Edad,
					Estado_Civil = @Estado_Civil,
					Pais = @Pais
			where	EmpleadoID = @Id;
		end
end;
GO
/****** Object:  StoredProcedure [dbo].[InsertupdateUsuario]    Script Date: 09/12/2019 11:41:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertupdateUsuario]
@UsuarioId int,
@Nombre varchar(50),
@Apellido varchar(50),
@Username varchar(50),
@Password varchar(50),
@Correo varchar(50),  
@Action int
AS

BEGIN
	IF @Action = 0	
		BEGIN
			INSERT INTO Usuario(Nombre,Apellido,Username,Password,Correo)
			VALUES(@Nombre,@Apellido,@Username,@Password,@Correo);
		END

	IF @Action = 1
		BEGIN
			UPDATE Usuario 
			SET Nombre = @Nombre, Apellido = @Apellido, Username = @Username, Password = @Password, Correo = @Correo WHERE UsuarioId = @UsuarioId;
		END
END;
GO
/****** Object:  StoredProcedure [dbo].[Login_Usuario]    Script Date: 09/12/2019 11:41:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Login_Usuario]
@Username varchar(50),
@Password varchar(50)
AS

BEGIN
	SELECT * FROM Usuario WHERE Username = @Username AND Password = @Password;
END;
GO
/****** Object:  StoredProcedure [dbo].[SelectEmpleado]    Script Date: 09/12/2019 11:41:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SelectEmpleado]
as 
begin
select * from Empleado;
end
GO
/****** Object:  StoredProcedure [dbo].[SelectUsuarios]    Script Date: 09/12/2019 11:41:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectUsuarios]
AS
SELECT * FROM Usuario
GO
USE [master]
GO
ALTER DATABASE [Empleados3DB] SET  READ_WRITE 
GO
