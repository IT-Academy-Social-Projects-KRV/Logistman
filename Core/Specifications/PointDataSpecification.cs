﻿using Ardalis.Specification;
using Core.Entities.PointEntity;
using System.Collections.Generic;
using System.Linq;

namespace Core.Specifications
{
    public static class PointDataSpecification
    {
        internal class GetByIds : Specification<PointData>
        {
            public GetByIds(List<int> pointsIds)
            {
                Query.Where(p => pointsIds.Contains(p.Id));
            }
        }

        internal class GetByTripId : Specification<PointData>
        {
            public GetByTripId(int tripId)
            {
                Query
                    .Where(p => p.TripId == tripId)
                    .OrderBy(p => p.Order);
            }
        }

        internal class GetPointsWithoutTripAndOffer : Specification<PointData>
        {
            public GetPointsWithoutTripAndOffer()
            {
                Query
                    .Where(p => p.TripId == null && p.OfferId == null);
            }
        }
    }
}
