using MongoDB.Driver;
using SKYNET.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SKYNET.DB
{
    public static class UserDB
    {
        private static MongoDbCollection<SteamPlayer> DB;

        public static void Initialize()
        {
            DB = new MongoDbCollection<SteamPlayer>("SIGPU_Users");

            DB.CreateIndex(Builders<SteamPlayer>.IndexKeys.Ascending((SteamPlayer i) => i.AccountID));
            DB.CreateIndex(Builders<SteamPlayer>.IndexKeys.Ascending((SteamPlayer i) => i.AccountName));
        }

        public static void CreateAccount(SteamPlayer user)
        {
            uint AccountID = DB.Collection.Find(FilterDefinition<SteamPlayer>.Empty, null).SortByDescending((SteamPlayer u) => (object)u.AccountID).Project((SteamPlayer u) => u.AccountID).FirstOrDefault(default(CancellationToken));
            AccountID = AccountID <= 0U ? 1000 : AccountID + 1;
            user.AccountID = AccountID;
            DB.Collection.InsertOne(user);
        }

        public static int Count(uint ExceptAccountID = 0)
        {
            return (int)DB.Collection.CountDocuments((SteamPlayer user) => user.AccountID != ExceptAccountID, null, default(CancellationToken));
        }

        public static bool IsValidPersonaName(string AccountName)
        {
            if (DB.Collection.CountDocuments((SteamPlayer usr) => usr.AccountName.ToLower() == AccountName.ToLower(), null, default(CancellationToken)) != 0L)
            {
                return false;
            }
            return true;
        }

        public static SteamPlayer Get(uint AccountID)
        {
            return DB.Collection.Find((SteamPlayer usr) => usr.AccountID == AccountID, null).FirstOrDefault(default(CancellationToken));
        }

        public static SteamPlayer GetByAccountName(string AccountName)
        {
            return DB.Collection.Find((SteamPlayer usr) => usr.AccountName == AccountName, null).FirstOrDefault(default(CancellationToken));
        }
    }
}
