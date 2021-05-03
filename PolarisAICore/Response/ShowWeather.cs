﻿using Serilog;
using System;

namespace PolarisAICore.Response {
    class ShowWeather {
        static readonly Random _random = new Random();

        static readonly String[] _noEntityResponses =
        {
            "Of course! Here's today's forecast:",
            "Sure! Here's the weather forecast for today:",
            "Alright! Here's today's forecast:",
            "You don't have to ask again! Here's the weather forecast for today:",
            "Sure, the day will be:",
            "Here it is:",
            "Got it, this is the forecast:",
            "Sure thing, the weather for today is:"
        };

        public static String SetResponse(Utterance u) {
            Log.Logger.Information($"Response for utterance with code: {u.Code}. Determined to be ShowWeather");
            return _noEntityResponses[_random.Next(_noEntityResponses.Length)];
        }
    }
}
