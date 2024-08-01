namespace excercise_api.Constants;

public static class SqlQueries
{
    public const string GetRecord = @"
        SELECT 
            r.Id,
            r.Timestamp,
            w.Value AS Weight, 
            bf.Value AS BodyFat,
            fm.Value AS FatMass,
            lm.Value AS LeanMass
        FROM Record r
        LEFT JOIN Weight w ON r.Id = w.RecordId
        LEFT JOIN BodyFat bf ON r.Id = bf.RecordId
        LEFT JOIN FatMass fm ON r.Id = fm.RecordId
        LEFT JOIN LeanMass lm ON r.Id = lm.RecordId";

    public const string AddRecord = @"
        BEGIN TRAN
        DECLARE @RecordId int;
        INSERT INTO Record (Timestamp) VALUES (@Timestamp);
        SET @RecordId = scope_identity();

        IF(@Weight <> 0)
            INSERT INTO Weight (Value, RecordId) VALUES (@Weight, @RecordId)
        IF(@BodyFat <> 0)
            INSERT INTO BodyFat (Value, RecordId) VALUES (@BodyFat, @RecordId)
        IF(@FatMass <> 0)
            INSERT INTO FatMass (Value, RecordId) VALUES (@FatMass, @RecordId)
        IF(@LeanMass <> 0)
            INSERT INTO LeanMass (Value, RecordId) VALUES (@LeanMass, @RecordId)
        COMMIT TRAN
    ";
}
