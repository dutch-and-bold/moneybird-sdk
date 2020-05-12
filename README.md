<img src="https://github.com/dutch-and-bold/moneybird-sdk/raw/master/.github/moneybird-logo.png" alt="Moneybird SDK Project Logo" title="Moneybird" align="right" height="60" srcset="https://github.com/dutch-and-bold/moneybird-sdk/raw/master/.github/moneybird-logo@2x.png 2x"/>
 
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

## Project structure

The solution is divided in several projects. All these projects have a purpose explained below.

```
|__/src
```

This is the main directory holding all the projects.

```
    |/MoneybirdSdk.Client
```

This directory contains the client project which is able to create an authenticated connection to the Moneybird API.

```
    |/MoneybirdSdk.Domain
```

This directory contains the 'domain' of Moneybird. Consisting of entities and repository interfaces.

```
    |/MoneybirdSdk.Extensions.Microsoft.DependencyInjection
```

This directory contains base setup configuration for Microsoft's dependency injection API.

## Support

Please [open an issue](https://github.com/dutch-and-bold/moneybird-sdk/issues/new) for support.

## Contributing

Please contribute using [Github Flow](https://guides.github.com/introduction/flow/). Create a branch, add commits, and [open a pull request](https://github.com/dutch-and-bold/moneybird-sdk/compare/).

### Coding style and rules

This project adopts the Microsoft recommended code quality rules and .NET API usage rules. To adhere to these rules the project uses [Microsoft.CodeAnalysis.FxCopAnalyzers](https://www.nuget.org/packages/Microsoft.CodeAnalysis.FxCopAnalyzers/) package for code analysis in all projects.