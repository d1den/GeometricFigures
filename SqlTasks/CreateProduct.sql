 CREATE TABLE Product (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(255) NOT NULL CHECK(Name != '' AND Name != ' ')
);

INSERT INTO Product ([Name])
VALUES  ('Печенье'),
('Телефон'),
('Белизна'),
('Лимонная кислота')