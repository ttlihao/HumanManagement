using HumanManagement.DataAccess.Models;
using HumanManagement.DataAccess.UnitOfWork.Interfaces;

namespace HumanManagement.Services.Interfaces
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> createUser(User user)
        {
            if(user != null) {
            await _unitOfWork.Users.Add(user);
                var result = _unitOfWork.Save();
                if(result > 0){
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> deleteUser(int id)
        {
            if(id > 0) { 
            var user = await _unitOfWork.Users.GetById(id);
                if(user != null)
                {
                    _unitOfWork.Users.Delete(user);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;

                }
            }
            return false;
        }

        public async Task<User> getUser(int id)
        {
            if (id > 0 )
            {
                var user = await _unitOfWork.Users.GetById(id);
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<User> getUserByUserName(string userName)
        {
            if (userName != null)
            {
                var user = await _unitOfWork.Users.GetUserByName(userName);   
                if(user != null)
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<IEnumerable<User>> getUsers()
        {
            var usersList = await _unitOfWork.Users.GetAll();
            return usersList;
        }

        public async Task<bool> updateUser(User user)
        {
            if(user != null)
            {
                var userUp = await _unitOfWork.Users.GetById(user.UserId);
                if(userUp != null)
                {
                    userUp = user;
                    _unitOfWork.Users.Update(userUp);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
