namespace Consultatii
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pacient")]
    public partial class Pacient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pacient()
        {
            Programares = new HashSet<Programare>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? CNP { get; set; }

        [StringLength(20)]
        public string Nume { get; set; }

        [StringLength(20)]
        public string Prenume { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Programare> Programares { get; set; }
    }
}
