namespace Domain.Entities
{
    public class MovementDetail:BaseEntity
    {
        public int IdProductFk {get;set;}
        public Product Product {get;set;}
        public int Quantity {get;set;}
        public int IdMovementTypeFk {get;set;}
        public MovementType MovementType {get;set;} 
        public int IdProdMovementFk {get;set;}
        public ProductMovement ProductMovement {get;set;}
        public double Price {get;set;}
    }
}