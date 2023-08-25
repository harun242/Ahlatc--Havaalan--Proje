﻿using Infrastructure.Model;

namespace WS.Model.Dtos.SeatNumber
{
    public class SeatNumberPutDto : IDto
    {
        public int ExpeditionID { get; set; }
        public string? BoardingCity { get; set; }
        public string? LandedCity { get; set; }
        public int? TicketNumber { get; set; }
    }
}
