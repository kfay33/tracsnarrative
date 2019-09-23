using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRACSNarrative.Models
{
    public partial class Narrative
    {
        public Narrative()
        {
            NarrativeText = new HashSet<NarrativeText>();
        }

        public string PerNo { get; set; }
        [Key, Column(Order = 0)]
        [Required]
        public string BrOffCode { get; set; }
        [Key, Column(Order = 1)]
        public int NrtvSequenceNmbr { get; set; }
        public string ContTypeCode { get; set; }
        public string NrtvTypeCode { get; set; }
        public string TracsAuthRacfId { get; set; }
        public DateTime? NrtvEntryDate { get; set; }
        public byte? NrtvTimeSpentHours { get; set; }
        public byte? NrtvTimeSpentMinutes { get; set; }
        public string NrtvStickyNote { get; set; }
        public DateTime? TklrAttentionDate { get; set; }
        public string NrtvEnteredOn { get; set; }
        public string LastUpdateBrOffCode { get; set; }
        public DateTime LastUpdateDtTm { get; set; }
        public string LastUpdateBy { get; set; }
        public string NrtvPendedFlag { get; set; }
        public string NrtvStatusCode { get; set; }
        public string NrtvScrnsChkdFlag { get; set; }

        public virtual ICollection<NarrativeText> NarrativeText { get; set; }
        public virtual Person Person { get; set; }
    }
}
