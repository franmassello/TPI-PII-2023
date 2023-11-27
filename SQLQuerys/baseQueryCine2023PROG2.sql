CREATE DATABASE CINEART5
GO
USE CINEART5
GO

-- ////////////////////////////////////////////////////TABLAS AUXILIARES///////////////////////////////////////////////////////////////////


CREATE TABLE usuarios (
id_usuario int identity(1,1),
nombre varchar(50),
usuario varchar(50),
contraseña varchar(50),
tipo_usuario varchar(50)

CONSTRAINT pk_usuarios PRIMARY KEY (id_usuario)
)

-- Table: Clientes
CREATE TABLE Clientes (
    id_cliente int  identity(1,1),
    nombre varchar(60)  NOT NULL,
    apellido varchar(50)  NOT NULL,
    dni int  NOT NULL,
    e_mail varchar(50)  NOT NULL,
	CONSTRAINT Clientes_pk PRIMARY KEY (id_cliente)
);


-- Table: Cines
CREATE TABLE Cines (
    id_cine int identity(1,1),
    nombre varchar(80)  NOT NULL,
    direccion varchar(120)  NOT NULL,
    telefono int  NOT NULL,
    cuit varchar(40)  NOT NULL,
    CONSTRAINT Cines_pk PRIMARY KEY  (id_cine)
);



-- Table: Idiomas
CREATE TABLE Idiomas (
    id_idioma int  identity(1,1),
    idioma varchar(80)  NOT NULL,
    CONSTRAINT Idiomas_pk PRIMARY KEY  (id_idioma)
);

-- Table: Generos
CREATE TABLE Generos (
    id_genero int  identity(1,1),
    genero varchar(50)  NOT NULL,
    CONSTRAINT Generos_pk PRIMARY KEY  (id_genero)
);


-- Table: Formatos_peliculas
CREATE TABLE Formatos_peliculas (
    id_formato int  identity(1,1),
    formato varchar(60)  NOT NULL,
    CONSTRAINT Formatos_peliculas_pk PRIMARY KEY  (id_formato)
);


-- Table: Formas_ventas
CREATE TABLE Formas_ventas (
    id_forma_venta int  identity(1,1),
    forma_venta varchar(50)  NOT NULL,
    CONSTRAINT Formas_ventas_pk PRIMARY KEY  (id_forma_venta)
);



-- Table: Tipos_salas
CREATE TABLE Tipos_salas (
    id_tipo_sala int  identity(1,1),
    tipo_sala varchar(50)  NOT NULL,
    CONSTRAINT Tipos_salas_pk PRIMARY KEY  (id_tipo_sala)
);

-- Table: Tipos_pagos
CREATE TABLE Tipos_pagos (
    id_tipo_pago int  identity(1,1),
    tipo varchar(60)  NOT NULL,
    CONSTRAINT Tipos_pagos_pk PRIMARY KEY  (id_tipo_pago)
);


--- /////////////////////////////////////////////TABLAS NO AUXILARES/////////////////////////////////////////////////////////////////




--select * from Reservas

-- Table: Salas
CREATE TABLE Salas (
    id_sala int  identity(1,1),
    id_tipo_sala int  NOT NULL,
    cant_butacas int  NOT NULL,
    id_cine int  NOT NULL,
    CONSTRAINT Salas_pk PRIMARY KEY  (id_sala),
    CONSTRAINT tipoSalaD_fk FOREIGN KEY (id_tipo_sala) REFERENCES Tipos_salas (id_tipo_sala),
    CONSTRAINT CineD_fk FOREIGN KEY (id_cine) REFERENCES Cines(id_cine)

);


-- Table: Butacas

CREATE TABLE Butacas (
    id_butaca int  identity(1,1),
    fila varchar(50)  NOT NULL,
    id_sala int  NOT NULL,
    nro_butaca int  NOT NULL,
    CONSTRAINT Butacas_pk PRIMARY KEY  (id_butaca),
	CONSTRAINT SalasA_fk FOREIGN KEY (id_sala) REFERENCES Salas (id_sala)
);
--SELECT * FROM BUTACAS



-- Table: Forma_pagos
CREATE TABLE Forma_pagos (
    id_forma_pago int  identity(1,1),
    forma_pago varchar(80)  NOT NULL,
    id_tipo_pago int  NOT NULL,
    CONSTRAINT Forma_pagos_pk PRIMARY KEY  (id_forma_pago),
	CONSTRAINT tipo_pagosA_fk FOREIGN KEY (id_tipo_pago) REFERENCES tipos_pagos (id_tipo_pago)

);


-- Table: Peliculas
CREATE TABLE Peliculas (
    id_pelicula int  identity(1,1),
    titulo varchar(70)  NOT NULL,
    descripcion varchar(500)  NOT NULL,
    id_genero int  NOT NULL,
    fecha_estreno date  NOT NULL,
    id_idioma int  NOT NULL,
    id_formato int  NOT NULL,
    CONSTRAINT Peliculas_pk PRIMARY KEY  (id_pelicula),
	CONSTRAINT GeneroB_FK FOREIGN KEY (id_genero) REFERENCES generos(id_genero),
	CONSTRAINT IdiomaB_FK FOREIGN KEY (id_idioma) REFERENCES idiomas(id_idioma),
	CONSTRAINT formatoB_FK FOREIGN KEY(id_formato) REFERENCES formatos_peliculas(id_formato)

);

-- Table: Funciones
CREATE TABLE Funciones (
    id_funcion int  identity(1,1),
    id_sala int  NOT NULL,
    id_pelicula int  NOT NULL,
    horario time  NOT NULL,
    dia date  NOT NULL,
    CONSTRAINT Funciones_pk PRIMARY KEY  (id_funcion),
	CONSTRAINT SalasB_fk FOREIGN KEY (id_sala) REFERENCES Salas(id_sala),
);
-- Table: Reservas
CREATE TABLE Reservas (
    id_reserva int  identity(1,1),
    id_cliente int  NOT NULL,
    id_forma_venta int  NOT NULL,
	id_funcion int NOT NULL,
    CONSTRAINT Reservas_pk PRIMARY KEY  (id_reserva),
    CONSTRAINT ClientesD_fk FOREIGN KEY (id_cliente) REFERENCES Clientes (id_cliente),
    CONSTRAINT FormaVentaD_fk FOREIGN KEY (id_forma_venta) REFERENCES Formas_ventas (id_forma_venta),
);

--select * from Funciones

-- Table: Facturas
CREATE TABLE Facturas (
    id_factura int  identity(1,1),
    fecha date  NOT NULL,
    hora time  NOT NULL,
    id_cliente int  NOT NULL,
    id_forma_pago int  NOT NULL,
    CONSTRAINT Facturas_pk PRIMARY KEY  (id_factura),
	CONSTRAINT clienteR_fk FOREIGN KEY (id_cliente) REFERENCES clientes (id_cliente),
	CONSTRAINT formarPagoR_fk FOREIGN KEY (id_forma_pago) REFERENCES Forma_pagos (id_forma_pago)
);

--SELECT * FROM Facturas


-- Table: Detalles
CREATE TABLE Detalles (
    id_detalle int  identity(1,1),
    id_factura int  NOT NULL,
    precio money  NOT NULL,
    id_funcion int  NOT NULL,
    descuento decimal(10,2)  NOT NULL,
    id_butaca int  NOT NULL,
    cantidad int  NOT NULL,
    CONSTRAINT Detalles_pk PRIMARY KEY  (id_detalle),
    CONSTRAINT facturaB_fk FOREIGN KEY (id_factura) REFERENCES Facturas (id_factura),
    CONSTRAINT butacaB_fk FOREIGN KEY (id_butaca) REFERENCES Butacas (id_butaca)
);













--///////////////////////////////////////////////INSERTS////////////////////////////////////////////////////////////////////////////////
-------------------------------------------------CLIENTES-------------------------------------------------------------------------------
INSERT [dbo].[Clientes] ( [nombre], [apellido], [dni], [e_mail]) VALUES ( N'Juan Roman', N'Riquelme', 10101010, N'elultimo10@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Pablo Horacio', N'Guinazu', 42568941, N'cholo5@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Roberto', N'Lopez', 21457689, N'lopez12roberto@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Diego', N'Maradona', 12154647, N'diegoarmando@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Maximiliano', N'Rodriguez', 35658954, N'maxrodriguez@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Mirtha', N'Rugeri', 12356932, N'mirtha555@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Lionel', N'Messi', 32365741, N'lio@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Luciana', N'Paz', 42365425, N'luchipaz@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Alex', N'Morgan', 35658412, N'morgan@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Horacio', N'Martinez', 35668941, N'horacio456@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Jordi', N'Elnino', 22859635, N'jordipo@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Mia', N'Khalifa', 33154569, N'mia69@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Sonia', N'Rodriguez', 32858414, N'soniaro@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Romina', N'Caniggia', 38256357, N'romi22@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Carolina', N'Arruabarrena', 22789654, N'arruromina@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Carlos', N'Tren', 4568123, N'carlostren@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Kevin', N'Morgan', 41658357, N'kmorgan@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Carlos', N'Astudillo', 34562315, N'astudillocarlos@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Luciana', N'Bobadilla', 36968852, N'lubobadilla98@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Estefania', N'Perez', 43569852, N'estefi2005@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Franco', N'Racca', 34624098, N'f.racca@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Camila', N'Carabello', 23438568, N'c.carabello@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Emanuel', N'Brizuela', 38742429, N'e.brizuela@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Facundo', N'Lujan', 17231850, N'f.lujan@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Romina', N'Gomez', 46092742, N'r.gomez@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Cristian', N'Arroyo', 32434999, N'c.arroyo@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Flavio', N'Piazzi', 24564877, N'f.piazzi@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Dalma', N'Garcia ', 33412655, N'd.garcia@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Brenda', N'Gonzalez', 25640002, N'b.gonzalez@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Milagros', N'Paez', 44531985, N'm.paez@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Elizabet ', N'Cejas', 38742124, N'e.cejas@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Leandro', N'Marcilli', 41235691, N'l.marcilli@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Juan', N'Gigena', 33532877, N'j.gigena@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Adrian', N'Luedueña', 17322643, N'a.ludueña@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Jeffrey ', N'Enriquez ', 24580765, N'j.enriquez@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Pablo', N'Merlo', 37452900, N'p.merlo@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Julieta', N'Vega', 19345721, N'j.vega@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Joregelina', N'Ordoñez', 38645639, N'j.ordoñez@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Luciana ', N'Paz', 41235623, N'l.paz@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Romeo', N'Santos', 40569866, N'r.santos@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Yamila', N'Hidalgo', 31173944, N'y.hidalgo@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Samuel', N'Heredia', 39171563, N's.heredia@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Ximena', N'Saviola', 19124570, N'j.saviola@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Alberto', N'Einstein', 13423844, N'a.einstein@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Horacio', N'Guarani', 35632198, N'h.guarani@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Waldo', N'Murua', 43468012, N'w.murua@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Zamir', N'Ventura', 25094478, N'z.ventura@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Enrique ', N'Ortuño', 35578901, N'.ortuño@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Dalila', N'Martin', 44531985, N'd.martin@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Gabriela', N'Mera', 41421360, N'g.mera@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Irene', N'Sanchez', 43901366, N'i.sanchez@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Kevin', N'Corner', 20773854, N'k.corner@hotmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Ulises', N'Malo', 17342093, N'u.malo@gmail.com')
INSERT [dbo].[Clientes] ([nombre], [apellido], [dni], [e_mail]) VALUES (N'Teodoro', N'Biblia', 44531985, N't.biblia@gmail.com')

--select * from clientes
----------------------------------------------------CINES---------------------------------------------------------------------

INSERT [dbo].[Cines] ([nombre], [direccion], [telefono], [cuit]) VALUES ('Cines Picon','Las Junturas 328','4721560','30710466430')

--select * from Cines

---------------------------------------------------IDIOMAS----------------------------------------------------------------------
INSERT [dbo].[Idiomas] ( [idioma]) VALUES ( 'Subtitulada')
INSERT [dbo].[Idiomas] ( [idioma]) VALUES ( 'Doblada')
INSERT [dbo].[Idiomas] ( [idioma]) VALUES ( 'Idioma Original')

--SELECT * FROM Idiomas

---------------------------------------------------GENEROS----------------------------------------------------------------------------
INSERT [dbo].[Generos] ( [genero]) VALUES ( 'Drama')
INSERT [dbo].[Generos] ( [genero]) VALUES ( 'Ciencia Ficcion')
INSERT [dbo].[Generos] ( [genero]) VALUES ( 'Accion')
INSERT [dbo].[Generos] ( [genero]) VALUES ( 'Horror')
INSERT [dbo].[Generos] ( [genero]) VALUES ( 'Comedia')
INSERT [dbo].[Generos] ( [genero]) VALUES ( 'Romance')
INSERT [dbo].[Generos] ( [genero]) VALUES ( 'Aventura')
INSERT [dbo].[Generos] ( [genero]) VALUES ( 'Musical')
INSERT [dbo].[Generos] ( [genero]) VALUES ( 'Animacion')
INSERT [dbo].[Generos] ( [genero]) VALUES ( 'Suspenso')
INSERT [dbo].[Generos] ( [genero]) VALUES ( 'Western')
INSERT [dbo].[Generos] ( [genero]) VALUES ( 'Infantiles')
INSERT [dbo].[Generos] ( [genero]) VALUES ( 'Fantasia')

--SELECT * FROM GENEROS

-------------------------------------------------FORMATO_PELICULAS-----------------------------------------------------------------------------
INSERT [dbo].[Formatos_peliculas] ([formato]) VALUES ( N'ATP')
INSERT [dbo].[Formatos_peliculas] ( [formato]) VALUES ( N'+13')
INSERT [dbo].[Formatos_peliculas] ( [formato]) VALUES ( N'+16')
INSERT [dbo].[Formatos_peliculas] ( [formato]) VALUES ( N'+18')

----------------------------------------------FORMAS_VENTAS---------------------------------------------------------------------------------------
INSERT [dbo].[Formas_ventas] ( [forma_venta]) VALUES ( N'online')
INSERT [dbo].[Formas_ventas] ( [forma_venta]) VALUES ( N'fisica')

------------------------------------------------TIPOS_SALAS---------------------------------------------------------------------------------------
INSERT [dbo].[Tipos_salas] ( [tipo_sala]) VALUES ( N'2D')
INSERT [dbo].[Tipos_salas] ( [tipo_sala]) VALUES ( N'3D')
INSERT [dbo].[Tipos_salas] ( [tipo_sala]) VALUES ( N'4D')
INSERT [dbo].[Tipos_salas] ( [tipo_sala]) VALUES ( N'VIP')

-----------------------------------------------TIPOS_PAGOS------------------------------------------------------------------------------------------
INSERT [dbo].[Tipos_pagos] ([tipo]) VALUES (N'Peso Argentino')
INSERT [dbo].[Tipos_pagos] ([tipo]) VALUES (N'Dolar')
INSERT [dbo].[Tipos_pagos] ([tipo]) VALUES (N' 1 Cuota  ')
INSERT [dbo].[Tipos_pagos] ([tipo]) VALUES (N' 2 Cuotas ')
INSERT [dbo].[Tipos_pagos] ([tipo]) VALUES (N' 3 Cuota ')
INSERT [dbo].[Tipos_pagos] ([tipo]) VALUES (N' 6 Cuotas ')
INSERT [dbo].[Tipos_pagos] ([tipo]) VALUES (N' 12 Cuotas ')

-----------------------------------------------SALAS-------------------------------------------------------------------------------------------
INSERT [dbo].[Salas] ([id_tipo_sala], [cant_butacas], [id_cine]) VALUES (  1,20, 1)
INSERT [dbo].[Salas] ( [id_tipo_sala], [cant_butacas], [id_cine]) VALUES ( 2, 20, 1)
INSERT [dbo].[Salas] ( [id_tipo_sala], [cant_butacas], [id_cine]) VALUES ( 3, 20, 1)
INSERT [dbo].[Salas] ( [id_tipo_sala], [cant_butacas], [id_cine]) VALUES ( 4, 20, 1)



----------------------------------------------BUTACAS---------------------------------------------------------------------------------
-----------------------------------------------SALA 1 2D----------------------------------------------------------------------------------


insert  into butacas (fila, id_sala, nro_butaca)
values (  'a' , 1 , 1)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 1, 2)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 1, 3)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 1, 4 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 1, 5)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 1, 6 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 1 , 7 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 1, 8 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 1 , 9 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 1 , 10 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 1 , 11 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 1 , 12 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 1 , 13 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 1, 14 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 1, 15 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 1 , 16)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 1 , 17)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 1 , 18)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 1 , 19)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 1, 20 )

----------------------------------------------------------SALA 2 3D--------------------------------------------------------------------------------------


insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 2 , 1)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 2 , 2)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 2 , 3)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 2, 4 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 2, 5 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 2, 6 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 2 , 7)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 2, 8 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 2 , 9)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 2, 10 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 2 , 11)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 2, 12 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 2 , 13)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 2 , 14)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 2 , 15)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 2 , 16)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 2 , 17)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 2, 18 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 2 , 19)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 2 , 20)

----------------------------------------------------SALA 3 4D----------------------------------------------------------------------


insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 3 , 1)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 3, 2 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 3, 3 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 3 , 4)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 3, 5)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 3 , 6)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 3 , 7)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 3 , 8)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 3 , 9)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 3 , 10)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 3 , 11 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 3 , 12)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 3, 13 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 3 , 14)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 3 , 15)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 3 , 16)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 3 , 17)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 3 , 18)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 3 , 19)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 3 , 20)

------------------------------------------------------------SALA 4 VIP -------------------------------------------------------------------------------
insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 4 , 1)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 4 , 2)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 4 , 3)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 4 , 4)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'a' , 4, 5 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 4 , 6)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 4 , 7)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 4 , 8)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 4 , 9)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'b' , 4 , 10)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 4 , 11)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 4 , 12)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 4 , 13)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 4 , 14)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'c' , 4 , 15)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 4 , 16 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 4, 17 )

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 4 , 18)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 4 , 19)

insert  into butacas (fila, id_sala,nro_butaca)
values (  'd' , 4 , 20)

-----------------------------------------------FORMAS DE PAGO ------------------------------------------------------------------------------

INSERT [dbo].[Forma_pagos] ([forma_pago], [id_tipo_pago]) VALUES (N'Efectivo', 1)
INSERT [dbo].[Forma_pagos] ([forma_pago], [id_tipo_pago]) VALUES (N'Efectivo', 2)
INSERT [dbo].[Forma_pagos] ([forma_pago], [id_tipo_pago]) VALUES (N'Tarjeta de Debito', 3)
INSERT [dbo].[Forma_pagos] ([forma_pago], [id_tipo_pago]) VALUES (N'Tarjeta de Crédito', 3)
INSERT [dbo].[Forma_pagos] ([forma_pago], [id_tipo_pago]) VALUES (N'Tarjeta de Crédito', 4)
INSERT [dbo].[Forma_pagos] ([forma_pago], [id_tipo_pago]) VALUES (N'Tarjeta de Crédito', 5)
INSERT [dbo].[Forma_pagos] ([forma_pago], [id_tipo_pago]) VALUES (N'Tarjeta de Crédito', 6)
INSERT [dbo].[Forma_pagos] ([forma_pago], [id_tipo_pago]) VALUES (N'Tarjeta de Crédito', 7)

---------------------------------------------PELICULAS---------------------------------------------------------------------------------

INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) 
VALUES ( 'Olmegod VS Dark Aliade', 
'Un universo menos devastado por el poder oscuro del feminismo, ahora el siguiente es el nuestro... Por suerte nuestro Heroe Electromecanico esta para salvarnos.',
 9, CAST('2023-11-12T00:00:00.000' AS DateTime), 2, 1)

INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) 
VALUES ( 'Picon, inicio de un negocio', 
'Una sola clase de 2 horas acerca de politicas de derecha fueron suficientes para convertir a un depravado en un genio de los negocios ilegales PERO economicamente liberales',
 9, CAST('2023-12-12T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ( 'El Conjuro', 'A principios de los años 70, Ed y Lorrain Warren, reputados investigadores de fenomenos paranormales, se enfrentan a una entidad demoniaca.', 4, CAST('2023-01-25T00:00:00.000' AS DateTime), 2, 4)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ( 'Toy Story 4', 'Woody siempre ha tenido claro cual es su labor en el mundo: cuidar a su dueño, ya sea Andy o Bonnie.', 9, CAST(N'2023-02-07T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ( 'Sherk 4', 'Instalado en su vida matrimonial y totalmente domesticado Shrek empieza a extrañar los dias en los que el se sentia como un verdadero ogro.', 9, CAST('2023-03-12T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ( 'el gran crossfit', 'un joven de barrios bajos logra ganar el premio mundial de crossfit', 7, CAST('2023-04-23T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ( 'el asesinato del politico picon ', 'un politico muy venerado por la causa de estar metido en trafico de mujeres se involucra con la hija del jefe de la mafia artero ', 3, CAST('2023-05-28T00:00:00.000' AS DateTime), 2, 4)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ( 'la caida del universo 7', 'una gran guerra intergalactica por el feminismo causa la gran destrucion del universo', 10, CAST('2023-06-01T00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ( 'El joven manos de tijera de villa union', ' un joven nacido con la manos de tijera con un amor no correspondido hacia una cantante que es adicta a las drogas', 8, CAST('2023-07-30T00:00:00.000' AS DateTime), 2, 3)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ( 'Creo', 'Una historia conmovedora basada en la duda existencial de un profesor universitario el cual posee alzheimer', 1, CAST('2023-08-08T00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ( 'Olmegod', 'Profesor de dia, superheroe de noche, se desarrolla la vida de un profesor de ingenieria el cual con su traje a base de leds programados en Assembler lucha por un mundo sin abortos', 5, CAST('2023-09-17T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ( 'GOTO, la perdicion', 'Una palabra silenciada por muchos forma parte del epicentro del terror del nuevo milenio', 4, CAST('2023-10-06T00:00:00.000' AS DateTime), 2, 4)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ( 'Hasta luego Lucas', 'La historia conmovedora de un joven que enfrenta un amor no correspondido a costa del cuidado de una hija la cual no es de el', 5, CAST('2023-11-14T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ( 'Hasta luego Lucas 2: en Canada', 'Despues de sufrir un entrincado en su hogar por una batalla campal con la bruja, idea el plan perfecto par recuperar su libertad... y la nena', 5, CAST('2023-12-22T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ('Mmm digame mas...','"Me encanta la dinamica de su clase" fueron las primeras palabras que desencadenaron una trama amorosa y polemica en una universidad estatal. Quieren estar juntes y nada mas', 5, CAST('2023-01-05T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ('Fri Faier','Un juego de movil inofensivo de repente se convierte en realidad a causa del retorno de una dictadora que causa el apocalipsis financiero en un tiempo record', 13, CAST('2023-02-27T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ('la muerte de gonza','un chico que le gustaba asistir a fiestas electronicas y tiene una muerte tragica por sobredosis drogas ', 7, CAST('2023-03-09T00:00:00.000' AS DateTime), 1, 3)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ('Black sheep','Una persona de color oscuro y un "blanquito" de pelo ondulado unen fuerzas para realizar una mision suicida, derribar el imperio ario y acabar con la esclavitud', 3, CAST(N'2023-04-30T00:00:00.000' AS DateTime), 1, 4)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ('Hasta luego Lucas 3: 3x1','Con la nena ya libre en una isla paradisiaca, Lucas se enfrenta a su nemesis, la bruja volvio con sus dos mejores amigas por una venganza digna la cual termina de una marea inesperada', 5, CAST('2023-05-12T00:00:00.000' AS DateTime), 2, 4)
INSERT [dbo].[Peliculas] ([titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ('Un flay','Hasta donde llega la imaginacion de la mente? Bruno lo descubre despues de experimentar con una droga psicotropica no apta para niños', 6, CAST('2023-06-14T00:00:00.000' AS DateTime), 1, 3)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ('Mataron a Kenny','Lo clavaron a la salida del baile de onduxa', 7, CAST('2023-07-06T00:00:00.000' AS DateTime), 1, 4)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ('NANI','Un profesor saca de la clase a dos alumnos porque hablaban de Naruto. Ese acto desencadena una masacre que junta balas, jutsus y aliens y nadie entiende como', 9, CAST('2023-08-02T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ('Narc','Cuando el rastro se congela en una investigacion de asesinato de un policia, un oficial encubierto de narcoticos es atrapado de vuelta a la fuerza para ayudar a resolver el caso.', 3, CAST('2023-09-10T00:00:00.000' AS DateTime), 2, 3)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ('Punch-Drunk Love','Un proveedor de novedades psicologicamente problematico es empujado hacia un romance con una mujer inglesa.', 6, CAST('2023-10-01T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Peliculas] ( [titulo], [descripcion], [id_genero], [fecha_estreno], [id_idioma], [id_formato]) VALUES ('Confidence','Jake Vig (Burns) es un estafador consumado a punto de sacar su mayor estafa hasta el momento, uno para vengar el asesinato de su amigo.', 3, CAST('2023-11-01T00:00:00.000' AS DateTime), 2, 4)

select * from funciones
select * from peliculas -- ID PELICULA 13 Y 19
						-- ID FUNCION 13 y 19
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 1, 1, CAST('22:30:00' AS Time), CAST(N'2023-11-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 2, 2, CAST('22:30:00' AS Time), CAST(N'2023-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 3, 3, CAST('22:30:00' AS Time), CAST(N'2023-01-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 4, 4, CAST('22:30:00' AS Time), CAST(N'2023-02-07T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 2, 5, CAST('22:30:00' AS Time), CAST(N'2023-03-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 4, 6, CAST('22:30:00' AS Time), CAST(N'2023-04-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 3, 7, CAST('22:30:00' AS Time), CAST(N'2023-05-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 1, 8, CAST('22:30:00' AS Time), CAST(N'2023-06-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 2, 9, CAST('22:30:00' AS Time), CAST(N'2023-07-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 1, 10, CAST('22:30:00' AS Time), CAST(N'2023-08-08T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 1, 11, CAST('22:30:00' AS Time), CAST(N'2023-09-17T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 2, 12, CAST('22:30:00' AS Time), CAST(N'2023-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 3, 13, CAST('22:30:00' AS Time), CAST(N'2023-11-14T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 4, 14, CAST('22:30:00' AS Time), CAST(N'2023-12-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 3, 15, CAST('22:30:00' AS Time), CAST(N'2023-01-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 2, 16, CAST('22:30:00' AS Time), CAST(N'2023-02-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 1, 17, CAST('22:30:00' AS Time), CAST(N'2023-03-09T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 3, 18, CAST('22:30:00' AS Time), CAST(N'2023-04-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 2, 19, CAST('22:30:00' AS Time), CAST(N'2023-05-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 2, 20, CAST('22:30:00' AS Time), CAST(N'2023-06-14T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 1, 21, CAST('22:30:00' AS Time), CAST(N'2023-07-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 3, 22, CAST('22:30:00' AS Time), CAST(N'2023-08-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 4, 23, CAST('22:30:00' AS Time), CAST(N'2023-09-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 4, 24, CAST('22:30:00' AS Time), CAST(N'2023-10-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 4, 25, CAST('22:30:00' AS Time), CAST(N'2023-11-01T00:00:00.000' AS DateTime))

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 2, 2, 1)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 34, 2, 2)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 4, 2, 3)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 41, 2, 4)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 1, 2, 5)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 2, 2, 6)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 15, 2, 7)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 15, 2, 8)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 29, 2, 9)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 12, 2, 10)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 6, 2, 11)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 32, 2, 12)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 47, 2, 13)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 54, 2, 14)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 23, 2, 15)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 3, 2, 16)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 44, 2, 17)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 44, 2, 18)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 12, 2, 19)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 18, 2, 20)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 17, 2, 21)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 52, 2, 22)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 36, 2, 23)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 29, 2, 24)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 10, 2, 25)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-12T00:00:00.000' AS DateTime), '20:45', 2, 3)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-12T00:00:00.000' AS DateTime), '21:36', 10, 1)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-12-12T00:00:00.000' AS DateTime), '21:04', 34, 6)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-12-12T00:00:00.000' AS DateTime), '21:15', 3, 1)




INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-01-25T00:00:00.000' AS DateTime), '20:07', 4, 1)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-01-25T00:00:00.000' AS DateTime), '20:32', 11, 5)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-01-25T00:00:00.000' AS DateTime), '20:45', 54, 1)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-01-25T00:00:00.000' AS DateTime), '21:00', 23, 4)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-01-25T00:00:00.000' AS DateTime), '21:15', 09, 1)





INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-02-07T00:00:00.000' AS DateTime), '20:15', 41, 7)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-02-07T00:00:00.000' AS DateTime), '20:22', 4, 1)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-02-07T00:00:00.000' AS DateTime), '20:33', 6, 1)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-02-07T00:00:00.000' AS DateTime), '21:07', 8, 3)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-02-07T00:00:00.000' AS DateTime), '21:20', 11, 1)







INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-03-12T00:00:00.000' AS DateTime), '20:01', 1, 4)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-03-12T00:00:00.000' AS DateTime), '20:15', 15, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-03-12T00:00:00.000' AS DateTime), '20:24', 16, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-03-12T00:00:00.000' AS DateTime), '20:58', 17, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-03-12T00:00:00.000' AS DateTime), '21:10', 19, 2)





INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-04-23T00:00:00.000' AS DateTime), '20:03', 2, 5)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-04-23T00:00:00.000' AS DateTime), '20:13', 8, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-04-23T00:00:00.000' AS DateTime), '20:33', 10, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-04-23T00:00:00.000' AS DateTime), '20:47', 15, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-04-23T00:00:00.000' AS DateTime), '21:03', 52, 8)



INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-05-28T00:00:00.000' AS DateTime), '20:08', 15, 7)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-05-28T00:00:00.000' AS DateTime), '20:18', 19, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-05-28T00:00:00.000' AS DateTime), '20:28', 33, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-05-28T00:00:00.000' AS DateTime), '20:48', 35, 6)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-05-28T00:00:00.000' AS DateTime), '20:58', 39, 1)






INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-06-01T00:00:00.000' AS DateTime), '20:06', 15, 8)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-06-01T00:00:00.000' AS DateTime), '20:16', 27, 5)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-06-01T00:00:00.000' AS DateTime), '20:26', 37, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-06-01T00:00:00.000' AS DateTime), '20:36', 48, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-06-01T00:00:00.000' AS DateTime), '20:56', 32, 1)






INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-07-30T00:00:00.000' AS DateTime), '20:05', 29, 4)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-07-30T00:00:00.000' AS DateTime), '20:15', 39, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-07-30T00:00:00.000' AS DateTime), '20:25', 49, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-07-30T00:00:00.000' AS DateTime), '20:35', 14, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-07-30T00:00:00.000' AS DateTime), '20:55', 2, 1)













INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-08-08T00:00:00.000' AS DateTime), '20:17', 12, 8)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-08-08T00:00:00.000' AS DateTime), '20:27', 8, 1)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-08-08T00:00:00.000' AS DateTime), '20:37', 5, 1)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-08-08T00:00:00.000' AS DateTime), '20:47', 1, 1)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-08-08T00:00:00.000' AS DateTime), '21:17', 54, 1)






INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-15T00:00:00.000' AS DateTime), '20:00', 6, 5)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-19T00:00:00.000' AS DateTime), '20:10', 53, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '20:20', 50, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-12T00:00:00.000' AS DateTime), '20:40', 48, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:10', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-11T00:00:00.000' AS DateTime), '21:11', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-12T00:00:00.000' AS DateTime), '21:12', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:13', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-11T00:00:00.000' AS DateTime), '21:14', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:15', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:16', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-15T00:00:00.000' AS DateTime), '21:17', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:18', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-16T00:00:00.000' AS DateTime), '21:19', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:20', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-18T00:00:00.000' AS DateTime), '21:21', 45, 1)









INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-10-06T00:00:00.000' AS DateTime), '20:04', 32, 6)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-10-06T00:00:00.000' AS DateTime), '20:14', 30, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-10-06T00:00:00.000' AS DateTime), '20:24', 36, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-10-06T00:00:00.000' AS DateTime), '20:34', 37, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-10-06T00:00:00.000' AS DateTime), '20:54', 39, 1)





INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-14T00:00:00.000' AS DateTime), '20:22', 47, 5)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-14T00:00:00.000' AS DateTime), '20:32', 40, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-14T00:00:00.000' AS DateTime), '20:42', 41, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-14T00:00:00.000' AS DateTime), '20:52', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-14T00:00:00.000' AS DateTime), '21:22', 48, 3)





INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-12-22T00:00:00.000' AS DateTime), '20:04', 54, 8)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-12-22T00:00:00.000' AS DateTime), '20:14', 47, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-12-22T00:00:00.000' AS DateTime), '20:24', 33, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-12-22T00:00:00.000' AS DateTime), '20:34', 21, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-12-22T00:00:00.000' AS DateTime), '20:54', 12, 4)











INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-01-05T00:00:00.000' AS DateTime), '20:15', 23, 3)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-01-05T00:00:00.000' AS DateTime), '20:15', 36, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-01-05T00:00:00.000' AS DateTime), '20:15', 4, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-01-05T00:00:00.000' AS DateTime), '20:15', 53, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-01-05T00:00:00.000' AS DateTime), '20:15', 51, 1)






INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-02-27T00:00:00.000' AS DateTime), '20:03', 3, 6)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-02-27T00:00:00.000' AS DateTime), '20:13', 38, 1)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-02-27T00:00:00.000' AS DateTime), '20:33', 39, 1)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-02-27T00:00:00.000' AS DateTime), '20:53', 37, 3)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-02-27T00:00:00.000' AS DateTime), '21:13', 13, 1)





INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-03-09T00:00:00.000' AS DateTime), '20:05', 44, 7)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-03-09T00:00:00.000' AS DateTime), '20:15', 24, 1)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-03-09T00:00:00.000' AS DateTime), '20:25', 14, 1)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-03-09T00:00:00.000' AS DateTime), '20:55', 4, 1)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-03-09T00:00:00.000' AS DateTime), '21:05', 54, 1)







INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-04-30T00:00:00.000' AS DateTime), '20:25', 44, 3)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-04-30T00:00:00.000' AS DateTime), '20:35', 37, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-04-30T00:00:00.000' AS DateTime), '20:57', 33, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-04-30T00:00:00.000' AS DateTime), '21:15', 52, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-04-30T00:00:00.000' AS DateTime), '21:25', 41, 1)







INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-05-12T00:00:00.000' AS DateTime), '20:07', 12, 4)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-05-12T00:00:00.000' AS DateTime), '20:17', 19, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-05-12T00:00:00.000' AS DateTime), '20:37', 18, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-05-12T00:00:00.000' AS DateTime), '20:47', 14, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-05-12T00:00:00.000' AS DateTime), '20:57', 10, 1)







INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-06-14T00:00:00.000' AS DateTime), '20:04', 18, 5)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-06-14T00:00:00.000' AS DateTime), '20:14', 17, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-06-14T00:00:00.000' AS DateTime), '20:24', 21, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-06-14T00:00:00.000' AS DateTime), '20:34', 28, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-06-14T00:00:00.000' AS DateTime), '20:54', 50, 1)






INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-07-06T00:00:00.000' AS DateTime), '20:23', 17, 7)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-07-06T00:00:00.000' AS DateTime), '20:43', 23, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-07-06T00:00:00.000' AS DateTime), '20:53', 25, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-07-06T00:00:00.000' AS DateTime), '20:57', 35, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-07-06T00:00:00.000' AS DateTime), '21:13', 39, 1)





INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-08-02T00:00:00.000' AS DateTime), '20:05', 52, 6)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-08-02T00:00:00.000' AS DateTime), '20:15', 37, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-08-02T00:00:00.000' AS DateTime), '20:25', 30, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-08-02T00:00:00.000' AS DateTime), '20:45', 27, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-08-02T00:00:00.000' AS DateTime), '21:35', 23, 4)






INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-10T00:00:00.000' AS DateTime), '20:02', 36, 4)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-10T00:00:00.000' AS DateTime), '20:12', 4, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-10T00:00:00.000' AS DateTime), '20:22', 26, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-10T00:00:00.000' AS DateTime), '20:32', 14, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-10T00:00:00.000' AS DateTime), '20:52', 34, 1)



INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-10-01T00:00:00.000' AS DateTime), '20:15', 29, 5)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-10-01T00:00:00.000' AS DateTime), '20:45', 26, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-10-01T00:00:00.000' AS DateTime), '21:15', 27, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-10-01T00:00:00.000' AS DateTime), '21:25', 39, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-10-01T00:00:00.000' AS DateTime), '21:37', 49, 1)



INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-01T00:00:00.000' AS DateTime), '20:07', 10, 6)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-01T00:00:00.000' AS DateTime), '20:17', 17, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-01T00:00:00.000' AS DateTime), '20:17', 24, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-01T00:00:00.000' AS DateTime), '20:57', 25, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-01T00:00:00.000' AS DateTime), '21:07', 38, 1)


-- FUNCION 1

INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (1, 300.0000, 1, CAST(0 AS Decimal(18, 0)), 1, 10)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (2, 300.0000, 1, CAST(0 AS Decimal(18, 0)), 11, 10)

-- FUNCION 2
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (3, 300.0000, 2, CAST(0 AS Decimal(18, 0)), 21, 5)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (4, 300.0000, 2, CAST(0 AS Decimal(18, 0)), 26, 5)

-- FUNCION 3
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (5, 350.0000, 3, CAST(0 AS Decimal(18, 0)), 41, 5)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (6, 350.0000, 3, CAST(0 AS Decimal(18, 0)), 46, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (7, 350.0000, 3, CAST(0 AS Decimal(18, 0)), 48, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (8, 350.0000, 3, CAST(0 AS Decimal(18, 0)), 42, 5)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (9, 350.0000, 3, CAST(0 AS Decimal(18, 0)), 45, 2)

-- FUNCION 4
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (10, 350.0000, 4, CAST(5 AS Decimal(18, 0)), 61, 5)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (11, 350.0000, 4, CAST(0 AS Decimal(18, 0)), 66, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (12, 350.0000, 4, CAST(2 AS Decimal(18, 0)), 78, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (13, 350.0000, 4, CAST(0 AS Decimal(18, 0)), 70, 5)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (14, 350.0000, 4, CAST(0 AS Decimal(18, 0)), 75, 2)

-- FUNCION 5
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (15, 350.0000, 5, CAST(5 AS Decimal(18, 0)), 21, 10)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (16, 350.0000, 5, CAST(0 AS Decimal(18, 0)), 22, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 17, 350.0000, 5, CAST(0 AS Decimal(18, 0)), 23, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 18, 350.0000, 5, CAST(10 AS Decimal(18, 0)), 35, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 19, 350.0000, 5, CAST(0 AS Decimal(18, 0)), 37, 3)

-- FUNCION 6
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 20, 350.0000, 6, CAST(0 AS Decimal(18, 0)), 61, 15)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 21, 350.0000, 6, CAST(0 AS Decimal(18, 0)), 66, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 22, 350.0000, 6, CAST(0 AS Decimal(18, 0)), 77, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 23, 350.0000, 6, CAST(5 AS Decimal(18, 0)), 78, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 24, 350.0000, 6, CAST(0 AS Decimal(18, 0)), 69, 1)

-- FUNCION 7
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 25, 350.0000, 7, CAST(0 AS Decimal(18, 0)), 41, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 26, 350.0000, 7, CAST(0 AS Decimal(18, 0)), 44, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 27, 350.0000, 7, CAST(0 AS Decimal(18, 0)), 57, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 28, 350.0000, 7, CAST(0 AS Decimal(18, 0)), 50, 5)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 29, 350.0000, 7, CAST(0 AS Decimal(18, 0)), 55, 5)

-- FUNCION 8
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 30, 350.0000, 8, CAST(0 AS Decimal(18, 0)), 1, 5)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 31, 350.0000, 8, CAST(0 AS Decimal(18, 0)), 6, 5)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 32, 350.0000, 8, CAST(5 AS Decimal(18, 0)), 11, 4)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 33, 350.0000, 8, CAST(0 AS Decimal(18, 0)), 15, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 34, 350.0000, 8, CAST(0 AS Decimal(18, 0)), 17, 3)

-- FUNCION 9
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 35, 350.0000, 9, CAST(0 AS Decimal(18, 0)), 31, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 36, 350.0000, 9, CAST(0 AS Decimal(18, 0)), 24, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 37, 350.0000, 9, CAST(5 AS Decimal(18, 0)), 27, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 38, 350.0000, 9, CAST(0 AS Decimal(18, 0)), 30, 5)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 39, 350.0000, 9, CAST(0 AS Decimal(18, 0)), 35, 2)


-- FUNCION 10
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 40, 350.0000, 10, CAST(0 AS Decimal(18, 0)), 1, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 41, 350.0000, 10, CAST(0 AS Decimal(18, 0)), 3, 4)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 42, 350.0000, 10, CAST(0 AS Decimal(18, 0)), 7, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 43, 350.0000, 10, CAST(0 AS Decimal(18, 0)), 8, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 44, 350.0000, 10, CAST(0 AS Decimal(18, 0)), 9, 5)

-- FUNCION 11
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 45, 350.0000, 11, CAST(0 AS Decimal(18, 0)), 1, 10)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 46, 350.0000, 11, CAST(0 AS Decimal(18, 0)), 11, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 47, 350.0000, 11, CAST(5 AS Decimal(18, 0)), 12, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 48, 350.0000, 11, CAST(0 AS Decimal(18, 0)), 14, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 49, 350.0000, 11, CAST(0 AS Decimal(18, 0)), 15, 4)

-- FUNCION 12
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 50, 350.0000, 12, CAST(0 AS Decimal(18, 0)), 21, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 51, 350.0000, 12, CAST(0 AS Decimal(18, 0)), 33, 4)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 52, 350.0000, 12, CAST(0 AS Decimal(18, 0)), 27, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 53, 350.0000, 12, CAST(0 AS Decimal(18, 0)), 28, 6)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 54, 350.0000, 12, CAST(0 AS Decimal(18, 0)), 34, 2)

-- FUNCION 13
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 55, 350.0000, 13, CAST(0 AS Decimal(18, 0)), 41, 6)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 56, 350.0000, 13, CAST(0 AS Decimal(18, 0)), 47, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 57, 350.0000, 13, CAST(0 AS Decimal(18, 0)), 59, 4)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 58, 350.0000, 13, CAST(0 AS Decimal(18, 0)), 53, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 59, 350.0000, 13, CAST(0 AS Decimal(18, 0)), 44, 3)

-- FUNCION 14
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 60, 350.0000, 14, CAST(0 AS Decimal(18, 0)), 62, 6)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 61, 350.0000, 14, CAST(5 AS Decimal(18, 0)), 67, 4)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 62, 350.0000, 14, CAST(0 AS Decimal(18, 0)), 71, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 63, 350.0000, 14, CAST(0 AS Decimal(18, 0)), 73, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 64, 350.0000, 14, CAST(0 AS Decimal(18, 0)), 75, 4)

-- FUNCION 15
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 65, 400.0000, 15, CAST(0 AS Decimal(18, 0)), 42, 9)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 66, 400.0000, 15, CAST(10 AS Decimal(18, 0)), 50, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 67, 400.0000, 15, CAST(0 AS Decimal(18, 0)), 52, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 68, 400.0000, 15, CAST(0 AS Decimal(18, 0)), 54, 6)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 69, 400.0000, 15, CAST(0 AS Decimal(18, 0)), 59, 1)

-- FUNCION 16
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 70, 400.0000, 16, CAST(0 AS Decimal(18, 0)), 22, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 71, 400.0000, 16, CAST(0 AS Decimal(18, 0)), 24, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 72, 400.0000, 16, CAST(50 AS Decimal(18, 0)), 36, 6)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 73, 400.0000, 16, CAST(0 AS Decimal(18, 0)), 32, 4)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 74, 400.0000, 16, CAST(0 AS Decimal(18, 0)), 26, 3)

-- FUNCION 17
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 75, 400.0000, 17, CAST(0 AS Decimal(18, 0)), 1, 6)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 76, 400.0000, 17, CAST(0 AS Decimal(18, 0)), 7, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 77, 400.0000, 17, CAST(0 AS Decimal(18, 0)), 8, 5)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 78, 400.0000, 17, CAST(0 AS Decimal(18, 0)), 13, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 79, 400.0000, 17, CAST(0 AS Decimal(18, 0)), 15, 2)

-- FUNCION 18
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 80, 400.0000, 18, CAST(0 AS Decimal(18, 0)), 42, 7)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 81, 400.0000, 18, CAST(0 AS Decimal(18, 0)), 48, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 82, 400.0000, 18, CAST(50 AS Decimal(18, 0)), 49, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 83, 400.0000, 18, CAST(0 AS Decimal(18, 0)), 52, 4)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 84, 400.0000, 18, CAST(0 AS Decimal(18, 0)), 56, 2)

-- FUNCION 19
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 85, 400.0000, 19, CAST(0 AS Decimal(18, 0)), 21, 6)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 86, 400.0000, 19, CAST(0 AS Decimal(18, 0)), 27, 4)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 87, 400.0000, 19, CAST(0 AS Decimal(18, 0)), 31, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 88, 400.0000, 19, CAST(0 AS Decimal(18, 0)), 34, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 89, 400.0000, 19, CAST(0 AS Decimal(18, 0)), 35, 4)

-- FUNCION 20
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 90, 400.0000, 20, CAST(0 AS Decimal(18, 0)), 21, 15)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 91, 400.0000, 20, CAST(0 AS Decimal(18, 0)), 26, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 92, 400.0000, 20, CAST(0 AS Decimal(18, 0)), 27, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 93, 400.0000, 20, CAST(0 AS Decimal(18, 0)), 28, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 94, 400.0000, 20, CAST(0 AS Decimal(18, 0)), 30, 1)

-- FUNCION 21
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 95, 400.0000, 21, CAST(0 AS Decimal(18, 0)), 1, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 96, 400.0000, 21, CAST(0 AS Decimal(18, 0)), 2, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 97, 400.0000, 21, CAST(0 AS Decimal(18, 0)), 4, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 98, 400.0000, 21, CAST(0 AS Decimal(18, 0)), 5, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 99, 400.0000, 21, CAST(0 AS Decimal(18, 0)), 8, 1)

-- FUNCION 22
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 100, 400.0000, 22, CAST(0 AS Decimal(18, 0)), 41, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 101, 400.0000, 22, CAST(0 AS Decimal(18, 0)), 42, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 102, 400.0000, 22, CAST(0 AS Decimal(18, 0)), 43, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 103, 400.0000, 22, CAST(0 AS Decimal(18, 0)), 46, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 104, 400.0000, 22, CAST(0 AS Decimal(18, 0)), 49, 1)

-- FUNCION 23
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 105, 400.0000, 23, CAST(0 AS Decimal(18, 0)), 61, 4)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 106, 400.0000, 23, CAST(0 AS Decimal(18, 0)), 65, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 107, 400.0000, 23, CAST(0 AS Decimal(18, 0)), 66, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 108, 400.0000, 23, CAST(0 AS Decimal(18, 0)), 67, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 109, 400.0000, 23, CAST(0 AS Decimal(18, 0)), 69, 5)

-- FUNCION 24
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 110, 400.0000, 24, CAST(0 AS Decimal(18, 0)), 71, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 111, 400.0000, 24, CAST(0 AS Decimal(18, 0)), 64, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 112, 400.0000, 24, CAST(0 AS Decimal(18, 0)), 77, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 113, 400.0000, 24, CAST(0 AS Decimal(18, 0)), 70, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 114, 400.0000, 24, CAST(0 AS Decimal(18, 0)), 72, 2)

-- FUNCION 25
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 115, 400.0000, 25, CAST(0 AS Decimal(18, 0)), 62, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 116, 400.0000, 25, CAST(0 AS Decimal(18, 0)), 72, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 117, 400.0000, 25, CAST(20 AS Decimal(18, 0)), 63, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 118, 400.0000, 25, CAST(0 AS Decimal(18, 0)), 65, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES ( 119, 400.0000, 25, CAST(0 AS Decimal(18, 0)), 76, 6)

INSERT INTO USUARIOS(nombre,usuario,contraseña,tipo_usuario) VALUES ('samuel','admin','admin','admin')


INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:11', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-16T00:00:00.000' AS DateTime), '21:12', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:13', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-18T00:00:00.000' AS DateTime), '21:14', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-19T00:00:00.000' AS DateTime), '21:15', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-16T00:00:00.000' AS DateTime), '21:16', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:17', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:18', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:19', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-13T00:00:00.000' AS DateTime), '21:20', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-12T00:00:00.000' AS DateTime), '21:21', 45, 1)



INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (120, 400.0000, 11, CAST(0 AS Decimal(18, 2)), 6, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (125, 400.0000, 11, CAST(5 AS Decimal(18, 2)), 7, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (126, 400.0000, 11, CAST(0 AS Decimal(18, 2)), 8, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (127, 400.0000, 11, CAST(0 AS Decimal(18, 2)), 9, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (128, 400.0000, 11, CAST(0 AS Decimal(18, 2)), 10, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (129, 400.0000, 11, CAST(0 AS Decimal(18, 2)), 11, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (130, 400.0000, 11, CAST(0 AS Decimal(18, 2)), 12, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (131, 400.0000, 11, CAST(0 AS Decimal(18, 2)), 13, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (132, 400.0000, 11, CAST(0 AS Decimal(18, 2)), 14, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (133, 400.0000, 11, CAST(0 AS Decimal(18, 2)), 15, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (134, 400.0000, 11, CAST(0 AS Decimal(18, 2)), 16, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (135, 400.0000, 11, CAST(0 AS Decimal(18, 2)), 17, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (136, 400.0000,11, CAST(2 AS Decimal(18, 2)), 18, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (137, 400.0000, 11, CAST(0 AS Decimal(18, 2)), 19, 1);


INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-11T00:00:00.000' AS DateTime), '20:00', 6, 5)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-12T00:00:00.000' AS DateTime), '20:10', 53, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '20:20', 50, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '20:40', 48, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-12T00:00:00.000' AS DateTime), '21:10', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-14T00:00:00.000' AS DateTime), '21:11', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-12T00:00:00.000' AS DateTime), '21:12', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:13', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-14T00:00:00.000' AS DateTime), '21:14', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:15', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-15T00:00:00.000' AS DateTime), '21:16', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:17', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:18', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-18T00:00:00.000' AS DateTime), '21:19', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-19T00:00:00.000' AS DateTime), '21:20', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:21', 45, 1)



INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (138, 400.0000, 12, CAST(0 AS Decimal(18, 2)), 26, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (139, 400.0000, 17, CAST(0 AS Decimal(18, 2)), 27, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (140, 400.0000, 13, CAST(0 AS Decimal(18, 2)), 28, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (141, 400.0000, 13, CAST(0 AS Decimal(18, 2)), 29, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (142, 400.0000, 13, CAST(0 AS Decimal(18, 2)), 24, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (143, 400.0000, 12, CAST(0 AS Decimal(18, 2)), 21, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (144, 400.0000, 13, CAST(0 AS Decimal(18, 2)), 22, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (145, 400.0000, 12, CAST(5 AS Decimal(18, 2)), 13, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (146, 400.0000, 13, CAST(0 AS Decimal(18, 2)), 14, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (147, 400.0000, 13, CAST(0 AS Decimal(18, 2)), 15, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (148, 400.0000, 13, CAST(0 AS Decimal(18, 2)), 16, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (149, 400.0000, 13, CAST(0 AS Decimal(18, 2)), 17, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (150, 400.0000, 13, CAST(0 AS Decimal(18, 2)), 18, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (151, 400.0000, 12, CAST(0 AS Decimal(18, 2)), 19, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (152, 400.0000, 12, CAST(0 AS Decimal(18, 2)), 19, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (153, 400.0000, 11, CAST(5 AS Decimal(18, 2)), 19, 1);







INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-06-17T00:00:00.000' AS DateTime), '20:00', 6, 5)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '20:10', 53, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-14T00:00:00.000' AS DateTime), '20:20', 50, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '20:40', 48, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-06-17T00:00:00.000' AS DateTime), '21:10', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:11', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-14T00:00:00.000' AS DateTime), '21:12', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:13', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-14T00:00:00.000' AS DateTime), '21:14', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:15', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-15T00:00:00.000' AS DateTime), '21:16', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:17', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-13T00:00:00.000' AS DateTime), '21:18', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-12T00:00:00.000' AS DateTime), '21:19', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-09-17T00:00:00.000' AS DateTime), '21:20', 45, 1)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-06-17T00:00:00.000' AS DateTime), '21:21', 45, 1)

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (153, 400.0000, 12, CAST(0 AS Decimal(18, 2)), 6, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (154, 400.0000, 12, CAST(0 AS Decimal(18, 2)), 7, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (155, 400.0000, 19, CAST(0 AS Decimal(18, 2)), 8, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (156, 400.0000, 12, CAST(0 AS Decimal(18, 2)), 9, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (157, 400.0000, 14, CAST(0 AS Decimal(18, 2)), 10, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (158, 400.0000, 19, CAST(0 AS Decimal(18, 2)), 11, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (159, 400.0000, 19, CAST(0 AS Decimal(18, 2)), 12, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (160, 400.0000, 16, CAST(0 AS Decimal(18, 2)), 13, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (161, 400.0000, 19, CAST(0 AS Decimal(18, 2)), 14, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (162, 400.0000, 17, CAST(0 AS Decimal(18, 2)), 15, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (163, 400.0000, 19, CAST(0 AS Decimal(18, 2)), 16, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (164, 400.0000, 19, CAST(0 AS Decimal(18, 2)), 17, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (165, 400.0000, 16, CAST(0 AS Decimal(18, 2)), 18, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (166, 400.0000, 19, CAST(0 AS Decimal(18, 2)), 19, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (167, 400.0000, 16, CAST(0 AS Decimal(18, 2)), 19, 1);

INSERT INTO Detalles (id_factura, precio, id_funcion, descuento, id_butaca, cantidad)
VALUES (168, 400.0000, 17, CAST(0 AS Decimal(18, 2)), 19, 1);



-- NUEVAS FUNCIONES NOVIEMBRE

-- 15 NOV
-- USE NewCINEART


-- FUNCION 1 DEL 15NOV

INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 4, 25, CAST('22:30:00' AS Time), CAST(N'2023-11-15T00:00:00.000' AS DateTime))

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 10, 1, 12)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 11, 1, 10)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 14, 1, 10)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 16, 1, 19)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 17, 1, 15)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 17, 1, 18)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-10T00:00:00.000' AS DateTime), '21:15', 10, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-10T00:00:00.000' AS DateTime), '21:15', 11, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-10T00:00:00.000' AS DateTime), '21:15', 14, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-10T00:00:00.000' AS DateTime), '21:15', 16, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-10T00:00:00.000' AS DateTime), '21:15', 17, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-10T00:00:00.000' AS DateTime), '21:15', 18, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-12T00:00:00.000' AS DateTime), '21:15', 11, 1)

INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (169, 300.0000, 12, CAST(5 AS Decimal(18, 0)), 1, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (170, 100.0000, 19, CAST(0 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (171, 100.0000, 19, CAST(0 AS Decimal(18, 0)), 4, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (172, 200.0000, 25, CAST(0 AS Decimal(18, 0)), 3, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (173, 500.0000, 22, CAST(0 AS Decimal(18, 0)), 5, 5)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (174, 100.0000, 19, CAST(0 AS Decimal(18, 0)), 6, 1)


-- FUNCION 2 DEL 15NOV

-- Nueva Funcion
INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) 
VALUES ( 3, 14, CAST('18:45:00' AS Time), CAST(N'2023-11-15T00:00:00.000' AS DateTime))

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 20, 1, 20)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 21, 1, 20)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 24, 1, 20)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) 
VALUES ( CAST('2023-11-15T00:00:00.000' AS DateTime), '19:30', 20, 3)

INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) 
VALUES (175, 250.0000, 20, CAST(0 AS Decimal(18, 0)), 1, 2)

INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) 
VALUES (176, 150.0000, 20, CAST(0 AS Decimal(18, 0)), 3, 1)

INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) 
VALUES (177, 200.0000, 20, CAST(0 AS Decimal(18, 0)), 5, 2)



-- FUNCIONES 16 NOV

-- FUNCION 1 

INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 4, 25, CAST('12:30:00' AS Time), CAST(N'2023-11-16T00:00:00.000' AS DateTime))

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 5, 1, 21)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 7, 1, 21)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 8, 1, 21)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 16, 1, 21)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 2, 1, 21)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 17, 1, 21)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-05T00:00:00.000' AS DateTime), '21:15', 10, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-02T00:00:00.000' AS DateTime), '21:15', 11, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-05T00:00:00.000' AS DateTime), '21:15', 14, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-10T00:00:00.000' AS DateTime), '21:15', 16, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-08T00:00:00.000' AS DateTime), '21:15', 17, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-11T00:00:00.000' AS DateTime), '21:15', 18, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-12T00:00:00.000' AS DateTime), '21:15', 11, 1)

INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (178, 300.0000, 21, CAST(0 AS Decimal(18, 0)), 1, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (179, 100.0000, 21, CAST(0 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (180, 100.0000, 21, CAST(0 AS Decimal(18, 0)), 4, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (181, 200.0000, 21, CAST(0 AS Decimal(18, 0)), 3, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (182, 500.0000, 21, CAST(0 AS Decimal(18, 0)), 5, 5)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (183, 100.0000, 21, CAST(0 AS Decimal(18, 0)), 6, 1)


-- FUNCIONES 17 NOV

-- FUNCION 1

INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 2, 25, CAST('12:30:00' AS Time), CAST(N'2023-11-16T00:00:00.000' AS DateTime))

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 6, 1, 22)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 10, 1, 22)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 8, 1, 22)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 13, 1, 22)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 12, 1, 22)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-05T00:00:00.000' AS DateTime), '21:15', 6, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-02T00:00:00.000' AS DateTime), '21:15', 10, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-05T00:00:00.000' AS DateTime), '21:15', 8, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-10T00:00:00.000' AS DateTime), '21:15', 13, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-08T00:00:00.000' AS DateTime), '21:15', 12, 2)

INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (183, 300.0000, 22, CAST(0 AS Decimal(18, 0)), 1, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (184, 100.0000, 22, CAST(0 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (185, 100.0000, 22, CAST(0 AS Decimal(18, 0)), 4, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (186, 200.0000, 22, CAST(0 AS Decimal(18, 0)), 3, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (187, 500.0000, 22, CAST(0 AS Decimal(18, 0)), 5, 5)

-- FUNCION 2

INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 1, 22, CAST('12:30:00' AS Time), CAST(N'2023-11-17T00:00:00.000' AS DateTime))

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 1, 1, 23)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 5, 1, 23)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 7, 1, 23)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 11, 1, 23)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 16, 1, 23)

INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-05T00:00:00.000' AS DateTime), '21:15', 1, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-02T00:00:00.000' AS DateTime), '21:15', 5, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-05T00:00:00.000' AS DateTime), '21:15', 7, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-10T00:00:00.000' AS DateTime), '21:15', 11, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-08T00:00:00.000' AS DateTime), '21:15', 16, 2)

INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (188, 300.0000, 23, CAST(0 AS Decimal(18, 0)), 1, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (189, 100.0000, 23, CAST(0 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (190, 100.0000, 23, CAST(0 AS Decimal(18, 0)), 4, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (191, 200.0000, 23, CAST(0 AS Decimal(18, 0)), 3, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (192, 500.0000, 23, CAST(0 AS Decimal(18, 0)), 5, 5)


-- FUNCION 3

INSERT [dbo].[Funciones] ( [id_sala], [id_pelicula], [horario], [dia]) VALUES ( 4, 22, CAST('14:30:00' AS Time), CAST(N'2023-11-17T00:00:00.000' AS DateTime))

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 2, 2, 24)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 5, 1, 24)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 8, 1, 24)

INSERT [dbo].[Reservas] ([id_cliente], [id_forma_venta], [id_funcion]) 
VALUES ( 15, 1, 24)


INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-05T00:00:00.000' AS DateTime), '21:15', 2, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-02T00:00:00.000' AS DateTime), '21:15', 5, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-05T00:00:00.000' AS DateTime), '21:15', 8, 2)
INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-10T00:00:00.000' AS DateTime), '21:15', 15, 2)

INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (192, 300.0000, 24, CAST(0 AS Decimal(18, 0)), 1, 3)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (193, 100.0000, 24, CAST(0 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (194, 100.0000, 24, CAST(0 AS Decimal(18, 0)), 4, 1)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (195, 200.0000, 24, CAST(0 AS Decimal(18, 0)), 3, 2)


INSERT [dbo].[Facturas] ( [fecha], [hora], [id_cliente], [id_forma_pago]) VALUES ( CAST('2023-11-05T00:00:00.000' AS DateTime), '21:15', 2, 2)
INSERT [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad]) VALUES (192, 300.0000, 24, CAST(0 AS Decimal(18, 0)), 1, 3)
