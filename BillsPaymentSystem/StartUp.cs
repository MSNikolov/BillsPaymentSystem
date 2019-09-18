using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BillsPaymentSystem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new BillsPaymentSystemContext();

            var id = int.Parse(Console.ReadLine());

            var amount = decimal.Parse(Console.ReadLine());

            Console.WriteLine(Withdraw(id, amount, context));
        }

        public static string UserDetails (int userId, BillsPaymentSystemContext context)
        {
            if (!context.Users.Any(u => u.UserId == userId))
            {
                return $"User with id {userId} not found!";
            }

            else
            {
                var result = new StringBuilder();

                var user = context.PaymentMethods
                    .Include(pm => pm.User)
                    .Include(pm => pm.BankAccount)
                    .Include(pm => pm.CreditCard)
                    .Where(pm => pm.UserId == userId)
                    .ToList();

                result.AppendLine($"User: {user.First().User.FirstName} {user.First().User.LastName}");

                result.AppendLine("Bank Accounts:");

                foreach (var account in user.Where(pm => pm.Type==Models.Enums.PaymentType.BankAccount))
                {
                    result.AppendLine($"-- ID: {account.BankAccountId}");

                    result.AppendLine($"--- Balance: {account.BankAccount.Balance:f2}");

                    result.AppendLine($"--- Bank: {account.BankAccount.BankName}");

                    result.AppendLine($"--- SWIFT: {account.BankAccount.SwiftCode}");
                }

                result.AppendLine("Credit Cards:");

                foreach (var card in user.Where(pm => pm.Type == Models.Enums.PaymentType.CreditCard))
                {
                    result.AppendLine($"-- ID: {card.CreditCard.CreditCardId}");

                    result.AppendLine($"--- Limit: {card.CreditCard.Limit:F2}");

                    result.AppendLine($"--- Money Owed: {card.CreditCard.MoneyOwned:f2}");

                    result.AppendLine($"--- Limit Left: {card.CreditCard.LimitLeft:f2}");

                    result.AppendLine($"--- Expiration Date: {card.CreditCard.ExpirationDate.Year}/{card.CreditCard.ExpirationDate.Month}");

                }

                return result.ToString().Trim();
            }            
        }
        public static string Withdraw(int userId, decimal amount, BillsPaymentSystemContext context)
        {
            var accounts = context.PaymentMethods
                .Include(pm => pm.BankAccount)
                .Where(pm => pm.UserId == userId && pm.Type == Models.Enums.PaymentType.BankAccount)                
                .ToList();

            var cards = context.PaymentMethods
                .Include(pm => pm.CreditCard)
                .Where(pm => pm.UserId == userId && pm.Type == Models.Enums.PaymentType.CreditCard)
                .ToList();

            if (amount > accounts.Sum(a => a.BankAccount.Balance) + cards.Sum(c => c.CreditCard.MoneyOwned))
            {
                return "Insufficient funds";
            }

            else
            {
                var leftToPay = amount;

                foreach (var acc in accounts)
                {
                    if (acc.BankAccount.Balance >= leftToPay)
                    {
                        acc.BankAccount.Balance -= leftToPay;
                        leftToPay = 0;
                        break;
                    }

                    else
                    {
                        leftToPay -= acc.BankAccount.Balance;
                        acc.BankAccount.Balance = 0;
                    }
                }

                foreach (var card in cards)
                {
                    if (card.CreditCard.MoneyOwned >= leftToPay)
                    {
                        card.CreditCard.MoneyOwned -= leftToPay;
                        leftToPay = 0;
                        break;
                    }

                    else
                    {
                        leftToPay -= card.CreditCard.MoneyOwned;
                        card.CreditCard.MoneyOwned = 0;
                    }
                }

                context.SaveChanges();

                return $"Withdrawed: {amount}";
            }
        }
    }
}
