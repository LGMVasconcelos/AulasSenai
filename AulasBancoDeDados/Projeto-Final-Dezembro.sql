
DROP DATABASE IF EXISTS agencia_luiz;
CREATE DATABASE agencia_luiz;
USE agencia_luiz;

CREATE TABLE departamentos (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL,
    sigla VARCHAR(10)
);

CREATE TABLE funcionarios (
    id INT PRIMARY KEY AUTO_INCREMENT,
    depto_id INT,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    cpf VARCHAR(14),              
    telefone VARCHAR(20),
    salario DECIMAL(10,2),
    cargo VARCHAR(50),
    data_admissao DATE,
    FOREIGN KEY (depto_id) REFERENCES departamentos(id)
);

CREATE TABLE projetos (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    orcamento DECIMAL(10,2),
    data_inicio DATE
);

CREATE TABLE alocacao (
    id INT PRIMARY KEY AUTO_INCREMENT,
    funcionario_id INT,
    projeto_id INT,
    horas_semanais INT,
    FOREIGN KEY (funcionario_id) REFERENCES funcionarios(id),
    FOREIGN KEY (projeto_id) REFERENCES projetos(id)
);

INSERT INTO departamentos (nome, sigla) VALUES
('Tecnologia da Informação', 'TI'),
('Recursos Humanos', 'RH'),
('Financeiro', 'FIN'),
('Marketing', 'MKT'),
('Vendas', 'VND');

INSERT INTO funcionarios (depto_id, nome, email, cpf, telefone, salario, cargo, data_admissao) VALUES
(1, 'Ana Silva', 'ana@empresa.com', '123.456.789-01', '(11) 99999-8888', 8500.00, 'Gerente de TI', '2020-03-10'),
(1, 'Bruno Santos', 'bruno@empresa.com', '987.654.321-09', '(11) 98888-7777', 6500.00, 'Desenvolvedor', '2021-07-15'),
(2, 'Carla Pereira', 'carla@empresa.com', '456.789.123-45', '(11) 97777-6666', 5500.00, 'Analista RH', '2019-01-20'),
(3, 'Diego Costa', 'diego@empresa.com', '789.123.456-78', '(11) 96666-5555', 7200.00, 'Analista Financeiro', '2020-11-05'),
(4, 'Elena Rodrigues', 'elena@empresa.com', '321.654.987-32', '(11) 95555-4444', 4800.00, 'Marketing', '2022-06-18'),
(5, 'Fernando Gomes', 'fernando@empresa.com', '654.987.321-65', '(11) 94444-3333', 6800.00, 'Vendedor', '2021-09-22'),
(1, 'Gabriela Martins', 'gabriela@empresa.com', '987.321.654-98', '(11) 93333-2222', 5300.00, 'Analista de Sistemas', '2020-08-14');

INSERT INTO projetos (nome, orcamento, data_inicio) VALUES
('Sistema de Gestão', 120000.00, '2024-01-15'),
('Site Nova Empresa', 80000.00, '2024-02-01'),
('App Mobile', 150000.00, '2024-03-10');

INSERT INTO alocacao (funcionario_id, projeto_id, horas_semanais) VALUES
(1, 1, 20),
(2, 1, 30),
(2, 3, 10),
(5, 2, 25),
(7, 3, 15);

SELECT 'Base de dados criada com sucesso!' as mensagem;
SELECT ' ATENÇÃO: CPFs estão VISÍVEIS no banco!' as alerta;
SELECT 'Total de funcionários: ' as info, COUNT(*) as quantidade FROM funcionarios;

SELECT * FROM funcionarios;

SELECT f.nome, f.cargo, d.nome as departamento
FROM funcionarios f
JOIN departamentos d ON f.depto_id = d.id;

SELECT d.nome, COUNT(f.id) as total_funcionarios
FROM departamentos d
LEFT JOIN funcionarios f ON d.id = f.depto_id
GROUP BY d.nome
ORDER BY total_funcionarios DESC;

SELECT d.nome, 
       ROUND(AVG(f.salario), 2) as salario_medio,
       COUNT(f.id) as qtde_funcionarios
FROM departamentos d
JOIN funcionarios f ON d.id = f.depto_id
GROUP BY d.nome
ORDER BY salario_medio DESC;

SELECT nome, cargo, salario
FROM funcionarios
ORDER BY salario DESC
LIMIT 5;

SELECT p.nome as projeto,
       f.nome as funcionario,
       a.horas_semanais,
       f.cargo
FROM projetos p
JOIN alocacao a ON p.id = a.projeto_id
JOIN funcionarios f ON a.funcionario_id = f.id
ORDER BY p.nome;

SELECT nome, cpf, email, telefone
FROM funcionarios
WHERE cpf IS NOT NULL;

SELECT 
    nome,
    CONCAT('CPF: ', cpf) as dado_sensivel,
    CONCAT('Salário: R$ ', FORMAT(salario, 2)) as info_financeira,
    telefone
FROM funcionarios;

SELECT 
    f.nome as Funcionario,
    f.cpf as CPF,
    f.email as Email,
    f.telefone as Telefone,
    f.salario as Salario,
    d.nome as Departamento,
    GROUP_CONCAT(p.nome) as Projetos
FROM funcionarios f
JOIN departamentos d ON f.depto_id = d.id
LEFT JOIN alocacao a ON f.id = a.funcionario_id
LEFT JOIN projetos p ON a.projeto_id = p.id
GROUP BY f.id;

CREATE USER 'gerente_ti'@'localhost';
SET PASSWORD FOR 'gerente_ti'@'localhost' = PASSWORD('Ger3nt3@2024!');
GRANT ALL PRIVILEGES ON empresa_teste.* TO 'gerente_ti'@'localhost';

CREATE USER 'analista_rh'@'localhost';
SET PASSWORD FOR 'analista_rh'@'localhost' = PASSWORD('Anal1st@2024!');
GRANT SELECT ON empresa_teste.* TO 'analista_rh'@'localhost';

CREATE USER 'estagiario'@'localhost';
SET PASSWORD FOR 'estagiario'@'localhost' = PASSWORD('Est4gi@2024!');
GRANT SELECT (id, nome, cargo) ON empresa_teste.funcionarios TO 'estagiario'@'localhost';

SELECT User, Host FROM mysql.user WHERE User LIKE '%empresa%' OR User IN ('gerente_ti', 'analista_rh', 'estagiario');

SHOW GRANTS FOR 'analista_rh'@'localhost';

SELECT * FROM funcionarios;
SELECT nome, cargo FROM funcionarios;

SELECT * FROM funcionarios;
UPDATE funcionarios SET salario = 10000;

SET @chave_secreta = 'MinhaChave#2024Segura!';

ALTER TABLE funcionarios 
ADD COLUMN cpf_criptografado VARBINARY(255) AFTER cpf;

UPDATE funcionarios 
SET cpf_criptografado = AES_ENCRYPT(cpf, @chave_secreta)
WHERE cpf IS NOT NULL;

SELECT 
    nome,
    cpf as "CPF VISÍVEL (PERIGO!)",
    cpf_criptografado as "CPF CRIPTOGRAFADO (SEGURO)"
FROM funcionarios;

SELECT 
	nome,
	CAST(AES_DECRYPT(cpf_criptografado, @chave_secreta) AS CHAR) as Cpf_descriptografado
FROM funcionarios;

CREATE VIEW funcionarios_publico AS
	SELECT
	id, 
	nome,
	CONCAT(
		LEFT(email, 1),
        '***',
		SUBSTRING(email, LOCATE('@', email))
	) as email_mascarado,

	CONCAT(
		'(', 
		SUBSTRING(telefone, 2, 2),
		') 9****-****'
	) as telefone_mascarado,
	cargo,
	CASE 
		WHEN salario < 5000 THEN 'Até R$5.000'
		WHEN salario BETWEEN 5000 AND 8000 THEN 'R$5.000 - R$8.000'
		ELSE 'Acima de R$8.000'
	END AS faixa_salarial
FROM funcionarios;

SELECT * FROM funcionarios_publico;
GRANT SELECT ON agencia_luiz.funcionarios_publico TO 'estagiario'@'localhost';

CREATE VIEW funcionarios_rh AS
SELECT
	f.id,
	f.nome,
	f.cpf,
	f.email,
	f.telefone,
	f.cargo,
	f.salario,
	d.nome as departamento
FROM funcionarios f
JOIN departamentos d ON f.depto_id = d.id;

CREATE TABLE auditoria_funcionarios (
id INT PRIMARY KEY AUTO_INCREMENT,
data_hora TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
usuario VARCHAR(100), 
funcionario_id INT, 
acao VARCHAR(10), 
dados_antigos TEXT, 
dados_novos TEXT,
foreign key (funcionario_id) references funcionarios(id) on delete cascade
)

DELIMITER $$
	CREATE TRIGGER audita_funcionario_update
	AFTER UPDATE ON funcionarios
	FOR EACH ROW
	BEGIN
	INSERT INTO auditoria_funcionarios
	(usuario, funcionario_id, acao, dados_antigos, dados_novos)
	VALUES (
		CURRENT_USER(),
		OLD.id,
		'UPDATE',
		CONCAT('Antigo salário:', OLD.salario, '| Cargo:', OLD.cargo),
		CONCAT('Novo salário:', NEW.salario, '| Cargo:', NEW.cargo)
	);
END$$
DELIMITER ;

UPDATE funcionarios
	SET salario = salario * 1.1
	WHERE id = 2;
    
SELECT * FROM auditoria_funcionarios;

DELIMITER $$
CREATE TRIGGER audita_funcionario_delete
AFTER DELETE ON funcionarios
FOR EACH ROW
BEGIN
	INSERT INTO auditoria_funcionarios
	(usuario, funcionario_id, acao, dados_antigos)
	VALUES (
		CURRENT_USER(),
		OLD.id,
		'DELETE',
		CONCAT('Excluiu: ', OLD.nome, '- CPF:' , OLD.cpf)
    );
END$$
DELIMITER ;

CREATE TABLE backup_cpfs AS
SELECT id, nome, cpf FROM funcionarios;
UPDATE funcionarios SET cpf = NULL;
SELECT nome, cpf, cpf_criptografado FROM funcionarios;

sql
DELIMITER $$
CREATE TRIGGER valida_funcionario_insert
BEFORE INSERT ON funcionarios
FOR EACH ROW 
BEGIN
	IF NEW.email NOT LIKE '%@%.%' THEN 
    SIGNAL SQLSTATE '45000' 
    SET MESSAGE_TEXT = 'Email inválido!';
    END IF;
    
	IF NEW.salario < 1518.00 THEN 
	SIGNAL SQLSTATE '45000'
	SET MESSAGE_TEXT = 'Salário abaixo do mínimo!';
	END IF;

	IF NEW.telefone IS NOT NULL THEN
		SET NEW.telefone = REPLACE(REPLACE(REPLACE(REPLACE(NEW.telefone, '(', ''), ')', ''), '-', ''), ' ', '');
	END IF;
END$$
DELIMITER ;

INSERT INTO funcionarios (nome, email, salario) VALUES ('Teste', 'emailinvalido', 1500.00);
INSERT INTO funcionarios (nome, email, salario) VALUES ('Teste', 'teste@email.com', 1000.00);
INSERT INTO funcionarios (nome, email, salario, telefone) VALUES ('Teste', 'teste@email.com', 2000.00, '(11) 99999-8888');

SELECT
'Funcionários' as categoria,
COUNT(*) as total
FROM funcionarios
UNION ALL
SELECT
'CPFs Criptografados',
COUNT(*)
FROM funcionarios
WHERE cpf_criptografado IS NOT NULL
UNION ALL
SELECT
	'Eventos de Auditoria',
	COUNT(*)
FROM auditoria_funcionarios
UNION ALL
SELECT
	'Views de Segurança',
	COUNT(*)
FROM information_schema.views
WHERE table_schema = 'agencia_luiz';

SELECT
	DATE(data_hora) as data,
	HOUR(data_hora) as hora,
	usuario,
	acao,
	COUNT(*) as quantidade
FROM auditoria_funcionarios
WHERE data_hora >= NOW() - INTERVAL 1 DAY
GROUP BY DATE(data_hora), HOUR(data_hora), usuario, acao
ORDER BY data DESC, hora DESC;

SELECT
	'CPFs ainda visíveis' as problema,
	COUNT(*) as quantidade
FROM funcionarios
WHERE cpf IS NOT NULL
UNION ALL
SELECT
	'Funcionários sem email',
	COUNT(*)
FROM funcionarios
WHERE email IS NULL OR email = ''
UNION ALL
SELECT
	'Salários abaixo do mercado',
	COUNT(*)
FROM funcionarios
WHERE salario < 2000;

CREATE TABLE backup_criptografia AS
SELECT
	id,
	nome,
	cpf_criptografado,
	SHA2(@chave_secreta, 256) as hash_chave,
	NOW() as data_backup
FROM funcionarios
WHERE cpf_criptografado IS NOT NULL;

SELECT * FROM backup_criptografia;

DROP USER IF EXISTS 'gerente_ti'@'localhost';
DROP USER IF EXISTS 'analista_rh'@'localhost';
DROP USER IF EXISTS 'estagiario'@'localhost';

DROP TRIGGER IF EXISTS audita_funcionario_update;
DROP TRIGGER IF EXISTS audita_funcionario_delete;
DROP TRIGGER IF EXISTS valida_funcionario_insert;

DROP VIEW IF EXISTS funcionarios_publico;
DROP VIEW IF EXISTS funcionarios_rh;

DROP DATABASE IF EXISTS agencia_luiz;
CREATE DATABASE agencia_luiz;
