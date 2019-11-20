using Firebase.Database;
using Firebase.Database.Query;
using OtterGameSetup.Data;
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

        public async Task GET()
        {
            var table = await FbaseClient
                .Child("Score")
                .OrderByKey()
                .StartAt("search")
                .OnceAsync<Score>();
        }
    }
}