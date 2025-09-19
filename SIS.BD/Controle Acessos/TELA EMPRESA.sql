use [SIS_CONTROLE]
go

--select * from Formulario where codFormulario = 26
--select * from Controle where codFormulario = 26
--select * from Sistema_Perfil_Controle  where codCOntrole = 67
--select * from Sistema_Usuario_Controle where codCOntrole = 67


begin tran

	declare @codUsuario int 
	set @codUsuario = 1

	declare @codSistema int 
	set @codSistema = 1

	declare @codPerfil int 
	set @codPerfil = 1

	declare @codForm int
	declare @codControle int
 
	set @codForm = 26
	

	--insert into Formulario values(@codSistema, 'Empresa','Tela Empresas', 'cd0001', getdate(), 'cd0001', getdate())

	--set @codForm = @@IDENTITY

	--insert into controle values(@codForm, 'ACESSO', 'Permite Acesso a tela', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	--set @codControle = @@IDENTITY

	--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	
	
	--insert into controle values(@codForm, 'Pesquisar', 'Permite Pesquisar por Empresas', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	--set @codControle = @@IDENTITY

	--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


	
	--insert into controle values(@codForm, 'Detalhe', 'Permite ver Detalhe da Empresas', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	--set @codControle = @@IDENTITY

	--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 




	--insert into controle values(@codForm, 'Editar', 'Permite Editar dados Empresas', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	--set @codControle = @@IDENTITY

	--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 




	--insert into controle values(@codForm, 'Excluir', 'Permite Excluir a Empresa', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	--set @codControle = @@IDENTITY

	--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 



	--insert into controle values(@codForm, 'Novo', 'Permite Incluir uma Empresa', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	--set @codControle = @@IDENTITY

	--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
	

	
	insert into controle values(@codForm, 'NovoContato', 'Permite Incluir um novo contato', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	set @codControle = @@IDENTITY

	insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
	

	insert into controle values(@codForm, 'EditarContato', 'Permite Editar um contato', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	set @codControle = @@IDENTITY

	insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
	

	insert into controle values(@codForm, 'ExcluirContato', 'Permite Excluir um Contato', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	set @codControle = @@IDENTITY

	insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
	

	
	
	insert into controle values(@codForm, 'NovoEndereco', 'Permite Incluir um novo endereço', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	set @codControle = @@IDENTITY

	insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
	

	insert into controle values(@codForm, 'EditarEndereco', 'Permite Editar um endereço', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	set @codControle = @@IDENTITY

	insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
	

	insert into controle values(@codForm, 'ExcluirEndereco', 'Permite Excluir um endereço', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	set @codControle = @@IDENTITY

	insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
	

	
	 
	
	
	insert into controle values(@codForm, 'NovoFuncionario', 'Permite Incluir um novo funcionário', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	set @codControle = @@IDENTITY

	insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
	

	insert into controle values(@codForm, 'EditarFuncionario', 'Permite Editar um funcionário', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	set @codControle = @@IDENTITY

	insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
	

	insert into controle values(@codForm, 'ExcluirFuncionario', 'Permite Excluir um funcionário', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	set @codControle = @@IDENTITY

	insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
	


	
	
	insert into controle values(@codForm, 'NovoSocio', 'Permite Incluir um novo sócio', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	set @codControle = @@IDENTITY

	insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
	

	insert into controle values(@codForm, 'EditarSocio', 'Permite Editar um sócio', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	set @codControle = @@IDENTITY

	insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
	

	insert into controle values(@codForm, 'ExcluirSocio', 'Permite Excluir um sócio', 'cd0001', getdate(), 'cd0001', getdate(),1 )

	set @codControle = @@IDENTITY

	insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, @codControle, 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

	insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, @codControle,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
	

	
	 
	

--COMMIT
--ROLLBACK