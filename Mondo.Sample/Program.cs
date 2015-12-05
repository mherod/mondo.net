﻿using System;
using System.Collections.Generic;
using System.Configuration;

namespace Mondo.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string url = ConfigurationManager.AppSettings["MondoApiUrl"];
                string clientId = ConfigurationManager.AppSettings["MondoClientId"];
                string clientSecret = ConfigurationManager.AppSettings["MondoClientSecret"];

                Console.Write("Email address: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                using (var mondoClient = new MondoClient(url, clientId, clientSecret))
                {
                    mondoClient.RequestAccessTokenAsync(username, password).Wait();

                    IList<Account> accounts = mondoClient.ListAccountsAsync().Result;
                    foreach (Account account in accounts)
                    {
                        Console.WriteLine("Account: id={0}, created={1}, description={2}", account.Id, account.Created, account.Description);
                    }

                    IList<Transaction> transactions = mondoClient.ListTransactionsAsync(accounts[0].Id).Result;
                    foreach (Transaction transaction in transactions)
                    {
                        Console.WriteLine("Transaction: created={0}, description={1}, amount={2}, currency={3}, accountBalance={4}", transaction.Created, transaction.Description, transaction.Amount, transaction.Currency, transaction.AccountBalance);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}