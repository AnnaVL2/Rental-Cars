using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Threading.Tasks;

namespace MySpace
{
    public class UsersLogic : BaseLogic
    {
        public List<UserDTO> GetAllUsers()
        {
            var q = from u in DB.Users
                    join r in DB.Roles on u.RoleID equals r.RoleID
                    select new UserDTO
                    {
                        userID = u.UserID,
                        roleID = u.RoleID,
                        roleTitle = r.RoleTitle,
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        userIDNumber = u.UserIDNumber,
                        userName = u.UserName,
                        birthDate = u.BirthDate,
                        gender = u.Gender,
                        email = u.Email,
                        password = u.Password,
                        image = u.Image
                    };

            return q.ToList();
        }

        public UserDTO GetOneUser(int id)
        {
            var q = from u in DB.Users
                    where u.UserID == id
                    select new UserDTO
                    {
                        userID = u.UserID,
                        roleID = u.RoleID,
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        userIDNumber = u.UserIDNumber,
                        userName = u.UserName,
                        birthDate = u.BirthDate,
                        gender = u.Gender,
                        email = u.Email,
                        password = u.Password,
                        image = u.Image
                    };
            return q.SingleOrDefault();
        }

        //add new user
        public UserDTO AddUser(UserDTO user)
        {
            User userToAdd = new User
            {
                RoleID = user.roleID,
                FirstName = user.firstName,
                LastName = user.lastName,
                UserIDNumber = user.userIDNumber,
                UserName = user.userName,
                BirthDate = user.birthDate,
                Gender = user.gender,
                Image = user.image,
                Email = user.email,
                Password = FormsAuthentication.HashPasswordForStoringInConfigFile(user.password, "sha1"),
            };

            DB.Users.Add(userToAdd);
            DB.SaveChanges();
            user.userID = userToAdd.UserID;
            return user;
        }

        //save img in DB
        public void SaveImage(int id, string fileName)
        {
            User imageToAdd = DB.Users.Where(u => u.UserID == id).SingleOrDefault();
            imageToAdd.Image = fileName;
            DB.SaveChanges();
        }


        // modify user - manager access
        public UserDTO UpdateUser(UserDTO user)
        {
            User userToUpdate = DB.Users
                .Where(u => u.UserID == user.userID).SingleOrDefault();

            if (userToUpdate == null)
                return null;

            userToUpdate.UserName = user.userName;
            userToUpdate.RoleID = user.roleID;
            userToUpdate.FirstName = user.firstName;
            userToUpdate.LastName = user.lastName;
            userToUpdate.UserIDNumber = user.userIDNumber;
            userToUpdate.BirthDate = user.birthDate;
            userToUpdate.Gender = user.gender;
            userToUpdate.Email = user.email;
            userToUpdate.Password = user.password;
            DB.SaveChanges();
            return user;
        }

        // delete user - manager access
        public void DeleteUser(int id)
        {
            User userToDelete = DB.Users
                 .Where(u => u.UserID == id).SingleOrDefault();
            if (userToDelete != null)
            {
                DB.Users.Remove(userToDelete);
                DB.SaveChanges();
            }
        }

        //login
        public UserDTO Login(string userName, string password)
        {
            var hash = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "sha1");
                //HashPasswordForStoringInConfigFile(password, "sha1");
            User u = DB.Users.Where(us => us.UserName.Equals(userName) && 
            us.Password.Equals(hash)).FirstOrDefault();
            return new UserDTO
            {
                userID = u.UserID,
                firstName = u.FirstName,
                lastName = u.LastName,
                userName = u.UserName,
                birthDate = u.BirthDate,
                gender = u.Gender,
                email = u.Email,
                password = u.Password,
                image = u.Image,
                roleID = u.RoleID,

            };
        }

        public List<RoleDTO> GetAllRoles()
        {
            var q = from r in DB.Roles
                    select new RoleDTO
                    {
                        roleID = r.RoleID,
                        roleTitle = r.RoleTitle
                    };
            return q.ToList();
        }
    }
}
