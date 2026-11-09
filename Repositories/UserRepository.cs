using System.Text.Json;
using WebAPI;

namespace Repositories
{
    public class UserRepository
    {
        string filePath = "../Repositories/Users.txt";

        public Userreg AddUser(Userreg user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
        }

        public Userreg GetUser(Userlog user)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Userreg user_2 = JsonSerializer.Deserialize<Userreg>(currentUserInFile);
                    if (user.l_email == user_2.email && user.l_password == user_2.password)
                        return user_2;
                }
                return null;
            }
        }

        public void UpdateUser(int id, Userreg user_1)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Userreg user =
                    JsonSerializer.Deserialize<Userreg>(currentUserInFile);
                    if (user.id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(user_1));
                System.IO.File.WriteAllText(filePath, text);
            }
        }
    }
}
