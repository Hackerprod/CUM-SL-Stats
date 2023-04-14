using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using SKYNET.DB;
using SKYNET.DB.Helpers;
using SKYNET.Models;
using SQLite;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using SQLiteNetExtensions.Extensions.TextBlob;

namespace SKYNET.Managers
{
    public class DBManager
    {
        public async static void Initialize()
        {
            var DBPath = frmMain.Settings.DBPath;
            if (!string.IsNullOrEmpty(DBPath))
            {
                Common.EnsureDirectoryExists(DBPath, true);
            }
            else
            {
                DBPath = Path.Combine("Data", "DB.db");
                Common.EnsureDirectoryExists(DBPath, true);
            }

            var DB = new SQLiteAsyncConnection(DBPath);

            TextBlobOperations.SetTextSerializer(new TextBlobSerializer());


            await SubjectDB.Initialize(DB);
            await CareerDB.Initialize(DB);
            await SchoolCourceDB.Initialize(DB);
            await EvaluationDB.Initialize(DB);
            await StudentDB.Initialize(DB);
            await GroupDB.Initialize(DB);
            await StudyPlanDB.Initialize(DB);
            await PlanDB.Initialize(DB);
        }
    }
}
