## Installation instruction for Linux

To run this app you will need:


1) Installed **.NET SDK 10** + **Entity Framework**(ORM).

You can either download and install .NET SDK: 

* from here: <https://dotnet.microsoft.com/download>

* with **apt** (package manager):
```bash
sudo apt update
sudo apt install dotnet-sdk-10.0
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
echo 'export PATH="$PATH:$HOME/.dotnet/tools"' >> ~/.bashrc
source ~/.bashrc
```

2) MySQL data base (and optionally client to work with it: MySQLWorkbench)

Install and run MySQL  with **apt**:
```bash
sudo apt update
sudo apt install mysql-server
sudo systemctl start mysql
sudo systemctl enable mysql
```

*Hint:*
```bash
systemctl enable mysql
```
*makes the database start automatically after system restart*

#### To verify the installation (check the version):
```bash
mysql --version
```

* #### Root Password Setup:
By default, your Linux installation may not prompt for a password. To set one, log in to MySQL as root:
```bash
sudo mysql
```
Then, within the MySQL shell, execute the following commands (replacing `new-password` with your own password):
```sql
ALTER USER 'root'@'localhost' IDENTIFIED WITH caching_sha2_password BY 'new-password';
FLUSH PRIVILEGES;
exit;
```
***You must remember this password*** to update the `appsettings.json` file.

*Optionally: you can download MySQLWorkbench: <https://dev.mysql.com/downloads/workbench/>*
or
```bash
sudo snap install mysql-workbench-community
```
(option 2 for Ubuntu)
