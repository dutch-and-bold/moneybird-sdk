<img src="https://github.com/dutch-and-bold/moneybird-sdk/raw/master/.github/moneybird-logo.png" alt="Moneybird SDK Project Logo" title="Moneybird" align="right" height="64" srcset="https://github.com/dutch-and-bold/moneybird-sdk/raw/master/.github/moneybird-logo@2x.png 2x"/>
 
 # Moneybird SDK
 
 ![.NET Standard](https://img.shields.io/badge/.NET%20Standard-2.1-purple)

Moneybird SDK for .NET and .NET Core

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Project structure](#project-structure)
- [Support](#support)
- [Contributing](#contributing)

## Installation

Not yet available.

## Usage

Not yet available.

## API Implementation Progress

| Resource                               | Status      |
| -------------------------------------- | ----------- |
| Administration                         | In progress |
| Contacts                               | Planned     |
| Custom fields                          | Planned     |
| Document styles                        | Planned     |
| Documents: General documents           | Planned     |
| Documents: General journal documents   | Planned     |
| Documents: Purchase invoices           | Planned     |
| Documents: Receipts                    | Planned     |
| Documents: Typeless documents          | Planned     |
| Estimates                              | Planned     |
| External sales invoices                | Planned     |
| Financial accounts                     | Planned     |
| Financial mutations                    | Planned     |
| Financial statements                   | Planned     |
| Identities                             | Planned     |
| Import mappings                        | Planned     |
| Ledger accounts                        | Planned     |
| Products                               | Planned     |
| Projects                               | Planned     |
| Recurring sales invoices               | Planned     |
| Sales invoices                         | Planned     |
| Tax rates                              | Planned     |
| Verifications                          | Planned     |
| Webhooks                               | Planned     |
| Workflows                              | Planned     |

More information about resources can be found [here](https://developer.moneybird.com/api/administration/)

## Project structure

The solution is divided in several projects. All these projects have a purpose explained below.

```
|__/src
```

This is the main directory holding all the projects.

```
    |/MoneybirdSdk.Client
```

This project contains the Moneybird base client with OAuth authentication and in memory token store.

```
    |/MoneybirdSdk.Client.AccessTokenStore.File
```

This project contains an alternative token store and accessor which uses `System.IO.File`.
This offers an alternative of using the in memory token store variant which will not persist after the application restarts.

```
    |/MoneybirdSdk.Domain
```

This project contains the 'domain' of Moneybird. Consisting of entities and repository interfaces.

```
    |/MoneybirdSdk.Extensions.Microsoft.DependencyInjection
```

This directory contains base setup configuration for Microsoft's dependency injection API.

## Support

Please [open an issue](https://github.com/dutch-and-bold/moneybird-sdk/issues/new) for support.

## Contributing

Please contribute using [Github Flow](https://guides.github.com/introduction/flow/). Create a branch, add commits, and [open a pull request](https://github.com/dutch-and-bold/moneybird-sdk/compare/).

### Setting up the project

1. Clone the project to a local directory
2. Restore packages with nuget

**Requirements**
* Dotnet SDK >= 3.1

#### Running tests

The project contains several XUnit unit tests, the tests can be run with `dotnet test`.

### Coding style and rules

This project adopts the Microsoft recommended code quality rules and .NET API usage rules. To adhere to these rules the project uses [Microsoft.CodeAnalysis.FxCopAnalyzers](https://www.nuget.org/packages/Microsoft.CodeAnalysis.FxCopAnalyzers/) package for code analysis in all projects.

### Releasing

This package uses [SemVer v2](https://semver.org). Patch versions are automatically 'upped' when pushing to master using [Nerdbank.GitVersioning](https://github.com/dotnet/Nerdbank.GitVersioning).

#### Releasing a new feature

When releasing a new version we can create a release branch using nbgv.

1. Run `nbgv prepare-release`
2. This has now created a new release/v1.* branch.

** More information will follow.

**Requirements**

* Nerdbank.GitVersioning CLI, install with dotnet `dotnet tool install -g nbgv`

### Interesting reads

* [Make HTTP requests using IHttpClientFactory in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-3.1)
* [.NET Microservices: Architecture for Containerized .NET Applications](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/)
