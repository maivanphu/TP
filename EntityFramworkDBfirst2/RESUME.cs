//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramworkDBfirst2
{
    using System;
    using System.Collections.Generic;
    
    public partial class RESUME
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RESUME()
        {
            this.VIDEO = new HashSet<VIDEO>();
        }
    
        public int ResumeId { get; set; }
        public int AffaireId { get; set; }
        public int PersonneId { get; set; }
        public string ResumeName { get; set; }
        public string ResumeComments { get; set; }
        public System.DateTime ResumeDateCreation { get; set; }
        public string ResumeParameters { get; set; }
    
        public virtual AFFAIRE AFFAIRE { get; set; }
        public virtual PERSONNE PERSONNE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIDEO> VIDEO { get; set; }
    }
}
