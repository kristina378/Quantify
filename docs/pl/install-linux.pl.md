## Instrukcje instalacji dla Linux

Aby uruchomić projekt, wymagane jest:


1) Zainstalowane środowisko **.NET SDK 10** + **Entity Framework**(ORM).

Pobierz i zainstaluj .NET SDK:

* ze strony:  <https://dotnet.microsoft.com/download>

* przy pomocy **apt**(package manager):
```bash
sudo apt update
sudo apt install dotnet-sdk-10.0
```

#### Aby sprawdzić wersję .NET:
```bash
dotnet --version
```

#### Jeśli jest już zainstalowany, musisz również zainstalować Entity Framework (ORM for .NET):
```bash
dotnet tool install --global dotnet-ef
```

#### Dodaj ścieżke PATH dla narzędzia dotnet-ef
```bash
echo 'export PATH="$PATH:$HOME/.dotnet/tools"' >> ~/.bashrc
source ~/.bashrc
```

2) Bazę danych MySQL (oraz opcjonalnie klienta do obsługi: MySQL Workbench)

Możesz ją pobrać i zainstalować na dwa sposoby:

* Ze strony internetowej: <https://dev.mysql.com/downloads/mysql>

* Instalowanie MySQL + uruchomienie przy pomocy **apt**:
```bash
sudo apt update
sudo apt install mysql-server
sudo systemctl start mysql
sudo systemctl enable mysql
```

*Uwaga:*
```bash
systemctl enable mysql
```
*sprawia, że baza będzie wstawać automatycznie po restarcie systemu*

### Sprawdzenie czy się zainstalowało:
```bash
mysql --version
```

    * #### Konfiguracja hasła root:
        Domyślnie instalacja na Linuxie może nie prosić o hasło. Aby je ustawić, zaloguj się do MySQL jako administrator:
        ```bash
        sudo mysql
        ```
        Następnie wewnątrz powłoki MySQL wykonaj poniższe komendy (zastępując `new-password` swoim własnym hasłem):
        ```sql
        ALTER USER 'root'@'localhost' IDENTIFIED WITH caching_sha2_password BY 'new-password';
        FLUSH PRIVILEGES;
        exit;
        ```
        ***Musisz zapamiętać to hasło***, aby zaktualizować plik `appsettings.json`.

*Wskazówka: Opcjonalnie możesz zainstalować MySQLWorkbench: <https://dev.mysql.com/downloads/workbench/>*

### Opcjonalne:

1. Wybrane IDE obsługujące język C# (Rider, VS Code lub inne)
    *Wskazówka: IDE jest opcjonalne, projekt można uruchomić samodzielnie w terminalu.*

* "Darmowe" IDE:
    * VS Code: <https://code.visualstudio.com/download>

* Odpłatne IDE:
    * Rider: <https://www.jetbrains.com/rider/download>
