using System;

namespace Switch4
{
    class Member
    {
        public bool VIP { get; set; }
    }

    class NonMember
    {
        public bool HasCoupon { get; set; }
    }


    class MainApp
    {
        static double GetDiscountRate(object customer)
        {
            return customer switch
            {
                Member c when c.VIP == true  => 0.15,
                Member c                     => 0.1,                
                NonMember s when s.HasCoupon => 0.1,
                _                            => 0
            };
        }

        static double GetActualPrice(double price, object customer)
        {
            return price * (1 - GetDiscountRate(customer));
        }

        static void Main(string[] args)
        {   
            Member Alice = new Member();
            Member Bob = new Member() { VIP = true };
            NonMember Charlie = new NonMember();
            NonMember Dave= new NonMember() { HasCoupon = true };

            double price = 1000;
            Console.WriteLine($"The original price: ${price}");
            Console.WriteLine($"Alice pays          ${GetActualPrice(price, Alice)}");
            Console.WriteLine($"Bob pays            ${GetActualPrice(price, Bob)}");
            Console.WriteLine($"Charlie pays        ${GetActualPrice(price, Charlie)}");
            Console.WriteLine($"Dave    pays        ${GetActualPrice(price, Dave)}");
        }
    }
}
