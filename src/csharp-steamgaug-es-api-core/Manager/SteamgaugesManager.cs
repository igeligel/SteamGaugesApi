using System;
using System.Runtime.CompilerServices;
using csharp_steamgaug_es_api_core.Exceptions;
using csharp_steamgaug_es_api_core.Http;
using csharp_steamgaug_es_api_core.Models.Enums;
using csharp_steamgaug_es_api_core.Models.Http;
using Newtonsoft.Json;

namespace csharp_steamgaug_es_api_core.Manager
{
    /// <summary>
    /// Singleton for managing steamgaug.es.
    /// This is a singleton because we need this just once in the application.
    /// Because of the singleton it has a cache variable to cache the response for not dosing the service.
    /// Also the singleton is thread safe which is important because of the caching.
    /// </summary>
    public sealed class SteamgaugesManager
    {
        private static volatile SteamgaugesManager instance;
        private static object syncRoot = new object();
        private static DateTime _lastRequest;
        private static SteamgaugesResponseModel _steamgaugResponseModel = new SteamgaugesResponseModel();

        private SteamgaugesManager()
        {
            
        }

        /// <summary>
        /// Instance of the Steamgauges manager.
        /// </summary>
        /// <returns>The instance of the singleton.</returns>
        public static SteamgaugesManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new SteamgaugesManager();
                        }

                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Method to check if the steam client is online.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// bool steamClientIsOnline = SteamgaugesManager.Instance.IsSteamClientOnline();
        /// </code>
        /// </example>
        /// <returns>
        /// A boolean which describes the current status of the steam client.
        /// It will return true if the steam client is online.
        /// It will return false if the steam client is offline.
        /// </returns>
        public bool IsSteamClientOnline()
        {
            updateResponseModel();
            return IsOnline(_steamgaugResponseModel.SteamClient.Online);
        }

        /// <summary>
        /// Method to check if the steam client is online.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// bool steamClientIsOnline = SteamgaugesManager.Instance.IsSteamCommunityOnline();
        /// </code>
        /// </example>
        /// <returns>
        /// A boolean which describes the current status of the steam community.
        /// It will return true if the steam community is online.
        /// It will return false if the steam community is offline.
        /// </returns>
        public bool IsSteamCommunityOnline()
        {
            updateResponseModel();
            return IsOnline(_steamgaugResponseModel.SteamCommunity.Online);
        }

        /// <summary>
        /// Method to check if the steam store is online.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// bool steamStoreIsOnline = SteamgaugesManager.Instance.IsSteamStoreOnline();
        /// </code>
        /// </example>
        /// <returns>
        /// A boolean which describes the current status of the steam store.
        /// It will return true if the steam store is online.
        /// It will return false if the steam store is offline.
        /// </returns>
        public bool IsSteamStoreOnline()
        {
            updateResponseModel();
            return IsOnline(_steamgaugResponseModel.SteamStore.Online);
        }

        /// <summary>
        /// Method to check if the steam user interface is online.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// bool steamUserInterfaceOnline = SteamgaugesManager.Instance.IsSteamUserOnline();
        /// </code>
        /// </example>
        /// <returns>
        /// A boolean which describes the current status of the steam user interface.
        /// It will return true if the steam user interface is online.
        /// It will return false if the steam user interface is offline.
        /// </returns>
        public bool IsSteamUserOnline()
        {
            updateResponseModel();
            return IsOnline(_steamgaugResponseModel.SteamUser.Online);
        }

        /// <summary>
        /// Method to check if the steam economy is online.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// bool steamEconomyOnline = SteamgaugesManager.Instance.IsEconomyOnline(Game.CounterStrikeGlobalOffensive);
        /// </code>
        /// </example>
        /// <param name="game">Game which should be the economy checked for.</param>
        /// <returns>
        /// A boolean which describes the current status of the steam economy.
        /// It will return true if the steam economy is online.
        /// It will return false if the steam economy is offline.
        /// </returns>
        public bool IsEconomyOnline(Game game)
        {
            updateResponseModel();
            if (game == Game.TeamFortress)
            {
                return IsOnline(_steamgaugResponseModel.EconItems["440"].Online);
            }
            else if (game == Game.CounterStrikeGlobalOffensive)
            {
                return IsOnline(_steamgaugResponseModel.EconItems["570"].Online);
            }
            else if (game == Game.DotaTwo)
            {
                return IsOnline(_steamgaugResponseModel.EconItems["730"].Online);
            }
            else
            {
                throw new GameNotSupportedException();
            }
        }

        /// <summary>
        /// Method to check if the steam game coordinator is online.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// bool gameCoordinatorOnline = SteamgaugesManager.Instance.IsGameCoordinatorOnline(Game.CounterStrikeGlobalOffensive);
        /// </code>
        /// </example>
        /// <param name="game">Game which should be the economy checked for.</param>
        /// <returns>
        /// A boolean which describes the current status of the game coordinator.
        /// It will return true if the steam economy is online.
        /// It will return false if the steam economy is offline.
        /// </returns>
        public bool IsGameCoordinatorOnline(Game game)
        {
            updateResponseModel();
            if (game == Game.TeamFortress)
            {
                return IsOnline(_steamgaugResponseModel.SteamGameCoordinator["440"].Online);
            }
            else if (game == Game.CounterStrikeGlobalOffensive)
            {
                return IsOnline(_steamgaugResponseModel.SteamGameCoordinator["570"].Online);
            }
            else if (game == Game.DotaTwo)
            {
                return IsOnline(_steamgaugResponseModel.SteamGameCoordinator["730"].Online);
            }
            else
            {
                throw new GameNotSupportedException();
            }
        }

        /// <summary>
        /// Method to get the response time of the steam community.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// int steamCommunityResponseTime = SteamgaugesManager.Instance.SteamCommunityResponseTime();
        /// </code>
        /// </example>
        /// <returns>
        /// An integer describing the time in milliseconds.
        /// </returns>
        public int SteamCommunityResponseTime()
        {
            updateResponseModel();
            return _steamgaugResponseModel.SteamCommunity.Time;
        }

        /// <summary>
        /// Method to get the response time of the steam store.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// int steamStoreResponseTime = SteamgaugesManager.Instance.SteamStoreResponseTime();
        /// </code>
        /// </example>
        /// <returns>
        /// An integer describing the time in milliseconds.
        /// </returns>
        public int SteamStoreResponseTime()
        {
            updateResponseModel();
            return _steamgaugResponseModel.SteamStore.Time;
        }

        /// <summary>
        /// Method to get the response time of the steam user inteface.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// int steamUserResponseTime = SteamgaugesManager.Instance.SteamUserResponseTime();
        /// </code>
        /// </example>
        /// <returns>
        /// An integer describing the time in milliseconds.
        /// </returns>
        public int SteamUserResponseTime()
        {
            updateResponseModel();
            return _steamgaugResponseModel.SteamUser.Time;
        }

        /// <summary>
        /// Method to get the response time of the steam economy.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// int steamEconomyResponseTime = SteamgaugesManager.Instance.GetEconomyResponseTime(Game.CounterStrikeGlobalOffensive);
        /// </code>
        /// </example>
        /// <param name="game">Game which should be the economy checked for.</param>
        /// <returns>
        /// An integer describing the time in milliseconds.
        /// </returns>
        public int GetEconomyResponseTime(Game game)
        {
            updateResponseModel();
            if (game == Game.TeamFortress)
            {
                return _steamgaugResponseModel.EconItems["440"].Time;
            }
            else if (game == Game.CounterStrikeGlobalOffensive)
            {
                return _steamgaugResponseModel.EconItems["570"].Online;
            }
            else if (game == Game.DotaTwo)
            {
                return _steamgaugResponseModel.EconItems["730"].Online;
            }
            else
            {
                throw new GameNotSupportedException();
            }
        }

        /// <summary>
        /// Method to check if the steam community has an error.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// int errorAtSteamCommunity = SteamgaugesManager.Instance.SteamCommunityHasError();
        /// </code>
        /// </example>
        /// <returns>
        /// A boolean which describes the if steam community has an error.
        /// It will return true if the steam community has an error.
        /// It will return false if the steam community has no error.
        /// </returns>
        public bool SteamCommunityHasError()
        {
            updateResponseModel();
            return HasError(_steamgaugResponseModel.SteamCommunity.Error);
        }

        /// <summary>
        /// Method to check if the steam store has an error.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// int errorAtSteamStore = SteamgaugesManager.Instance.SteamStoreHasError();
        /// </code>
        /// </example>
        /// <returns>
        /// A boolean which describes the if steam store has an error.
        /// It will return true if the steam store has an error.
        /// It will return false if the steam store has no error.
        /// </returns>
        public bool SteamStoreHasError()
        {
            updateResponseModel();
            return HasError(_steamgaugResponseModel.SteamStore.Error);
        }

        /// <summary>
        /// Method to check if the steam user interface has an error.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// int errorAtSteamUser = SteamgaugesManager.Instance.SteamUserHasError();
        /// </code>
        /// </example>
        /// <returns>
        /// A boolean which describes the if steam user interface has an error.
        /// It will return true if the steam user interface has an error.
        /// It will return false if the steam user interface has no error.
        /// </returns>
        public bool SteamUserHasError()
        {
            updateResponseModel();
            return HasError(_steamgaugResponseModel.SteamUser.Error);
        }

        /// <summary>
        /// Method to check if the steam economy has an error.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// int errorAtEconomy = SteamgaugesManager.Instance.EconomyHasError(Game.CounterStrikeGlobalOffensive);
        /// </code>
        /// </example>
        /// <param name="game">Game which should be the economy checked for.</param>
        /// <returns>
        /// A boolean which describes the if steam economy has an error.
        /// It will return true if the steam economy has an error.
        /// It will return false if the steam economy has no error.
        /// </returns>
        public bool EconomyHasError(Game game)
        {
            updateResponseModel();
            if (game == Game.TeamFortress)
            {
                return HasError(_steamgaugResponseModel.EconItems["440"].Error);
            }
            else if (game == Game.CounterStrikeGlobalOffensive)
            {
                return HasError(_steamgaugResponseModel.EconItems["570"].Error);
            }
            else if (game == Game.DotaTwo)
            {
                return HasError(_steamgaugResponseModel.EconItems["730"].Error);
            }
            else
            {
                throw new GameNotSupportedException();
            }
        }

        /// <summary>
        /// Method to check if the game coordinator has an error.
        /// </summary>
        /// <example>
        /// This is how to use the code:
        /// <code>
        /// int errorAtCoordinator = SteamgaugesManager.Instance.GameCoordinatorHasError(Game.CounterStrikeGlobalOffensive);
        /// </code>
        /// </example>
        /// <param name="game">Game which should be the economy checked for.</param>
        /// <returns>
        /// A boolean which describes the if game coordinator has an error.
        /// It will return true if game coordinator has an error.
        /// It will return false if the game coordinator has no error.
        /// </returns>
        public bool GameCoordinatorHasError(Game game)
        {
            updateResponseModel();
            if (game == Game.TeamFortress)
            {
                return HasError(_steamgaugResponseModel.SteamGameCoordinator["440"].Error);
            }
            else if (game == Game.CounterStrikeGlobalOffensive)
            {
                return HasError(_steamgaugResponseModel.SteamGameCoordinator["570"].Error);
            }
            else if (game == Game.DotaTwo)
            {
                return HasError(_steamgaugResponseModel.SteamGameCoordinator["730"].Error);
            }
            else
            {
                throw new GameNotSupportedException();
            }
        }

        public string GetSchema(Game game)
        {
            updateResponseModel();
            if (game != Game.TeamFortress)
            {
                throw new GameNotSupportedException();
            }
            return _steamgaugResponseModel.SteamGameCoordinator["440"].Schema;
        }

        public int GetSpyScore(Game game)
        {
            updateResponseModel();
            if (game != Game.TeamFortress)
            {
                throw new GameNotSupportedException();
            }
            int? spyScore = _steamgaugResponseModel.SteamGameCoordinator["440"].Stats.SpyScore;
            if (spyScore == null)
            {
                throw new SteamgaugesOfflineException();
            }
            else
            {
                return spyScore.Value;
            }
        }

        public int GetEngineScore(Game game)
        {
            if (game != Game.TeamFortress)
            {
                throw new GameNotSupportedException();
            }
            int? engiScore = _steamgaugResponseModel.SteamGameCoordinator["440"].Stats.EngiScore;
            if (engiScore == null)
            {
                throw new SteamgaugesOfflineException();
            }
            else
            {
                return engiScore.Value;
            }
        }

        public int GetPlayersSearching(Game game)
        {
            updateResponseModel();
            int? playersSearching = null;
            if (game == Game.TeamFortress)
            {
                throw new GameNotSupportedException();
            }
            else if (game == Game.CounterStrikeGlobalOffensive)
            {
                playersSearching = _steamgaugResponseModel.SteamGameCoordinator["570"].Stats.SpyScore;
            }
            else if (game == Game.DotaTwo)
            {
                playersSearching = _steamgaugResponseModel.SteamGameCoordinator["730"].Stats.SpyScore;
            }

            if (playersSearching == null)
            {
                throw new SteamgaugesOfflineException();
            }
            else
            {
                return playersSearching.Value;
            }
        }

        public int GetAverageWaitTime(Game game)
        {
            if (game != Game.DotaTwo)
            {
                throw new GameNotSupportedException();
            }
            int? averageWaitTime = _steamgaugResponseModel.SteamGameCoordinator["730"].Stats.AverageWaitTime;
            if (averageWaitTime == null)
            {
                throw new SteamgaugesOfflineException();
            }
            else
            {
                return averageWaitTime.Value;
            }
        }

        public int GetOnGoingMatches(Game game)
        {
            if (game != Game.DotaTwo)
            {
                throw new GameNotSupportedException();
            }
            int? onGoingMatches = _steamgaugResponseModel.SteamGameCoordinator["730"].Stats.OnGoingMatches;
            if (onGoingMatches == null)
            {
                throw new SteamgaugesOfflineException();
            }
            else
            {
                return onGoingMatches.Value;
            }
        }

        public int GetServersAvailable(Game game)
        {
            if (game != Game.DotaTwo)
            {
                throw new GameNotSupportedException();
            }
            int? serversAvailable = _steamgaugResponseModel.SteamGameCoordinator["730"].Stats.ServersAvailable;
            if (serversAvailable == null)
            {
                throw new SteamgaugesOfflineException();
            }
            else
            {
                return serversAvailable.Value;
            }
        }

        public string GetMenuUrl(Game game)
        {
            if (game != Game.DotaTwo)
            {
                throw new GameNotSupportedException();
            }
            string menuUrl = _steamgaugResponseModel.SteamGameCoordinator["730"].Stats.MenuUrl;
            if (menuUrl == null)
            {
                throw new SteamgaugesOfflineException();
            }
            else
            {
                return menuUrl;
            }
        }

        public int GetPlayersOnline(Game game)
        {
            if (game != Game.DotaTwo)
            {
                throw new GameNotSupportedException();
            }
            int? playersOnline = _steamgaugResponseModel.SteamGameCoordinator["730"].Stats.PlayersOnline;
            if (playersOnline == null)
            {
                throw new SteamgaugesOfflineException();
            }
            else
            {
                return playersOnline.Value;
            }
        }
        
        internal bool IsOnline(int status)
        {
            if (status == 1)
            {
                return true;
            }
            return false;
        }

        private bool HasError(string errorMessage)
        {
            if (errorMessage == "No Error")
            {
                return false;
            }
            return true;
        }

        private void updateResponseModel()
        {
            SteamgaugesResponseModel steamgaugResponseModel = _steamgaugResponseModel;
            if (_lastRequest == null || !ResponseCached())
            {
                _lastRequest = DateTime.UtcNow;
                var result = SteamgaugesService.GetJsonData().Result;
                steamgaugResponseModel = JsonConvert.DeserializeObject<SteamgaugesResponseModel>(result);
            }
            if (_steamgaugResponseModel == null)
            {
                throw new SteamgaugesOfflineException();
            }
            _steamgaugResponseModel = steamgaugResponseModel;
        }

        private bool ResponseCached()
        {
            if (_lastRequest <= DateTime.UtcNow.AddSeconds(-10))
            {
                return false;
            }
            return true;
        }
    }
}
