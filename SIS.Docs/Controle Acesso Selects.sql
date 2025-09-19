use sis_controle
go

select * from Departamento

select * from Usuario
select * from Usuario_Sistema

select * from Perfil

select * from Formulario
--insert into Formulario values(1, 'Permission', 'Permissoes por usuario acesso', 'cd0001', getdate(), 'cd0001', getdate())

select * from Controle  where CodFormulario = 7 
--insert into controle values(7, 'ACESSO', 'ACESSO', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--insert into controle values(6, 'LiberarAcessoControle', 'LiberarAcesso por Controle', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--insert into controle values(6, 'BloquearAcessoControle', 'BloquearAcesso por Controle', 'cd0001', getdate(), 'cd0001', getdate(),1 )
--insert into controle values(7, 'Pesquisar', 'Pesquisar por Permissoes', 'cd0001', getdate(), 'cd0001', getdate(),1 )


select * from Sistema_Perfil_Controle where CodPerfil = 1
--insert into Sistema_Perfil_Controle values(1,1,31,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Perfil_Controle values(1,1,25,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Perfil_Controle values(1,1,26,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

select * from Sistema_Usuario_Controle where CodUsuario = 2
--insert into Sistema_Usuario_Controle values(1,1,31,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(1,1,25,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(1,1,26,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 

--insert into Sistema_Usuario_Controle values(1,2,31,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(1,2,25,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(1,2,26,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 


--insert into Sistema_Usuario_Controle values(1,16,31,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 
--insert into Sistema_Usuario_Controle values(1,17,31,1,getdate(), 'cd0001',getdate(), 'cd0001',getdate()) 