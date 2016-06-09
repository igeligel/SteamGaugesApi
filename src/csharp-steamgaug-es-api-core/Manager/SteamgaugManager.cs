using System;
using csharp_steamgaug_es_api_core.Exceptions;
using csharp_steamgaug_es_api_core.Http;
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
            if (_steamgaugResponseModel.SteamClient.Online == 1)
            {
                return true;
            }
            return false;
        }

        public bool IsSteamCommunityOnline()
        {
            updateResponseModel();
            if (_steamgaugResponseModel.SteamCommunity.Online == 1)
            {
                return true;
            }
            return false;
        }

        public int SteamCommunityResponseTime()
        {
            updateResponseModel();
            return _steamgaugResponseModel.SteamCommunity.Time;
        }

        public bool SteamCommunityHasError()
        {
            updateResponseModel();
            if (_steamgaugResponseModel.SteamCommunity.Error == "No Error")
            {
                return false;
            }
            return true;
        }

        public bool IsSteamStoreOnline()
        {
            updateResponseModel();
            if (_steamgaugResponseModel.SteamStore.Online == 1)
            {
                return true;
            }
            return false;
        }

        public int SteamStoreResponseTime()
        {
            updateResponseModel();
            return _steamgaugResponseModel.SteamStore.Time;
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
