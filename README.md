# Altkom.DotNetCore.201810

## Polecenia z linii polecen

* Utworzenie nowej aplikacji konsolowej

~~~ bash
dotnet new console
~~~~

* Utworzenie nowej aplikacji webapi

~~~ bash
dotnet new webapi
~~~~

* Utworzenie nowej aplikacji MVC

~~~ bash
dotnet new mvc
~~~~



* Uruchomienie aplikacji

~~~
dotnet helloworld.dll
~~~


* Uruchomienie testów jednostkowych
~~~
dotnet test
~~~

* Dodanie pakietu 
~~~ bash
dotnet add package <nazwa>
~~~

## Entity Framework

* Instalacja Entity Framework


~~~ powershell
Install-Package Microsoft.EntityFrameworkCore
~~~



* Pobranie **connection string** z pliku konfiguracyjnego *appsettings.json*

~~~ json
 "ConnectionStrings": {
    "MyConnection":  "Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=MyDb;Integrated Security=true"
  }
  
  ~~~~
  
 ~~~ csharp
 string connectionString = Configuration.GetConnectionString("MyConnection");
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

## Migracje

1. Instalacja narzędzi do Visual Studio 
~~~ Powershell
PM> Install-Package Microsoft.EntityFrameworkCore.Tools
~~~

2. Utwórz klasę

~~~ csharp
 public class MyContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyConnection"));

            return new MyContext(optionsBuilder.Options);
        }
    }
~~~

### Utworzenie bazy danych

PowerShell
~~~ Powershell
Add-Migration InitialCreate
~~~

Konsola
~~~ bash
dotnet ef migrations add InitialCreate
~~~

### Zastosowanie migracji do utworzenie bazy danych

PowerShell
~~~ Powershell
Update-Database
~~~

Konsola
~~~ bash
dotnet ef database update
~~~



### Dodanie migracji

PowerShell
~~~ Powershell
Add-Migration AddCustomerCity
~~~

Konsola
~~~ bash
dotnet ef migrations add AddCustomerCity
~~~


4. Zastosuj migrację
~~~ Powershell
Update-Database
~~~

### Usuwanie migracji

PowerShell
~~~ Powershell
Remove-Migration
~~~

Konsola
~~~ bash
dotnet ef migrations remove
~~~


### Powracanie do migracji

PowerShell
~~~ Powershell
Update-Database LastGoodMigration
~~~

Konsola
~~~ bash
dotnet ef database update LastGoodMigration
~~~



### Generowanie skryptu SQL
PowerShell
~~~ Powershell
Script-Migration
~~~

Konsola
~~~ basg
dotnet ef migrations script
~~~


## Narzędzia

* Ngrok - umożliwia wystawienie własnej usługi pod adresem publicznym
https://ngrok.com/
