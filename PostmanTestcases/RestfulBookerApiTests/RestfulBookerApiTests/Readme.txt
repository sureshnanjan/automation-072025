// =============================
// File: README.md (how to run)
// =============================
# Restful Booker – NUnit Test Suite (C#)


## 1) Prereqs
- Install .NET SDK 8.x: https://dotnet.microsoft.com/download


## 2) Create the test project
```bash
mkdir RestfulBooker.Tests
cd RestfulBooker.Tests
# If you want the template files first
# dotnet new nunit -n RestfulBooker.Tests
# Replace the generated .csproj and add the files from this repo.
```


## 3) Install packages (if you used the template and not the provided .csproj)
```bash
dotnet add package Microsoft.NET.Test.Sdk --version 17.10.0
dotnet add package NUnit --version 3.14.0
dotnet add package NUnit3TestAdapter --version 4.5.0
dotnet add package RestSharp --version 112.0.0
dotnet add package FluentAssertions --version 6.12.0
```


## 4) Configure base URL & creds
Use your **Postman Mock Server** base URL or the real API.


**PowerShell (Windows):**
```powershell
$env:BASE_URL = "https://46a3d7ae-80a4-40ca-981b-37df110c39e2.mock.pstmn.ioo" # or https://restful-booker.herokuapp.com
$env:USERNAME = "admin"
$env:PASSWORD = "password123"
```


**bash (macOS/Linux):**
```bash
export BASE_URL="https://46a3d7ae-80a4-40ca-981b-37df110c39e2.mock.pstmn.io"
export USERNAME="admin"
export PASSWORD="password123"
```


> If you point to the mock server, responses will come from your Postman **Examples**. If you point to the real site, auth + write ops require the token cookie.


## 5) Run the tests
```bash
dotnet test -v n
```


## 6) Notes
- Tests are tolerant to differences between real API and examples (e.g., 403 vs 200 with reason on /auth failure, plain text vs JSON on delete).
- Update or add assertions to exactly mirror your Postman **Examples** if needed.