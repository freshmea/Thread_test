using System;
using System.Collections.Generic;

namespace ReadonlyStruct
{
    readonly struct Transaction
    {
        public Transaction(string from, string to, int amount)
        {
            transactionId = Guid.NewGuid();
            this.from = from;
            this.to = to;
            this.amount = amount;
        }

        public readonly Guid transactionId;
        public readonly string from;
        public readonly string to;
        public readonly int amount;
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(new Transaction("Alice", "Bob", 100));
            transactions.Add(new Transaction("Alice", "Charlie", 50));
            transactions.Add(new Transaction("Bob", "Charlie", 20));
            transactions.Add(new Transaction("Dave", "Alice", 40));

            int revenue = 0;
            int expense = 0;
            foreach(var t in transactions)
            {
                if (t.from == "Alice")
                    revenue += t.amount;
                else if (t.to == "Alice")
                    expense += t.amount;
            }

            Console.WriteLine($"Alice's profit : {revenue - expense}");
        }
    }
}