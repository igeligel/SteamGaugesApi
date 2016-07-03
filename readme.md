

# csharp-steamgaug-es-api
[![Discord](https://img.shields.io/badge/discord-join%20chat-blue.svg)](https://discord.gg/011jg2foytc2XogS6)


|               | Build Status  | 
| ------------- |:-------------:| 
| Linux/Mac     | [![Build status](https://travis-ci.org/igeligel/csharp-steamgaug-es-api.svg)](https://travis-ci.org/igeligel/csharp-steamgaug-es-api) | 
| Windows       | [![Build status](https://ci.appveyor.com/api/projects/status/yj63her0xoo0t0sr?svg=true)](https://ci.appveyor.com/project/igeligel/csharp-steamgaug-es-api) |

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

Also there is an enum which is describing games. These games are:
- Team Fortress 2
- Counter-Strike: Global Offensive
- Dota 2

### **IsSteamClientOnline()**
**Description**
> Method to check if the steam client is online.

**return**
> A boolean which describes the current status of the steam client.
It will return true if the steam client is online.
It will return false if the steam client is offline.

*Example*:
```csharp
bool steamClientOnline = SteamgaugesManager.Instance.IsSteamClientOnline();
```

### **IsSteamCommunityOnline()**
**Description**
> Method to check if the steam community is online.

**return**
> A boolean which describes the current status of the steam community.
It will return true if the steam community is online.
It will return false if the steam community is offline.

*Example*:
```csharp
bool steamCommunityIsOnline = SteamgaugesManager.Instance.IsSteamCommunityOnline();
```

### **IsSteamStoreOnline()**
**Description**
> Method to check if the steam store is online.

**return**
> A boolean which describes the current status of the steam store.
It will return true if the steam store is online.
It will return false if the steam store is offline.

*Example*:
```csharp
bool steamStoreIsOnline = SteamgaugesManager.Instance.IsSteamStoreOnline();
```

### **IsSteamUserOnline()**
**Description**
> Method to check if the steam user interface is online.

**return**
> A boolean which describes the current status of the steam user interface.
It will return true if the steam user interface is online.
It will return false if the steam user interface is offline.

*Example*:
```csharp
bool steamUserInterfaceOnline = SteamgaugesManager.Instance.IsSteamUserOnline();
```

### **IsEconomyOnline(Game game)**
**Description**
> Method to check if the steam economy is online.

**Parameter**

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | Game | Game which should be checked for the economy status. |

**return**
> A boolean which describes the current status of the steam economy.
It will return true if the steam economy is online.
It will return false if the steam economy is offline.

*Example*:
```csharp
bool csgoEconomyOnline = SteamgaugesManager
    .Instance
    .IsEconomyOnline(Game.CounterStrikeGlobalOffensive);
```

### **IsGameCoordinatorOnline(Game game)**
**Description**
> Method to check if the steam game coordinator is online.

**Parameter**

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | Game | Game which should be the game coordinator checked for. |

**return**
> A boolean which describes the current status of the game coordinator.
It will return true if the game coordinator is online.
It will return false if the game coordinator is offline.

*Example*:
```csharp
bool gameCoordinatorOnline = SteamgaugesManager
    .Instance
    .IsGameCoordinatorOnline(Game.CounterStrikeGlobalOffensive);
```

### **SteamCommunityResponseTime()**
**Description**
> Method to get the response time of the steam community.

**return**
> An integer describing the time in milliseconds.

*Example*:
```csharp
int steamCommunityResponseTime = SteamgaugesManager
    .Instance
    .SteamCommunityResponseTime();
```

### **SteamStoreResponseTime()**
**Description**
> Method to get the response time of the steam store.

**return**
> An integer describing the time in milliseconds.

*Example*:
```csharp
int steamStoreResponseTime = SteamgaugesManager
    .Instance
    .SteamStoreResponseTime();
```

### **SteamUserResponseTime()**
**Description**
> Method to get the response time of the steam user inteface.

**return**
> An integer describing the time in milliseconds.

*Example*:
```csharp
int steamUserResponseTime = SteamgaugesManager
    .Instance
    .SteamUserResponseTime();
```

### **GetEconomyResponseTime(Game game)**
**Description**
> Method to get the response time of the steam economy.

**Parameter**

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | Game | Game which should be the economy response time checked for. |

**return**
> An integer describing the time in milliseconds.

*Example*:
```csharp
int steamEconomyResponseTime = SteamgaugesManager
    .Instance
    .GetEconomyResponseTime(Game.CounterStrikeGlobalOffensive);
```

### **SteamCommunityHasError()**
**Description**
> Method to check if the steam community has an error.

**return**
> A boolean which describes the if steam community has an error.
It will return true if the steam community has an error.
It will return false if the steam community has no error.

*Example*:
```csharp
bool errorAtSteamCommunity = SteamgaugesManager
    .Instance
    .SteamCommunityHasError();
```

### **SteamStoreHasError()**
**Description**
> Method to check if the steam store has an error.

**return**
> A boolean which describes the if steam store has an error.
It will return true if the steam store has an error.
It will return false if the steam store has no error.

*Example*:
```csharp
bool errorAtSteamStore = SteamgaugesManager
    .Instance
    .SteamStoreHasError();
```

### **SteamUserHasError()**
**Description**
> Method to check if the steam user interface has an error.

**return**
> A boolean which describes the if steam user interface has an error.
It will return true if the steam user interface has an error.
It will return false if the steam user interface has no error.

*Example*:
```csharp
bool errorAtSteamUser = SteamgaugesManager
    .Instance
    .SteamUserHasError();
```

### **EconomyHasError(Game game)**
**Description**
> Method to check if the steam economy has an error.

**Parameter**

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | Game | Game which should be the economy checked for. |

**return**
> A boolean which describes the if steam economy has an error.
It will return true if the steam economy has an error.
It will return false if the steam economy has no error.

*Example*:
```csharp
bool errorAtEconomy = SteamgaugesManager
    .Instance
    .EconomyHasError(Game.CounterStrikeGlobalOffensive);
```

### **GameCoordinatorHasError(Game game)**
**Description**
> Method to check if the game coordinator has an error.

**Parameter**

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | Game | Game which should be the game coordinator checked for. |

**return**
> A boolean which describes the if game coordinator has an error.
It will return true if game coordinator has an error.
It will return false if the game coordinator has no error.

*Example*:
```csharp
bool errorAtCoordinator = SteamgaugesManager
    .Instance
    .GameCoordinatorHasError(Game.CounterStrikeGlobalOffensive);
```

### **GetSchema(Game game)**
**Description**
> Method to get the schema for a game. Actually it is just possible for Team Fortress.

**Parameter**

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | Game | Game which should be checked for a schema. |

**return**
> The url to the schema.

*Example*:
```csharp
string urlToSchema = SteamgaugesManager
    .Instance
    .GetSchema(Game.TeamFortress);
```

### **GetSpyScore(Game game)**
**Description**
> Method to get the spy score for a game. Actually it is just possible for Team Fortress.

**Parameter**

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | Game | Game which should be checked for the spy score. |

**return**
> The spy score as integer.

*Example*:
```csharp
int spyScore = SteamgaugesManager
    .Instance
    .GetSpyScore(Game.TeamFortress);
```

### **GetEngineScore(Game game)**
**Description**
> Method to get the engine score for a game. Actually it is just possible for Team Fortress.

**Parameter**

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | Game | Game which should be checked for the engine score. |

**return**
> The engine score as integer.

*Example*:
```csharp
int engineScore = SteamgaugesManager
    .Instance
    .GetSpyScore(Game.TeamFortress);
```

### **GetPlayersSearching(Game game)**
**Description**
> Method to get the amount of players searching in the game. This is not supported for Team Fortress 2.

**Parameter**

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | Game | Game which should be checked for the amount of players searching for a game. |

**return**
> The number of players as integer.

*Example*:
```csharp
int playersSearchingDota = SteamgaugesManager
    .Instance
    .GetPlayersSearching(Game.DotaTwo);
```

### **GetAverageWaitTime(Game game)**
**Description**
> Method to get the average wait game for searching for a match. This is just supported for Dota 2.

**Parameter**

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | Game | Game which should be checked for the average wait time. |

**return**
> The average wait time as milliseconds.

*Example*:
```csharp
int averageWaitTime = SteamgaugesManager
    .Instance
    .GetAverageWaitTime(Game.DotaTwo);
```

### **GetOnGoingMatches(Game game)**
**Description**
> Method to get the amount of on going matches for a game. This method will just work for Dota 2.

**Parameter**

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | Game | Game which should be checked for the amount of on going matches. |

**return**
> An integer of the amount of matches.

*Example*:
```csharp
int onGoingMatches = SteamgaugesManager
    .Instance
    .GetOnGoingMatches(Game.DotaTwo);
```

### **GetServersAvailable(Game game)**
**Description**
> Method to get the amount of servers available for a game. This method will just work for Dota 2.

**Parameter**

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | Game | Game which should be checked for the amount of servers available. |

**return**
> An integer of the amount of free servers.

*Example*:
```csharp
int serversAvailable = SteamgaugesManager
    .Instance
    .GetServersAvailable(Game.DotaTwo);
```

### **GetMenuUrl(Game game)**
**Description**
> Method to get the menu url of a game. This method will just work for Dota 2.

**Parameter**

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | Game | Game which should be checked for the menu url. |

**return**
> The url of the menu as string.

*Example*:
```csharp
string menuUrl = SteamgaugesManager
    .Instance
    .GetMenuUrl(Game.DotaTwo);
```

### **GetPlayersOnline(Game game)**
**Description**
> Method to get the players online. This method will just work for Dota 2.

**Parameter**

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | Game | Game which should be checked for the amount of players which are online. |

**return**
> The amount of online players as integer.

*Example*:
```csharp
int playersOnline = SteamgaugesManager
    .Instance
    .GetPlayersOnline(Game.DotaTwo);
```

## Used libraries
| Library        | Usage        | Version |
| ------------- | ------------- | ------- |
| Newtonsoft.Json | A library for deserializing the json we are getting through the http response | 8.0.4-beta1 |

## Contribute

You should always make an issue before changing something. I will check the issue and after that i will ask for a pull request.

For pull request please respect this coding style guidelines and this commit style guideline:
- [C# Style Guideline](https://github.com/igeligel/contributing-template/blob/master/code-style/csharp.md)
- [Commit Style Guideline](https://github.com/igeligel/contributing-template/blob/master/commits.md)

## Authors
- [igeligel](https://github.com/igeligel)

## Contact
[![Steam](https://raw.githubusercontent.com/encharm/Font-Awesome-SVG-PNG/master/black/png/16/steam-square.png "Steam Account") Steam](http://steamcommunity.com/profiles/76561198028630048/)

[![Discord](http://i.imgur.com/wlwOQpl.png "Discord") Discord](https://discord.gg/011jg2foytc2XogS6)

[![Twitter](https://raw.githubusercontent.com/encharm/Font-Awesome-SVG-PNG/master/black/png/16/twitter.png "Twitter") Twitter](https://twitter.com/kevinpeters_)

## License
[MIT](LICENSE)
