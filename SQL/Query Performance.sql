------- Query Performance -------

/*
Clears the SQL Server execution plan cache.
Forces SQL Server to generate new execution plans the next time queries run.
Commonly used when testing query performance.
*/
DBCC FREEPROCCACHE;


/*
Displays execution time and I/O statistics for queries.
The results appear in the Messages tab in SQL Server Management Studio (SSMS).*/
SET STATISTICS TIME ON;
SET STATISTICS IO ON;

-- Query Here--

SET STATISTICS TIME OFF;
SET STATISTICS IO OFF;