using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.DAL
{
    public class DAL
    {
    }
    public class department
    {
        [Key]
        
        public string deptid { get; set; }
        
        public string deptname { get; set; }
      
        public string location { get; set; }

       
        public IList<items> items { get; set; }

    }
    public class items
    {
        [Key]
        public string itemcode { get; set; }
        public string itemname { get; set; }
        [ForeignKey("department")]
        public string deptid { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> cost { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> rate { get; set; }
        public DateTime date { get; set; }
        public string picture { get; set; }
        public department department { get; set; }
        public IList<purchasedetails> purchasedetails { get; set; }
        public IList<salesdetails> salesdetails { get; set; }
    }
    public class purchasemaster
    {
        [Key]
        public string purchaseId { get; set; }
        public DateTime date { get; set; }
        [ForeignKey("party")]
        public string partyId { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> total { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> discount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> net { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> paid { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> due { get; set; }
        public IList<purchasedetails> purchasedetails { get; set; }
        public party party { get; set; }
    }
    public class purchasedetails
    {
        [Key]
        [ForeignKey("purchasemaster")]
        public string purchaseId { get; set; }
        [Key]
        public string slno { get; set; }
        [ForeignKey("items")]
        public string itemcode { get; set; }
        public DateTime date { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> costprice { get; set; }
        public int qty { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> total { get; set; }

        public items items { get; set; }
        public purchasemaster purchasemaster { get; set; }
    }

    public class party
    {
        [Key]
        public string partyId { get; set; }
        public string partyname { get; set; }
        public string address { get; set; }
        public IList<purchasemaster> purchasemaster { get; set; }
        public IList<salesemaster> salesemaster { get; set; }
    }
    public class salesemaster
    {
        [Key]
        public string saleId { get; set; }
        public DateTime date { get; set; }
        [ForeignKey("party")]
        public string partyId { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> total { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> discount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> net { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> paid { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> due { get; set; }
        public IList<salesdetails> salesdetails { get; set; }
        public party party { get; set; }
    }
    public class salesdetails
    {
        [Key]
        [ForeignKey("salesemaster")]
        public string saleId { get; set; }
        [Key]
        public string slno { get; set; }
        [ForeignKey("items")]
        public string itemcode { get; set; }
        public DateTime date { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> costprice { get; set; }
        public int qty { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> total { get; set; }

        public items items { get; set; }
        public salesemaster salesemaster { get; set; }
    }


    public class storeledger
    {
        [Key]
        public string slno { get; set; }
        public DateTime date { get; set; }
        public string vono { get; set; }
        public string narration { get; set; }
        public int received { get; set; }
        public int issue { get; set; }
        public int valance { get; set; }
    }
    public class stockseet
    {
        [Key]
        public int slno { get; set; }
        public string itemcode { get; set; }
        public int op_qty { get; set; }
        public int rec_qty { get; set; }
        public int iss_qty { get; set; }
        public int bal { get; set; }
    }

    public class Users
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
    public class Tokens
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
