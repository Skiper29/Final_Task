# OnlineStore Console Application

**OnlineStore** is a C# console application for managing an online store's product inventory. It allows adding, viewing, deleting, sorting, filtering products, as well as saving and loading product data from files. The application uses the **Command design pattern** and **Spectre.Console** for a clean and interactive console user interface.

## Features

- Add products (Milk, Kefir, Meat, Sausage) with detailed properties.
- Display all products in a formatted table.
- Delete specific products or all products at once.
- Filter and sort products by price, stock, and other parameters.
- File operations: Save product data to a file and load data from a file.
- Interactive console input using **Spectre.Console**.

## Table of Contents

1. [Installation](#installation)
2. [Usage](#usage)
3. [Available Commands](#available-commands)
4. [File Operations](#file-operations)
5. [Project Structure](#project-structure)

## Installation

To run the OnlineStore application locally, follow these steps:

1. **Clone the repository:**

   ```bash
   git clone https://github.com/Skiper29/OnlineStore.git
   ```

2. **Navigate to the project directory:**

   ```bash
   cd OnlineStore
   ```

3. **Build the project:**

   You can build the project using .NET CLI or an IDE like Visual Studio or Rider.

   ```bash
   dotnet build
   ```

4. **Run the application:**

   ```bash
   dotnet run
   ```

## Usage

When you run the application, a main menu will be displayed allowing you to perform operations like adding, viewing, filtering, sorting, and deleting products. File operations for saving and loading data are also available.

### Example

- **Add a Product:**
  - Select the product type (Milk, Kefir, Sausage, or Meat).
  - Enter the details: description, price, and stock.
  - The product is added to the list and displayed.

- **Display All Products:**
  - Displays a table of all added products with their ID, description, price, stock, and type.

## Available Commands

Here is a breakdown of the key commands available in the application:

- **AddProductCommand**: Adds a new product to the list.
- **DisplayAllProductsCommand**: Displays all products in a formatted table.
- **FilterProductsCommand**: Filters products by criteria such as price or stock.
- **SearchProductsCommand**: Searches for products by all parameters.
- **SortProductsCommand**: Sorts products by price, stock, and other attributes.
- **DeleteProductCommand**: Deletes a specific product or all products.
- **FileOperationsCommand**: Handles saving and loading product data to/from a file.
- **SerializationCommand**: Serializes and deserializes the product list.

## File Operations

You can save the current product list to a text file and load it back into the application later.

- **Save to File**: Saves the current list of products.
- **Load from File**: Loads products from an existing file.

## Project Structure

```bash
OnlineStore/
│
├── Commands/                 # Command classes for handling actions
│   ├── AddProductCommand.cs
│   ├── DeleteProductCommand.cs
│   ├── DisplayAllProductsCommand.cs
│   ├── FileOperationsCommand.cs
│   ├── FilterProductsCommand.cs
│   ├── SearchProductsCommand.cs
│   ├── SerializationCommand.cs
│   └── SortProductsCommand.cs
│
├── Models/                   # Product models
│   ├── Dairy/                # Dairy product hierarchy
│   │   ├── Implementation/
│   │   │   ├── Kefir.cs
│   │   │   └── Milk.cs
│   │   └── DairyProduct.cs
│   ├── Meats/                # Meat product hierarchy
│   │   ├── Implementation/
│   │   │   ├── Meat.cs
│   │   │   └── Sausage.cs
│   │   └── MeatProduct.cs
│   └── IProduct.cs           # Interface for all products
│
├── UI/                       # User interface related code
│   └── MainMenu.cs
│
├── Logger.cs                 # Logging functionality
├── log4net.config            # Configuration for log4net
└── Program.cs                # Entry point of the application
```




