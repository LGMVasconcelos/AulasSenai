create database senai;
use senai;

create table alunos (
	id int auto_increment primary key,
    nome varchar(100) not null,
    email varchar(100) not null
);
delete from alunos where id = 2;
select * from alunos;