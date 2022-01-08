namespace Consultatii
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cadru")]
    public partial class Cadru
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cadru()
        {
            Programares = new HashSet<Programare>();
        }

        [Key]
        public int Nr_cadru { get; set; }

        [StringLength(20)]
        public string Nume { get; set; }

        [StringLength(20)]
        public string Prenume { get; set; }

        [StringLength(50)]
        public string Specializare { get; set; }

        public int? Telefon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Programare> Programares { get; set; }
    }
}
