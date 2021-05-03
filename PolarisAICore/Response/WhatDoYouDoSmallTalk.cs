using Serilog;
using System;

namespace PolarisAICore.Response {
    class WhatDoYouDoSmallTalk {
        static readonly Random _random = new Random();

        static readonly String[] _noEntityResponses =
        {
            "I mostly stay at the clouds and help nice people!",
            "I like drinking tea while looking at the beautiful Sky.",
            "I love helping people and telling funny jokes!"
        };

        public static String SetResponse(Utterance u) {
            Log.Logger.Information($"Response for utterance with code: {u.Code}. Determined to be WhatDoYouDoSmallTalk");
            return _noEntityResponses[_random.Next(_noEntityResponses.Length)];
        }
    }
}
