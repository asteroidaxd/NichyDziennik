//using System;
//using DziennikOcen;

//public class najwnajnsrednia
//{
//    public decimal ObliczSrednia()
//    {
//        if (Oceny.Count == 0)
//            return 0;

//        return Oceny.Average();
//    }

//    public decimal ObliczNajwyzszaSrednia(List<List<decimal>> zestawyOcen)
//    {
//        if (zestawyOcen.Count == 0)
//            return null;

//        return zestawyOcen.Max(zestaw => zestaw.Average());
//    }

//    public decimal ObliczNajmniejszaSrednia(List<List<decimal>> zestawyOcen)
//    {
//        if (zestawyOcen.Count == 0)
//            return null;

//        return zestawyOcen.Min(zestaw => zestaw.Average());
//    }
//    List<List<decimal>> zestawyOcen = new List<List<decimal>>
//    {
//    new List<decimal> { 5.0m, 4.5m, 3.0m },
//    new List<decimal> { 4.0m, 4.0m, 4.0m },
//    new List<decimal> { 3.5m, 4.5m, 5.0m }
//    };

//    decimal najwyzszaSrednia = przedmiot.ObliczNajwyzszaSrednia(zestawyOcen);
//    decimal najmniejszaSrednia = przedmiot.ObliczNajmniejszaSrednia(zestawyOcen);
//}
