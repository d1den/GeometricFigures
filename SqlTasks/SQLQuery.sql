USE TestDB;
SELECT [Product].[Name] as 'Продукт', [Category].[Name] as 'Категория'
FROM [Product]
LEFT JOIN [ProductAndCategory]
ON [Product].[Id] = [ProductAndCategory].[Product_Id]
INNER JOIN [Category]
ON [ProductAndCategory].[Category_Id] = [Category].[Id]
ORDER BY [Product].[Name];