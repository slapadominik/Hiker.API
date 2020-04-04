namespace Hiker.Application.Common.Models
{
    public struct LatLong
    {
        public double Latitude { get; }
        public double Longitude { get; }

        public LatLong(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
