namespace BackEnd_ASP_NET.Models
{
    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Shipped,
        Delivered,
        Canceled
    }

    public enum DiscountType
    {
        ShippingFee,
        OrderFee,
    }

    public static class RoleName {

        public const string User = "User";
        public const string Admin = "Admin";
    }
}