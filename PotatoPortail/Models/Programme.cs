namespace PotatoPortail.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Programme")]
    public partial class Programme
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Programme()
        {
            PlanCadre = new HashSet<PlanCadre>();
        }

        [Key]
        public int IdProgramme { get; set; }

        [StringLength(200)]
        [Display(Name = "Nom du programme")]
        public string Nom { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "Ann�e")]
        public string Annee { get; set; }

        public DateTime? DateValidation { get; set; }

        public bool? StatutStageValider { get; set; }

        [Display(Name = "Nombre de sessions")]
        public int NbSession { get; set; }

        [Display(Name = "Identifiant du devis")]
        public int IdDevis { get; set; }

        public virtual DevisMinistere DevisMinistere { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanCadre> PlanCadre { get; set; }
    }
}
