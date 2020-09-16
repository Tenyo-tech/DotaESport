namespace DotaESport.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ISteamInfoService
    {
        long Steam64ToSteam32(long communityId);

        long GetSteamId64(string providerKey);

    }
}
