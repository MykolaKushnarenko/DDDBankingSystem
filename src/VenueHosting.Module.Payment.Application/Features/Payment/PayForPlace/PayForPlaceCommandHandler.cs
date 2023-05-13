// namespace VenueHosting.Module.Payment.Application.Features.Payment.PayForPlace;
//
// public class PayForPlaceCommandHandler : IRequestHandler<PayForPlaceCommand, Unit>
// {
//
//
//     public PayForPlaceCommandHandler()
//     {
//
//     }
//
//     public async Task<Unit> Handle(PayForPlaceCommand request, CancellationToken cancellationToken)
//     {
//         //Send notification
//         await _atomicScope.CommitAsync(cancellationToken);
//
//         return Unit.Value;
//     }
// }