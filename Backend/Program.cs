using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Globalization;
using AlbertslundForsyning.Entities;
using CsvHelper;
using System.IO;
using AlbertslundForsyning.Context;


namespace AlbertslundForsyning
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            // int[] array = new int[5];
            // for (int i = 0; i < array.Length; i++)
            // {
            //     array[i] = 1+i;
            //     Console.WriteLine(array[i]);
            // }
            //readCSV();    


        }

        public static void readCSV()
        {          
            using (var context = new EFCoreContext()) // get connection to the DB
            {
                using (var streamReader = new StreamReader(@"C:/Programmering/.NET_Core/AlbertslundForsyning/DailyReading1.csv"))
                {
                    List<User> userList = context.Users.ToList();                    
                    int index = 0;
                    int days = 0;
                    while (!streamReader.EndOfStream)
                    {                    
                        var line = streamReader.ReadLine();

                        var values = line.Split(';');
                        DataReading dataReading = new DataReading();
                        if(index == 0)
                        {
                            days++;
                        }
                        
                        dataReading.Date = DateTime.Now.AddYears(-2).AddDays(days);
                        dataReading.HeatUsage = Double.Parse(values[2]);
                        dataReading.WaterUsage = Double.Parse(values[4]);
                        dataReading.TemperatureIn = Double.Parse(values[8]);
                        dataReading.TemperatureOut = Double.Parse(values[10]);

                        dataReading.User = userList[index];
            
                        context.Add(dataReading);
                        context.SaveChanges();

                        if(index < userList.Count-1)
                        {
                            index += 1;
                        } else {
                            index = 0;
                        }                        
                    }                    
                }                
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
