use pruebas

select * from localidades
sp_helptext spAddEditCuenta

CREATE procedure spAddEditCuenta (@idCuenta int,@descripcion varchar(50),@recibe bit,@ajusta bit,@idtipo int,@activo bit) as            
--yjs 060519,030619  
if exists (select descripcion from cuentas where idCuenta = @idCuenta)        
begin        
 update cuentas set descripcion = @descripcion,recibeasientos = @recibe,ajustable = @ajusta,idTipoCuenta = @idtipo,activo = @activo  
  where idCuenta = @idCuenta      
 return        
end;         
insert into cuentas (descripcion,recibeasientos,ajustable,idTipocuenta,activo) values (@descripcion,@recibe,@ajusta,@idtipo,@activo)        
return 


SELECT TOP 1000 [idEmployee]
      ,[fullName]
      ,[email]
      ,[mobile]
      ,[city]
      ,[gender]
      ,[department]
      ,[hireDate]
      ,[isPermanent]
  FROM [pruebas].[dbo].[Employee]
  
sp_helptext spAddEditBanco  

CREATE procedure spAddEditBanco (@idBanco int,@descripcion varchar(50),@cuit varchar(20)) as      
--yjs 260419  
if exists (select descripcion from bancos where idBanco = @idBanco)  
begin  
 update bancos set descripcion = @descripcion,numerocuit = @cuit where idBanco = @idBanco  
 return  
end;   
declare @nextcod as int  
select @nextcod= max(idbanco) from bancos  
set @nextcod = @nextcod + 1  
insert into bancos (idBanco,descripcion,numerocuit) values (@nextcod,@descripcion,@cuit)  


  sp_helptext spAddEditEmployee
  
  CREATE procedure spAddEditEmployee (@idEmp int,@fullname varchar(50),@email varchar(20),@mobile varchar(50),    
 @city varchar(50), @gender int,@department int ,@hiredate varchar(50),@ispermanent bit)  as          
--yjs 270519      
if exists (select fullname from employee where idEmployee = @idEmp)      
begin      
 update employee set fullname = @fullname,email = @email,mobile = @mobile,city = @city,gender = @gender,    
 department = @department,hiredate = @hiredate,ispermanent = @ispermanent     
 where idEmployee = @idEmp    
 return      
end;       
--declare @nextcod as int      
--select @nextcod= max(idbanco) from bancos      
--set @nextcod = @nextcod + 1      
insert into employee (fullname,email,mobile,city,gender,department,hiredate,ispermanent) values     
 (@fullname,@email,@mobile,@city,@gender,@department,@hiredate,@ispermanent)      
 
--YJS 290719 
 create table Ciudades (idCiudad int identity,
								descripcion varchar(50))

create table ClientesCrud (idCliente int identity,
								descripcion varchar(50),
								email varchar(50),
								mobile varchar(30),
								idCiudad int,
								fechaAlta datetime,
								activo bit
								)
								
-------- yjs 290719
								
CREATE procedure spAddEditCliente (@idCli int,@descri varchar(50),@email varchar(20),@mobile varchar(50),    
 @idCity int, @fechaAlta datetime,@activo bit)  as          
--yjs 270519      
if exists (select descripcion from ClientesCrud where idCliente = @idCli)      
begin      
 update ClientesCrud set descripcion = @descri,email = @email,mobile = @mobile,idCiudad = @idCity,
 fechaAlta = @fechaAlta,activo = @activo
 where idCliente = @idCli
 return      
end;       

insert into ClientesCrud (descripcion,email,mobile,idCiudad,fechaAlta,activo) values     
 (@descri,@email,@mobile,@idCity,@fechaAlta,@activo)      


---------

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ordersId]
      ,[orderNo]
      ,[idProveedor]
      ,[pMethod]
      ,[gTotal]
  FROM [pruebas].[dbo].[orders]
  
  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ordersDetailId]
      ,[ordersId]
      ,[itemId]
      ,[Quantity]
  FROM [pruebas].[dbo].[ordersDetail]
  
-------------------
--yjs 01082019

 create table bills (idBill int identity,
								billNo int,
								idCliente int,
								pMethod varchar(50),
								gTotal decimal (18,2))


 create table billsDetail (billDetailId int identity,
								billNo int,
								itemId int,
								Quantity int)


select b.descripcion nombreCliente,a.* from bills a inner join clientesCrud b on a.idCliente = b.idCliente


USE PRUEBAS

select * from clientescrud
select * from employee
	
select a.*,b.descripcion desCiudad,replace(convert(NVARCHAR, a.fechaAlta, 106), ' ', '/') fechaCorta from ClientesCrud a							
inner join ciudades b on a.idCiudad = b.idCiudad	
order by a.idcliente
							
select * from ciudades								
								
insert into ciudades (descripcion) values ('Córdoba')								
insert into ciudades (descripcion) values ('Santiago')								
								
SELECT replace(convert(NVARCHAR, getdate(), 106), ' ', '/')								
								use pruebas
								
update clientescrud set mobile = '999999999' where idcliente = 6								
								
spAddEditCliente 0,'Empresas Polar','polar@gmail.com','+58 0212 234234234',1,'2019-07-30 03:00:00.000',False								

select * from orders


select top 100 * from cccte order by fechaf desc

select top 100 * from facturas order by idfactura desc

select top 100 * from cccte_aclaraciones order by idcomprobante desc