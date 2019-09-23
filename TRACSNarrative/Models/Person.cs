using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRACSNarrative.Models
{
    public partial class Person
    {
        [Key]
        public string PerNo { get; set; }
        public string PerLastName { get; set; }
        public string PerFirstName { get; set; }
        public string PerMi { get; set; }
        public string PerSuffixName { get; set; }
        public string PerGoesByName { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? PerBirthDate { get; set; }
        public string CitznCode { get; set; }
        public string RaceCode { get; set; }
        public string PerSexCode { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DcsdPerDeathDate { get; set; }
        public string DcsdPerDeathFlag { get; set; }
        public string SsnNmbr { get; set; }
        public string PnaNmbr { get; set; }
        public string PerMfInSync { get; set; }
        public string JobsStatDescShort { get; set; }
        public string PerComment { get; set; }
        public DateTime? PerInsertDate { get; set; }
        public string PerInsertBy { get; set; }
        public string LastUpdateBrOffCode { get; set; }
        public DateTime LastUpdateDtTm { get; set; }
        public string LastUpdateBy { get; set; }
        public string PerEducCode { get; set; }
        public string PerJasFlag { get; set; }
        public string PerVeteranFlag { get; set; }
        public DateTime? PerCommentDate { get; set; }
        public string PerDisabilityCode { get; set; }
        public string PerDisAccModCode { get; set; }
        public string PerDisAccModText { get; set; }
        public string PerEmailAddress { get; set; }
        public string PerAbawdCode { get; set; }
        public DateTime? PerAbawdLastUpdateDtTm { get; set; }
        public decimal? IeIndividualId { get; set; }

        public virtual ICollection<Narrative> Narrative { get; set; }

    }
}
