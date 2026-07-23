## Instrukcje instalacji dla Windows

Aby uruchomić projekt, wymagane jest:


1) Zainstalowane środowisko **.NET SDK 10** + **Entity Framework**(ORM).

Pobierz i zainstaluj .NET SDK: 

* ze strony:  <https://dotnet.microsoft.com/download>

* przy pomocy **winget**(package manager):
    W PowerShell wpisz:
    ```bash
    winget install Microsoft.DotNet.SDK.10
    ```
    *Wskazówka 1: po pobraniu .NET SDK w PowerShell zamknij Powershell i otwórz ponownie, aby odświeżyć zmienne środowiskowe.*
    *Wskazówka 2: jeśli Twój system nie znajdzie tego pakietu, spróbuj wpisać:*
    ```bash
    winget search Microsoft.DotNet.SDK
    ```
    *a następnie spróbuj zainstalować ponownie.*

    

#### Aby sprawdzić wersję .NET:
```bash
dotnet --version
```

#### Jeśli jest już zainstalowany, musisz również zainstalować Entity Framework (ORM for .NET):
```bash
dotnet tool install --global dotnet-ef
```

2) Bazę danych MySQL (oraz opcjonalnie klienta do obsługi: MySQL Workbench)

Możesz ją pobrać i zainstalować na dwa sposoby:
* Ze strony internetowej:
    Pobierz instalator stąd: <https://dev.mysql.com/downloads/installer/>
    *Wskazówka:*
    *Masz do wyboru 2 opcje: instalator sieciowy (2 MB) i pełny instalator offline (565.9 MB).*
    *Jeśli jesteś osobą początkującą, zaleca się pobranie drugiego (większego) instalatora.*
    
    
    Jeśli system zapyta o uprawnienia administratora, po prostu kliknij "Tak".

    Następnie w sekcji ***Select options*** wybierz: *Server Only*

    Opcjonalnie: Jeśli chcesz zainstalować również klienta do pracy z bazą danych, możesz wybrać:
    W **Select options** : ***Full*** , aby zainstalować wszystkie funkcje, w tym klienta i serwer bazy danych,
    lub ***Custom***, a następnie w **Select Products** wybrać produkty, które chcesz zainstalować:

    *Wskazówka: jeśli wybierzesz **Custom**, musisz zainstalować MySQL Server 8.0.x i opcjonalnie klienta **MySQL Workbench**.*


* W PowerShell za pomocą **winget** : 
    Zainstaluj i uruchom MySQL :
    ```bash
    winget install Oracle.MySQL
    ```

    Aby zweryfikować instalację (sprawdzić wersję):
    ```bash
    mysql --version
    ```

    * #### Konfiguracja instalacji:
        1. Znajdź ścieżkę: C:\ProgramData\Microsoft\Windows\Menu Start\Programs\MySQL\MySQL Server 8.x (gdzie 8.x to wersja MySQL, którą zainstalowałaś; jeśli masz inną wersję, szukaj MySQL Server )
        2. Otwórz program MySQL Configurator
        3. W sekcji **Type and Networking** w polu **Config Type** wybierz *Development Computer* i pozostaw resztę ustawień domyślnych
        4. W sekcji **Account and Roles** wpisz **nowe hasło do bazy dla uytkownika root** (superuser), ***musisz zapamiętać to hasło*** aby móc połączyć się z bazą danych i korzystać z aplikacji.
        5. Kliknij *Execute*

        *Wskazówka: tutaj znajdziesz poradnik wideo, jeśli potrzebujesz dokładniejszego wytłumaczenia: <https://www.youtube.com/watch?v=v8i2NgiM5pE&t=30s>*


### Opcjonalne:

1. Wybrane IDE obsługujące język C# (Rider, VS Code lub inne)
    *Wskazówka: IDE jest opcjonalne, projekt można uruchomić samodzielnie w terminalu.*

"Darmowe" IDE:
    VS Code: <https://code.visualstudio.com/download>
    Visual Studio: <https://visualstudio.microsoft.com/downloads/>

Odpłatne IDE:
    Rider: <https://www.jetbrains.com/rider/download>

2. Możesz pobrać klienta do pracy z MySQL, na przykład: ***MySQL Workbench***.
Wskazówki, jak go zainstalować, znajdują się w sekcji z instrukcją instalacji MySQL
