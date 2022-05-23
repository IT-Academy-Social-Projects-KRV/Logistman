﻿using Core.DTO.TripDTO;
using System.Threading.Tasks;

namespace Core.Interfaces.CustomService
{
    public interface ITripService
    {
        Task<bool> CheckIsTripExistsById(int tripId);
        Task CreateTripAsync(CreateTripDTO createTripDTO, string creatorId);
    }
}
