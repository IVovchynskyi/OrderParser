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

        List<Customer> people = new List<Customer>();
        
        foreach (var group in grouping)
        {
            var customer = new Customer();
            people.Add(customer);

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
                        order.Status = "In Progress";
                    } 
                    else if (string.IsNullOrEmpty(item.OrderEndDate) && !string.IsNullOrEmpty(item.CancellationDate))
                    {
                        order.Status = "Canceled";
                        DateTime formattedCancellationDate = DateTime.Parse(item.CancellationDate);
                        order.CancellationDate = formattedCancellationDate.ToString("yyyy-MM-dd");
                    }
                    else if (!string.IsNullOrEmpty(item.OrderEndDate) && string.IsNullOrEmpty(item.CancellationDate))
                    {
                        DateTime formattedOrderEndDate = DateTime.Parse(item.OrderEndDate);
                        order.EndDate = formattedOrderEndDate.ToString("yyyy-MM-dd");
                       
                        if (formattedOrderEndDate > DateTime.Now) // date in the future
                        {
                            order.Status = "Scheuled";
                        }
                        else // date in the past
                        {
                            order.Status = "Completed";
                            // CompletionTime calculation 
                            TimeSpan formattedCompletionTime = formattedOrderEndDate - formattedStartDate; // formattedCompletionTime is TimeSpan NOT DateTime
                            order.CompletionTime = $"{formattedCompletionTime.Days} day(s) {formattedCompletionTime.Hours} hour(s) {formattedCompletionTime.Minutes} minute(s)";
                        }
                    }
                    
                    else
                    {
                        order.Status = "Unknown";

                        break;
                    }
                          
                }
            }

        }
        
        string jsonString = JsonSerializer.Serialize(people, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(jsonString);
    }
}


