

namespace Wondwear.Application.Features.Bewohners.Commands.Update;

public record BewohnerUpdateRequest(int? BewohnerId,
                                    string userName, 
                                    int ZimmerNummer,
                                    string name,
                                    string nachName,
                                    DateTime geburtsdatum,
                                    DateTime einzugsdatum,
                                    string telefonnummer) :IRequest<Result>;
