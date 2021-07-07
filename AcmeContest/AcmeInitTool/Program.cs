using AcmeCore.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AcmeInitTool {
    /// <summary>
    /// Program to generate serial number and save them in database
    /// Program to export all serial number in database on pdf file
    /// </summary>
    class Program {

        //Import db context
        static AcmeContext db = new AcmeContext();
        static void Main(string[] args) {
            ConsoleKeyInfo choice;
            Console.WriteLine("Hi, you have the following choices or Enter to exit:");
            do {
                Console.WriteLine("");
                Console.WriteLine("- Generate 100 Serial numbers - press 1.");
                Console.WriteLine("- Export existing serial number on a pdf file - press 2.");
                choice = Console.ReadKey();
                if (char.IsDigit(choice.KeyChar)) {
                    switch (choice.Key) {
                        case ConsoleKey.D1: case ConsoleKey.NumPad1:
                            GenerateSerialNumber();
                            break;
                        case ConsoleKey.D2: case ConsoleKey.NumPad2:
                            ExportSerialNumberPDF();
                            break;
                        default:
                            break;
                    }
                }
            }
            while (choice.Key != ConsoleKey.Enter);

        }

        // 
        static void GenerateSerialNumber() {
            try {
                Console.WriteLine("");
                Console.WriteLine("Generate Serial numbers");
                var list = new List<Product>();

                for (int i = 0; i < 100; i++) {
                    var rnd = new Random().Next(1, 99999);
                    db.Products.Add(new Product { Name = "Product_" + rnd, SerialNumber = Guid.NewGuid() });
                    db.SaveChanges();
                }
                Console.WriteLine("");
                Console.WriteLine("The serial numbers have been generated.");
            }
            catch (Exception) {
                Console.WriteLine("");
                Console.WriteLine("An Error occured, please try again or press enter to exit");
            }
        }

        /// <summary>
        /// Export pdf file with valid serial number
        /// 
        /// </summary>
        static void ExportSerialNumberPDF() {
            try {
                Console.WriteLine("");
                Console.WriteLine("Enter path to export the file");
                string path = string.Empty;
                do {
                    path = Console.ReadLine();
                    if (!Directory.Exists(path))
                        Console.WriteLine("Wrong path, please enter a new one");
                    Console.WriteLine("");
                } while (!Directory.Exists(path));

                Console.WriteLine("Thanks, the application will create the file");

                // add filename to path with creatiion time
                path = path + @"\serialnumber_" + DateTime.Now.ToShortDateString() + ".pdf";
                var sb = new StringBuilder();

                //query serial number from database
                db.Products.Select(x => x.SerialNumber)
                        .ToList()
                        .ForEach(x => sb = sb.Append(x + Environment.NewLine));

                if (sb.Length == 0)
                    Console.WriteLine("There are no serial numbers in the database");
                else {
                    if (!File.Exists(path)) {
                        File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                        Console.WriteLine("PDF File have been created");
                    }
                    else {
                        Console.WriteLine("File already exists, if you want to delete ");
                        Console.WriteLine("-press y or press Enter to continue");
                        Console.WriteLine("");
                        var delete = Console.ReadKey();
                        if(delete.Key == ConsoleKey.Y) {
                            File.Delete(path);
                            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
                            Console.WriteLine("");
                            Console.WriteLine("PDF File have been created");
                        }
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("Press Enter to Exit or try other option");

            }
            catch (Exception) {
                Console.WriteLine("An error occured pleased try again.");
            }
        }
    }

}
