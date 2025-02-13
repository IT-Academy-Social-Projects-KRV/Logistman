﻿using Core.DTO;
using Core.DTO.NotificationDTO;
using Core.Entities.TripEntity;
using Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.CustomService
{
    public interface INotificationService
    {
        Task ManageTripNotificationsAsync(Trip trip, List<BriefNotificationDTO> offers);
        Task<PaginatedList<NotificationPreviewDTO>> GetByUserIdAsync(
            string userId, PaginationFilterDTO paginationFilter);
        Task DeleteNotificationsAsync(int tripId);
    }
}
