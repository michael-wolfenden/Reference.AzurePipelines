# Reference.AzurePipelines

[![Build Status](https://michaelwolfenden.visualstudio.com/Reference.AzurePipelines/_apis/build/status/Reference.AzurePipelines-CI?branchName=master)](https://michaelwolfenden.visualstudio.com/Reference.AzurePipelines/_build/latest?definitionId=4)
[![nuget](https://img.shields.io/nuget/v/Reference.AzurePipelines.svg)](https://www.nuget.org/packages/Reference.AzurePipelines/)
[![nuget downloads](https://img.shields.io/nuget/dt/Reference.AzurePipelines.svg)](https://www.nuget.org/packages/Reference.AzurePipelines/)
[![github last commit](https://img.shields.io/github/last-commit/michael-wolfenden/Reference.AzurePipelines.svg)](https://github.com/michael-wolfenden/Reference.AzurePipelines)
[![github license](https://img.shields.io/github/license/michael-wolfenden/Reference.AzurePipelines.svg)](https://github.com/michael-wolfenden/Reference.AzurePipelines/blob/master/LICENSE)
[![Code of Conduct](https://img.shields.io/badge/code%20of-conduct-ff69b4.svg)](https://github.com/michael-wolfenden/Reference.AzurePipelines/blob/master/CODE_OF_CONDUCT.md)
[![semantic-release](https://img.shields.io/badge/%20%20%F0%9F%93%A6%F0%9F%9A%80-semantic--release-e10079.svg)](https://github.com/semantic-release/semantic-release)
[![dependabot](https://img.shields.io/badge/Dependabot-enabled-green.svg?logo=dependabot&style=flat)](https://dependabot.com/)

NET Standard library reference implementation built via Azure Pipelines.

![Reference.AzurePipelines](assets/logo.png)

## Motivation

To serve as a reference for building a NET Standard library with a [CI/CD](https://en.wikipedia.org/wiki/CI/CD) pipeline provided by [Azure Pipleines](https://azure.microsoft.com/en-au/services/devops/pipelines/).

### Features

- [x] Automatic Versioning, [Publishing](https://github.com/michael-wolfenden/Reference.AzurePipelines/releases) and [Changelog](https://github.com/michael-wolfenden/Reference.AzurePipelines/blob/master/CHANGELOG.md) generation using [semantic-release](https://github.com/semantic-release/semantic-release)
- [x] [Strong Naming](https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/strong-naming#create-strong-named-net-libraries)
- [x] [SourceLink](https://github.com/dotnet/sourcelink/) support
- [x] Performs both Windows, Linux and macOS builds using [Azure Pipelines](https://azure.microsoft.com/en-au/services/devops/pipelines/) and [Cake](https://cakebuild.net/)
- [x] Testing via [xUnit.net](https://xunit.github.io/)
- [x] [EditorConfig](https://docs.microsoft.com/en-us/visualstudio/ide/create-portable-custom-editor-options) support
- [x] Follows Microsoft's  [open-source library guidance](https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/)

## Access tokens

`semantic-release` requires both a **GitHub** and **NuGet** authentication token to be made available via the `GITHUB_TOKEN` and `NUGET_TOKEN` environment variables

### GITHUB_TOKEN
This token is used to authenticate with GitHub to read repository information, publish a GitHub release and upload files.

Create a [new personal access token](https://github.com/settings/tokens/new) with following scopes:

![access token scopes](https://i.imgur.com/vWIB1iQ.png "access token scopes")

### NUGET_TOKEN
This token is used to authenticate with NuGet to push packages.

Create a [new api key](https://www.nuget.org/account/apikeys) with following scopes:

![api key scopes](https://i.imgur.com/0iNGQ6V.png "api key scopes")

### Using the tokens with Azure Pipelines

Once you have both tokens, you can add `GITHUB_TOKEN` and `NUGET_TOKEN` as [secret Pipeline variables](
https://docs.microsoft.com/en-us/azure/devops/pipelines/process/variables?view=vsts&tabs=yaml%2Cbatch#secret-variables) in your PipeLine's settings. They will automatically be decrypted in the `azure-pipelines.yml` script.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/michael-wolfenden/Reference.AzurePipelines/tags).

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/michael-wolfenden/Reference.AzurePipelines/blob/master/LICENSE.md) file for details

## Acknowledgments

* This is a port of the [original project](https://github.com/kentcdodds/starwars-names) by [Kent C. Dodds](https://kentcdodds.com/)
* Icons made by [Smashicons](https://www.flaticon.com/authors/smashicons) from [www.flaticon.com](https://www.flaticon.com) is licensed by [CC 3.0 BY](http://creativecommons.org/licenses/by/3.0/)
