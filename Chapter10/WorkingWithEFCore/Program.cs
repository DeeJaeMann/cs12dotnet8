﻿using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels;

/* Previous demonstration code
using NorthwindDb db = new();
WriteLine($"Provider: {db.Database.ProviderName}");
*/

ConfigureConsole();
QueryingCategories();
//FilteredIncludes();
//QueryingProducts();
//GettingOneProduct();
//QueryingWithLike();
//GetRandomProduct();
//LazyLoadingWithNoTracking();

// Add product demo
var resultAdd = AddProduct(categoryId: 6,
    productName: "Bob's Burgers", price: 500M, stock: 72);

if (resultAdd.affected == 1)
{
    WriteLine($"Add product successful with ID: {resultAdd.productId}");
}    

ListProducts(productIdsToHighlight: new[] { resultAdd.productId });

// Update product demo
/*
var resultUpdate = IncreaseProductPrice(
    productNameStartsWith: "Bob", amount: 20M);

if (resultUpdate.affected == 1)
{
    WriteLine($"Increase price success for ID: {resultUpdate.productId}.");
}

ListProducts(productIdsToHighlight: new[] { resultUpdate.productId });
*/

// Delete product demo

WriteLine("About to delete all products whose name starts with Bob.");
Write("Press Enter to continue or any other key to exit: ");
if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
    int deleted = DeleteProducts(productNameStartsWith: "Bob");
    WriteLine($"{deleted} product(s) were deleted.");
}
else
{
    WriteLine("Delete was canceled.");
}


// Alternate update product demo
/*
var resultUpdateBetter = IncreaseProductPricesBetter(
    productNameStartsWith: "Bob", amount: 20M);

if (resultUpdateBetter.affected > 0)
{
    WriteLine("Increase product price successful.");
}

ListProducts(productIdsToHighlight: resultUpdateBetter.productIds);
*/


// Alternate delete product demo
WriteLine("About to delete all products whose name starts with Bob.");
Write("Press Enter to continue or any other key to exit: ");
if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
    int deleted = DeleteProductsBetter(productNameStartsWith: "Bob");
    WriteLine($"{deleted} product(s) were deleted.");
}
else
{
    WriteLine("Delete was canceled");
}