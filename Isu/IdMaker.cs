namespace Isu
{
    public class IdMaker
    {
        private static int _studentId = 0;

        public static int MakeId()
        {
            return _studentId++;
        }
    }
}