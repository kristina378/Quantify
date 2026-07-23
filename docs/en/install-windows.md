## Installation instruction for Windows

To run this app you will need:


1) Installed **.NET SDK 10** + **Entity Framework**(ORM).

You can either download and install .NET SDK: 

* from here:  <https://dotnet.microsoft.com/download>

* with **winget**(package manager):
    In PowerShell you type:
    ```bash
    winget install Microsoft.DotNet.SDK.10
    ```
    *Hint 1: after installing .NET SDK in PowerShell you should close it and then open it again to refresh enviromental pathes*
    *Hint 2: if your system didn't find this package try:*
    ```bash
    winget search Microsoft.DotNet.SDK
    ```
    *and then try again to install*

    

#### To check dotnet version .NET:
```bash
dotnet --version
```

#### If it is installed then you need to also install Entity Framework (ORM for .NET):
```bash
dotnet tool install --global dotnet-ef
```

2) MySQL data base (and optionally client to work with it: MySQLWorkbench)

You can download and install by installing it:
* With web:
    Download installer from here <https://dev.mysql.com/downloads/installer/>
    *Hint:*
    *You have 2 options: web (2 MB) and offline one installer(565.9 MB).*
    *If you are beginner it is recommend for you to download the second (bigger) installer*

    If it asks you about privileges just click on yes

    Then in **Select options** you choose : ***Server Only***

    Optionally: If you want also to install client to work with Database you can choose:
    In **Select options** : ***Full*** to install all features including client and Database server
    or ***Custom***, and then in **Select Products** you choose the products you want do install:

    *Hint: if you choose **Custom**, you must install **MySQL Server 8.0.x** and possibly client **MySQL Workbench***


* In PowerShell with **winget** : 
    Install and run MySQL :
    ```bash
    winget install Oracle.MySQL
    ```

    To verify the installation (check the version):
    ```bash
    mysql --version
    ```

    * #### installing:
        1. Then search: C:\ProgramData\Microsoft\Windows\Menu Start\Programs\MySQL\MySQL Server 8.x (8.x is version of MySQL that you installed, if you installed another version you should search for: **MySQL Server <version>** )
        2. Open MySQL Configurator
        3. In **Type and Networking** section in **Config Type** choose *Development Computer* and left default configurations
        4. In **Account and Roles** section you enter **password for root** (superuser), ***you need to remember this password*** to be able to use Database, in consequences to use app
        5. Click Execute

        *Hint: here a video tutorial if you need more details: <https://www.youtube.com/watch?v=v8i2NgiM5pE&t=30s>*


### Optional:

1. IDE of your choice that supports C# (Rider, VS Code or something else)
    *Hint: IDE is optional, you can run project in terminal by itself*

"Free" IDE:
    VS Code: <https://code.visualstudio.com/download>

Paid IDE:
    Rider: <https://www.jetbrains.com/rider/download>

2. You can download client to work with MySQL, for example: ***MySQL Workbench***
    Hints how to install it in section with installing instruction for MySQL

## To run app:

1) Clone and go to repository:
```bash
git clone <https://github.com/kristina378/Quantify>
cd Quantify
```
2) Create appsettings.json and copy the contents of appsettings.example.json into it
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
