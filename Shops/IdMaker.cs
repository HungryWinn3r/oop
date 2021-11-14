namespace Shops
{
    public class IdMaker
    {
        private static int _id = 0;

        public static int MakeId()
        {
            return _id++;
        }
    }
}
