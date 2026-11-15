namespace Service
{
    public interface IStrongPassword
    {
        //fix: added the missing semicolon, the interface did not compile
        int GetStrongPassword(string password);
    }
}