USE [SIS_CONTROLE]
GO


declare @codSistema int 
set @codSistema = 1

declare @codUsuario int 
set @codUsuario = 1

declare @codPerfil int 
set @codPerfil = 1

--insert into Formulario values(1, 'Login', 'Tela Login', 'cd0001', getdate(), 'cd0001', getdate())
--set @codForm = @@IDENTITY
--insert into controle values(@codForm, 'ACESSO', 'Permite Acesso a tela', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into Formulario values(1, 'Profile','Tela Meu Perfil', 'cd0001', getdate(), 'cd0001', getdate())	
--set @codForm = @@IDENTITY
--insert into controle values(, 'ACESSO', 'Permite Acesso a tela', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into Formulario values(1, 'Settings','Tela Configurações', 'cd0001', getdate(), 'cd0001', getdate())
--set @codForm = @@IDENTITY
--insert into controle values(, 'ACESSO', 'Permite Acesso a tela', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into Formulario values(1, 'Registro','Tela Registro', 'cd0001', getdate(), 'cd0001', getdate())
--set @codForm = @@IDENTITY
--insert into controle values(, 'ACESSO', 'Permite Acesso a tela', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into Formulario values(1, 'Convencao','Tela de CCT', 'cd0001', getdate(), 'cd0001', getdate())
--set @codForm = @@IDENTITY
--insert into controle values(, 'ACESSO', 'Permite Acesso a tela', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'Pesquisar', 'Permite Pesquisar CCTs', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'Inserir', 'Permite Inserir a CCT', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'Detalhe', 'Permite ver Detalhe da CCT', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'Editar', 'Permite Editar a CCT', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'Excluir', 'Permite Excluir a CCT', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into Formulario values(1, 'HistConvencao','Tela de Histórico CCT', 'cd0001', getdate(), 'cd0001', getdate())
--set @codForm = @@IDENTITY
--insert into controle values(, 'ACESSO', 'Permite Acesso a tela', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into Formulario values(1, 'Roles','Tela Perfis de Acesso', 'cd0001', getdate(), 'cd0001', getdate())
--set @codForm = @@IDENTITY
--insert into controle values(, 'ACESSO', 'Permite Acesso a tela', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'LiberarAcessoPerfil', 'Permite LiberarAcesso por Perfil', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'BloquearAcessoPerfil', 'Permite BloquearAcesso por Perfil', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into Formulario values(1, 'Controls','Tela Controles de Acesso', 'cd0001', getdate(), 'cd0001', getdate())
--set @codForm = @@IDENTITY
--insert into controle values(, 'ACESSO', 'Permite Acesso a tela', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'Pesquisar', 'Permite Pesquisar por Controles', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'LiberarAcessoControle', 'Permite LiberarAcesso por Controle', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'BloquearAcessoControle', 'Permite BloquearAcesso por Controle', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into Formulario values(1, 'Permission','Tela Permissões de Acesso', 'cd0001', getdate(), 'cd0001', getdate())
--set @codForm = @@IDENTITY
--insert into controle values(, 'ACESSO', 'Permite Acesso a tela', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'Pesquisar', 'Permite Pesquisar por Permissões', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into Formulario values(1, 'ListUser','Tela Lista de Usuários', 'cd0001', getdate(), 'cd0001', getdate())
--set @codForm = @@IDENTITY
--insert into controle values(, 'ACESSO', 'Permite Acesso a tela', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'Pesquisar', 'Pesquisar um Usuário', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'BloqueiaUsuario', 'Permite Bloquear um Usuario', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'DesbloqueiaUsuario', 'Permite Desbloquear um Usuario', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into controle values(, 'ResetarSenha', 'Permite Resetar a Senha um Usuario', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

 
--insert into Formulario values(1, 'AlterarSenha','Tela Alterar de Senha', 'cd0001', getdate(), 'cd0001', getdate())
--set @codForm = @@IDENTITY
--insert into controle values(, 'ACESSO', 'Permite Acesso a tela', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--set @codControle = @@IDENTITY
--insert into Sistema_Perfil_Controle values(@codSistema,@codPerfil, , 1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(@codSistema,@codUsuario, ,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 