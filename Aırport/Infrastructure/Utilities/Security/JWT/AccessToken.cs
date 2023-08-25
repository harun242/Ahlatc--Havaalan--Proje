﻿namespace Infrastructure.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<string> Claims { get; set; }
    }
}
