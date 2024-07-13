﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Entity;

namespace Data_Access_Layer
{
    public class DALLogin
    {
        private AppDbContext _context;

        public DALLogin(AppDbContext context)
        {
            _context = context;
        }

        public User LoginUser(User user)
        {
            User userObj = new User();
            try
            {
                //var query = from u in _context.User
                //            where u.EmailAddress == user.EmailAddress
                //            select new
                //            {
                //                u.Id,
                //                u.FirstName,
                //                u.LastName,
                //                u.Password
                //            };
                var query = _context.User.Where(u => u.EmailAddress == user.EmailAddress);
                var userData = query.FirstOrDefault();
                if (userData != null)
                {
                    if (userData.Password == user.Password)
                    {
                        userObj.Id = userData.Id;
                        userObj.FirstName = userData.FirstName;
                        userObj.LastName = userData.LastName;
                        userObj.Message = "Login Successfully";
                    }
                    else
                    {
                        userObj.Message = "Incorrect Passoword";
                    }
                }
                else
                {
                    userObj.Message = "EmailAddress is not found.";
                }
            }
            catch (Exception ex)
            {
                userObj.Message = ex.Message;
            }
            return userObj;
        }
    }
}
