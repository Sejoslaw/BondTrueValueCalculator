using System;

namespace BondTrueValueCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cena sprawiedliwa - we are looking for that
            double fairPrice = 0;

            // Cena sprzedaży
            Assign("Selling Price ($) = ", out double sellingPrice);
            // Obligacja x-letnia
            Assign("Years = ", out double years);
            // Odsetki (%)
            Assign("Interest Rate (%) = ", out double interestRate);
            // Wartość nominalna
            Assign("Nominal Price ($) = ", out double nominalPrice);
            // Rentowność bonów skarbowych (%)
            Assign("Yield of Treasury Bills (%) = ", out double treasuryBillYield); 

            double interest = nominalPrice * interestRate;

            for (int i = 1; i <= years; ++i)
            {
                fairPrice += interest / Math.Pow(1 + treasuryBillYield, i);
            }

            fairPrice += nominalPrice / Math.Pow(1 + treasuryBillYield, years);

            Console.WriteLine($"Fair Price = { fairPrice }");

            if (fairPrice > sellingPrice)
            {
                Console.WriteLine("BUY !!!");
            }
            else
            {
                Console.WriteLine("DON'T TOUCH IT !!!");
            }

            Console.ReadKey();
        }

        static void Assign(string message, out double value)
        {
            Console.Write(message);
            double.TryParse(Console.ReadLine(), out value);
        }
    }
}
