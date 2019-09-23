using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TRACSNarrative.Models
{
    public partial class NarrativeText
    {
        [Key]
        public string PerNo { get; set; }
        [Key]
        public string BrOffCode { get; set; }
        [Key]
        public int NrtvSequenceNmbr { get; set; }
        [Key]
        public int NrtvTextSeqNmbr { get; set; }
        public string NrtvTextDetail { get; set; }
        public string LastUpdateBrOffCode { get; set; }
        public DateTime LastUpdateDtTm { get; set; }
        public string LastUpdateBy { get; set; }

        public virtual Narrative Narrative { get; set; }
    }
}
