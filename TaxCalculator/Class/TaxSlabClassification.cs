using TaxCalculator.Model;

namespace TaxCalculator.Class
{
    public class TaxSlabClassification
    {
        /// <summary>
        /// This function creates the Tax Slab for Senior Citizen
        /// </summary>
        /// <param name="taxableAmount"></param>
        /// <returns></returns>
        public double SeniorCitizen(double taxableAmount)
        {
            double tax = 0;
            List<SlabLimits> items = new List<SlabLimits> {new SlabLimits {LowerLimit=0,UpperLimit=240000,TaxRate=0},
                                                          new SlabLimits {LowerLimit=240000,UpperLimit=300000,TaxRate=0.1},
                                                          new SlabLimits {LowerLimit=300000,UpperLimit=500000,TaxRate=0.2},
                                                          new SlabLimits {LowerLimit=500000,UpperLimit=double.MaxValue,TaxRate=0.3}
                                                          };
            foreach (SlabLimits item in items)
            {
                if (taxableAmount > item.LowerLimit)
                {
                    if (taxableAmount <= item.UpperLimit)
                    {
                        tax += (taxableAmount - item.LowerLimit) * item.TaxRate;
                    }
                    else
                    {
                        tax += (item.UpperLimit - item.LowerLimit) * item.TaxRate;
                    }
                }
            }
            return tax;
        }
        /// <summary>
        /// This function creates the Tax Slab for Men
        /// </summary>
        /// <param name="taxableAmount"></param>
        /// <returns></returns>
        public double Male(double taxableAmount)
        {
            double tax = 0;
            List<SlabLimits> items = new List<SlabLimits> { new SlabLimits {LowerLimit=0,UpperLimit=160000,TaxRate=0},
                                                          new SlabLimits {LowerLimit=160000,UpperLimit=300000,TaxRate=0.1},
                                                          new SlabLimits {LowerLimit=300000,UpperLimit=500000,TaxRate=0.2},
                                                          new SlabLimits {LowerLimit=500000,UpperLimit=double.MaxValue,TaxRate=0.3}
                                                          };
            foreach (SlabLimits item in items)
            {
                if (taxableAmount > item.LowerLimit)
                {
                    if (taxableAmount <= item.UpperLimit)
                    {
                        tax += (taxableAmount - item.LowerLimit) * item.TaxRate;
                    }
                    else
                    {
                        tax += (item.UpperLimit - item.LowerLimit) * item.TaxRate;
                    }
                }
            }
            return tax;
        }
        /// <summary>
        /// This function creates tax slab for Female
        /// </summary>
        /// <param name="taxableAmount"></param>
        /// <returns></returns>
        public double Female(double taxableAmount)
        {
            double tax = 0;
            List<SlabLimits> items = new List<SlabLimits> { new SlabLimits {LowerLimit=0,UpperLimit=190000,TaxRate=0},
                                                          new SlabLimits {LowerLimit=190000,UpperLimit=300000,TaxRate=0.1},
                                                          new SlabLimits {LowerLimit=300000,UpperLimit=500000,TaxRate=0.2},
                                                          new SlabLimits {LowerLimit=500000,UpperLimit=double.MaxValue,TaxRate=0.3}
                                                          };
            foreach (SlabLimits item in items)
            {
                if (taxableAmount > item.LowerLimit)
                {
                    if (taxableAmount <= item.UpperLimit)
                    {
                        tax += (taxableAmount - item.LowerLimit) * item.TaxRate;
                    }
                    else
                    {
                        tax += (item.UpperLimit - item.LowerLimit) * item.TaxRate;
                    }
                }
            }
            return tax;
        }

    }
}
