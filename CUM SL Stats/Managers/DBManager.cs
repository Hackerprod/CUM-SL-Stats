using System;
using System.Collections.Generic;
using System.Linq;
using SKYNET.DB;
using SKYNET.Models;
using SQLite;

namespace SKYNET.Managers
{
    public class DBManager
    {
        private static SQLiteDatabase DB;

        public static void Initialize(SQLiteDatabase dB)
        {
            DB = dB;

            CareerDB.Initialize(DB);
            SchoolCourceDB.Initialize(DB);
            EvaluationDB.Initialize(DB);
            StudentDB.Initialize(DB);
            SubjectDB.Initialize(DB);
            GroupDB.Initialize(DB);
        }
    }
}
