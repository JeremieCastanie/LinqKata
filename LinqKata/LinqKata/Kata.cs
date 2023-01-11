using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;

namespace LinqKata;

public class Kata
{
    public static double GetMaxAverage(
        IEnumerable<int> input1,
        IEnumerable<int> input2,
        IEnumerable<int> input3)
    {
        return Math.Max(Math.Max(input1.Average(), input2.Average()), input3.Average());
    }

    public static IEnumerable<int> Flat(IEnumerable<IEnumerable<int>> input)
    {
        return input.SelectMany(x => x);
    }

    public static IEnumerable<Car> OrderByMarkAndPrice(IEnumerable<Car> cars)
    {
        return cars.OrderBy(x => x.Mark).ThenBy(x => x.Price);
    }

    public static IEnumerable<string> GetFrom4To6(IEnumerable<string> input)
    {
        return input.Skip(4).Take(3);
    }

    public static IEnumerable<int> Inverse(IEnumerable<int> input)
    {
        return input.Reverse();
    }

    public static IEnumerable<Analysis> GetAnalyses(IEnumerable<Equity> equities, IEnumerable<Bond> bonds)
    {
        return (
            from e in equities.Distinct()
            from b in bonds.Distinct()
            select new Analysis
            {
                EquityCode = e.Code,
                BondCode = b.Code
            });
    }

    public static IEnumerable<Car> GetMaxPriceByMark(IEnumerable<Car> input)
    {
        return (
            from c in input
            group c by c.Mark into carsGroupMarks
            select new Car
            {
                Mark = carsGroupMarks.Key,
                Price = carsGroupMarks.Max(x => x.Price)
            });
    }

    public static IDictionary<string, int> GetDictionary(IEnumerable<string> input)
    {
        var groupement = (
            from x in input
            group x by x into elementsGroupes
            select new
            {
                Element = elementsGroupes.Key,
                NbreElements = elementsGroupes.Count()
            });

        IDictionary<string, int> res = new Dictionary<string, int>();
        foreach(var x in groupement)
        {
            res.Add(x.Element, x.NbreElements);
        }
        return res;
    }
}