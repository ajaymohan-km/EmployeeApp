﻿namespace webapi.Model
{
    public class Response
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public dynamic? Data { get; set; }
    }

}
