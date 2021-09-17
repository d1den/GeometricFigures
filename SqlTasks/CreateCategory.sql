 CREATE TABLE Category (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(255) NOT NULL CHECK(Name != '' AND Name != ' ')
);

INSERT INTO Category ([Name])
VALUES  ('Еда'),
('Электроника'),
('Химия')