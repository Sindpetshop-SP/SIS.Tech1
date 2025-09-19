use SIS_TECH
go


select * from Contato
--insert into contato values(1, '11', '93208-6050', 'email1@empresa.com.br')
--insert into contato values(2, '11', '93208-6030', 'email2@empresa.com.br')

select * from Empresa

update Empresa set Sindicalizada = 1, Ativo =1

select * from EmpresaContato
--insert into EmpresaContato values(2, 3, 'cd0001', getdate())
--insert into EmpresaContato values(2, 4, 'cd0001', getdate())



select * from Endereco
--insert into Endereco values(1, '05367-120', 'Rua Carlos Chambelland', 59, 'casa', 'Butanta', 'São Paulo', 'SP')
--insert into Endereco values(2, '05367-120', 'Rua Clelia', 550, 'Sala 92', 'Lapa', 'São Paulo', 'SP')

select * from Empresa
select * from EmpresaEndereco

--insert into EmpresaEndereco values(2, 1, 'cd0001', getdate())
--insert into EmpresaEndereco values(2, 2, 'cd0001', getdate())


--select * from Cnae where NumeroCnae = '8230001'
--select * from Empresa
--select * from EmpresaCnae

--insert into EmpresaCnae values(2, 677, 1, 0, 'cd0001', GETDATE())
--insert into EmpresaCnae values(2, 537, 1, 0, 'cd0001', GETDATE())
--insert into EmpresaCnae values(2, 557, 1, 0, 'cd0001', GETDATE())
--insert into EmpresaCnae values(2, 566, 1, 0, 'cd0001', GETDATE())


select * from Convencao
select * from Empresa
select * from EmpresaCnae