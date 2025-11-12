CREATE DATABASE Teste;
SHOW DATABASES;

USE Teste;

CREATE TABLE alunos (
	id int auto_increment primary key,
	nome varchar(100) not null,
    idade int,
    disciplina varchar(50)
);

SHOW TABLES;

INSERT INTO alunos (nome, idade, disciplina)
VALUES
('João Carlos', 17, 'Banco de Dados'),
('Maria Rita', 23, 'Lógica de Programação'),
('Renato da Silva', 28, 'Banco de Dados'),
('Fernanda Ramos', 21, 'Programação de Aplicativos'),
('Evelyn Duarte', 32, 'Lógica de Programação'),
('Mariana Alves', 18, 'Modelagem de Sistemas'),
('Carlos Lima', 17, 'Desenvolvimento Web'),
('Ana Souza', 16, 'Banco de Dados'),
('Marcelo Vieira', 25, 'Programação de Aplicativos'),
('André Gregório', 17, 'Modelagem de Sistemas');

-- Exercício 1
SELECT * FROM alunos;

-- Exercício 2
SELECT nome, idade FROM alunos;

-- Exercício 3
SELECT * FROM alunos WHERE disciplina = 'Modelagem de Sistemas';

-- Exercício 4
SELECT * FROM alunos WHERE idade > 19;

-- Exercício 5
SELECT * FROM alunos ORDER BY nome ASC;

-- Exercício 6
SELECT * FROM alunos ORDER BY idade ASC;

-- Exercício 7
SELECT * FROM alunos WHERE disciplina = 'Banco de Dados' OR disciplina = 'Programação de Aplicativos';

-- Exercício 8
SELECT COUNT(*) AS total_alunos FROM alunos;

-- Exercício 9
SELECT AVG(idade) FROM alunos AS media_idade;

-- Exercício 10
SELECT disciplina, COUNT(id) AS total_por_disciplina FROM alunos GROUP BY disciplina ORDER BY disciplina;

-- Exercício 11
UPDATE alunos SET idade = 19  WHERE id = 8;

-- Exercício 12
UPDATE alunos SET disciplina = 'Programação Mobile' WHERE disciplina = 'Programação de Aplicativos';

-- Exercício 13
DELETE FROM alunos WHERE id = 10;

-- Exercício 14
ALTER TABLE alunos ADD COLUMN email VARCHAR(150);

-- Exercício 15
ALTER TABLE alunos MODIFY COLUMN disciplina VARCHAR(150);

-- Exercício 16
ALTER TABLE alunos DROP COLUMN email;

-- Exercício 17
SELECT * FROM alunos WHERE nome LIKE 'A%';

-- Exercício 18
SELECT * FROM alunos WHERE nome LIKE '%a';

-- Exercício 19
SELECT * FROM alunos WHERE nome LIKE '%e%';

-- Exercício 20
SELECT disciplina, AVG(idade) AS media_idade_por_disciplina
FROM alunos
GROUP BY disciplina
HAVING AVG(idade) > 19;

-- Exercício 21
SELECT nome, idade
FROM alunos
WHERE idade = (SELECT MAX(idade) FROM alunos);

-- Exercício 22
CREATE TABLE alunos_db AS SELECT * FROM ALUNOS WHERE disciplina = 'Banco de Dados';
