﻿using Core.Entities.OfferEntity;
using Core.Entities.TripEntity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTO.InviteDTO;

namespace Core.Interfaces.CustomService
{
    public interface IInviteService
    {
        Task ManageTripInvitesAsync(Trip trip, List<Offer> offers);
        Task ManageAsync(ManageInviteDTO manageInviteDTO, string userId);
    }
}
