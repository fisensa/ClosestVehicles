using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Collections;


namespace ClosestVehicles;

internal static class Program
{



    public static void Main(string[] args)
    {
        var vehicles = new HashSet<Vehicle>();

        //Read file with vehicles and add them to the HashSet
        //Tried to load file in chunks, but is not improving performance, best is to have data in the DB and load it from there, it will also improve querry for the closest vehicles

        using (var fileStream = new FileStream("VehiclePositions.dat", FileMode.Open, FileAccess.Read))
        {
            //binary reader to read the file
            using (BinaryReader fileReader = new BinaryReader(fileStream))
            {

                int ID;
                string Regnumber;
                float Langitude;
                float Latitude;
                long Recordedtime;


                //adding the records to the list
                while (fileReader.BaseStream.Position != fileReader.BaseStream.Length)
                {
                    ID = fileReader.ReadInt32();
                    Regnumber = ReadNullTerminatedString(fileReader);
                    Langitude = fileReader.ReadSingle();
                    Latitude = fileReader.ReadSingle();
                    Recordedtime = fileReader.ReadInt64();
                    vehicles.Add(new Vehicle(ID, Regnumber, Langitude, Latitude, Recordedtime));


                }


            }
        }
        
        //Creating list of positions to be checked on
        var positions = new List<Position>();

        positions.Add(new Position("Pos 1", 34.544909f, -102.100843f));
        positions.Add(new Position("Pos 2", 32.345544f, -99.123124f));
        positions.Add(new Position("Pos 3", 33.234235f, -100.214124f));
        positions.Add(new Position("Pos 4", 35.195739f, -95.348899f));
        positions.Add(new Position("Pos 5", 31.895839f, -97.789573f));
        positions.Add(new Position("Pos 6", 32.895839f, -101.789573f));
        positions.Add(new Position("Pos 7", 34.115839f, -100.225732f));
        positions.Add(new Position("Pos 8", 32.335839f, -99.992232f));
        positions.Add(new Position("Pos 9", 33.535339f, -94.792232f));
        positions.Add(new Position("Pos 10", 32.234235f, -100.222222f));



        DateTime now = DateTime.Now;

        //loop trough the positions and find the closest vehicles
        //this can be done in parallel to speed it up, but as per requirements, it will go trough like this
        foreach (var position in positions)
        {
            var closestVehicles = vehicles.OrderBy(v => v.Distance(position.Latitude, position.Longitude)).Take(1);




            Console.WriteLine($"Closest vehicles to {position.Name}");


            foreach (var vehicle in closestVehicles)
            {

                Console.WriteLine($"Vehicle {vehicle.Regnumber} distance: {vehicle.Distance(position.Latitude, position.Longitude)}");
            }

        }

        Console.WriteLine($"Time taken: {DateTime.Now - now}");
    }




    //Changed from string to StringBuilder to reduce the memory usage, as each adding of a char to a string object is creating new string object on the heap
    public static string ReadNullTerminatedString(BinaryReader bininaryReader)
    {
        StringBuilder sb = new StringBuilder();
        char ch;
        while ((int)(ch = bininaryReader.ReadChar()) != 0)
            sb.Append(ch);
        return sb.ToString();
    }

}



