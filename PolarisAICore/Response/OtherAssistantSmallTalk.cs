using Serilog;
using System;

namespace PolarisAICore.Response {
    class OtherAssistantSmallTalk {
        static readonly Random _random = new Random();

        static readonly String[] _noEntityResponses =
        {
            "I know her! Even if she doesn't have my brightness, I respect her usefulness.",
            "Her name isn't as cute as mine, but that's asking too much anyway.",
            "I respect her! The work we do is hard, you know?",
            "I like her so much, that I would give her the second place easily!"
        };

        public static String SetResponse(Utterance u) {
            Log.Logger.Information($"Response for utterance with code: {u.Code}. Determined to be OtherAssistantSmallTalk");
            return _noEntityResponses[_random.Next(_noEntityResponses.Length)];
        }
    }
}
