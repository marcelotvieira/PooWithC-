use BIManager;

INSERT INTO [Usuario]
    (username, email, [password], isRandomPassword)
VALUES
    ('usuario1', 'usuario1@email.com', 'senha123', 1),
    ('usuario2', 'usuario2@email.com', 'outrasenha', 0);



INSERT INTO [BaseDeDados]
    (name, connectionUrl, ownerId)
VALUES
    ('Banco de Dados 1', 'string_de_conexao_1', 1),
    ('Banco de Dados 2', 'string_de_conexao_2', 1),
    ('Banco de Dados 3', 'string_de_conexao_3', 2);



INSERT INTO [Consulta]
    (name, queryString, chartYAxisKey, chartXAxisKey)
VALUES
    ('Consulta 1', 'SELECT * FROM Tabela1', 'Y1', 'X1'),
    ('Consulta 2', 'SELECT * FROM Tabela2', 'Y2', 'X2');


INSERT INTO ConsultasDaBaseDeDados
    (BaseDeDadosId, ConsultaId)
VALUES
    (1, 1),
    (1, 2),
    (2, 2),
    (3, 1);
