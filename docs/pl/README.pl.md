# Quantify

* [English version of ReadMe](../../README.md)

Dane repozytorium to przyszła platforma edukacyjna, która ma za zadanie pomagać uczniom szkół średnich w nauce matematyki.

## Stos technologiczny
- **Język**: C#
- **Platforma**: .NET 10
- **Aplikacja webowa**: ASP.NET Core MVC
- **Frameworki**: Microsoft Entity Framework Core 9.0
- **Połączenie z bazą danych**: Pomelo
- **Baza danych**: MySQL 
- **System budowania**: dotnet


## Wymagania wstępne

Aby uruchomić projekt, wymagane jest:

1) Wybrane IDE (Visual Studio, Rider, albo VS Code)
*Popowiedź: IDE nie jest wymagane, kwestia preferencji*

2) Środowisko **.NET SDK 10**.

3) Baza MySQL oraz klient do pracy z nią: MySQLWorkbench


## Instrukcje instalacji dla poszczegółnych systemów operacyjnych:

* [Instalacja na systemie Windows](install-windows.pl.md) 
* [Instalacja na systemie macOS](install-mac.pl.md)
* [Instalacja na systemie Linux](install-linux.pl.md)


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

*Wskazówka: na Windows:*
```bash
copy appsettings.example.json appsettings.json
```
3) W pliku appsettings.json w connection string, w tym miejscu: [Pwd=YOUR_PASSWORD;](../../appsettings.example.json#L10)
wpisz swoje hasło od bazy danych dla użytkownika root

4) Pobierz pakiety niezbędne do uruchomienia aplikacji (np. NuGet):
```bash
dotnet restore
```
5) Dodaj nową bazę danych:
```bash
dotnet ef database update
```
6) Uruchom projekt:
```bash
dotnet run
```
7) Aplikacja będzie aktywna pod adresem: <http://localhost:5270>

*Wskazówka: Jeśli otrzymasz błąd: "Połączenie nie jest prywatne" (Connection isn't private), spróbuj wpisać:*
```bash
dotnet dev-certs https --trust
```
*a następnie ponownie uruchom projekt wpisując:*
```bash
dotnet run
```
