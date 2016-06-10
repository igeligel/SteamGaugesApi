using System;
using csharp_steamgaug_es_api_core.Exceptions;
using csharp_steamgaug_es_api_core.Http;
using csharp_steamgaug_es_api_core.Models.Enums;
using csharp_steamgaug_es_api_core.Models.Http;
using Newtonsoft.Json;

namespace csharp_steamgaug_es_api_core.Manager
{
    public sealed class SteamgaugManager
    {
        private static volatile SteamgaugManager instance;
        private static object syncRoot = new object();
        private static DateTime _lastRequest;
        private static SteamgaugResponseModel _steamgaugResponseModel = new SteamgaugResponseModel();

        private SteamgaugManager() { }

        public static SteamgaugManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new SteamgaugManager();
                        }

                    }
                }
                return instance;
            }
        }

        public bool IsSteamClientOnline()
        {
            updateResponseModel();
            return IsOnline(_steamgaugResponseModel.SteamClient.Online);
        }

        public bool IsSteamCommunityOnline()
        {
            updateResponseModel();
            return IsOnline(_steamgaugResponseModel.SteamCommunity.Online);
        }

        public bool IsSteamStoreOnline()
        {
            updateResponseModel();
            return IsOnline(_steamgaugResponseModel.SteamStore.Online);
        }

        public bool IsSteamUserOnline()
        {
            updateResponseModel();
            return IsOnline(_steamgaugResponseModel.SteamUser.Online);
        }

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

        public int SteamCommunityResponseTime()
        {
            updateResponseModel();
            return _steamgaugResponseModel.SteamCommunity.Time;
        }

        public int SteamStoreResponseTime()
        {
            updateResponseModel();
            return _steamgaugResponseModel.SteamStore.Time;
        }

        public int SteamUserResponseTime()
        {
            updateResponseModel();
            return _steamgaugResponseModel.SteamUser.Time;
        }

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
        
        public bool SteamCommunityHasError()
        {
            updateResponseModel();
            return HasError(_steamgaugResponseModel.SteamCommunity.Error);
        }
        
        public bool SteamStoreHasError()
        {
            updateResponseModel();
            return HasError(_steamgaugResponseModel.SteamStore.Error);
        }

        public bool SteamUserHasError()
        {
            updateResponseModel();
            return HasError(_steamgaugResponseModel.SteamUser.Error);
        }

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

        private bool IsOnline(int status)
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
            SteamgaugResponseModel steamgaugResponseModel = _steamgaugResponseModel;
            if (_lastRequest == null || !ResponseCached())
            {
                _lastRequest = DateTime.UtcNow;
                var result = SteamgaugService.GetJsonData().Result;
                steamgaugResponseModel = JsonConvert.DeserializeObject<SteamgaugResponseModel>(result);
            }
            if (_steamgaugResponseModel == null)
            {
                throw new SteamgaugOfflineException();
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
