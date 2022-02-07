using System;

namespace ProjectPartA_A1
{
    class Program
    {
        struct Article
        {
            public string Name;
            public decimal Price;
        }

        const int _maxNrArticles = 10;
        const int _maxArticleNameLength = 20;
        const decimal _vat = 0.25M;

        static Article[] articles = new Article[_maxNrArticles];
        static int nrArticles;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Project Part A");
            Console.WriteLine("Let's print a receipt!");
            Console.WriteLine();


            ReadArticles();
            PrintReceipt();
            Console.ReadLine();
        }


        private static void ReadArticles()
        {
            //Your code to enter the articles

            Console.WriteLine("How many articles do you want (between 1 and 10?)");

            bool inputWasWrong = true;

            do
            {
                string input = Console.ReadLine();
                int.TryParse(input, out nrArticles);
                if (nrArticles >= 1 && nrArticles <= _maxNrArticles)
                    inputWasWrong = false;
                else
                    Console.WriteLine("Number was wrong, pls try again");


            } while (inputWasWrong);

            int i = 0;
            while (i < nrArticles)
            {
                Console.WriteLine($"Please enter name and price for article #{i} in the format: name ; price (example Beer ; 2,25): ");

                try
                {
                    string item = Console.ReadLine();
                    string[] inputSplit = item.Split(';');
                    string name = inputSplit[0];
                    decimal price;

                    if (string.IsNullOrEmpty(name) || name.Length > _maxArticleNameLength)
                    {
                        Console.WriteLine("Please enter a valid name (1-20 characters).");
                        continue;
                    }

                    if (!decimal.TryParse(inputSplit[1], out price))
                    {
                        Console.WriteLine("Please enter a valid price");
                        continue;
                    }


                    articles[i].Name = name;
                    articles[i].Price = price;
                    i++;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("SCRUM-MASTER SAYS INCORRECT FORMAT!", ex.Message);
                }

                Console.WriteLine();
            }

            Console.WriteLine();



            //Console.WriteLine($"Du skrev: {item}");
        }
        private static void PrintReceipt()
        {
            //Your code to print out a reciept

            Console.WriteLine();


            Console.WriteLine("Receipt Purchased Articles");
            Console.WriteLine($"Purchase date: {DateTime.Now} ");

            Console.WriteLine($"Number of items purchased: {nrArticles}");
            Console.WriteLine();

            Console.WriteLine($"{"#",-5} {"Name",-30} {"Price"}");

            for (int i = 0; i < articles.Length; i++)
            {
                if (articles[i].Name != null)
                {
                    Console.WriteLine("{0,-5} {1,-30} {2:C2}", i, articles[i].Name, articles[i].Price);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            decimal sum = 0;
            for (int i = 0; i < articles.Length; i++)
            {
                sum += articles[i].Price;
            }

            Console.WriteLine($"Total purchase: {sum,28:C2}");
            Console.WriteLine($"Includes VAT (25%): {_vat * sum,24:C2}");








        }
    }
}
