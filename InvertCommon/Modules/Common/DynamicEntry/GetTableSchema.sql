


SELECT 
c.table_name As TableName, 
c.column_name As ColumnName, 
c.data_type As DataType, 
c.character_maximum_length As MaxLength,
    COALESCE (
    ( SELECT 
        CASE cu.column_name
            WHEN null THEN 0
            ELSE 1
        END
    FROM information_schema.constraint_column_usage cu
    INNER join information_schema.table_constraints ct
    ON ct.constraint_name = cu.constraint_name
    WHERE 
    ct.constraint_type = 'PRIMARY KEY' 
    AND ct.table_name = c.table_name
    AND cu.column_name = c.column_name 
    ),0) AS IsPrimaryKey
FROM information_schema.columns c
INNER JOIN information_schema.tables t
ON c.table_name = t.table_name
WHERE '@table' = t.table_name and 
	  (t.table_type = 'BASE TABLE' and not 
	  (t.table_name = 'dtproperties') and not 
	  (t.table_name = 'sysdiagrams'))
ORDER BY c.table_name, c.ordinal_position