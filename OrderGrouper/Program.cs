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

        Console.WriteLine("super feature");
        
        foreach (var group in grouping)
        {
            var customer = new Customer();

            var splittedName = group.Key.Split(' ');
            customer.FirstName = splittedName.FirstOrDefault() ?? "NoNameGiven";
            customer.LastName = splittedName.Last();

            
            foreach (InputOrder item in group)
            {
                Order order = new Order();

                if (string.IsNullOrEmpty(item.OrderDate))
                {
                    Console.WriteLine("The order date is EMPTY; Skipping current order parsing");
                    break;
                }
                else
                {
                    DateTime formattedStartDate = DateTime.Parse(item.OrderDate);
                    order.StartDate = formattedStartDate.ToString("yyyy-MM-dd");

                    if (string.IsNullOrEmpty(item.OrderEndDate) && string.IsNullOrEmpty(item.CancellationDate))
                    {
                        order.Status = "Scheduled";
                        Console.WriteLine(item.OrderItemName);
                    }
                    else if (string.IsNullOrEmpty(item.OrderEndDate) && !string.IsNullOrEmpty(item.CancellationDate))
                    {
                        order.Status = "Canceled";
                        DateTime formattedCancellationDate = DateTime.Parse(item.CancellationDate);
                        order.CancellationDate = formattedCancellationDate.ToString("yyyy-MM-dd");
                    }
                    else if (!string.IsNullOrEmpty(item.OrderEndDate) && string.IsNullOrEmpty(item.CancellationDate))
                    {
                        order.Status = "Completed";
                        DateTime formattedOrderEndDate = DateTime.Parse(item.OrderEndDate);
                        order.EndDate = formattedOrderEndDate.ToString("yyyy-MM-dd");
                        // CompletionTime calculation 
                        TimeSpan formattedCompletionTime = formattedOrderEndDate - formattedStartDate; // formattedCompletionTime is TimeSpan NOT DateTime
                        order.CompletionTime = $"{formattedCompletionTime.Days} day(s) {formattedCompletionTime.Hours} hour(s) {formattedCompletionTime.Minutes} minute(s)";
                    }
                    else
                    {
                        Console.WriteLine("The order has CancellationDate and OrderEndDate in the same time; Skipping current order parsing");
                        break;
                    }
                
                    Console.WriteLine($"item is {item.OrderItemName}");
                    Console.WriteLine($"start date is {order.StartDate}");
                    Console.WriteLine($"end date is {order.EndDate}");
                    Console.WriteLine($"duration date is {order.CompletionTime}");
                    Console.WriteLine($"cancelation date is {order.CancellationDate}");
                }
            }
            
            // Status calculator 


            // customer.TotalSpentAmount = group.Sum(x => x.Cost); // not all! only completed 


        }
    }
}


