using System;

namespace ProjectPartA_A2
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
        static int nrArticles = 0;

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Project Part A\n");

            int menuSel = 5;
            do
            {
                menuSel = MenuSelection();
                MenuExecution(menuSel);

            } while (menuSel != 5);




        }
        private static int MenuSelection()
        {
            int menuSel = 5;

            Console.WriteLine($"{nrArticles} articles entered.");
            Console.WriteLine("Menu: ");

            //Your code for menu selection

            Console.WriteLine("1 - Enter an article");
            Console.WriteLine("2 - Remove an article");
            Console.WriteLine("3 - Print receipt sorted by price");
            Console.WriteLine("4 - Print receipt sorted by name");
            Console.WriteLine("5 - Quit");

            string input = Console.ReadLine();
            int.TryParse(input, out menuSel);



            return menuSel;
        }
        private static void MenuExecution(int menuSel)
        {
            //Your code for execution based on the menu selection
            switch (menuSel)
            {
                case 1:
                    ReadAnArticle();
                    break;
                case 2:
                    RemoveAnArticle();
                    break;
                case 3:
                    SortArticles();
                    PrintReceipt();
                    break;
                case 4:
                    SortArticles(true);
                    PrintReceipt();
                    break;
                case 5:
                    Console.WriteLine("Thanks for entering my shop");
                    break;
            }

        }
        private static void ReadAnArticle()
        {
            //Your code to enter an article

            while (nrArticles < _maxNrArticles)
            {
                Console.WriteLine($"Please enter name and price for article #{nrArticles} in the format name ; price (example Beer ; 2,25): ");

                try
                {
                    string item = Console.ReadLine();
                    string[] inputSplit = item.Split(';');
                    string name = inputSplit[0].Trim();
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

                    articles[nrArticles].Name = name;
                    articles[nrArticles].Price = price;
                    nrArticles++;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("SCRUM-MASTER SAYS WRONG FORMAT", ex.Message);

                }
                Console.WriteLine();
                break;
            }
            Console.WriteLine();

        }
        private static void RemoveAnArticle()
        {
            //Your code to remove an article

            Console.WriteLine("Please select item to remove: ");
            string articleName = Console.ReadLine().ToLower();

            bool found = false;
            for (int i = 0; i < articles.Length; i++)
            {
                if (articles[i].Name != null)
                {
                    if (articles[i].Name.ToLower().Contains(articleName))
                    {
                        Console.WriteLine($"{articles[i].Name} is now removed. \n");
                        Array.Clear(articles, i, 1);
                        nrArticles--;
                        found = true;
                        return;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("Article not found");
            }
        }
        private static void PrintReceipt()
        {
            //Your code to print a receipt
            Console.WriteLine("Receipt Purchased Articles");
            Console.WriteLine($"Purchase date: {DateTime.Now} ");

            Console.WriteLine($"Number of items purchased: {nrArticles}");
            Console.WriteLine();

            Console.WriteLine($"{"#",-5} {"Name",-30} {"Price"}");

            var articlePosition = 0;
            for (int i = 0; i < articles.Length; i++)
            {
                if (articles[i].Name != null)
                {
                    Console.WriteLine("{0,-5} {1,-30} {2:C2}", articlePosition++, articles[i].Name, articles[i].Price);
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
        private static void SortArticles(bool sortByName = false)
        {
            //Your code to Sort. Either BubbleSort or SelectionSort
            if (sortByName == true)
            {

                for (int i = 0; i < articles.Length; i++)
                {
                    bool canChange = false;
                    for (int j = 0; j < articles.Length - 1; j++)
                    {
                        if (string.Compare(articles[j + 1].Name, articles[j].Name) < 0)
                        {
                            canChange = true;
                            (articles[j], articles[j + 1]) = (articles[j + 1], articles[j]);
                        }
                    }
                    if (!canChange)
                    {
                        break;
                    }
                }
            }
            else
            {

                for (int k = 0; k < articles.Length - 1; k++)
                {
                    int minIndex = k;
                    decimal minValue = articles[k].Price;

                    for (int l = k + 1; l < articles.Length; l++)
                    {
                        if (articles[l].Price < minValue)
                        {
                            minIndex = l;
                            minValue = articles[l].Price;
                        }
                    }

                    (articles[k], articles[minIndex]) = (articles[minIndex], articles[k]);

                }
            }

        }
    }
}



