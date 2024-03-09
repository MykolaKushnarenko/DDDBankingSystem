namespace VenueHosting.SharedKernel.Domain;

public interface IAuditable
{
    public DateTime CreatedAtDateTime { get; set; }

    public DateTime? UpdatedAtDateTime { get; set; }
}