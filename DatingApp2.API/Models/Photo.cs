﻿using System;

namespace DatingApp2.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public virtual User User { get; set; } // robię to po to aby migracja była poprawna (ReferentialAction.Cascade)
        public int UserId { get; set; } // jeśli kasuję user'a to kasuję też photos
    }
}