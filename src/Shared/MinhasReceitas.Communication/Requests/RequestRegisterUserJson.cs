﻿namespace MinhasReceitas.Communication.Requests
{
    public class RequestRegisterUserJson
    {
        public string Nome {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
