# Altkom.DotNetCore.201810


* Utworzenie nowej aplikacji konsolowej

~~~ bash
dotnet new console
~~~~


* Uruchomienie aplikacji

~~~
dotnet helloworld.dll
~~~


* Uruchomienie testów jednostkowych
~~~
dotnet test
~~~

## Entity Framework

* Instalacja Entity Framework


~~~ powershell
Install-Package Microsoft.EntityFrameworkCore
~~~

~~~ bash
dotnet add package
~~~


* Instalacja obsługi bazy danych SQL Server
~~~ powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
~~~

Dzięki temu możemy użyć metodę **UseSqlServer**
~~~ csharp
services.AddDbContext<MyContext>(options =>
                            options.UseSqlServer(connectionString));
~~~

* Instalacja obsługi relacyjnej bazy danych, np. dodanie metodę HasColumnType
~~~ powershell
Install-Package Microsoft.EntityFrameworkCore.Relational
~~~

Przykład:
~~~ csharp
builder
              .Property(p => p.UnitPrice)
              .HasColumnType("decimal(10,2)");
			  
~~~