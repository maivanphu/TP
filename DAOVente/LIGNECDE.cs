//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAOVente
{
    using System;
    using System.Collections.Generic;
    
    public partial class LIGNECDE
    {
        public decimal CDEID { get; set; }
        public decimal LIGNEID { get; set; }
        public Nullable<decimal> PRODID { get; set; }
        public Nullable<decimal> PRIXACTUEL { get; set; }
        public Nullable<decimal> QTE { get; set; }
        public Nullable<decimal> TOTLIGNE { get; set; }
    
        public virtual COMMANDE COMMANDE { get; set; }
    }
}
