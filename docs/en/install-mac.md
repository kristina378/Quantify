## Installation instruction for macOS

To run this app you will need:


1) Installed **.NET SDK 10** + **Entity Framework**(ORM).

You can either download and install .NET SDK: 

* from here:  <https://dotnet.microsoft.com/download>

* with **brew** (package manager):
```bash
brew install --cask dotnet-sdk
```

#### To check dotnet version .NET:
```bash
dotnet --version
```

#### If it is installed then you need to also install Entity Framework (ORM for .NET):
```bash
dotnet tool install --global dotnet-ef
```

#### Add PATH for dotnet-ef tool
```bash
echo 'export PATH="$PATH:$HOME/.dotnet/tools"' >> ~/.zshrc
source ~/.zshrc
```

2) MySQL data base (and optionally client to work with it: MySQLWorkbench)

You can download and install by installing it:
* Installing guide : <https://dev.mysql.com/doc/mysql-macos-excerpt/8.0/en/macos-installation.html>

* Install and run MySQL with **brew**:
```bash
brew install mysql
brew services start mysql
```
#### To verify the installation (check the version):
```bash
mysql --version
```

* #### Configuring the root password:
To set a password for the database, log in to MySQL:
```bash
mysql -u root
```
Then, within the MySQL shell, execute the following commands (replacing `new-password` with your own password):
```sql
ALTER USER 'root'@'localhost' IDENTIFIED WITH caching_sha2_password BY 'new-password';
FLUSH PRIVILEGES;
exit;
```
***You must remember this password*** to update the `appsettings.json` file.

*Optionally: you can download MySQLWorkbench: <https://dev.mysql.com/downloads/workbench/>*
