﻿namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleItemResult
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
}