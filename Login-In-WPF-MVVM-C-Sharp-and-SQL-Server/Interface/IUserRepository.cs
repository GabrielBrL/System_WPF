using Login_In_WPF_MVVM_C_Sharp_and_SQL_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Login_In_WPF_MVVM_C_Sharp_and_SQL_Server.Interface
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Delete(int id);
        UserModel GetById(int id);
        UserModel GetByName(string name);
        IEnumerable<UserModel> GetAll();
    }
}
