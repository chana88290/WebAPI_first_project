namespace Service
{
    public interface IStrongPassword
    {
        //Missing ; at the end of this line: the project doesn't build without it
        int GetStrongPassword(string password)
    }
}