During these exercises, you will be asked to perform a simple REST API application,
which allows you to perform operations that allow you to modify data
in the SQL Server database.
A script is included with the task, allowing you to create a table
Animals and fill it with data. Communication with the database should
be done via the SqlConnection/SqlCommand classes.

Server data: db-mssql16.pjwstk.edu.pl
1. Add the Animals controller
2. Add a method/endpoint that allows you to get a list of animals.
The terminal should respond to an HTTP GET request sent to
the address /api/animals
1. The terminal should allow you to accept a parameter in the query string,
which specifies the sorting. The parameter is called orderBy. Example:
api/animals?orderBy=name
2. The parameter accepts the following values ​​as available: name, description,
category, area. We can only sort by one column.
The sorting is always in the "ascending" direction. 3. The default sorting (when no parameter is passed in the query string) should be done by the name column.
3. Add a method/endpoint allowing you to add a new animal.
1. The method should respond to an HTTP POST request to the address
api/animals
2. The method should accept data in the form of JSON2
4. Add a method/endpoint allowing you to update the data of a specific
animal.
1. The method should respond to an HTTP PUT request sent to the
address /api/animals/{idAnimal}
2. The method accepts data in the form of JSON
3. We assume that the primary keys are not modified (column
IdAnimal)
5. Add a method/endpoint for deleting data about a specific
animal.
1. The method should respond to an HTTP DELETE request sent
to /api/animals/{idAnimal}
6. Remember about correct HTTP codes
7. Try to use the built-in mechanism for
DependencyInjection.
8. Take care of data validation
9. Take care of naming and style
