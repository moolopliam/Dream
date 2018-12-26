using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RiceMill5911.Models
{

    public partial class VRice
    {
        [Display(Name = "รหัสข้าว")]
        public int RiceID { get; set; }

        [Display(Name = "ชื่อข้าว")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string RiceName { get; set; }

        [Display(Name = "ประเภท")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<int> TypeRiceID { get; set; }

        [Display(Name = "ราคารับซื้อ")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<double> PurchasePrice { get; set; }

        [Display(Name = "ราคาขาย")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<double> SalePrice { get; set; }

        [Display(Name = "จำนวนข้าวในคลัง")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<double> WareHouse { get; set; }


        [Display(Name = "รูปภาพ")]
        public byte[] RicePicture { get; set; }
    }
    [MetadataType(typeof(VRice))]
    public partial class Rice { }

    /////////////////////////////////////////////////////////////////////////////////////////////

    public partial class VTypeRice
    {
        [Display(Name = "รหัสประเภท")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public int TypeRiceID { get; set; }

        [Display(Name = "ประเภทข้าว")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string TypeRiceName { get; set; }

        [MetadataType(typeof(VTypeRice))]
        public partial class TypeRice { }

    }
    [MetadataType(typeof(VTypeRice))]
    public partial class TypeRice { }
    /////////////////////////////////////////////////////////////////////////////////////////////

    public partial class VBookingDescription
    {
        [Display(Name = "รหัสรายละเอียดการจอง")]
        public int DesBookingID { get; set; }

        [Display(Name = "รหัสใบจอง")]
        public int BookingID { get; set; }

        [Display(Name = "ข้าว")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<int> BookRice { get; set; }

        [Display(Name = "รายละเอียด")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string Description { get; set; }

        [Display(Name = "ปริมาณ")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<double> RiceQuantity { get; set; }

        [Display(Name = "ส่วนลด")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<double> Discount { get; set; }

        [Display(Name = "ราคารวม")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<double> TotalPrice { get; set; }

        [Display(Name = "สถานะการชำระเงิน")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string PaymentStatus { get; set; }

        [Display(Name = "ราคาต่อหน่วย")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<double> DesPrice { get; set; }

    }
    [MetadataType(typeof(VBookingDescription))]
    public partial class BookingDescription { }
    /////////////////////////////////////////////////////////////////////////////////////////////

    public partial class VBuyDescription
    {
        [Display(Name = "รหัสรายละเอียดการจอง")]
        public int DesBuyID { get; set; }

        [Display(Name = "รหัสการซื้อ")]
        public int BuyID { get; set; }

        [Display(Name = "ข้าว")]
        public Nullable<int> BuyRice { get; set; }

        [Display(Name = "ปริมาณ")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<double> BuyAmount { get; set; }

        [Display(Name = "ราคาต่อหน่วย")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<double> BuyPrice { get; set; }

        [Display(Name = "ราคารวม")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<double> BuyTotal { get; set; }

        [Display(Name = "สภาพข้าว")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<int> ConditionID { get; set; }

        [Display(Name = "สถานะข้าว")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<int> StatusRiceID { get; set; }

       
    }
    [MetadataType(typeof(VBuyDescription))]
    public partial class BuyDescription { }
    /////////////////////////////////////////////////////////////////////////////////////////////


    public partial class VStatusRice
    {
        [Display(Name = "รหัสสถานะ")]
        public int StatusRiceID { get; set; }

        [Display(Name = "ชื่อสถานะ")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string StatusRiceName { get; set; }

    }
    [MetadataType(typeof(VStatusRice))]
    public partial class StatusRice { }
    /////////////////////////////////////////////////////////////////////////////////////////////
    ///
    public partial class VBuyForm
    {
        [Display(Name = "รหัสการซื้อ")]
        public int BuyID { get; set; }


        [Display(Name = "รหัสผู้มาจำหน่าย")]
        public Nullable<int> DealerID { get; set; }

        [Display(Name = "วันที่การรับซื้อ")]
        public string BuyDate { get; set; }
    }
    [MetadataType(typeof(VBuyForm))]
    public partial class BuyForm { }
    /////////////////////////////////////////////////////////////////////////////////////////////

    public partial class VBookingForm
    {

        [Display(Name = "รหัสการจอง")]
        public int BookingID { get; set; }

        [Display(Name = "วันที่จอง")]
        public string BookingDate { get; set; }

        [Display(Name = "วันที่ต้องการข้าว")] 
        public string BookingWant { get; set; }

        [Display(Name = "วันที่ส่งข้าว")]
        public string BookingSubmit { get; set; }

        [Display(Name = "ค่าขนส่ง")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<double> BookingDeliveryFee { get; set; }

        [Display(Name = "รหัสพนักงาน")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<int> EmployeeID { get; set; }

        [Display(Name = "บัตรประชาชนลูกค้า")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string CustomerUsre { get; set; }

        [Display(Name = "สถานะการจอง")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public Nullable<int> StatusBookingID { get; set; }
        
    }
    [MetadataType(typeof(VBookingForm))]
    public partial class BookingForm    { }
    /////////////////////////////////////////////////////////////////////////////////////////////

    public partial class VCondition
    {

        [Display(Name = "รหัสสภาพข้าว")]      
        public int ConditionID { get; set; }

        [Display(Name = "สภาพข้าว")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string ConditionName { get; set; }

      
    }
    [MetadataType(typeof(VCondition))]
    public partial class Condition { }
    /////////////////////////////////////////////////////////////////////////////////////////////

    public partial class VCustomer
    {

        [Display(Name = "บัตรประชาชนลูกค้า")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string CustomerUsre { get; set; }

        [Display(Name = "รหัสผ่าน")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string CustomerPass { get; set; }

        [Display(Name = "ชื่อลูกค้า")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string CustomerName { get; set; }

        [Display(Name = "เบอร์โทรศัพท์ลูกค้า")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string CustTelephone { get; set; }

        
    }
    [MetadataType(typeof(VCustomer))]
    public partial class Customer { }
    /////////////////////////////////////////////////////////////////////////////////////////////

    public partial class VDealer
    {

        [Display(Name = "บัตรประชาชนผู้จำหน่าย")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public int DealerID { get; set; }

        [Display(Name = "ชื่อผู้จำหน่าย")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string DealerName { get; set; }

        [Display(Name = "เบอร์โทรศัพท์ผู้จำหน่าย")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string DeTelephone1 { get; set; }
    
    }
    [MetadataType(typeof(VDealer))]
    public partial class Dealer { }
    /////////////////////////////////////////////////////////////////////////////////////////////

    public partial class VEmployee
    {

        [Display(Name = "บัตรประชาชนพนักงาน")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public int EmployeeID { get; set; }

        [Display(Name = "ชื่อพนักงาน")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string EmployeeName { get; set; }

        [Display(Name = "เบอร์โทรศัพท์พนักงาน")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string EmployeeTelephone { get; set; }

       
    }

    [MetadataType(typeof(VEmployee))]
    public partial class Employee { }
    /////////////////////////////////////////////////////////////////////////////////////////////

    public partial class VStatusBooking
    {
        [Display(Name = "รหัสสถานะการจอง")]
        public int StatusBookingID { get; set; }

        [Display(Name = "สถานะการจอง")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string StatusBookingName { get; set; }

        
    }
    [MetadataType(typeof(VStatusBooking))]
    public partial class StatusBooking { }
    /////////////////////////////////////////////////////////////////////////////////////////////

}
