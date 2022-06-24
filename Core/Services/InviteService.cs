﻿using AutoMapper;
using Core.DTO;
using Core.DTO.InviteDTO;
using Core.Entities.InviteEntity;
using Core.Entities.OfferEntity;
using Core.Entities.TripEntity;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.CustomService;
using Core.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class InviteService : IInviteService
    {
        private readonly IRepository<Invite> _inviteRepository;
        private readonly IRepository<Trip> _tripRepository;
        private readonly IRepository<Offer> _offerRepository;
        private readonly IMapper _mapper;

        public InviteService(
            IRepository<Invite> inviteRepository,
            IRepository<Trip> tripRepository,
            IRepository<Offer> offerRepository,
            IMapper mapper)
        {
            _inviteRepository = inviteRepository;
            _tripRepository = tripRepository;
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task ManageAsync(ManageInviteDTO manageInviteDTO, string userId)
        {
            var invite = await _inviteRepository.GetBySpecAsync(
                new InviteSpecification.GetUnansweredByInviteAndUserIds(manageInviteDTO.InviteId, userId));

            ExceptionMethods.InviteNullCheck(invite);

            invite.IsAccepted = manageInviteDTO.IsAccepted;
            invite.IsAnswered = true;

            await _inviteRepository.SaveChangesAsync();
        }

        public async Task ManageTripInvitesAsync(Trip trip, List<OfferInviteDTO> offers)
        {
            var previousTripInvites = await _inviteRepository.ListAsync(
                new InviteSpecification.GetByTripId(trip.Id));
            var newInvites = new List<Invite>();
            var invitesIdsForDelete = new List<int>();

            if (previousTripInvites.Count == 0)
            {
                newInvites.Add(new Invite
                {
                    IsAccepted = false,
                    IsAnswered = false,
                    OfferId = null,
                    TripId = trip.Id,
                    UserId = trip.TripCreatorId
                });
            }

            foreach (var previousInvite in previousTripInvites)
            {
                if (previousInvite.OfferId == null)
                {
                    continue;
                }

                var offerId = (int)previousInvite.OfferId;

                if (offers.Any(o => o.Id == offerId))
                {
                    offers.Remove(offers.First(o => o.Id == offerId));
                }
                else
                {
                    invitesIdsForDelete.Add(previousInvite.Id);
                }
            }

            foreach (var offer in offers)
            {
                newInvites.Add(new Invite
                {
                    IsAccepted = false,
                    IsAnswered = false,
                    OfferId = offer.Id,
                    UserId = offer.OfferCreatorId,
                    TripId = trip.Id
                });
            }

            if (invitesIdsForDelete.Count > 0)
            {
                var invitesForDelete = await _inviteRepository.ListAsync(
                    new InviteSpecification.GetByIds(invitesIdsForDelete));

                await _inviteRepository.DeleteRangeAsync(invitesForDelete);
            }

            if (newInvites.Count > 0)
            {
                await _inviteRepository.AddRangeAsync(newInvites);
            }
        }

        public async Task<PaginatedList<InvitePreviewDTO>> OffersInvitesAsync(
            string userId, PaginationFilterDTO paginationFilter)
        {
            var invitesCount = await _inviteRepository.CountAsync(
                new InviteSpecification.GetOffersInvites(userId, paginationFilter));

            int totalPages = PaginatedList<InvitePreviewDTO>.GetTotalPages(paginationFilter, invitesCount);

            if (totalPages == 0)
            {
                return null;
            }

            var invites = await _inviteRepository.ListAsync(
                new InviteSpecification.GetOffersInvites(userId, paginationFilter));

            return PaginatedList<InvitePreviewDTO>.Evaluate(
                _mapper.Map<List<InvitePreviewDTO>>(invites), paginationFilter.PageNumber, invitesCount, totalPages);
        }
    }
}
