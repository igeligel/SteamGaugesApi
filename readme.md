# SteamGaugesApi - Check steam status easily

<a href="./License.md"><img src="https://img.shields.io/github/license/igeligel/SteamGaugesApi.svg" alt="badge of license" /></a>
<a href="https://ci.appveyor.com/project/igeligel/csharp-steamgaug-es-api"><img src="https://ci.appveyor.com/api/projects/status/yj63her0xoo0t0sr?svg=true" alt="Build status" /></a>
<a href="https://github.com/igeligel/SteamGaugesApi/pulls"><img src="https://img.shields.io/badge/PR-welcome-green.svg" alt="badge of pull request welcome" /></a>

<img style="width: 888px" src="./docs/logo/banner.svg" />

> SteamGaugesApi is an API client for checking the status of Steam, Dota, CS:GO and Team Fortress. It will consume the API of [steamgaug.es](https://steamgaug.es/) and is provided by a .NET Standard 2.0 Nuget package.

## Installation

<p><details>
  <summary><b>Requirements</b></summary>
  You need to have a .NET version installed which is supporting .NET Standard 2.0. For more information you can lookup this <a href="https://github.com/dotnet/standard/blob/master/docs/versions.md">document</a>.
</details></p>

<p><details>
  <summary><b>Via nuget</b></summary>
  <pre><code>PM> Install-Package SteamGaugesApi -Version 1.0.0</code></pre>
</details></p>

## Usage

To use this library you need to add a reference to the used packages, instantiate a Client and create a request to the API.

```csharp
using SteamGaugesApi.Core;
using SteamGaugesApi.Core.Models;
```

Then we can use the Client and the response.

```csharp
var client = new SteamGaugesApi.Core.Client();
var response = client.Get();
```

<p><details>
  <summary><b>Response schema</b></summary>
  <p></p>
  <img src="https://i.imgur.com/vNms4JU.png" alt="debugging object representation of response"/>
</details></p>

## Used libraries

| Library        |  Version |
| ------------- | ------- |
| Newtonsoft.Json | 10.0.3 |

## Contact

<a href="http://steamcommunity.com/profiles/76561198028630048"><img src="https://img.shields.io/badge/Steam-igeligel-000000.svg" alt="steam of Kevin Peters"></a>
<a href="https://twitter.com/kevinpeters_"><img src="https://img.shields.io/badge/Twitter-kevinpeters__-1da1f2.svg" alt="Twitter of Kevin Peters"></a>
<a href="https://www.kevinpeters.net/"><img src="https://img.shields.io/badge/Personal%20Site-igeligel-a1c4fd.svg" alt="badge for personal site of igeligel"></a>

## Contributors

<table><thead><tr><th align="center"><a href="https://github.com/igeligel"><img src="https://avatars2.githubusercontent.com/u/12736734?v=3" width="100px;" style="max-width:100%;"><br><sub>igeligel</sub></a><br><p>Contributions: 127</p></th></tbody></table>

## License

*SteamGaugesApi* is realeased under the [MIT License](/License).
