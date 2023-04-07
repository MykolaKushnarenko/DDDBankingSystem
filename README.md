# DDDBankingSystem

### Table doc:
// Docs: https://www.dbml.org/docs
 ```
//--------------- User 
Table User {
    Id integer [primary key]
    Info varchar
}

//--------------- Owner
Table Owner {
    Id integer [primary key]
    UserId integer
}

Ref: Owner.UserId > User.Id

//--------------- Lessee
Table Lessee {
    Id integer [primary key]
    UserId integer
}

Ref: Lessee.UserId > User.Id

//--------------- Place
Table Place {
    Id integer [primary key]
    OwnerId integer
    AddressCountry varchar
    AddressCity varchar
    AddressStreet bool
    AddressNumber integer
}

Table Facility {
    Id integer [primary key]
    Description varchar
    Name varchar
    Quantity integer
    PlaceId integer
}
Ref: Place.OwnerId > Owner.Id
Ref: Facility.PlaceId > Place.Id

//--------------- Venue
Table Venue {
    Id integer [primary key]
    OwnerId integer
    LeseeId integer
    PlaceId integer
    Desc varchar
    EventName varchar
    IsPublic bool
}

Table Activity {
    Id integer [primary key]
    Name varchar
    Desc varchar
}

Table VenueActivities {
    Id integer [primary key]
    VenueId integer
    ActivityId integer
}
Ref: Venue.OwnerId > Owner.Id
Ref: Venue.LeseeId > Lesee.Id
Ref: Venue.PlaceId > Place.Id

Ref: VenueActivities.VenueId > Venue.Id
Ref: VenueActivities.ActivityId > Activity.Id

//--------------- AttendeeReview
Table VenueReview {
    Id integer [primary key]
    AttendeeId integer
    VenueId integer
    Comment varchar
}
Ref: VenueReview.AttendeeId > Attendee.Id
Ref: VenueReview.VenueId > Venue.Id

//--------------- Attendee
Table Attendee {
    Id integer [primary key]
    UserId integer
    Name varchar
    Desc varchar
}

Table AttendeeVenues {
    Id integer [primary key]
    AttendeeId integer
    VenueId integer
}

Ref: AttendeeVenues.Id > Venue.Id
Ref: AttendeeVenues.AttendeeId > Attendee.Id
Ref: Attendee.UserId > User.Id

//--------------- AttendeeReview aggretage
Table AttendeeReview {
    Id integer [primary key]
    AttendeeId integer
    VenueId integer
    Comment varchar
}

Ref: AttendeeReview.AttendeeId > Attendee.Id
Ref: AttendeeReview.VenueId > Venue.Id

//--------------- AttendeeReview aggretage
Table Bill {
    Id integer [primary key]
    AttendeeId integer
    VenueId integer
}

Ref: Bill.AttendeeId > Attendee.Id
Ref: Bill.VenueId > Venue.Id

//--------------- AttendeeReview aggretage
Table Reservation {
    Id integer [primary key]
    AttendeeId integer
    VenueId integer
    BillId integer
    DateTme time
    Amount integer
}

Ref: Reservation.AttendeeId > Attendee.Id
Ref: Reservation.VenueId > Venue.Id
Ref: Reservation.VenueId > Bill.Id
 ```