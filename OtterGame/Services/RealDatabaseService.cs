using Firebase.Database;
using Firebase.Database.Query;
using OtterGame.Entities;
using OtterGameSetup.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OtterGameSetup.Services
{
    class RealDatabaseService
    {
        private FirebaseClient FbaseClient { get; set; }

        public RealDatabaseService()
        {
            FbaseClient = new FirebaseClient("https://senacbaset5.firebaseio.com/");
        }

        public async Task<ScoreData> GET()
        {
            var register = await FbaseClient
                .Child("Score")
                .OrderByKey()
                .StartAt("search")
                .OnceAsync<ScoreData>();

            return (register as ScoreData);
        }

        public async Task Post(Player player, ScoreData score)
        {
            var register = await FbaseClient
                .Child("Placar")
                .PostAsync();
        }
    }
}