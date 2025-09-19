use [SIS_CONTROLE]
go

select * from Formulario where CodFormulario = 23
select * from Controle where CodFormulario = 23
select * from Sistema_Perfil_Controle where CodControle in(select CodControle from Controle where CodFormulario = 23)
select * from Sistema_Usuario_Controle where CodControle in(select CodControle from Controle where CodFormulario = 23)



begin tran

	declare @codUsuario int 
	set @codUsuario = 1

	declare @codSistema int 
	set @codSistema = 1

	declare @codPerfil int 
	set @codPerfil = 1

	declare @codForm int
	declare @codControle int
 

	insert into Formulario values(@codSistema, 'AlterarSenha','Tela Alterar de Senha', 'cd0001', getdate(), 'cd0001', getdate())

	set @codForm = @@IDENTITY

	insert into controle values(@codForm, 'ACESSO', 'Permite Acesso a tela', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	set @codControle = @@IDENTITY

	insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
	


--COMMIT
--ROLLBACK