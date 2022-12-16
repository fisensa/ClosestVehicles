using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestVehicles
{
    //Not relevant at this case, but reduces work for the Garbage collector, it will be stored on the stack, and when finished it will be discarded.
    //In the larger application this may be important
    public struct Vehicle
    {
        private float _longitude;
        private float _latitude;
        private int _id;
        private string _regnumber;
        private long _recordedtime;

        public Vehicle(int id, string regnumber, float langitude, float latitude, long recordedtime)
        {
            _longitude = langitude;
            _latitude = latitude;
            _id = id;
            _regnumber = regnumber;
            _recordedtime = recordedtime;
        }

        public float Longitude { get => _longitude; set => _longitude = value; }

        public float Latitude { get => _latitude; set => _latitude = value; }
        public int Id { get => _id; set => _id = value; }

        public string Regnumber { get => _regnumber; set => _regnumber = value; }

        public long Recordedtime { get => _recordedtime; set => _recordedtime = value; }


        //Distance is no more calculated on the creation of the object, but calculated when needed.
        //This removes the need to create a new object for each position, and the distance is calculated only when needed.
        //Distance for this case is calculated using the Eucledian formula, for better purposes it should be calculated using the Haversine formula. However, more information about
        //routes should be included and 
        //the distance should be calculated using the shortest route.
        public float Distance(float positionX, float positionY)
        {
            return  (float)Math.Sqrt(Math.Pow(positionX - _latitude, 2) + Math.Pow(positionY - _longitude, 2));
        
        }

      

       
    }
}
