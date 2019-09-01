﻿using System;
using System.Collections.Generic;

namespace Screeps_API
{
    [Serializable]
    public class ServerCache
    {
        public string Name { get; set; }

        public Address Address = new Address();
        public Credentials Credentials = new Credentials();
        public Dictionary<string, string> Terrain = new Dictionary<string, string>();
        public bool SaveCredentials;

        public int LikeCount { get; set; }

        
    }
}