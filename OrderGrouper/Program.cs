using OrderGrouper.Models;
using System.Text.Json;
using System;

class Program
{
    static void Main()
    {
        var inputFile = @"C:\Users\Igor V\source\repos\OrderGrouper\OrderGrouper\input_model.json";  
        var jsonContent = File.ReadAllText(inputFile);
        var readedOrderList = JsonSerializer.Deserialize<List<InputOrder>>(jsonContent) ?? new List<InputOrder>();

        var grouping = readedOrderList.GroupBy(x => x.CustomerFullName);



      
        
        
        foreach (var group in grouping)
        {
            var customer = new Customer();

            var splittedName = group.Key.Split(' ');
            customer.FirstName = splittedName.FirstOrDefault() ?? "NoNameGiven";
            customer.LastName = splittedName.Last();

            Console.WriteLine(customer.FirstName + " " + customer.LastName);

        }
    }
}


