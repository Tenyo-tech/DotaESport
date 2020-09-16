namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;

    public class SteamInfoService : ISteamInfoService
    {
        public long GetSteamId64(string providerKey)
        {
            var providerKEy = "https://steamcommunity.com/openid/id/76561198053563088";
            var pattern = "7656119([0-9]{10})$";

            var steamId64 = Regex.Match(providerKEy, pattern).Value;

            return long.Parse(steamId64);
        }

        public long Steam64ToSteam32(long communityId)
        {
           string steamId = string.Format("U:1:{0}", communityId - 76561197960265728L);

           var pattern = "([0-9]{8})$";

           var steamId32 = Regex.Match(steamId, pattern).Value;

           return long.Parse(steamId32);
        }

    }
}
