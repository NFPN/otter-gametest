using System;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace OtterGameSetup.Data
{
    class SQLiteDao
    {
        private SQLiteConnection Connection { get; set; }

        public SQLiteDao()
        {
            Connection = new SQLiteConnection("Data Source = GameBD.sqlite; Version = 3; ");
            var cmd = Connection.CreateCommand();
        }

        public async Task CreateTablesAsync()
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Scores(Id varchar(50), Player varchar(50), Score int)";
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> IncludeScore(string player, int score)
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.CommandText = "INSTER INTO Placar(Id, Player, Score) VALUES(@id, @player, @score)";
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@player", player);
                    cmd.Parameters.AddWithValue("@score", score);
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable ListScore()
        {
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Scores";

                    var dataTable = new DataTable();
                    var adapter = new SQLiteDataAdapter(cmd.CommandText, Connection);
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}