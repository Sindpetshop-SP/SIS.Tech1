use [SIS_CONTROLE]
go

select * from Formulario
select * from Controle
select * from Sistema_Perfil_Controle
select * from Sistema_Usuario_Controle


begin tran

	declare @codUsuario int 
	set @codUsuario = 2

	declare @codSistema int 
	set @codSistema = 1

	declare @codPerfil int 
	set @codPerfil = 1

	declare @codForm int
	declare @codControle int
 

	insert into Formulario values(1, 'Login', 'Tela Login', 'cd0001', getdate(), 'cd0001', getdate())

	set @codForm = @@IDENTITY

	insert into controle values(@codForm, 'ACESSO', 'Permite Acesso a tela', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	set @codControle = @@IDENTITY

	insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

--COMMIT
--ROLLBACK