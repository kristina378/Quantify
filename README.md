# Quantify

* [Polish version of ReadMe](./docs/pl/README.pl.md)

An educational platform designed to help high school students learn mathematics.

## Technologies:
- **Programming languages**: C#
- **Platform**: .NET 10
- **Web application**: ASP.NET Core MVC
- **Frameworks**: Microsoft Entity Framework Core 9.0
- **Database provider**: Pomelo
- **Database**: MySQL 
- **Build system**: dotnet


## System requirements:

To run this app you will need:

1) IDE of your choice (Visual Studio, Rider, or VS Code)
*Hint: An IDE is not strictly required, but it makes development much easier.*

2) **.NET SDK 10** environment

3) MySQL data base and client to work with it, for example: MySQLWorkbench


## Instruction how to install for certain OS:

* [Installation process for Windows](docs/en/install-windows.md)
* [Installation process on macOS](docs/en/install-mac.md)
* [Installation process on Linux](docs/en/install-linux.md)


## To run app:

1) Clone and go to repository:
```bash
git clone https://github.com/kristina378/Quantify
cd Quantify
```
2) Create appsettings.json and copy the contents of appsettings.example.json into it
```bash
cp appsettings.example.json appsettings.json
```
*Hint: on Windows use:*
```bash
copy appsettings.example.json appsettings.json
```
3) In appsettings.json, find the connection string and replace [Pwd=YOUR_PASSWORD;] with your actual MySQL root password.

4) To download necessary packages for app to run (like for example NuGet):
```bash
dotnet restore
```
5) Apply database migrations:
```bash
dotnet ef database update
```
6) Run project:
```bash
dotnet run
```
7) Application will be active at: <http://localhost:5270>

*Hint: If you get error: "Connection isn't private", then try:*
```bash
dotnet dev-certs https --trust
```
*and then run project again by*
```bash
dotnet run
```
