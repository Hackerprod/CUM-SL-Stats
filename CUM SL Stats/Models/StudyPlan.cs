using Newtonsoft.Json;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace SKYNET.Models
{
    public class StudyPlan : DBModel
    {
        public uint CourceID { get; set; }
        public string Name { get; set; }

        [OneToMany()]
        public List<uint> Plans
        {
            get
            {
                try
                {
                    return (List<uint>) JsonConvert.DeserializeObject(SerializedPlans, typeof(List<uint>));
                }
                catch (System.Exception)
                {
                    return new List<uint>();
                }
            }
            set
            {
                try
                {
                    SerializedPlans = JsonConvert.SerializeObject(value);
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Serialized Plans list
        /// </summary>
        public string SerializedPlans { get; set; }

        public StudyPlan()
        {
            Plans = new List<uint>();
        }
    }
}
