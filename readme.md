# csharp-steamgaug-es-api
This is a .net core library for the API of [Steam Gauges](https://steamgaug.es/)

## Project
An API wrapper to be used with [steamgaug.es](https://steamgaug.es/).
It will enable you to check status of:
- Steam Client
- Steam Community
- Steam User Service
- Economy for these games:
   - Team Fortress 2
   - Counter-Strike: Global Offensive
   - Dota 2
- Game Coordinator for these games:
   - Team Fortress 2
   - Counter-Strike: Global Offensive

It will also enable you:
- To get the current Team Fortress 2 schema
- To get the spy-/engine score of Team Fortress 2
- Get the current ammount of players queuing for a game for:
   - Counter-Strike: Global Offensive
   - Dota 2
- Dota 2 specific statuses:
    - average wait time
    - amount of ongoing matches
    - amount of servers available
    - get the menu url
    - get the amount of players online

## Installation
1. You need to install .net core. For instructions head over [here](https://www.microsoft.com/net/core).
2. Open your CLI.
3. Change directory to the package's source.
4. 
   ```
   $ dotnet restore
   ```
5. 
   ```
   $ dotnet build
   ```
6. Reference your build like this:

   ```
   "csharp-steamgaug-es-api-core": "1.0.0-*"
   ```

   in your project.json file. For an example watch the [testing package](https://github.com/igeligel/csharp-steamgaug-es-api/blob/master/src/csharp-steamgaug-es-api-test/project.json).

## Documentation

### General information
There is one service which should be used. This service is:
```csharp
SteamgaugesManager
```

Because this is a singleton you need to grab the instance and then call the methods like:
```csharp
SteamgaugesManager.Instance.IsSteamCommunityOnline();
```

### IsSteamClientOnline()
Method to check if the steam client is online.
*Example*:
```csharp
bool steamClientOnline = SteamgaugesManager.Instance.IsSteamClientOnline();
```

## Used libraries
| Library        | Usage        | Version |
| ------------- | ------------- | ------- |
| Newtonsoft.Json | A library for deserializing the json we are getting through the http response | 8.0.4-beta1 |

## Contribute

## Authors
- [igeligel](https://github.com/igeligel)

## Contact
[![Steam](https://raw.githubusercontent.com/encharm/Font-Awesome-SVG-PNG/master/black/png/16/steam-square.png "Steam Account") Steam](http://steamcommunity.com/profiles/76561198028630048/)

[![Discord](http://i.imgur.com/wlwOQpl.png "Discord") Discord](https://discord.gg/011jg2foytc2XogS6)

[![Twitter](https://raw.githubusercontent.com/encharm/Font-Awesome-SVG-PNG/master/black/png/16/twitter.png "Twitter") Twitter](https://twitter.com/kevinpeters_)

## License
[MIT]()
