using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Product
    {
        public string Name { get; set; }
        public ProductCategory Category { get; set; }
        public decimal Price { get; set; }

        public static int totalCount = 0;
        public static decimal totalCost = 0;

        public Product(string name, ProductCategory category, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ошибка: Наименование товара не может быть пустым или содержать только пробелы.");
                return;
            }

            if (price <= 0)
            {
                Console.WriteLine("Ошибка: Стоимость товара должна быть больше нуля.");
                return;
            }

            Name = name;
            Category = category;
            Price = price;

            totalCount++;
            totalCost += price;
        }

        public void PrintProductInfo()
        {
            Console.WriteLine($"Наименование: {Name}");
            Console.WriteLine($"Категория: {Category}");
            Console.WriteLine($"Стоимость: {Price}");
        }

        public static void PrintTotalInfo()
        {
            Console.WriteLine($"Общее количество товаров: {totalCount}");
            Console.WriteLine($"Общая стоимость товаров: {totalCost}");
            Console.WriteLine($"Средняя цена товаров: {totalCost / totalCount}");
        }

        public void SellWithDiscount()
        {
            decimal discount = 0;

            switch (Category)
            {
                case ProductCategory.Clothing:
                    discount = 0.05m;
                    break;
                case ProductCategory.Footwear:
                    discount = 0.07m;
                    break;
                case ProductCategory.Accessories:
                    discount = 0.1m;
                    break;
                default:
                    break;
            }

            decimal discountedPrice = Price * (1 - discount);
            Console.WriteLine($"Продан товар: {Name}. Цена со скидкой: {discountedPrice}");

            totalCount--;
            totalCost -= Price;
        }
    }

    public enum ProductCategory
    {
        Clothing,
        Footwear,
        Accessories
    }
}
