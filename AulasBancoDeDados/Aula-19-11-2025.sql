drop database if exists escola;
create database escola;
use escola;
show databases;

create table alunos (
	id int auto_increment primary key,
    nome varchar(100) not null,
    email varchar(100) not null,
    data_nascimento date,
    turma_id int
);

create table professores (
	id int auto_increment primary key,
    nome varchar(100) not null,
    especialidade varchar(100)
);

create table turmas (
	id int auto_increment primary key,
    nome varchar(50) not null,
    professor_id int,
    horario time,
    foreign key (professor_id) references professores(id)
);

create table disciplinas (
	id int auto_increment primary key,
    nome varchar(100) not null,
    carga_horaria int
);

create table notas (
	id int auto_increment primary key,
    aluno_id int,
    disciplina_id int,
	nota decimal (2, 1),
    bimestre int,
    foreign key (aluno_id) references alunos(id),
    foreign key (disciplina_id) references disciplinas(id)
);

alter table alunos 
add foreign key (turma_id) references turmas(id);

insert into professores (nome, especialidade)
values
('Carlos Silva', 'Matemática'),
('Ana Santos', 'Português'),
('Marcos Lima', 'História'),
('Julia Costa', 'Ciências'),
('Roberto Alves', 'Geografia');

insert into turmas (nome, professor_id, horario)
values
('1º Ano A', 1, '08:00:00'),
('1º Ano B', 2, '10:00:00'),
('2º Ano A', 3, '08:00:00'),
('2º Ano B', 4, '13:00:00'),
('3º Ano A', 5, '14:00:00');

INSERT INTO alunos (nome, email, data_nascimento, turma_id) VALUES
('Luiz', 'luizgustavomoraisvasconcelos@gmail.com', '2008-12-08', 1),
('Djeffer', 'djefferbervianprange123@gmail.com', '2008-02-20', 1),
('Enrico', 'halloichbinenrico@gmail.com', '2008-06-24', 1),
('Lucas Urgnani', 'bombeiro@gmail.com', '2007-05-18', 1),
('Gabriel Bertaglia', 'emosigma@gmail.com', '2007-06-16', 1),
('Letícia', 'veia@gmail.com', '2007-07-20', 1),
('Lucas Belini', 'voltapramim@gmail.com', '2008-09-20', 1),
('Daniel', 'programadorruim@gmail.com', '1996-06-19', 2);

INSERT INTO disciplinas (nome, carga_horaria) VALUES
('Sociologia', 200),
('História', 200),
('Geografia', 200),
('Português', 200),
('Matemática', 200),
('Química', 200),
('Física', 200),
('Arte', 200),
('Biologia', 200),
('Língua Inglesa', 200);

INSERT INTO notas (aluno_id, disciplina_id, nota, bimestre) VALUES
-- Aluno 1 (Luiz)
(1, 1, 7.5, 1),
(1, 2, 8.0, 1),
(1, 3, 6.5, 1),
(1, 4, 9.0, 1),
(1, 5, 7.0, 2),
(1, 6, 8.5, 2),
(1, 7, 5.0, 2),
(1, 8, 9.5, 2),
(1, 9, 7.8, 3),
(1, 10, 8.2, 3),
-- Aluno 2 (Djeffer)
(2, 1, 6.0, 1),
(2, 2, 7.0, 1),
(2, 3, 5.5, 2),
(2, 4, 8.5, 2),
(2, 5, 9.0, 3),
(2, 6, 6.8, 3),
(2, 7, 7.2, 4),
(2, 8, 8.8, 4),
(2, 9, 6.5, 4),
(2, 10, 7.5, 4),
-- Aluno 3 (Enrico)
(3, 1, 9.0, 1),
(3, 2, 9.5, 2),
(3, 3, 8.5, 3),
(3, 4, 8.0, 4),
(3, 5, 7.5, 1),
(3, 6, 9.2, 2),
(3, 7, 6.0, 3),
(3, 8, 7.0, 4),
(3, 9, 8.3, 1),
(3, 10, 8.8, 2),
-- Aluno 4 (Lucas Urgnani)
(4, 1, 5.0, 2),
(4, 2, 6.0, 3),
(4, 3, 7.0, 4),
(4, 4, 7.5, 1),
(4, 5, 8.0, 2),
(4, 6, 5.5, 3),
(4, 7, 6.5, 4),
(4, 8, 9.0, 1),
(4, 9, 7.3, 2),
(4, 10, 6.8, 3),
-- Aluno 5 (Gabriel Bertaglia)
(5, 1, 8.0, 3),
(5, 2, 7.5, 4),
(5, 3, 9.0, 1),
(5, 4, 6.5, 2),
(5, 5, 7.0, 3),
(5, 6, 8.2, 4),
(5, 7, 5.8, 1),
(5, 8, 8.5, 2),
(5, 9, 7.7, 3),
(5, 10, 6.2, 4),
-- Aluno 6 (Letícia)
(6, 1, 9.5, 4),
(6, 2, 8.8, 1),
(6, 3, 7.5, 2),
(6, 4, 9.2, 3),
(6, 5, 8.7, 4),
(6, 6, 7.0, 1),
(6, 7, 6.5, 2),
(6, 8, 9.0, 3),
(6, 9, 8.0, 4),
(6, 10, 7.5, 1),
-- Aluno 7 (Lucas Belini)
(7, 1, 7.0, 1),
(7, 2, 6.5, 2),
(7, 3, 8.0, 3),
(7, 4, 5.5, 4),
(7, 5, 9.0, 1),
(7, 6, 7.8, 2),
(7, 7, 6.2, 3),
(7, 8, 8.5, 4),
(7, 9, 7.5, 1),
(7, 10, 6.0, 2),
-- Aluno 8 (Daniel)
(8, 1, 6.8, 2),
(8, 2, 7.2, 3),
(8, 3, 5.0, 4),
(8, 4, 8.0, 1),
(8, 5, 6.5, 2),
(8, 6, 9.0, 3);


-- Exercício 1: Listar todos os alunos da turma 1º Ano A
SELECT * FROM alunos WHERE turma_id = 1;

-- Exercício 2: Listar todos os alunos em ordem alfabética
SELECT * FROM alunos ORDER BY nome ASC;

-- Exercício 3: Listar alunos nascidos após o ano de 2008 (coluna nome e data_nascimento)
SELECT * FROM alunos WHERE data_nascimento > '2008-01-01';

-- Exercício 4: Listar quantos alunos tem em cada turma (count)
SELECT turma_id, COUNT(turma_id) AS alunos_por_turma FROM alunos GROUP BY turma_id ORDER BY turma_id;

-- Exercício 5: Mostrar média de notas por disciplina
SELECT disciplina_id, AVG(nota) AS media_notas_por_disciplina FROM notas GROUP BY disciplina_id ORDER BY disciplina_id;

-- Exercício 6: INNER JOIN básico: alunos com suas turmas e professores
SELECT alunos.nome as nome_alunos, professores.nome as nome_professores, turmas.nome as nome_turmas
FROM turmas 
INNER JOIN alunos ON alunos.id = turmas.id
INNER JOIN professores ON professores.id = turmas.professor_id;

-- Exercício 7 (também responde o exercício 10: "Query para mostrar Aprovado se a nota for maior que 7.0 ou reprovado se a nota for menor") JOIN com múltiplas tabelas: notas dos alunos com detalhes
SELECT alunos.nome AS nome_aluno, notas.nota,
CASE
	WHEN notas.nota < 7 THEN 'Reprovado.'
    WHEN notas.nota >= 7 THEN 'Aprovado.'
    ELSE 'Aprovado com honras.'
END AS status_nota
FROM notas
JOIN alunos ON alunos.id = notas.aluno_id;

-- Exercício 8: PROCEDURES: para calcular a média do aluno

DELIMITER //

CREATE PROCEDURE CalcularMediaAluno (
    IN p_aluno_id INT,
    OUT p_media_final DECIMAL(5, 2)
)
BEGIN
    DECLARE temp_media DECIMAL(5, 2);

    SELECT AVG(nota)
    INTO temp_media
    FROM notas
    WHERE aluno_id = p_aluno_id;

    IF temp_media IS NULL THEN
        SET p_media_final = 0.00;
    ELSE
        SET p_media_final = temp_media;
    END IF;
END //
DELIMITER ;

-- Exercício 9: PROCEDURES: Para listar alunos por turma
DELIMITER //
CREATE PROCEDURE listar_alunos_por_turma(IN turma_id_param INT)
BEGIN
    SELECT
        alunos.id AS aluno_id,
        alunos.nome AS nome_aluno,
        alunos.email,
        alunos.data_nascimento,
        turmas.nome AS nome_turma
    FROM
        alunos a
    JOIN
        turmas ON alunos.turma_id = turmas.id
    WHERE
        alunos.turma_id = turma_id_param;
END //
DELIMITER ;

-- Exercício 11: Rankear melhores alunos
SELECT alunos.nome AS nome_aluno, notas.nota
 FROM notas JOIN alunos on alunos.id = aluno_id ORDER BY notas.nota DESC;
