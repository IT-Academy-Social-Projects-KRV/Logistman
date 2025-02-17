﻿using Ardalis.Specification;
using Core.DTO;
using Core.Entities.OfferEntity;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Specifications
{
    public static class OfferSpecification
    {
        internal class GetById : Specification<Offer>, ISingleResultSpecification<Offer>
        {
            public GetById(int offerId, string userId)
            {
                Query
                    .Where(o => o.Id == offerId && o.OfferCreatorId == userId)
                    .Include(o => o.Point)
                    .Include(o => o.OfferRole)
                    .Include(o => o.GoodCategory);
            }
        }

        internal class GetByIdForSpecificTrip : Specification<Offer>,
                                                ISingleResultSpecification<Offer>
        {
            public GetByIdForSpecificTrip(
                int offerId, int tripId, DateTimeOffset tripDepartureDate)
            {
                Query
                    .Where(o => o.Id == offerId
                                     && !o.IsClosed
                                     && (o.RelatedTripId == tripId || o.RelatedTripId == null)
                                     && o.StartDate <= tripDepartureDate)
                    .Include(o => o.Point);
            }
        }

        internal class GetByUserId : Specification<Offer>
        {
            public GetByUserId(string userId, PaginationFilterDTO paginationFilter)
            {
                Query
                    .Where(o => o.OfferCreatorId == userId)
                    .Include(o => o.Point)
                    .Include(o => o.OfferRole)
                    .Include(o => o.GoodCategory)
                    .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                    .Take(paginationFilter.PageSize);
            }
        }

        internal class GetOffersNearRoute : Specification<Offer>
        {
            public GetOffersNearRoute(
                Geometry routeGeography,
                double dist,
                DateTimeOffset tripDepartureDate)
            {
                Query
                    .Where(offer => offer.Point.Location.IsWithinDistance(routeGeography, dist)
                                    && !offer.IsClosed
                                    && offer.StartDate <= tripDepartureDate)
                    .Include(offer => offer.Point)
                    .Include(offer => offer.OfferRole)
                    .Include(offer => offer.GoodCategory);
            }
        }

        internal class GetOfferByIds : Specification<Offer>
        {
            public GetOfferByIds(List<int> offersIds)
            {
                Query
                    .Where(o => offersIds.Contains(o.Id))
                    .Include(o => o.User);
            }
        }

        internal class GetFullyByTripId : Specification<Offer>
        {
            public GetFullyByTripId(int tripId)
            {
                Query
                    .Where(o => o.RelatedTripId == tripId)
                    .Include(o => o.Point)
                    .Include(o => o.OfferRole)
                    .Include(o => o.GoodCategory)
                    .AsNoTracking();
            }
        }

        internal class GetByTripId : Specification<Offer>
        {
            public GetByTripId(int tripId)
            {
                Query
                    .Where(o => o.RelatedTripId == tripId)
                    .AsNoTracking();
            }
        }

        internal class GetOpenByUserId : Specification<Offer>
        {
            public GetOpenByUserId(string userId)
            {
                Query
                    .Where(o => o.OfferCreatorId == userId && !o.IsClosed)
                    .Include(o => o.Point);
            }
        }

        public class GetOpenByIdAndUserIdWithoutTrip : Specification<Offer>,
                                                       ISingleResultSpecification<Offer>
        {
            public GetOpenByIdAndUserIdWithoutTrip(int offerId, string userId)
            {
                Query
                    .Where(o => o.Id == offerId
                           && o.OfferCreatorId == userId
                           && !o.IsClosed
                           && o.RelatedTripId == null)
                    .Include(o => o.Point);
            }
        }

        public class GetByIdWithActiveTrip : Specification<Offer>,
                                             ISingleResultSpecification<Offer>
        {
            public GetByIdWithActiveTrip(int offerId, string userId)
            {
                Query
                    .Where(o => o.Id == offerId
                        && o.Trip.TripCreatorId == userId
                        && o.Trip.IsActive
                        && !o.IsAnsweredByDriver)
                    .Include(o => o.Trip);
            }
        }

        public class GetByIdWithTrip : Specification<Offer>,
                                       ISingleResultSpecification<Offer>
        {
            public GetByIdWithTrip(int offerId, string userId)
            {
                Query
                    .Where(o => o.Id == offerId
                        && o.OfferCreatorId == userId
                        && !o.IsAnsweredByCreator)
                    .Include(o => o.Trip);
            }
        }

        internal class GetToConfirmByTripAndUserIds : Specification<Offer>
        {
            public GetToConfirmByTripAndUserIds(int tripId, string userId)
            {
                Query
                    .Where(o => o.Trip.TripCreatorId == userId
                             && o.RelatedTripId == tripId)
                    .OrderBy(o => o.Point.Order)
                    .Include(o => o.GoodCategory)
                    .Include(o => o.User)
                    .Include(o => o.Point)
                    .Include(o => o.OfferRole);
            }
        }

        internal class GetWithTripByUserId : Specification<Offer>
        {
            public GetWithTripByUserId(string userId, PaginationFilterDTO paginationFilter)
            {
                Query
                    .Where(o => o.OfferCreatorId == userId
                    && o.RelatedTripId != null
                    && (o.Trip.IsActive
                    || o.Trip.IsEnded))
                    .Include(o => o.Point)
                    .Include(o => o.OfferRole)
                    .Include(o => o.GoodCategory)
                    .Include(o => o.Trip)
                    .Include(o => o.Trip.User)
                    .Include(o => o.Trip.Car)
                    .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                    .Take(paginationFilter.PageSize);
            }
        }
    }
}
