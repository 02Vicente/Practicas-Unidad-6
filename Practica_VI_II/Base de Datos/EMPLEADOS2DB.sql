USE [Empleados2DB]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 04/12/2019 9:06:48 ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteEmpleado]    Script Date: 04/12/2019 9:06:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteEmpleado] (@Id Integer)
as 
	begin
	Delete Empleado
	where EmpleadoID = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[InsertupdateEmpleado]    Script Date: 04/12/2019 9:06:49 ******/
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
end
GO
/****** Object:  StoredProcedure [dbo].[SelectEmpleado]    Script Date: 04/12/2019 9:06:49 ******/
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
