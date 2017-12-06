namespace CS460Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bid")]
    public partial class Bid
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BidID { get; set; }

        public int ItemID { get; set; }

        public int BuyerID { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public virtual Item Item { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}
