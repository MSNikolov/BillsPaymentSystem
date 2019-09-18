using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem
{
    public class InitializeDb
    {
        public static void Seed (BillsPaymentSystemContext context)
        {
            AddUsers(context);

            AddCreditCards(context);

            AddBankAccounts(context);

            AddPayments(context);
        }

        private static void AddUsers(BillsPaymentSystemContext context)
        {
            var users = new List<User>();

            users.Add(new User
            {
                FirstName = "Petko",
                LastName = "Goshkov",
                Password = "Kurax",
                Email = "petko@goshkovi.bg"
            });

            users.Add(new User
            {
                FirstName = "Mitko",
                LastName = "Ivanov",
                Password = "Kurax",
                Email = "mitko@goshkovi.bg"
            });

            users.Add(new User
            {
                FirstName = "Hlebarka",
                LastName = "Vidolova",
                Password = "Kurax",
                Email = "hlebitu@goshkovi.bg"
            });

            users.Add(new User
            {
                FirstName = "Goshka",
                LastName = "Manchova",
                Password = "Kurax",
                Email = "goshka@goshkovi.bg"
            });

            users.Add(new User
            {
                FirstName = "Uasen",
                LastName = "Tupkov",
                Password = "Kurax",
                Email = "tupkov@goshkovi.bg"
            });

            context.Users.AddRange(users);

            context.SaveChanges();
        }

        private static void AddBankAccounts (BillsPaymentSystemContext context)
        {
            var accounts = new List<BankAccount>();

            accounts.Add(new BankAccount
            {
                Balance = (decimal)2845.00,
                BankName = "Kurska Banka",
                SwiftCode = "Kur"
            });

            accounts.Add(new BankAccount
            {
                Balance = (decimal)132845.00,
                BankName = "Kursk",
                SwiftCode = "Kur"
            });

            accounts.Add(new BankAccount
            {
                Balance = (decimal)246845.00,
                BankName = "Kurax",
                SwiftCode = "Kur"
            });

            accounts.Add(new BankAccount
            {
                Balance = (decimal)92402845.00,
                BankName = "Kurvenska banka",
                SwiftCode = "Kur"
            });

            accounts.Add(new BankAccount
            {
                Balance = (decimal)8462845.00,
                BankName = "Pichiui",
                SwiftCode = "Kur"
            });

            context.BankAccounts.AddRange(accounts);

            context.SaveChanges();
        }

        private static void AddCreditCards (BillsPaymentSystemContext context)
        {
            var cards = new List<CreditCard>();

            cards.Add(new CreditCard
            {
                Limit = (decimal)100000.00,
                MoneyOwned = 64,
                ExpirationDate = DateTime.Parse("15/02/2019")
            });

            cards.Add(new CreditCard
            {
                Limit = (decimal)1003500.00,
                MoneyOwned = 6400000,
                ExpirationDate = DateTime.Parse("15/12/2019")
            });

            cards.Add(new CreditCard
            {
                Limit = (decimal)1500000.00,
                MoneyOwned = 100064,
                ExpirationDate = DateTime.Parse("15/02/2029")
            });

            cards.Add(new CreditCard
            {
                Limit = (decimal)13500000.00,
                MoneyOwned = 4654564,
                ExpirationDate = DateTime.Parse("17/02/2019")
            });

            cards.Add(new CreditCard
            {
                Limit = (decimal)1000008.00,
                MoneyOwned = 6412034,
                ExpirationDate = DateTime.Parse("15/02/2019")
            });

            context.CreditCards.AddRange(cards);

            context.SaveChanges();
        }

        private static void AddPayments (BillsPaymentSystemContext context)
        {
            var payments = new List<PaymentMethod>();

            payments.Add(new PaymentMethod
            {
                Type = Models.Enums.PaymentType.BankAccount,
                UserId = 1,
                BankAccountId = 1
            });

            payments.Add(new PaymentMethod
            {
                Type = Models.Enums.PaymentType.CreditCard,
                UserId = 2,
                CreditCardId = 2
            });

            payments.Add(new PaymentMethod
            {
                Type = Models.Enums.PaymentType.BankAccount,
                UserId = 3,
                BankAccountId = 3
            });

            payments.Add(new PaymentMethod
            {
                Type = Models.Enums.PaymentType.CreditCard,
                UserId = 4,
                CreditCardId = 4
            });

            payments.Add(new PaymentMethod
            {
                Type = Models.Enums.PaymentType.BankAccount,
                UserId = 5,
                BankAccountId = 5
            });

            context.PaymentMethods.AddRange(payments);

            context.SaveChanges();
        }
    }
}
