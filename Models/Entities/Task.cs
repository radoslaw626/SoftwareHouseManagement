﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareHouseManagement.Models.Entities
{
    public class Task
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [AllowNull]
        public TimeSpan AssignedHours { get; set; }
        [DisplayFormat(DataFormatString="{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [AllowNull]
        public TimeSpan WorkedHours { get; set; }

        public virtual Team Team { get; set; } 
        public virtual Client Client { get; set; }
        public long ClientId { get; set; }
    }
}
