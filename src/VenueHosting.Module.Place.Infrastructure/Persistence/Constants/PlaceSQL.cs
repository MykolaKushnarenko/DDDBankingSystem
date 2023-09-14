namespace VenueHosting.Module.Place.Infrastructure.Persistence.Constants;

internal static class PlaceSql
{
    internal const string Exists = """
                                       IF (EXISTS (SELECT * FROM Places WHERE PlaceId = '@PlaceId'))
                                       BEGIN
                                           SELECT 1;
                                       END
                                           ELSE
                                       BEGIN
                                           SELECT 0;
                                       END
                                   """;

    internal const string FetchAll = "SELECT * FROM Places";

    internal const string Fetch = """
                                       SELECT
                                           places.PlaceId AS Id, Status, OwnerId, Address_Country, Address_City,
                                           Address_Number, facility.FacilityId, facility.Description, facility.Name, facility.Quantity
                                       FROM Places places
                                       INNER JOIN Facilities facility on places.PlaceId = facility.PlaceId
                                       WHERE places.PlaceId = @PlaceId
                                       """;

    internal const string Insert =
        """
        INSERT INTO Places (PlaceId, Status, OwnerId, Address_Country, Address_City, Address_Street, Address_Number)
        OUTPUT INSERTED.PlaceId
            VALUES(@PlaceId, @Status, @OwnerId, @Address_Country, @Address_City, @Address_Street, @Address_Number)
        """;

    internal const string Update =
        """
        UPDATE Places SET Status= @Status, OwnerId= @OwnerId, Address_Country= @Address_Country, Address_City= @Address_City, Address_Street= @Address_Street, Address_Number = @Address_Number)
        WHERE PlaceId=@PlaceId
        """;

    internal const string InsertFacility = """
                                           INSERT INTO Facilities (FacilityId, Description, Name, Quantity, PlaceId)
                                           VALUES (@FacilityId, @Description, @Name, @Quantity, @PlaceId)
                                           """;
}