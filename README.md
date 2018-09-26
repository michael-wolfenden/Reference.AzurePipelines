# Reference.AzurePipelines

[![Build Status](https://michaelwolfenden.visualstudio.com/Reference.AzurePipelines/_apis/build/status/Reference.AzurePipelines-CI)](https://michaelwolfenden.visualstudio.com/Reference.AzurePipelines/_build/latest?definitionId=4)
[![nuget](https://img.shields.io/nuget/v/Reference.AzurePipelines.svg)](https://www.nuget.org/packages/Reference.AzurePipelines/)
[![github license](https://img.shields.io/github/license/michael-wolfenden/Reference.AzurePipelines.svg)](https://github.com/michael-wolfenden/Reference.AzurePipelines/blob/master/LICENSE)
[![semantic-release](https://img.shields.io/badge/%20%20%F0%9F%93%A6%F0%9F%9A%80-semantic--release-e10079.svg)](https://github.com/semantic-release/semantic-release)

NET Standard library reference implementation built via Azure Pipelines.

![Reference.AzurePipelines](assets/logo.png)

## Motivation

To serve as a reference for building a NET Standard library with a [CI/CD](https://en.wikipedia.org/wiki/CI/CD) pipeline provided by [Azure Pipleines](https://azure.microsoft.com/en-au/services/devops/pipelines/).

### Features

- [x] Automatic Versioning, Publishing and Changelog generation using [semantic-release](https://github.com/semantic-release/semantic-release)
- [x] [SourceLink](https://github.com/dotnet/sourcelink/) support
- [x] Performs both Windows and Linux builds using [Azure Pipleines](https://azure.microsoft.com/en-au/services/devops/pipelines/) and [Cake](https://cakebuild.net/)
- [x] Testing via [xUnit.net](https://xunit.github.io/)
- [x] [EditorConfig](https://docs.microsoft.com/en-us/visualstudio/ide/create-portable-custom-editor-options) support

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

## Credits
This is a port of the [original project](https://github.com/kentcdodds/starwars-names) by [Kent C. Dodds](https://kentcdodds.com/)

Icons made by [Smashicons](https://www.flaticon.com/authors/smashicons) from [www.flaticon.com](www.flaticon.com) is licensed by [CC 3.0 BY](http://creativecommons.org/licenses/by/3.0/)

## License
MIT © [Michael Wolfenden](https://michael-wolfenden.github.io/)
