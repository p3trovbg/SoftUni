namespace _02.VaniPlanning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Agency : IAgency
    {
        private Dictionary<string, Invoice> invoicesById = new Dictionary<string, Invoice>();
        public void Create(Invoice invoice)
        {
            if(Contains(invoice.SerialNumber))
            {
                throw new ArgumentException();
            }

            invoicesById.Add(invoice.SerialNumber, invoice);
        }

        public void ThrowInvoice(string number)
        {
            var newList = invoicesById.Where(x => x.Value.SerialNumber != number).ToDictionary(x => x.Key, x => x.Value);
            if(newList.Count == invoicesById.Count)
            {
                throw new ArgumentException();
            }

            invoicesById = newList;
        }

        public void ThrowPayed() 
            => invoicesById = invoicesById.Where(x => x.Value.Subtotal != 0).ToDictionary(x => x.Key, x => x.Value);

        public int Count() => invoicesById.Count;

        public bool Contains(string number) => invoicesById.ContainsKey(number);

        public void PayInvoice(DateTime due)
        {
            var payedInvoices = invoicesById.Values.Where(x => x.DueDate == due).ToList();
            if(payedInvoices.Count == 0)
            {
                throw new ArgumentException();
            }

            payedInvoices.ForEach(x => x.Subtotal = 0);
        }

        public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
         => invoicesById.Values
            .Where(x => x.IssueDate >= start && x.IssueDate <= end)
            .OrderBy(x => x.IssueDate)
            .ThenBy(x => x.DueDate);
        public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
        {
         var selected = invoicesById.Values.Where(x => x.SerialNumber.Contains(serialNumber)).OrderByDescending(x => x.SerialNumber);
            if(selected.Count() == 0)
            {
                throw new ArgumentException();
            }

            return selected;
        }

        public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
        {
            int previousCount = invoicesById.Count;

            invoicesById = invoicesById
            .Where(x => x.Value.DueDate <= start || x.Value.DueDate >= end).ToDictionary(x => x.Key, x=> x.Value);

            if(previousCount == invoicesById.Count)
            {
                throw new ArgumentException();
            }

            return invoicesById.Values;

        }

        public IEnumerable<Invoice> GetAllFromDepartment(Department department)
          => invoicesById.Values.Where(x => x.Department == department).OrderByDescending(x => x.Subtotal).ThenBy(x => x.IssueDate);

        public IEnumerable<Invoice> GetAllByCompany(string company)
          => invoicesById.Values.Where(x => x.CompanyName == company).OrderByDescending(x => x.SerialNumber);

        public void ExtendDeadline(DateTime dueDate, int days)
        {
            var selectedInvoices = invoicesById.Values.Where(x => x.DueDate == dueDate).ToList();
            if(selectedInvoices.Count() == 0)
            {
                throw new ArgumentException();
            }

            selectedInvoices.ForEach(x => x.DueDate = x.DueDate.AddDays(days));
        }
    }
}
