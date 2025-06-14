# Developer Evaluation Project

## Scope

Implemented **Sales only**. Examples:

- Entity
  - Sale (rules-based below): https://github.com/jmrqs/developer-challenge/blob/main/src/Ambev.DeveloperEvaluation.Domain/Entities/Sale.cs
  - SaleItem: https://github.com/jmrqs/developer-challenge/blob/main/src/Ambev.DeveloperEvaluation.Domain/Entities/SaleItem.cs

- Handlers
  - CreateSale: https://github.com/jmrqs/developer-challenge/blob/main/src/Ambev.DeveloperEvaluation.Application/Sales/CreateSale/CreateSaleHandler.cs
  - GetSale: https://github.com/jmrqs/developer-challenge/blob/main/src/Ambev.DeveloperEvaluation.Application/Sales/GetSale/GetSaleHandler.cs
  - UpdateSale: https://github.com/jmrqs/developer-challenge/blob/main/src/Ambev.DeveloperEvaluation.Application/Sales/UpdateSale/UpdateSaleHandler.cs
  - DeleteSale: https://github.com/jmrqs/developer-challenge/blob/main/src/Ambev.DeveloperEvaluation.Application/Sales/DeleteSale/DeleteSaleHandler.cs



## Get started

To run the project, insert a valid connection string in the file located in the project "Ambev.DeveloperEvaluation.WebApi" called "appsettings.Development.json".

After inserting the connection string, open the Package Manager Console, select the project "Ambev.DeveloperEvaluation.WebApi", and execute the following commands:
```
- PM> Add-Migration
- PM> Update-Database
```

* Based on git flow: [https://github.com/jmrqs/development-guidelines](https://github.com/jmrqs/development-guidelines)

`READ CAREFULLY`

## Instructions
**The test below will have up to 7 calendar days to be delivered from the date of receipt of this manual.**

- The code must be versioned in a public Github repository and a link must be sent for evaluation once completed
- Upload this template to your repository and start working from it
- Read the instructions carefully and make sure all requirements are being addressed
- The repository must provide instructions on how to configure, execute and test the project
- Documentation and overall organization will also be taken into consideration

## Use Case
**You are a developer on the DeveloperStore team. Now we need to implement the API prototypes.**

As we work with `DDD`, to reference entities from other domains, we use the `External Identities` pattern with denormalization of entity descriptions.

Therefore, you will write an API (complete CRUD) that handles sales records. The API needs to be able to inform:

* Sale number
* Date when the sale was made
* Customer
* Total sale amount
* Branch where the sale was made
* Products
* Quantities
* Unit prices
* Discounts
* Total amount for each item
* Cancelled/Not Cancelled

It's not mandatory, but it would be a differential to build code for publishing events of:
* SaleCreated
* SaleModified
* SaleCancelled
* ItemCancelled

If you write the code, **it's not required** to actually publish to any Message Broker. You can log a message in the application log or however you find most convenient.

### Business Rules

* Purchases above 4 identical items have a 10% discount
* Purchases between 10 and 20 identical items have a 20% discount
* It's not possible to sell above 20 identical items
* Purchases below 4 items cannot have a discount

These business rules define quantity-based discounting tiers and limitations:

1. Discount Tiers:
   - 4+ items: 10% discount
   - 10-20 items: 20% discount

2. Restrictions:
   - Maximum limit: 20 items per product
   - No discounts allowed for quantities below 4 items

## Overview
This section provides a high-level overview of the project and the various skills and competencies it aims to assess for developer candidates. 

See [Overview](/.doc/overview.md)

## Tech Stack
This section lists the key technologies used in the project, including the backend, testing, frontend, and database components. 

See [Tech Stack](/.doc/tech-stack.md)

## Frameworks
This section outlines the frameworks and libraries that are leveraged in the project to enhance development productivity and maintainability. 

See [Frameworks](/.doc/frameworks.md)

<!-- 
## API Structure
This section includes links to the detailed documentation for the different API resources:
- [API General](./docs/general-api.md)
- [Products API](/.doc/products-api.md)
- [Carts API](/.doc/carts-api.md)
- [Users API](/.doc/users-api.md)
- [Auth API](/.doc/auth-api.md)
-->

## Project Structure
This section describes the overall structure and organization of the project files and directories. 

See [Project Structure](/.doc/project-structure.md)