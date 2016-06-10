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

## Used libraries

| Library        | Usage        | Version |
| ------------- | ------------- | ------- |
| Newtonsoft.Json | A library for deserializing the json we are getting through the http response | 8.0.4-beta1 |

## Contribute

## Authors
- [igeligel](https://github.com/igeligel)

## Contact



## License


