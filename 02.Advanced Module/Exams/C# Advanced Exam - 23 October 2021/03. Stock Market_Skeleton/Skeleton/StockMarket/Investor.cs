using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest - stock.PricePerShare > 0)
            {
                Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            var company = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if (company == null)
            {
                return $"{companyName} does not exist.";
            }
            else if (company.PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                Portfolio.Remove(company);
                return $"{companyName} was sold.";
            }
        }
        public Stock FindStock(string companyName)
        {
            return Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var stocks in Portfolio)
            {
                sb.AppendLine(stocks.ToString().TrimEnd());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
