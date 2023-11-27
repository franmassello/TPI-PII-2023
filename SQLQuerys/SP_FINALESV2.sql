USE CINEART5

-- SPs 
CREATE PROCEDURE SP_GET_PELICULAS 
as 
begin
	select 
	p.id_pelicula, 
	p.titulo, 
	p.descripcion,
	g.genero,
	p.fecha_estreno,
	i.idioma,
	fp.formato
	from Peliculas p
	join Generos g on g.id_genero = p.id_genero
	join Idiomas i on i.id_idioma = p.id_idioma
	join Formatos_peliculas fp on fp.id_formato = p.id_formato
end


CREATE PROCEDURE SP_GET_IDIOMAS
as 
begin
	select *
	from Idiomas i 
end


CREATE PROCEDURE SP_GET_FORMATOS
as 
begin
	select *
	from Formatos_peliculas 
end


CREATE PROCEDURE SP_GET_GENEROS
as 
begin
	select *
	from Generos
end


CREATE PROCEDURE SP_INSERT_PELICULA
    @titulo NVARCHAR(100),
    @descripcion NVARCHAR(500),
    @genero_var VARCHAR(100),
    @fecha_estreno DATE,
    @idioma_var VARCHAR(100),
    @formato_var VARCHAR(100)
AS
BEGIN
    DECLARE @id_genero INT,
            @id_idioma INT,
            @id_formato INT

    SELECT @id_genero = id_genero FROM Generos WHERE genero = @genero_var
    SELECT @id_idioma = id_idioma FROM Idiomas WHERE idioma = @idioma_var
    SELECT @id_formato = id_formato FROM Formatos_peliculas WHERE formato = @formato_var

    INSERT INTO Peliculas (titulo, descripcion, id_genero, fecha_estreno, id_idioma, id_formato)
    VALUES (@titulo, @descripcion, @id_genero, @fecha_estreno, @id_idioma, @id_formato)
END


CREATE PROCEDURE SP_DELETE_PELICULA
    @id_pelicula INT
AS
BEGIN
	DELETE FROM Funciones
	WHERE id_pelicula=@id_pelicula

	DECLARE @ID_FUNC INT;
	SELECT @ID_FUNC = id_funcion FROM Funciones WHERE id_pelicula=@id_pelicula

	DELETE FROM Detalles
	WHERE id_funcion=@ID_FUNC

	DELETE FROM Reservas
	WHERE id_funcion=@ID_FUNC

	DELETE FROM Peliculas
	WHERE id_pelicula=@id_pelicula
	
END


CREATE PROCEDURE SP_UPDATE_PELICULA
	@id_pelicula INT,
    @titulo NVARCHAR(100),
    @descripcion NVARCHAR(500),
    @genero_var VARCHAR(100),
    @fecha_estreno DATE,
    @idioma_var VARCHAR(100),
    @formato_var VARCHAR(100)
AS
BEGIN
    DECLARE @id_genero INT,
            @id_idioma INT,
            @id_formato INT

    SELECT @id_genero = id_genero FROM Generos WHERE genero = @genero_var
    SELECT @id_idioma = id_idioma FROM Idiomas WHERE idioma = @idioma_var
    SELECT @id_formato = id_formato FROM Formatos_peliculas WHERE formato = @formato_var

	UPDATE Peliculas
	SET titulo= @titulo, 
		descripcion=@descripcion,
		id_genero=@id_genero,
		fecha_estreno=@fecha_estreno,
		id_idioma=@id_idioma,
		id_formato=@id_formato
	WHERE id_pelicula = @id_pelicula

    
END


-- SP_GET_FACTURAS ---------------------------------------
CREATE PROCEDURE SP_GET_FACTURAS
AS
BEGIN
	select 
		f.id_factura,
		f.fecha,
		f.hora,
		c.nombre + ' ' + c.apellido as cliente,
		c.dni,
		fu.id_funcion,
		df.precio as precio_entrada,
		df.cantidad,
		c.id_cliente,
		df.descuento,
		(df.cantidad*df.precio) - df.descuento as precioFinal,
		fp.forma_pago,
		fp.id_forma_pago,
		df.id_detalle,
		id_butaca
	from Facturas f
	join Detalles df on df.id_factura = f.id_factura
	join Clientes c on c.id_cliente=f.id_cliente
	join Forma_pagos fp on fp.id_forma_pago=f.id_forma_pago
	join Funciones fu on fu.id_funcion=df.id_funcion
END

EXEC SP_GET_FACTURAS


-- SP_GET_FUNCIONES ---------------------------------------

alter PROCEDURE SP_GET_FUNCIONES
AS
BEGIN
	select  
		f.id_funcion,
		s.id_sala,
		s.cant_butacas,
		ts.tipo_sala,
		fp.formato,
		p.titulo as titulo_pelicula,
		dia,
		LEFT(RTRIM(horario), 5) as horario,
		i.idioma,
		p.id_pelicula,
		p.titulo  + ' / ' + convert(varchar,dia)  + ' / ' + convert(varchar,horario) + ' / ' + i.idioma+' / ' + fp.formato + ' / ' + ts.tipo_sala      as titulo_promocion,
       (SELECT Count(*)
        FROM   detalles d
        WHERE  d.id_funcion = f.id_funcion) as butacas_ocupadas,
		s.cant_butacas
	from Funciones f
	join peliculas p on p.id_pelicula=f.id_pelicula
	join salas s on s.id_sala=f.id_sala
	join Idiomas i on i.id_idioma=p.id_idioma
	join Formatos_peliculas fp on fp.id_formato=p.id_formato
	join Tipos_salas ts on ts.id_tipo_sala=s.id_tipo_sala
END


EXEC SP_GET_FUNCIONES

-- SP_GET_SALAS ---------------------------------------

CREATE PROCEDURE SP_GET_SALAS
AS
BEGIN
	SELECT s.id_sala, ts.tipo_sala, s.cant_butacas, s.id_tipo_sala FROM Salas s
	join Tipos_salas ts on ts.id_tipo_sala=s.id_tipo_sala
END

EXEC SP_GET_SALAS

-- SP_INSERT_FACTURA ---------------------------------------

CREATE PROCEDURE SP_INSERT_FACTURA
    @fecha DateTime,
    @hora Time,
    @id_cliente INT,
    @id_forma_pago INT,
    @precio Decimal(18, 4),
    @id_funcion INT,
    @descuento Decimal(18, 0),
    @id_butaca INT,
    @cantidad INT
AS
BEGIN
    INSERT INTO [dbo].[Facturas] ([fecha], [hora], [id_cliente], [id_forma_pago])
    VALUES (@fecha, @hora, @id_cliente, @id_forma_pago)

    DECLARE @id_factura INT
    SET @id_factura = SCOPE_IDENTITY()

    INSERT INTO [dbo].[Detalles] ([id_factura], [precio], [id_funcion], [descuento], [id_butaca], [cantidad])
    VALUES (@id_factura, @precio, @id_funcion, @descuento, @id_butaca, @cantidad)
END

EXEC SP_INSERT_FACTURA
    '2023-11-05T00:00:00.000', '21:15', 2, 2,
    300.0000, 24, 0, 1, 3;


-- SP_UPDATE_FACTURA ---------------------------------------
CREATE PROCEDURE SP_UPDATE_FACTURA
    @id_factura INT,
    @fecha DateTime,
    @hora Time,
    @id_cliente INT,
    @id_forma_pago INT
AS
BEGIN
    UPDATE [dbo].[Facturas]
    SET
        [fecha] = @fecha,
        [hora] = @hora,
        [id_cliente] = @id_cliente,
        [id_forma_pago] = @id_forma_pago
    WHERE
        [id_factura] = @id_factura;
END

EXEC SP_UPDATE_FACTURA
    @id_factura = 191,
    @fecha = '2023-11-06T00:00:00.000',
    @hora = '22:30',
    @id_cliente = 3,
    @id_forma_pago = 1;




-- SP_DELETE_FACTURA ---------------------------------------
CREATE PROCEDURE SP_DELETE_FACTURA
    @id_factura INT
AS
BEGIN
    DELETE FROM [dbo].[Detalles] WHERE [id_factura] = @id_factura;

    DELETE FROM [dbo].[Facturas] WHERE [id_factura] = @id_factura;
END

EXEC SP_DELETE_FACTURA @id_factura = 192;



-- SP_INSERT_FUNCION ---------------------------------------

CREATE PROCEDURE SP_INSERT_FUNCION
    @id_sala INT,
    @id_pelicula INT,
    @horario Time,
    @dia DateTime

AS
BEGIN
    INSERT INTO [dbo].[Funciones] ([id_sala], [id_pelicula], [horario], [dia])
    VALUES (@id_sala, @id_pelicula, @horario, @dia);
END

EXEC SP_INSERT_FUNCION
    @id_sala = 4,
    @id_pelicula = 22,
    @horario = '14:30:00',
    @dia = '2023-11-17T00:00:00.000';


-- SP_UPDATE_FUNCION ---------------------------------------
CREATE PROCEDURE SP_UPDATE_FUNCION 
    @id_funcion INT,
    @id_sala INT,
    @id_pelicula INT,
    @horario Time,
    @dia DateTime
AS
BEGIN
    UPDATE [dbo].[Funciones]
    SET
        [id_sala] = @id_sala,
        [id_pelicula] = @id_pelicula,
        [horario] = @horario,
        [dia] = @dia
    WHERE
        [id_funcion] = @id_funcion;
END

EXEC SP_UPDATE_FUNCION
    @id_funcion = 7,  
    @id_sala = 4,
    @id_pelicula = 22,
    @horario = '14:30:00',
    @dia = '2023-11-17T00:00:00.000';



-- SP_DELETE_FUNCION ---------------------------------------
CREATE PROCEDURE SP_DELETE_FUNCION
    @id_funcion INT
AS
BEGIN
    DELETE FROM [dbo].[Detalles] WHERE [id_funcion] = @id_funcion;

    DELETE FROM [dbo].[Funciones] WHERE [id_funcion] = @id_funcion;
END

EXEC SP_DELETE_FUNCION @id_funcion = 10;  


-- SP_GET_BUTACAS_OCUPADAS ---------------------------------------

create PROCEDURE SP_GET_BUTACAS_OCUPADAS
    @id_funcion INT
AS
BEGIN
	select  
		--f.id_funcion,
		df.id_factura,
		df.id_butaca,
		s.id_sala,
		b.nro_butaca,
		b.fila,
		p.titulo as titulo_pelicula,
		f.id_funcion,
       (SELECT Count(*)
        FROM   detalles d
        WHERE  d.id_funcion = f.id_funcion) as butacas_ocupadas,
		s.cant_butacas
	from Funciones f
	join peliculas p on p.id_pelicula=f.id_pelicula
	join salas s on s.id_sala=f.id_sala
	join Idiomas i on i.id_idioma=p.id_idioma
	join Formatos_peliculas fp on fp.id_formato=p.id_formato
	join Tipos_salas ts on ts.id_tipo_sala=s.id_tipo_sala
	join Detalles df on df.id_funcion=f.id_funcion
	join Butacas b on b.id_butaca=df.id_butaca
	where f.id_funcion = @id_funcion
	
END

EXEC SP_GET_BUTACAS_OCUPADAS @id_funcion=6

-- SP_GET_BUTACAS_TOTALES ---------------------------------------

CREATE PROCEDURE SP_GET_BUTACAS_TOTALES
    @id_funcion INT
AS
BEGIN
	SELECT  
		f.id_funcion,
		p.titulo as titulo_pelicula,
		p.id_pelicula,
		b.id_butaca,
		s.id_sala,
		b.nro_butaca,
		b.fila
	FROM Funciones f
	JOIN peliculas p ON p.id_pelicula = f.id_pelicula
	JOIN salas s ON s.id_sala = f.id_sala
	JOIN Idiomas i ON i.id_idioma = p.id_idioma
	JOIN Formatos_peliculas fp ON fp.id_formato = p.id_formato
	JOIN Tipos_salas ts ON ts.id_tipo_sala = s.id_tipo_sala
	JOIN Butacas b ON b.id_sala = s.id_sala
	WHERE f.id_funcion = @id_funcion
		AND NOT EXISTS (
			SELECT 1
			FROM Detalles df
			WHERE df.id_funcion = f.id_funcion
			AND df.id_butaca = b.id_butaca
		);
END

EXEC SP_GET_BUTACAS_TOTALES @id_funcion=6



-- MIGRACION A VISTAS --------------------------------------------------------------

CREATE VIEW V_BUTACAS_TOTALES 
AS
	SELECT  
		f.id_funcion,
		p.titulo as titulo_pelicula,
		p.id_pelicula,
		b.id_butaca,
		s.id_sala,
		b.nro_butaca,
		b.fila
	FROM Funciones f
	JOIN peliculas p ON p.id_pelicula = f.id_pelicula
	JOIN salas s ON s.id_sala = f.id_sala
	JOIN Idiomas i ON i.id_idioma = p.id_idioma
	JOIN Formatos_peliculas fp ON fp.id_formato = p.id_formato
	JOIN Tipos_salas ts ON ts.id_tipo_sala = s.id_tipo_sala
	JOIN Butacas b ON b.id_sala = s.id_sala

CREATE VIEW V_BUTACAS_OCUPADAS 
AS 
	select  
		--f.id_funcion,
		df.id_factura,
		df.id_butaca,
		s.id_sala,
		b.nro_butaca,
		b.fila,
		p.titulo as titulo_pelicula,
		f.id_funcion,
       (SELECT Count(*)
        FROM   detalles d
        WHERE  d.id_funcion = f.id_funcion) as butacas_ocupadas,
		s.cant_butacas
	from Funciones f
	join peliculas p on p.id_pelicula=f.id_pelicula
	join salas s on s.id_sala=f.id_sala
	join Idiomas i on i.id_idioma=p.id_idioma
	join Formatos_peliculas fp on fp.id_formato=p.id_formato
	join Tipos_salas ts on ts.id_tipo_sala=s.id_tipo_sala
	join Detalles df on df.id_funcion=f.id_funcion
	join Butacas b on b.id_butaca=df.id_butaca


-- SP_GET_BUTACAS_LIBRES ---------------------------------------

ALTER PROCEDURE SP_BUTACAS_LIBRES
	@id_funcion INT
AS
BEGIN
	SELECT tot.*, str(tot.nro_butaca) + ' ' + tot.fila  nombre_butaca FROM 
	(SELECT * FROM V_BUTACAS_TOTALES where id_funcion=@id_funcion) tot
	left join
	(SELECT * FROM V_BUTACAS_OCUPADAS where id_funcion=@id_funcion) ocu
	on tot.id_butaca=ocu.id_butaca
	where ocu.id_butaca is null
END

EXEC SP_BUTACAS_LIBRES @id_funcion=5
