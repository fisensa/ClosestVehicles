using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestVehicles
{
    public struct Vehicle
    {
        private float _langitude;
        private float _latitude;
        private int _id;
        private string _regnumber;
        private long _recordedtime;

        public Vehicle(int id, string regnumber, float langitude, float latitude, long recordedtime)
        {
            _langitude = langitude;
            _latitude = latitude;
            _id = id;
            _regnumber = regnumber;
            _recordedtime = recordedtime;
        }

        public float Langitude { get => _langitude; set => _langitude = value; }

        public float Latitude { get => _latitude; set => _latitude = value; }
        public int Id { get => _id; set => _id = value; }

        public string Regnumber { get => _regnumber; set => _regnumber = value; }

        public long Recordedtime { get => _recordedtime; set => _recordedtime = value; }

        public float Distance(float positionX, float positionY)
        {
            return  (float)Math.Sqrt(Math.Pow(positionX - _latitude, 2) + Math.Pow(positionY - _langitude, 2));
        
        }

      

       
    }
}
