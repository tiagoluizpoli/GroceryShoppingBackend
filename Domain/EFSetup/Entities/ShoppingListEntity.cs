﻿using Domain.EFSetup.Entities.Abstractions;

namespace Domain.EFSetup.Entities;

public class ShoppingListEntity : AuditableEntity
{
    public ShoppingListEntity()
    {
    }

    public ShoppingListEntity(Guid id, DateTime createdAt, DateTime updatedAt, Guid shoppingEventId,
        ShoppingEventEntity shoppingEvent, Guid productId, ProductEntity product, bool grabbed, int quantity,
        double faceValue, int minWholesaleQuantity, double wholesaleFaceValue) : base(id, createdAt, updatedAt)
    {
        ShoppingEventId = shoppingEventId;
        ShoppingEvent = shoppingEvent;
        ProductId = productId;
        Product = product;
        Grabbed = grabbed;
        Quantity = quantity;
        FaceValue = faceValue;
        MinWholesaleQuantity = minWholesaleQuantity;
        WholesaleFaceValue = wholesaleFaceValue;
    }

    public Guid ShoppingEventId { get; set; }
    public ShoppingEventEntity ShoppingEvent { get; set; }
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public bool Grabbed { get; set; }
    public int Quantity { get; set; }
    public double FaceValue { get; set; }
    public int MinWholesaleQuantity { get; set; }
    public double WholesaleFaceValue { get; set; }
}