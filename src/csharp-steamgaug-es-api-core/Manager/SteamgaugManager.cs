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
            return false;
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
