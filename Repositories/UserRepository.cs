using System.Text.Json;
using WebAPI;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        string filePath = "../Repositories/Users.txt";

        public async Task<Userreg> GetAsync(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    Userreg user = JsonSerializer.Deserialize<Userreg>(currentUserInFile);
                    if (user != null && user.id == id)
                        return user;
                }
            }
            return null;
        }

        public async Task<Userreg> PostAsync(Userreg user)
        {
            int numberOfUsers = await System.IO.File.ReadLinesAsync(filePath).CountAsync();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            await System.IO.File.AppendAllTextAsync(filePath, userJson + Environment.NewLine);
            return user;
        }

        public async Task<Userreg> PostLoginAsync(Userlog user)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    Userreg user_2 = JsonSerializer.Deserialize<Userreg>(currentUserInFile);
                    if (user.l_email == user_2.email && user.l_password == user_2.password)
                        return user_2;
                }
                return null;
            }
        }

        public async Task PutAsync(int id, Userreg user_1)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    Userreg user =
                    JsonSerializer.Deserialize<Userreg>(currentUserInFile);
                    if (user.id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = await System.IO.File.ReadAllTextAsync(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(user_1));
                System.IO.File.WriteAllText(filePath, text);
            }
        }
    }
}
