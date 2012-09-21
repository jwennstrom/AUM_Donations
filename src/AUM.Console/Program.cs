using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUM.Data;
using AUM.Domain;

namespace AUM.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var d = new Donor
                {
                    CreatedOn = DateTime.Now,
                    Name = "Joe Donor",
                    Phone = "512-555-1212"
                };

                var dt = new Donation
                {
                    Donor = d,
                    Amount=100.25m,
                    CreatedOn = DateTime.Now,
                    DateOfDonation = DateTime.Now
                };

                session.SaveOrUpdate(dt);
                session.Flush();
            }
            
        }
    }
}
