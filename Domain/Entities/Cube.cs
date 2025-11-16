namespace Domain.Entities
{

    //ENTIDAD DEL CUBO Y SUS VARIABLES Y CONSTRUCTOR.
    public class Cube : Entity
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Size { get; set; }

        public Cube(float pX, float pY, float pZ, float pSize)
        {
            X = pX; Y = pY; Z = pZ; Size = pSize;
        }
    }
}
