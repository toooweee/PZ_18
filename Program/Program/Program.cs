using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите информацию о товарах:");

            while (true)
            {
                Console.Write("Введите наименование товара (для завершения введите 'выход'): ");
                string name = Console.ReadLine();

                if (name.ToLower() == "выход")
                    break;

                Console.WriteLine("Выберите категорию товара:");
                Console.WriteLine("1. Одежда");
                Console.WriteLine("2. Обувь");
                Console.WriteLine("3. Аксессуары");
                Console.Write("Введите номер категории: ");
                string categoryInput = Console.ReadLine();

                ProductCategory category;
                switch (categoryInput)
                {
                    case "1":
                        category = ProductCategory.Clothing;
                        break;
                    case "2":
                        category = ProductCategory.Footwear;
                        break;
                    case "3":
                        category = ProductCategory.Accessories;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод категории. Повторите попытку.");
                        continue;
                }

                Console.Write("Введите стоимость товара: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price <= 0)
                {
                    Console.WriteLine("Ошибка: Некорректная стоимость товара. Повторите попытку.");
                    continue;
                }

                Product newProduct = new Product(name, category, price);
                newProduct.PrintProductInfo();
            }

            Product.PrintTotalInfo();
        }
    }
}
