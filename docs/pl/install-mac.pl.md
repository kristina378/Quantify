## Instrukcje instalacji dla macOS

Aby uruchomić projekt, wymagane jest:


1) Zainstalowane środowisko **.NET SDK 10** + **Entity Framework**(ORM).

Pobierz i zainstaluj .NET SDK:

* ze strony: <https://dotnet.microsoft.com/download>

* przy pomocy **brew**(package manager):
```bash
brew install --cask dotnet-sdk
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
echo 'export PATH="$PATH:$HOME/.dotnet/tools"' >> ~/.zshrc
source ~/.zshrc
```

2) Bazę danych MySQL (oraz opcjonalnie klienta do obsługi: MySQL Workbench)

* Instalowanie MySQL + uruchomienie przy pomocy **brew**:
```bash
brew install mysql
brew services start mysql
```
Sprawdzenie czy się zainstalowało:
```bash
mysql --version
```

    * #### Konfiguracja hasła root:
        Aby ustawić hasło dla bazy danych, zaloguj się do MySQL:
        ```bash
        mysql -u root
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
