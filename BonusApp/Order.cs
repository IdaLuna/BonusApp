using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusApp
{
    public delegate double BonusProvider(double amount); //SKULLE DELEGATEN HELLERE VÆRE HEROPPE?

    public class Order
    {
        // public delegate double BonusProvider(double amount); // ELLER HERNEDE?

        public List<Product> products = new List<Product>();

        public BonusProvider Bonus { get; set; }

        public void AddProduct(Product p) 
        { 
            products.Add(p);
        }

        public double GetValueOfProducts() 
        {
            double totalValue = 0.0;

            foreach (Product p in products)
            {
                totalValue += p.Value;
            }

            return totalValue;
        }


        public double GetBonus() 
        {
            double totalValue = GetValueOfProducts();

            BonusProvider bonus;
            BonusProvider bp1 = new BonusProvider(Bonuses.TenPercent);
            BonusProvider bp2 = new BonusProvider(Bonuses.FlatTwoIfAmountMoreThanFive);
            bonus = bp1;
            bonus += bp2;

            if (Bonus != null) // UNIT TESTEN SÆTTER SELV BONUS...
            {
                totalValue = Bonus(totalValue);
            }


            //double totalValue = 0.0;

            //foreach (Product p in products)
            //{
            //    totalValue += p.Value;
            //}

            //BonusProvider bonus;
            //BonusProvider bp1 = new BonusProvider(Bonuses.TenPercent);
            //BonusProvider bp2 = new BonusProvider(Bonuses.FlatTwoIfAmountMoreThanFive);
            //bonus = bp1;
            //bonus += bp2;

            //totalValue = bonus(totalValue);

            return totalValue;

        }

        public double GetTotalPrice() 
        {
            
            double totalValue = GetValueOfProducts();
            double bonus = GetBonus();
            double totalPrice = totalValue - bonus;

            return totalPrice;

            //double totalValue = 0.0;

            //foreach (Product p in products)
            //{
            //    totalValue += p.Value;
            //}

            //BonusProvider bonus = new BonusProvider(Bonuses.TenPercent);

            //totalValue = bonus(totalValue);

            //bonus = new BonusProvider(Bonuses.FlatTwoIfAmountMoreThanFive);

            //totalValue = bonus(totalValue);

            //return totalValue;
        }
    }
}
