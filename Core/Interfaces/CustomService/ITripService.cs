﻿using Core.DTO;
using Core.DTO.TripDTO;
using Core.Helpers;
using NetTopologySuite.Geometries;
using System.Threading.Tasks;

namespace Core.Interfaces.CustomService
{
    public interface ITripService
    {
        Task<bool> CheckIsTripExistsById(int tripId);
        Task CreateTripAsync(CreateTripDTO createTripDTO, string creatorId);
        Task<PaginatedList<RouteDTO>> GetAllRoutesAsync(PaginationFilterDTO paginationFilter);
        Task<LineString> GetRouteGeographyDataAsync(int routeId);
        Task<PaginatedList<RoutePreviewDTO>> GetUserRoutesAsync(
            PaginationFilterDTO paginationFilter, string tripCreatorId);
        Task ManageOffersTripAsync(ManageTripDTO manageTrip);
        Task<TripInfoDTO> GetTripByIdAsync(int tripId);
    }
}
