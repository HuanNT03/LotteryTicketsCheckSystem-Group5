﻿namespace LotteryBackend.DTOs
{
    public class UpdateUserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // Admin or User
    }
}
