namespace SysInternshipManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccesProgramme")]
    public partial class AccesProgramme
    {
        [Key]
        [Column(Order = 0)]
        public int IdAcces { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(256)]
        public string UserMail { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(3)]
        public string Discipline { get; set; }

        public virtual Departement Departement { get; set; }
    }
}
