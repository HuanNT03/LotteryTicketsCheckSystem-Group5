using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LotteryBackend.Models
{
    public class Role : IdentityRole
    {
        public string Description { get; set; } //admin or user
    }
}
