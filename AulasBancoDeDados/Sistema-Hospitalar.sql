create database if not exists hospital;
use hospital;

create table endereco (
id_endereco int auto_increment primary key,
	rua varchar(120),
	numero varchar(10),
	bairro varchar(80),
	cidade varchar(80),
	estado varchar(2)
);

create table paciente (
	id_paciente int auto_increment primary key,
	cpf varchar(14) unique,
	nome varchar(100),
	data_nascimento date,
	telefone varchar(20),
	id_endereco int,
    foreign key (id_endereco) references endereco(id_endereco)
);

create table medico (
	id_medico int auto_increment primary key,
	crm varchar(20) unique,
	nome varchar(100),
	telefone varchar(20)
);

create table especialidade (
	id_especialidade int auto_increment primary key,
	nome varchar(80)
);

create table medico_especialidade (
	id_medico int,
	id_especialidade int,
	primary key (id_medico, id_especialidade),
    foreign key (id_especialidade) references especialidade(id_especialidade),
    foreign key (id_medico) references medico(id_medico)
);

create table consulta (
	id_consulta int auto_increment primary key,
	id_medico int,
    id_paciente int,
    data_hora datetime,
    descricao text,
    foreign key (id_paciente) references paciente(id_paciente),
    foreign key (id_medico) references medico(id_medico)
);

create table leito (
	id_leito int auto_increment primary key,
	codigo varchar(20) unique,
	tipo varchar(50)
);

create table internacao (
	id_internacao int auto_increment primary key,
	id_paciente int,
	id_leito int,
    data_internacao date,
    data_alta date,
    motivo text,
    foreign key (id_paciente) references paciente(id_paciente),
    foreign key (id_leito) references leito(id_leito)
);

create table medicamento (
	id_medicamento int auto_increment primary key,
    nome varchar(80),
    principio_ativo varchar(120)
);

create table prescricao (
	id_prescricao int auto_increment primary key,
    id_consulta int,
    id_medicamento int,
    dose varchar(40),
    frequencia varchar(40),
    duracao_dias int,
    foreign key (id_consulta) references consulta(id_consulta),
    foreign key (id_medicamento) references medicamento(id_medicamento)
);

create table exame (
	id_exame int auto_increment primary key,
    id_consulta int,
    tipo_exame varchar(80),
    foreign key (id_consulta) references consulta(id_consulta)
);

create table resultado_exame (
	id_resultado int auto_increment primary key,
    id_exame int unique,
    resultado_texto text,
    data_resultado date,
    foreign key (id_exame) references exame(id_exame)
);

INSERT INTO endereco (rua, numero, bairro, cidade, estado) VALUES
('Rua das Flores', '123', 'Centro', 'São Paulo', 'SP'),
('Avenida Brasil', '456', 'Jardins', 'São Paulo', 'SP'),
('Rua das Palmeiras', '789', 'Copacabana', 'Rio de Janeiro', 'RJ'),
('Avenida Paulista', '1000', 'Bela Vista', 'São Paulo', 'SP'),
('Rua XV de Novembro', '55', 'Centro', 'Curitiba', 'PR'),
('Rua da Paz', '33', 'Moema', 'São Paulo', 'SP'),
('Avenida Atlântica', '200', 'Copacabana', 'Rio de Janeiro', 'RJ'),
('Rua das Acácias', '77', 'Alphaville', 'Barueri', 'SP'),
('Rua São Paulo', '321', 'Centro', 'Belo Horizonte', 'MG'),
('Avenida das Nações', '999', 'Jardim Europa', 'São Paulo', 'SP');

INSERT INTO paciente (cpf, nome, data_nascimento, telefone, id_endereco) VALUES
('123.456.789-01', 'João Silva', '1980-05-15', '(11) 99999-1111', 1),
('234.567.890-12', 'Maria Santos', '1992-08-22', '(11) 98888-2222', 2),
('345.678.901-23', 'Pedro Oliveira', '1975-12-10', '(21) 97777-3333', 3),
('456.789.012-34', 'Ana Costa', '1988-03-30', '(11) 96666-4444', 4),
('567.890.123-45', 'Carlos Pereira', '1965-07-18', '(41) 95555-5555', 5),
('678.901.234-56', 'Fernanda Lima', '1995-11-25', '(11) 94444-6666', 6),
('789.012.345-67', 'Ricardo Souza', '1978-09-05', '(21) 93333-7777', 7),
('890.123.456-78', 'Juliana Almeida', '1983-01-20', '(11) 92222-8888', 8),
('901.234.567-89', 'Roberto Mendes', '1959-06-14', '(31) 91111-9999', 9),
('012.345.678-90', 'Amanda Ferreira', '1990-04-12', '(11) 90000-0000', 10);

INSERT INTO medico (crm, nome, telefone) VALUES
('12345-SP', 'Dr. Carlos Alberto', '(11) 99911-2233'),
('23456-SP', 'Dra. Mariana Santos', '(11) 98822-3344'),
('34567-RJ', 'Dr. Ricardo Oliveira', '(21) 97733-4455'),
('45678-SP', 'Dra. Beatriz Costa', '(11) 96644-5566'),
('56789-PR', 'Dr. Paulo Mendes', '(41) 95555-6677'),
('67890-SP', 'Dra. Patricia Lima', '(11) 94466-7788'),
('78901-RJ', 'Dr. Fernando Silva', '(21) 93377-8899'),
('89012-SP', 'Dra. Carolina Alves', '(11) 92288-9900'),
('90123-MG', 'Dr. Antonio Pereira', '(31) 91199-0011'),
('01234-SP', 'Dra. Luciana Martins', '(11) 90000-1122');

INSERT INTO especialidade (nome) VALUES
('Cardiologia'),
('Dermatologia'),
('Ginecologia'),
('Ortopedia'),
('Pediatria'),
('Neurologia'),
('Oftalmologia'),
('Psiquiatria'),
('Urologia'),
('Endocrinologia');

INSERT INTO medico_especialidade (id_medico, id_especialidade) VALUES
(1, 1), (1, 10),  -- Dr. Carlos: Cardiologia e Endocrinologia
(2, 3),           -- Dra. Mariana: Ginecologia
(3, 4),           -- Dr. Ricardo: Ortopedia
(4, 2),           -- Dra. Beatriz: Dermatologia
(5, 1), (5, 6),   -- Dr. Paulo: Cardiologia e Neurologia
(6, 5),           -- Dra. Patricia: Pediatria
(7, 7),           -- Dr. Fernando: Oftalmologia
(8, 8),           -- Dra. Carolina: Psiquiatria
(9, 9),           -- Dr. Antonio: Urologia
(10, 10);         -- Dra. Luciana: Endocrinologia

INSERT INTO consulta (id_medico, id_paciente, data_hora, descricao) VALUES
(1, 1, '2024-03-01 09:00:00', 'Consulta de rotina - checkup cardíaco'),
(2, 2, '2024-03-01 10:30:00', 'Consulta ginecológica anual'),
(3, 3, '2024-03-02 14:00:00', 'Dor no joelho direito'),
(4, 4, '2024-03-03 11:00:00', 'Avaliação de dermatite'),
(1, 5, '2024-03-04 08:30:00', 'Controle de hipertensão'),
(6, 6, '2024-03-05 15:00:00', 'Consulta pediátrica - criança com febre'),
(7, 7, '2024-03-06 09:30:00', 'Exame de vista'),
(8, 8, '2024-03-07 13:00:00', 'Acompanhamento psicológico'),
(9, 9, '2024-03-08 16:00:00', 'Consulta urológica'),
(10, 10, '2024-03-09 10:00:00', 'Controle de diabetes');

INSERT INTO leito (codigo, tipo) VALUES
('LEI-101', 'Enfermaria'),
('LEI-102', 'Enfermaria'),
('LEI-201', 'Apartamento'),
('LEI-202', 'Apartamento'),
('LEI-301', 'UTI'),
('LEI-302', 'UTI'),
('LEI-401', 'Semi-Intensiva'),
('LEI-402', 'Semi-Intensiva'),
('LEI-501', 'Pediatria'),
('LEI-502', 'Pediatria');

INSERT INTO internacao (id_paciente, id_leito, data_internacao, data_alta, motivo) VALUES
(1, 5, '2024-02-15', '2024-02-20', 'Infarto agudo do miocárdio'),
(3, 1, '2024-02-20', '2024-02-25', 'Cirurgia de joelho'),
(5, 3, '2024-02-25', '2024-03-02', 'Controle de pressão arterial'),
(7, 6, '2024-03-01', '2024-03-05', 'Pós-operatório de catarata'),
(9, 2, '2024-03-05', '2024-03-10', 'Tratamento de infecção urinária');

INSERT INTO medicamento (nome, principio_ativo) VALUES
('Losartana', 'Losartana Potássica'),
('Sinvastatina', 'Sinvastatina'),
('Metformina', 'Cloridrato de Metformina'),
('Amoxicilina', 'Amoxicilina Tri-Hidratada'),
('Dipirona', 'Dipirona Monoidratada'),
('Omeprazol', 'Omeprazol'),
('Atenolol', 'Atenolol'),
('Levotiroxina', 'Levotiroxina Sódica'),
('Sertralina', 'Cloridrato de Sertralina'),
('Insulina', 'Insulina Humana');

INSERT INTO prescricao (id_consulta, id_medicamento, dose, frequencia, duracao_dias) VALUES
(1, 1, '50mg', '1x ao dia', 30),
(1, 2, '20mg', '1x à noite', 30),
(2, 4, '500mg', '3x ao dia', 7),
(3, 5, '500mg', '6/6 horas', 5),
(4, 6, '20mg', '1x ao dia', 30),
(5, 1, '100mg', '1x ao dia', 30),
(5, 7, '25mg', '1x ao dia', 30),
(8, 9, '50mg', '1x ao dia', 60),
(10, 3, '850mg', '2x ao dia', 30),
(10, 10, '10UI', '3x ao dia antes das refeições', 30);

INSERT INTO exame (id_consulta, tipo_exame) VALUES
(1, 'Eletrocardiograma'),
(1, 'Hemograma completo'),
(2, 'Ultrassom pélvico'),
(3, 'Raio-X joelho'),
(4, 'Biópsia de pele'),
(5, 'Exame de sangue'),
(6, 'Teste alérgico'),
(7, 'Mapeamento de retina'),
(8, 'Escala de depressão'),
(10, 'Glicemia em jejum');

INSERT INTO resultado_exame (id_exame, resultado_texto, data_resultado) VALUES
(1, 'Ritmo sinusal normal, sem alterações significativas', '2024-03-01'),
(2, 'Hemograma dentro dos parâmetros normais', '2024-03-01'),
(3, 'Útero e ovários normais, sem alterações', '2024-03-02'),
(4, 'Fraturas consolidadas, sem evidência de novas lesões', '2024-03-03'),
(5, 'Dermatite de contato alérgica', '2024-03-04'),
(6, 'Pressão arterial controlada, exames normais', '2024-03-05'),
(7, 'Alergia a penicilina confirmada', '2024-03-06'),
(8, 'Retina normal, sem lesões', '2024-03-07'),
(9, 'Escala de depressão moderada - necessário acompanhamento', '2024-03-08'),
(10, 'Glicemia de 110 mg/dL - controle adequado', '2024-03-09');

-- Pacientes e seus endereços completos
SELECT 
    p.nome AS paciente,
    p.cpf,
    p.data_nascimento,
    p.telefone,
    CONCAT(e.rua, ', ', e.numero, ' - ', e.bairro) AS endereco,
    e.cidade,
    e.estado
FROM paciente p
JOIN endereco e ON p.id_endereco = e.id_endereco;

-- Consultas com informações de médico e paciente
SELECT 
    c.data_hora,
    m.nome AS medico,
    m.crm,
    p.nome AS paciente,
    p.telefone AS telefone_paciente,
    c.descricao
FROM consulta c
JOIN medico m ON c.id_medico = m.id_medico
JOIN paciente p ON c.id_paciente = p.id_paciente
ORDER BY c.data_hora DESC;

-- Médicos com suas especialidades
SELECT 
    m.nome AS medico,
    m.crm,
    GROUP_CONCAT(e.nome SEPARATOR ', ') AS especialidades
FROM medico m
JOIN medico_especialidade me ON m.id_medico = me.id_medico
JOIN especialidade e ON me.id_especialidade = e.id_especialidade
GROUP BY m.id_medico, m.nome, m.crm;

-- Internações com detalhes completos
SELECT 
    i.id_internacao,
    p.nome AS paciente,
    l.codigo AS leito,
    l.tipo AS tipo_leito,
    i.data_internacao,
    i.data_alta,
    DATEDIFF(i.data_alta, i.data_internacao) AS dias_internacao,
    i.motivo
FROM internacao i
JOIN paciente p ON i.id_paciente = p.id_paciente
JOIN leito l ON i.id_leito = l.id_leito
ORDER BY i.data_internacao DESC;

-- Prescrições detalhadas com medicamento e consulta
SELECT 
    pr.id_prescricao,
    c.data_hora AS data_consulta,
    m.nome AS medico,
    p.nome AS paciente,
    med.nome AS medicamento,
    med.principio_ativo,
    pr.dose,
    pr.frequencia,
    pr.duracao_dias
FROM prescricao pr
JOIN consulta c ON pr.id_consulta = c.id_consulta
JOIN medico m ON c.id_medico = m.id_medico
JOIN paciente p ON c.id_paciente = p.id_paciente
JOIN medicamento med ON pr.id_medicamento = med.id_medicamento
ORDER BY c.data_hora DESC;

-- Exames com resultados
SELECT 
    e.id_exame,
    e.tipo_exame,
    c.data_hora AS data_consulta,
    m.nome AS medico_solicitante,
    p.nome AS paciente,
    re.resultado_texto,
    re.data_resultado
FROM exame e
JOIN consulta c ON e.id_consulta = c.id_consulta
JOIN medico m ON c.id_medico = m.id_medico
JOIN paciente p ON c.id_paciente = p.id_paciente
LEFT JOIN resultado_exame re ON e.id_exame = re.id_exame
ORDER BY c.data_hora DESC;

-- Médicos que também são cardiologistas (especialidade específica)
SELECT 
    m.nome AS medico,
    m.crm,
    m.telefone
FROM medico m
JOIN medico_especialidade me ON m.id_medico = me.id_medico
JOIN especialidade e ON me.id_especialidade = e.id_especialidade
WHERE e.nome = 'Cardiologia';

-- Pacientes internados em UTI
SELECT 
    p.nome AS paciente,
    p.cpf,
    p.telefone,
    l.codigo AS leito,
    i.data_internacao,
    i.data_alta,
    i.motivo
FROM internacao i
JOIN paciente p ON i.id_paciente = p.id_paciente
JOIN leito l ON i.id_leito = l.id_leito
WHERE l.tipo = 'UTI'
ORDER BY i.data_internacao DESC;

-- Consultas com mais de uma prescrição
SELECT 
    c.id_consulta,
    c.data_hora,
    m.nome AS medico,
    p.nome AS paciente,
    COUNT(pr.id_prescricao) AS qtd_prescricoes,
    GROUP_CONCAT(med.nome SEPARATOR ', ') AS medicamentos_prescritos
FROM consulta c
JOIN medico m ON c.id_medico = m.id_medico
JOIN paciente p ON c.id_paciente = p.id_paciente
JOIN prescricao pr ON c.id_consulta = pr.id_consulta
JOIN medicamento med ON pr.id_medicamento = med.id_medicamento
GROUP BY c.id_consulta, c.data_hora, m.nome, p.nome
HAVING COUNT(pr.id_prescricao) > 1;

-- Pacientes que tiveram consultas e internações
SELECT 
    p.nome AS paciente,
    p.cpf,
    COUNT(DISTINCT c.id_consulta) AS total_consultas,
    COUNT(DISTINCT i.id_internacao) AS total_internacoes
FROM paciente p
LEFT JOIN consulta c ON p.id_paciente = c.id_paciente
LEFT JOIN internacao i ON p.id_paciente = i.id_paciente
GROUP BY p.id_paciente, p.nome, p.cpf
HAVING total_consultas > 0 OR total_internacoes > 0
ORDER BY total_internacoes DESC, total_consultas DESC;

-- Médicos por quantidade de consultas realizadas
SELECT 
    m.nome AS medico,
    m.crm,
    e.nome AS especialidade_principal,
    COUNT(c.id_consulta) AS total_consultas
FROM medico m
LEFT JOIN consulta c ON m.id_medico = c.id_medico
LEFT JOIN medico_especialidade me ON m.id_medico = me.id_medico
LEFT JOIN especialidade e ON me.id_especialidade = e.id_especialidade
GROUP BY m.id_medico, m.nome, m.crm, e.nome
ORDER BY total_consultas DESC;

-- Exames sem resultado registrado
SELECT 
    e.id_exame,
    e.tipo_exame,
    c.data_hora AS data_consulta,
    m.nome AS medico,
    p.nome AS paciente,
    'PENDENTE' AS status_resultado
FROM exame e
JOIN consulta c ON e.id_consulta = c.id_consulta
JOIN medico m ON c.id_medico = m.id_medico
JOIN paciente p ON c.id_paciente = p.id_paciente
LEFT JOIN resultado_exame re ON e.id_exame = re.id_exame
WHERE re.id_resultado IS NULL;

-- Prescrições de medicamentos controlados (exemplo: psicotrópicos)
SELECT 
    p.nome AS paciente,
    med.nome AS medicamento,
    pr.dose,
    pr.frequencia,
    pr.duracao_dias,
    c.data_hora AS data_consulta,
    m.nome AS medico_prescritor
FROM prescricao pr
JOIN consulta c ON pr.id_consulta = c.id_consulta
JOIN medicamento med ON pr.id_medicamento = med.id_medicamento
JOIN medico m ON c.id_medico = m.id_medico
JOIN paciente p ON c.id_paciente = p.id_paciente
WHERE med.nome IN ('Sertralina', 'Atenolol', 'Insulina')  -- Exemplo de medicamentos controlados
ORDER BY c.data_hora DESC;

-- Leitos ocupados atualmente (sem data de alta)
SELECT 
    l.codigo AS leito,
    l.tipo AS tipo_leito,
    p.nome AS paciente,
    i.data_internacao,
    DATEDIFF(CURDATE(), i.data_internacao) AS dias_internado,
    i.motivo
FROM internacao i
JOIN leito l ON i.id_leito = l.id_leito
JOIN paciente p ON i.id_paciente = p.id_paciente
WHERE i.data_alta IS NULL OR i.data_alta > CURDATE()
ORDER BY l.codigo;

-- Histórico completo de um paciente específico
SELECT 
    'Consulta' AS tipo_evento,
    c.data_hora AS data,
    m.nome AS medico,
    c.descricao AS descricao,
    NULL AS leito
FROM consulta c
JOIN medico m ON c.id_medico = m.id_medico
WHERE c.id_paciente = 1  -- Substituir pelo ID do paciente desejado

UNION ALL

SELECT 
    'Internação' AS tipo_evento,
    i.data_internacao AS data,
    NULL AS medico,
    i.motivo AS descricao,
    l.codigo AS leito
FROM internacao i
JOIN leito l ON i.id_leito = l.id_leito
WHERE i.id_paciente = 1  -- Substituir pelo ID do paciente desejado

ORDER BY data DESC;

-- Medicamentos mais prescritos
SELECT 
    med.nome AS medicamento,
    med.principio_ativo,
    COUNT(pr.id_prescricao) AS vezes_prescrito,
    GROUP_CONCAT(DISTINCT m.nome SEPARATOR '; ') AS medicos_prescritores
FROM medicamento med
JOIN prescricao pr ON med.id_medicamento = pr.id_medicamento
JOIN consulta c ON pr.id_consulta = c.id_consulta
JOIN medico m ON c.id_medico = m.id_medico
GROUP BY med.id_medicamento, med.nome, med.principio_ativo
ORDER BY vezes_prescrito DESC;

-- Pacientes por cidade
SELECT 
    e.cidade,
    e.estado,
    COUNT(p.id_paciente) AS total_pacientes,
    GROUP_CONCAT(p.nome SEPARATOR ', ') AS lista_pacientes
FROM paciente p
JOIN endereco e ON p.id_endereco = e.id_endereco
GROUP BY e.cidade, e.estado
ORDER BY total_pacientes DESC;

-- Consultas por especialidade médica
SELECT 
    e.nome AS especialidade,
    COUNT(c.id_consulta) AS total_consultas,
    GROUP_CONCAT(DISTINCT m.nome SEPARATOR ', ') AS medicos
FROM especialidade e
JOIN medico_especialidade me ON e.id_especialidade = me.id_especialidade
JOIN medico m ON me.id_medico = m.id_medico
LEFT JOIN consulta c ON m.id_medico = c.id_medico
GROUP BY e.id_especialidade, e.nome
ORDER BY total_consultas DESC;

-- Pacientes com múltiplas internações
SELECT 
    p.nome AS paciente,
    p.cpf,
    p.telefone,
    COUNT(i.id_internacao) AS total_internacoes,
    GROUP_CONCAT(DISTINCT i.motivo SEPARATOR '; ') AS motivos
FROM paciente p
JOIN internacao i ON p.id_paciente = i.id_paciente
GROUP BY p.id_paciente, p.nome, p.cpf, p.telefone
HAVING COUNT(i.id_internacao) > 1
ORDER BY total_internacoes DESC;

-- Dashboard resumido do hospital
SELECT 
    (SELECT COUNT(*) FROM paciente) AS total_pacientes,
    (SELECT COUNT(*) FROM medico) AS total_medicos,
    (SELECT COUNT(*) FROM consulta) AS total_consultas,
    (SELECT COUNT(*) FROM internacao WHERE data_alta IS NULL OR data_alta > CURDATE()) AS pacientes_internados,
    (SELECT COUNT(DISTINCT id_paciente) FROM consulta WHERE MONTH(data_hora) = MONTH(CURDATE())) AS pacientes_atendidos_mes,
    (SELECT COUNT(*) FROM leito WHERE tipo = 'UTI') AS leitos_uti,
    (SELECT GROUP_CONCAT(DISTINCT cidade SEPARATOR ', ') FROM endereco e JOIN paciente p ON e.id_endereco = p.id_endereco) AS cidades_atendidas;
