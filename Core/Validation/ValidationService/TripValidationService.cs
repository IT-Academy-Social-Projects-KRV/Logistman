﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.DTO;
using Core.Entities.OfferEntity;
using Core.Entities.PointEntity;
using Core.Entities.TripEntity;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.CustomService;
using Core.Resources;
using Core.Specifications;

namespace Core.Validation.ValidationService
{
    public class TripValidationService : ITripValidationService
    {
        private readonly IRepository<Offer> _offerRepository;
        private readonly IRepository<Trip> _tripRepository;

        public TripValidationService(
            IRepository<Offer> offerRepository, 
            IRepository<Trip> tripRepository)
        {
            _offerRepository = offerRepository;
            _tripRepository = tripRepository;
        }

        public async Task ValidateOffersCheckAsync(
            List<PointTripDTO> points,
            int tripId,
            DateTimeOffset tripDepartureDate)
        {
            foreach (var point in points)
            {
                if (point.OfferId != null)
                {
                    var offer = await _offerRepository
                        .GetBySpecAsync(new OfferSpecification
                            .GetByIdForSpecificTrip((int)point.OfferId, tripId, tripDepartureDate));

                    ExceptionMethods.OfferNullCheck(offer);

                    if (offer.Point.Id != point.Id)
                    {
                        throw new HttpException(
                            ErrorMessages.OfferNotValid + $" Id: {point.OfferId}",
                            HttpStatusCode.BadRequest);
                    }
                }
            }
        }

        public async Task ValidateTripDateAsync(
            DateTimeOffset tripDepartureDate, 
            string creatorId)
        {
            var isTimeSpaceBusy = await _tripRepository.AnyAsync(
                new TripSpecification.GetInTheSameDayByCreatorId(tripDepartureDate, creatorId));

            if (isTimeSpaceBusy)
            {
                throw new HttpException(
                    ErrorMessages.TripIsAlreadyExistsInTheTimeSpace,
                    HttpStatusCode.BadRequest);
            }
        }

        public void ValidatePointsInTrip(Trip trip, List<PointTripDTO> points)
        {
            var newTripPoints = new List<PointTripDTO>();
            var tripPoints = new List<PointData>();

            newTripPoints = points
                .Where(point => point.OfferId == null)
                .ToList();

            tripPoints = trip.Points
                .Where(point => point.OfferId == null)
                .ToList();

            if (newTripPoints.Count != tripPoints.Count)
            {
                throw new HttpException(
                    ErrorMessages.PointsDoNotMatch, 
                    HttpStatusCode.Forbidden);
            }

            foreach (var tripPoint in tripPoints)
            {
                if (!newTripPoints.Any(point => point.Id == tripPoint.Id))
                {
                    throw new HttpException(
                        ErrorMessages.PointsDoNotMatch, 
                        HttpStatusCode.Forbidden);
                }
            }
        }
    }
}
