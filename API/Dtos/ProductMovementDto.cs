namespace API.Dtos
{
    public class ProductMovementDto
    {
        public ProductDto Product {get;set;}
        public int Quantity {get;set;}
        public decimal TotalPrice {get;set;}
        public DateTime Date{get;set;}
        public MovementTypeDto MovementType {get;set;} 
    }
}