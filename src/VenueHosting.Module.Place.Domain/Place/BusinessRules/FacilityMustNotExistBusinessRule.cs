using VenueHosting.Module.Place.Domain.Place.Entities;
using VenueHosting.Module.Place.Domain.Place.Exceptions;
using VenueHosting.SharedKernel.BLSpecifications;

namespace VenueHosting.Module.Place.Domain.Place.BusinessRules;

internal sealed class FacilityMustNotExistBusinessRule : IBusinessRule
{
    private readonly IEnumerable<Facility> _existingFacilities;
    private readonly IEnumerable<Facility> _addingFacilities;

    public FacilityMustNotExistBusinessRule(IEnumerable<Facility> existingFacilities,
        IEnumerable<Facility> addingFacilities)
    {
        _addingFacilities = addingFacilities;
        _existingFacilities = existingFacilities;
    }

    public void CheckIfSatisfied()
    {
        HashSet<Facility> existingSet = _existingFacilities.ToHashSet();
        HashSet<Facility> addingSet = _addingFacilities.ToHashSet();

        if (existingSet.Overlaps(addingSet))
        {
            throw new FacilityDuplicateFoundException();
        }
    }
}