USE VenuePlace
GO

IF (EXISTS (SELECT *
            FROM INFORMATION_SCHEMA.TABLES
            WHERE TABLE_NAME = 'Facilities'))
    BEGIN
        DROP TABLE Facilities
    END
GO

IF(EXISTS(SELECT *
          FROM INFORMATION_SCHEMA.TABLES
          WHERE TABLE_NAME = 'Places'))
    BEGIN
        DROP TABLE Places
    END
GO

IF (EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
                    WHERE TABLE_NAME = 'Owners'))
    BEGIN
        DROP TABLE Owners
    END
GO


CREATE TABLE Owners
(
    OwnerId VARCHAR NOT NULL,
    UserId  VARCHAR NOT NULL,
    CONSTRAINT PK_Owner PRIMARY KEY NONCLUSTERED (OwnerId)
)
GO

CREATE TABLE Places
(
    PlaceId         VARCHAR     NOT NULL,
    Status          VARCHAR     NOT NULL,
    OwnerId         VARCHAR     NOT NULL,
    Address_Country VARCHAR(25) NOT NULL,
    Address_City    VARCHAR(25) NOT NULL,
    Address_Street  VARCHAR(25) NOT NULL,
    Address_Number  INT         NOT NULL,
    CONSTRAINT PK_Place PRIMARY KEY NONCLUSTERED (PlaceId),
    CONSTRAINT FK_Place_Owner FOREIGN KEY (OwnerId) REFERENCES Owners (OwnerId)
        ON DELETE CASCADE
)
GO

CREATE TABLE Facilities
(
    FacilityId  VARCHAR      NOT NULL,
    Description VARCHAR(100) NOT NULL,
    Name        VARCHAR(50)  NOT NULL,
    Quantity    INT,
    PlaceId     VARCHAR      NOT NULL,
    CONSTRAINT PK_Facility PRIMARY KEY (FacilityId),
    CONSTRAINT FK_Place FOREIGN KEY (PlaceId) REFERENCES Places (PlaceId) ON DELETE CASCADE
)
GO