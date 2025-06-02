create table Desenvolvedoras(
        Id INT PRIMARY KEY IDENTITY(1,1),
        Nome NVARCHAR(255) NOT NULL,
        Bio NVARCHAR(255) NOT NULL
);

create table Jogos(
        Id INT PRIMARY KEY IDENTITY(1,1),
        Nome NVARCHAR(255) NOT NULL
);

insert into Desenvolvedoras (Nome, Bio) values ('FromSoftware', 'Fundadora do gênero soulslike ');

insert into Jogos (Nome) values ('Dark Souls');

SELECT * FROM Desenvolvedoras;

SELECT * FROM Jogos;

drop table Desenvolvedoras;