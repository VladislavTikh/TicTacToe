﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateTicTacToe.ViewModels
{
    public class ProfilePageVM
    {
        public ProfilePageVM(User currentUser)
        {
            Users = new List<User> { currentUser };
            CurrentUser = currentUser;
            GitHubProfile = "https://github.com/VladislavTikh/TicTacToe";
        }

        public User CurrentUser { get; set; }

        public List<User> Users { get; private set; }

        public string GitHubProfile { get; set; }

        public string CurrentTime { get => DateTime.Now.ToString(); }

    }
}
