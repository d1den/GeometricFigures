CREATE TABLE ProductAndCategory (
	Product_Id  INT NOT NULL,
	Category_Id INT NOT NULL,
	CONSTRAINT UQ_Product_Category UNIQUE(Product_Id, Category_Id)
);

INSERT INTO ProductAndCategory
VALUES  (1, 1), (2, 2), (3, 3), (4, 1), (4, 3);