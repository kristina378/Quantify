## Installation instruction for macOS

To run this app you will need:

1) IDE of your choice that supports C# (Rider, VS Code or something else)
*Hint: IDE is optional, you can run project in terminal by itself*

"Free" IDE:
VS Code: <https://code.visualstudio.com/download>

Paid IDE:
Rider: <https://www.jetbrains.com/rider/download>


2) Installed **.NET SDK 10**.

Download and install .NET SDK from here:  
<https://dotnet.microsoft.com/download>

To check dotnet version .NET:
```bash
dotnet --version
```

3) MySQL data base and client to work with it: MySQLWorkbench

Install and run MySQL :
```bash
brew install mysql
brew services start mysql
```
To verify the installation (check the version):
```bash
mysql --version
```

Download MySQLWorkbench: <https://dev.mysql.com/downloads/workbench/>



## To run app:

1) Clone and go to repository:
```bash
git clone <https://github.com/kristina378/Quantify>
cd Quantify
```
2) Create appsettings.json and copy the contents of appsettings.example.json into it
```bash
cp appsettings.example.json appsettings.json
```
3) In appsettings.json, find the connection string and replace [Pwd=TUTAJ_WPISZ_HASLO;] with your actual MySQL root password.

4) Apply database migrations:
```bash
dotnet ef database update
```
5) Run project:
```bash
dotnet run
```
6) Application will be active at: <http://localhost:5270>
