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
                //using (var uow = new NHibernateUnitOfWork())
                //{
                //    var donorRep = new Repository<Donor>(uow.Session);
                //    var donationRep = new Repository<Donation>(uow.Session);

                //    var d = new Donor
                //    {
                //        CreatedOn = DateTime.Now,
                //        Name = "Joe Donor",
                //        Phone = "512-555-1212"
                //    };

                //    var dt = new Donation
                //    {
                //        Donor = d,
                //        Amount = 100.25m,
                //        CreatedOn = DateTime.Now,
                //        DateOfDonation = DateTime.Now
                //    };

                //    donorRep.Add(d);
                //    donationRep.Add(dt);

                //    uow.Commit();
                //}

                // Sample of fetching a row
                using (var uow = new NHibernateUnitOfWork())
                {
                    var donorRep = new Repository<Donor>(uow.Session);
                    var donors = donorRep.Select(x=>x);
                }
            }
            
        }
    }
}
