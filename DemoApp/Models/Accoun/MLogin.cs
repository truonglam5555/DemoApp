using System;
using System.Collections.Generic;
using DemoApp.Models.Base;

namespace DemoApp.Models.Accoun
{
    public class MLogin_RQ
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class MLogin
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Alias { get; set; }
        public string HoDem { get; set; }
        public string Ten { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string ForManager { get; set; }
        public string ForGroup { get; set; }
        public int ForType { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime? DateCreated { get; set; }
    }

    public class MLogin_RS: MBaseResponse<List<MLogin>>
    {

    }
}
