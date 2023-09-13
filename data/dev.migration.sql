use BIManager;

CREATE TABLE [Usuario]
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(255) UNIQUE,
    email VARCHAR(255) UNIQUE,
    [password] VARCHAR(255),
    isRandomPassword BIT DEFAULT 1,
    createdAt DATETIME DEFAULT GETDATE(),
    updatedAt DATETIME,
);

CREATE TABLE [BaseDeDados]
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(255),
    connectionUrl VARCHAR(MAX),
    createdAt DATETIME DEFAULT GETDATE(),
    updatedAt DATETIME,
    ownerId INT,
    FOREIGN KEY (ownerId) REFERENCES [Usuario](id)
);

CREATE TABLE [Consulta]
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(255),
    queryString VARCHAR(MAX),
    isCompatibleWithPeriod BIT DEFAULT 1,
    chartYAxisKey VARCHAR(255) DEFAULT '',
    chartXAxisKey VARCHAR(255) DEFAULT '',
);


CREATE TABLE [ConsultasDaBaseDeDados]
(
    BaseDeDadosId INT,
    ConsultaId INT,
    PRIMARY KEY (BaseDeDadosId, ConsultaId),
    FOREIGN KEY (BaseDeDadosId) REFERENCES BaseDeDados(id),
    FOREIGN KEY (ConsultaId) REFERENCES Consulta(id)
);


