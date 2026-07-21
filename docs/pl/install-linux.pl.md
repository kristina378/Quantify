## Instrukcje instalacji dla Linux

Aby uruchomić projekt, wymagane jest:

1) Wybrane IDE (Rider, VS Code lub inne)

"Bezpłatne" IDE:
VS Code: <https://code.visualstudio.com/download>

Odpłatne IDE:
Rider: <https://www.jetbrains.com/rider/download>


2) zainstalowane środowisko **.NET SDK 10**.

Pobierz i zainstaluj .NET SDK ze strony:  
<https://dotnet.microsoft.com/download>

Sprawdzenie wersji .NET:
```bash
dotnet --version
```


3) Baza MySQL oraz klient do pracy z nią: MySQLWorkbench

Instalowanie MySQL + uruchomienie:
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

Sprawdzenie czy się zainstalowało:
```bash
mysql --version
```

Instalowanie MySQLWorkbench: <https://dev.mysql.com/downloads/workbench/>
lub
```bash
sudo snap install mysql-workbench-community
```
(wersja nr 2 dla Ubuntu)


## Uruchamianie
1) Sklonuj repozytorium i wejdź w nie:
```bash
git clone <https://github.com/kristina378/Quantify>
cd Quantify
```
2) Utwórz plik appsettings.json i skopiuj do niego zawartość appsettings.example.json
```bash
cp appsettings.example.json appsettings.json
```
3) W pliku appsettings.json w connection string, w tym miejscu: [Pwd=TUTAJ_WPISZ_HASLO;](appsettings.example.json#L10)
wpisz swoje hasło od bazy danych dla użytkownika root

4) Dodaj nową bazę danych:
```bash
dotnet ef database update
```
5) Uruchom projekt:
```bash
dotnet run
```
6) Aplikacja będzie aktywna pod adresem: <http://localhost:5270>
