select version();

create user 'aluno_luiz'@'localhost';
set password for 'aluno_luiz'@'localhost' = password('luiz123');
alter user 'aluno_luiz'@'localhost' password expire interval 90 day;
select user, Host from mysql.user where user like '%luiz%';
create user 'usuario_ext'@'192.168.1.%';
set password for 'usuario_ext'@'192.168.1.%' = password('usuario123');
alter user 'usuario_ext'@'192.168.1.%' password expire never;
select user, Host from mysql.user where user like '%usuario%';
select user, host, password_expired as 'Senha Expirada?' from mysql.user
where user not like 'mysql%' and user != 'root';

-- Criando um usuário com permissões específicas (de leitura)
create user 'usuario_leitor'@'localhost';
set password for 'usuario_leitor'@'localhost' = password('leitor123');
create database if not exists empresa_dados;
show databases;
grant select on empresa_dados.* to 'usuario_leitor'@'localhost';
flush privileges;
show grants for 'usuario_leitor'@'localhost';

-- Criptografando informações

create database loja_virtual;
use loja_virtual;

create table clientes (
	id int primary key auto_increment,
    nome_completo varchar(100) not null,
    cpf_visivel varchar(14),
    cpf_criptografado varbinary(255),
    email varchar(100),
    telefone varchar(20),
    data_cadastro timestamp default current_timestamp
);

create index idx_cliente_nome on clientes(nome_completo);

describe clientes;

set @minha_chave_secreta = 'SenhaUltraForte!123@;.,';

insert into clientes
(nome_completo, cpf_criptografado, email, telefone)
values ('Enrico Padovan', aes_encrypt('123.456.789-00', @minha_chave_secreta),
'halloichbinenrico@gmail.com', '+55 (44) 91234-5678'),
('Luiz Gustavo', aes_encrypt('104.271.769-99', @minha_chave_secreta),
'luizgustavomoraisvasconcelos@gmail.com', '+55 (44) 98827-4435');

select id, nome_completo, cpf_criptografado, email from clientes;

select hex(cpf_criptografado) from clientes;

-- Descriptografar
set @minha_chave_secreta = 'SenhaUltraForte!123@;.,';

select id, nome_completo,
cast(aes_decrypt(cpf_criptografado, @minha_chave_secreta)
as char) as cpf_descriptografado, email, telefone from clientes;