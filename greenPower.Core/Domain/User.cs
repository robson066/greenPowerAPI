using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace greenPower.Core.Domain
{
    class User
    {
        private static readonly Regex UserRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string UserName { get; protected set; }
        public string FullName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public User(Guid id, string email, string password, string salt,
            string username, string fullname)
        {
            Id = id;
            SetEmail(email);
            SetPassword(password, salt);
            SetUsername(username);
            SetFullname(fullname);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email can not be null");
            }

            if (Email == email) return;
            else Email = email.ToLowerInvariant();

            UpdatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new Exception("Username can not be empty.");
            }

            if (!UserRegex.IsMatch(username))
            {
                throw new Exception("Username is invalid.");
            }

            UserName = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetFullname(string fullname)
        {
            if (String.IsNullOrEmpty(fullname))
            {
                throw new Exception("Name can not be empty.");
            }

            FullName = fullname.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, string salt)
        {
            if (String.IsNullOrEmpty(password))
            {
                throw new Exception("Password can not be empt.");
            }

            if (String.IsNullOrEmpty(salt))
            {
                throw new Exception("Salt can not be empty.");
            }

            if (password.Length < 4 || password.Length > 90)
            {
                throw new Exception("Password must contain at least 4 and must be no longer than 90 characters.");
            }

            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
