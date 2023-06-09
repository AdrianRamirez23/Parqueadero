USE [Parqueadero]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 5/7/2023 8:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[Id] [varchar](13) NOT NULL,
	[Nombres] [varchar](150) NOT NULL,
	[Correo] [varchar](150) NOT NULL,
	[Celular] [varchar](13) NOT NULL,
	[Contrasena] [varchar](20) NOT NULL,
	[TipoUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 5/7/2023 8:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[Id_Estado] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[Id_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Importes]    Script Date: 5/7/2023 8:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Importes](
	[Id_Registro] [int] IDENTITY(1,1) NOT NULL,
	[FechaEntrada] [datetime] NOT NULL,
	[FechaSalida] [datetime] NULL,
	[Placa] [varchar](9) NOT NULL,
	[TiempoTotal] [float] NULL,
	[TiempoAcumulado] [float] NULL,
	[Importe] [float] NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Importes] PRIMARY KEY CLUSTERED 
(
	[Id_Registro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposUsuarios]    Script Date: 5/7/2023 8:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposUsuarios](
	[Id_TipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[TipoUsuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TiposUsuarios] PRIMARY KEY CLUSTERED 
(
	[Id_TipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposVehiculos]    Script Date: 5/7/2023 8:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposVehiculos](
	[Id_TipoVehiculo] [int] IDENTITY(1,1) NOT NULL,
	[TipoVehiculo] [varchar](50) NOT NULL,
	[ImportePorMinuto] [float] NOT NULL,
 CONSTRAINT [PK_TiposVehiculos] PRIMARY KEY CLUSTERED 
(
	[Id_TipoVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculos]    Script Date: 5/7/2023 8:17:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculos](
	[Placa] [varchar](9) NOT NULL,
	[Id_TipoVehiculo] [int] NOT NULL,
 CONSTRAINT [PK_Vehiculos] PRIMARY KEY CLUSTERED 
(
	[Placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Empleados] ([Id], [Nombres], [Correo], [Celular], [Contrasena], [TipoUsuario]) VALUES (N'1036598444', N'Adrian Ramirez', N'adrianr@correo.com', N'3014881243', N'Tmljb2xhczEq', 1)
GO
SET IDENTITY_INSERT [dbo].[Estados] ON 

INSERT [dbo].[Estados] ([Id_Estado], [Estado]) VALUES (1, N'Entrada')
INSERT [dbo].[Estados] ([Id_Estado], [Estado]) VALUES (2, N'Salida')
INSERT [dbo].[Estados] ([Id_Estado], [Estado]) VALUES (3, N'Cerrado')
SET IDENTITY_INSERT [dbo].[Estados] OFF
GO
SET IDENTITY_INSERT [dbo].[Importes] ON 

INSERT [dbo].[Importes] ([Id_Registro], [FechaEntrada], [FechaSalida], [Placa], [TiempoTotal], [TiempoAcumulado], [Importe], [Estado]) VALUES (1, CAST(N'2023-05-07T22:56:16.080' AS DateTime), CAST(N'2023-05-07T23:38:33.280' AS DateTime), N'LSN-00609', 42, 42, 2.1, 3)
INSERT [dbo].[Importes] ([Id_Registro], [FechaEntrada], [FechaSalida], [Placa], [TiempoTotal], [TiempoAcumulado], [Importe], [Estado]) VALUES (2, CAST(N'2023-05-08T00:42:41.127' AS DateTime), CAST(N'2023-05-08T01:23:59.370' AS DateTime), N'EIO-00542', 41, 0, 0, 3)
INSERT [dbo].[Importes] ([Id_Registro], [FechaEntrada], [FechaSalida], [Placa], [TiempoTotal], [TiempoAcumulado], [Importe], [Estado]) VALUES (4, CAST(N'2023-05-08T01:05:58.490' AS DateTime), CAST(N'2023-05-08T01:42:10.703' AS DateTime), N'HIQ-00511', 36, 0, 18, 3)
SET IDENTITY_INSERT [dbo].[Importes] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposUsuarios] ON 

INSERT [dbo].[TiposUsuarios] ([Id_TipoUsuario], [TipoUsuario]) VALUES (1, N'Super Admin')
INSERT [dbo].[TiposUsuarios] ([Id_TipoUsuario], [TipoUsuario]) VALUES (2, N'Usuario')
INSERT [dbo].[TiposUsuarios] ([Id_TipoUsuario], [TipoUsuario]) VALUES (3, N'Sencillo')
INSERT [dbo].[TiposUsuarios] ([Id_TipoUsuario], [TipoUsuario]) VALUES (4, N'Invitado')
SET IDENTITY_INSERT [dbo].[TiposUsuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposVehiculos] ON 

INSERT [dbo].[TiposVehiculos] ([Id_TipoVehiculo], [TipoVehiculo], [ImportePorMinuto]) VALUES (1, N'Residente', 0.05)
INSERT [dbo].[TiposVehiculos] ([Id_TipoVehiculo], [TipoVehiculo], [ImportePorMinuto]) VALUES (2, N'Oficial', 0)
SET IDENTITY_INSERT [dbo].[TiposVehiculos] OFF
GO
INSERT [dbo].[Vehiculos] ([Placa], [Id_TipoVehiculo]) VALUES (N'EIO-00542', 2)
INSERT [dbo].[Vehiculos] ([Placa], [Id_TipoVehiculo]) VALUES (N'LSN-00609', 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Empleados]    Script Date: 5/7/2023 8:17:45 PM ******/
ALTER TABLE [dbo].[Empleados] ADD  CONSTRAINT [IX_Empleados] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Estados]    Script Date: 5/7/2023 8:17:45 PM ******/
ALTER TABLE [dbo].[Estados] ADD  CONSTRAINT [IX_Estados] UNIQUE NONCLUSTERED 
(
	[Id_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Importes]    Script Date: 5/7/2023 8:17:45 PM ******/
ALTER TABLE [dbo].[Importes] ADD  CONSTRAINT [IX_Importes] UNIQUE NONCLUSTERED 
(
	[Id_Registro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TiposUsuarios]    Script Date: 5/7/2023 8:17:45 PM ******/
ALTER TABLE [dbo].[TiposUsuarios] ADD  CONSTRAINT [IX_TiposUsuarios] UNIQUE NONCLUSTERED 
(
	[Id_TipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TiposVehiculos]    Script Date: 5/7/2023 8:17:45 PM ******/
ALTER TABLE [dbo].[TiposVehiculos] ADD  CONSTRAINT [IX_TiposVehiculos] UNIQUE NONCLUSTERED 
(
	[Id_TipoVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Vehiculos]    Script Date: 5/7/2023 8:17:45 PM ******/
ALTER TABLE [dbo].[Vehiculos] ADD  CONSTRAINT [IX_Vehiculos] UNIQUE NONCLUSTERED 
(
	[Placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_TiposUsuarios] FOREIGN KEY([TipoUsuario])
REFERENCES [dbo].[TiposUsuarios] ([Id_TipoUsuario])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_TiposUsuarios]
GO
ALTER TABLE [dbo].[Importes]  WITH CHECK ADD  CONSTRAINT [FK_Importes_Estados] FOREIGN KEY([Estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[Importes] CHECK CONSTRAINT [FK_Importes_Estados]
GO
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_TiposVehiculos] FOREIGN KEY([Id_TipoVehiculo])
REFERENCES [dbo].[TiposVehiculos] ([Id_TipoVehiculo])
GO
ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_TiposVehiculos]
GO
