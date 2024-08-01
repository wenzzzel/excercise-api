using Microsoft.Data.SqlClient;
using excercise_api.Models;
using excercise_api.Constants;

namespace excercise_api.Repositories;

public interface IRecordRepository
{
    IEnumerable<RecordDto> GetRecords();
    void AddRecord(RecordDto record);
}

public class RecordRepository : IRecordRepository
{
    public IEnumerable<RecordDto> GetRecords()
    {
        var records = new List<RecordDto>();

        using (var connection = new SqlConnection("<masked>"))
        {
            connection.Open();

            using (var command = new SqlCommand(SqlQueries.GetRecord, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var recordDto = new RecordDto
                        {
                            Id = reader.GetValue(0) == DBNull.Value ? null : reader.GetInt32(0),
                            Timestamp = reader.GetValue(1) == DBNull.Value ? null : reader.GetDateTime(1),
                            Weight = reader.GetValue(2) == DBNull.Value ? null : reader.GetDecimal(2),
                            BodyFat = reader.GetValue(3) == DBNull.Value ? null : reader.GetDecimal(3),
                            FatMass = reader.GetValue(4) == DBNull.Value ? null : reader.GetDecimal(4),
                            LeanMass = reader.GetValue(5) == DBNull.Value ? null : reader.GetDecimal(5)
                        };

                        records.Add(recordDto);
                    }
                }
            }
        }

        return records;
    }

    public void AddRecord(RecordDto record)
    {
        using (var connection = new SqlConnection("<masked>"))
        {
            connection.Open();

            using (var command = new SqlCommand(SqlQueries.AddRecord, connection))
            {
                command.Parameters.AddWithValue("@Weight", record.Weight ?? 0);
                command.Parameters.AddWithValue("@BodyFat", record.BodyFat ?? 0);
                command.Parameters.AddWithValue("@FatMass", record.FatMass ?? 0);
                command.Parameters.AddWithValue("@LeanMass", record.LeanMass ?? 0);
                command.Parameters.AddWithValue("@Timestamp", record.Timestamp);

                command.ExecuteNonQuery();
            }
        }
    }
}