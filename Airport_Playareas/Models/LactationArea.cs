﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Airport_Playareas.Models
{
    public class LactationArea
    {
        public LactationArea()
        {
        }

        public int LactationAreaID { get; set; }

        public string? Terminal { get; set; }
        public string? Gate { get; set; }
        public string? Description { get; set; }
        public string? PhotoURL { get; set; }
        [ForeignKey("AirportID")]
        public int AirportID { get; set; }

        public Airport Airport { get; set; }

    }

}
