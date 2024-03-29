﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mission9.Infrastructure
{
    public static class SessionExtensions //static changes it for the object everywhere
    {
        public static void SetJson (this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value)); //this allows use to set a json object

        }

        public static T GetJson<T> (this ISession session, string key)
        {
            var sessionData = session.GetString(key); //this will pull the info from the json object
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }

    }
}
