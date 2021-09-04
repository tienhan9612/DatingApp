
using System;

namespace Ecommerce_App.Models
{
    public class User 
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public string PassWord { get; set; }

    }
}