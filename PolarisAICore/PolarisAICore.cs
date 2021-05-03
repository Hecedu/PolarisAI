using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using PolarisAICore.Properties;
using Serilog;

namespace PolarisAICore {
	public class PolarisAICore {

        static readonly PolarisAIDatabaseConnection _database = new PolarisAIDatabaseConnection(
            Resources.ResourceManager.GetString("DBsource"),
            Resources.ResourceManager.GetString("DBname"),
            Resources.ResourceManager.GetString("DBlogin"),
            Resources.ResourceManager.GetString("DBpassword"));

        static void Main() {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName)
                .AddJsonFile("appsettings.json")
                .Build();
            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(configuration)
               .CreateLogger();
            while (true) {
                Log.Logger.Information("PolarisAI console instance started.");
                Console.WriteLine("Enter a test query:");
                Console.WriteLine(CognizeDebug(Console.ReadLine()));
            }
        }

        public static JObject Cognize(String query){
            Log.Logger.Debug($"DEBUG: Cognize called with query: {query}");
            Utterance utterance = new Utterance(
                IntentClassificatorSingleton.Instance.Cognize(query));
            utterance.Response = Response.ResponseController.SetResponse(utterance);

            _database.InsertRequestDetails(utterance);

            return utterance.GetResponse();
        }

        public static String CognizeDebug(String query) {
            Log.Logger.Debug($"DEBUG: CognizeDebug called with query: {query}");
            Utterance utterance = new Utterance(
                IntentClassificatorSingleton.Instance.Cognize(query));
            utterance.Response = Response.ResponseController.SetResponse(utterance);

            return utterance.GetDebugLog();
        }
	}
}
