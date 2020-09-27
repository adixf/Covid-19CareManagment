using CareManagment.BL.Interfaces;
using CareManagment.DAL;
using CareManagment.DAL.Interfaces;
using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Accord.MachineLearning;

namespace CareManagment.BL
{
    public class BLImp : IBL
    {
        public IRepository IRepository { get; set; }

        public BLImp()
        {
            IRepository = new Repository();
        }

        #region update db
        public void AddVolunteer(Volunteer volunteer)
        {
            IRepository.AddVolunteer(volunteer);
        }
        public void AddAdmin(Admin admin)
        {
            IRepository.AddAdmin(admin);
        }
        public void AddRecipient(Recipient recipient)
        {
            IRepository.AddRecipient(recipient);
        }

        public void AddDistribution(Distribution distribution)
        {
            IRepository.AddDistribution(distribution);
        }
        public void AddDistributions(List<Distribution> distributions)
        {
            foreach(Distribution d in distributions)
                IRepository.AddDistribution(d);
        }
        public void UpdateDistribution(Distribution distribution)
        {
            IRepository.UpdateDistribution(distribution);
        }

        public void AddPackage(Package package)
        {
            IRepository.AddPackage(package);
        }
        //public void UpdatePerson(Person person)
        //{
        //    IRepository.UpdatePerson(person);
        //}

        //public void DeletePerson(Person person)
        //{
        //    IRepository.DeletePerson(person);
        //}


        #endregion

        #region fetch from db
        public List<Recipient> GetAllRecipients(Func<Recipient, bool> predicate = null)
        {
           return IRepository.GetAllRecipients(predicate);
        }
        public List<Volunteer> GetAllVolunteers(Func<Volunteer, bool> predicate = null)
        {
            return IRepository.GetAllVolunteers(predicate);
        }

        public List<Admin> GetAllAdmins(Func<Admin, bool> predicate = null)
        {
            return IRepository.GetAllAdmins(predicate);
        }


        public List<Package> GetAllPackages(Func<Package, bool> predicate = null)
        {
            return IRepository.GetAllPackages(predicate);
        }


        public List<Distribution> GetAllDistributions(Func<Distribution, bool> predicate = null)
        {
            return IRepository.GetAllDistributions(predicate);
        }

        public JsonAddress GetAddressDetails(Address address)
        {
            return IRepository.GetAddressDetails(address);
        }

        #endregion

        #region Distribution Creation
        public List<Package>[] DividePackages(List<Package> Packages, int K)
        {
            // create locations array for k-means algorithm
            double[][] Locations = new double[Packages.Count][];
            int i = 0;
            foreach (var p in Packages)
            {
                Locations[i] = new double[2];
                Locations[i][0] = p.Recipient.Address.Lat;
                Locations[i][1] = p.Recipient.Address.Lat;

                i++;
            }

            // send array to algorithm
            int[] result = CreateKClusters(K, Locations);

            // create and return k lists of packages
            List<Package>[] DividedPackages = new List<Package>[K];

            // init empty lists
            for(int l=0; l<K; l++)
            {
                DividedPackages[l] = new List<Package>();
            }

            // fill lists with packages according to k-means result
            for (int p = 0; p < Packages.Count; p++)
            {
                DividedPackages[result[p]].Add(Packages[p]);
            }
            return DividedPackages;

        }

        public Volunteer FindClosestVolunteer(List<Volunteer> Volunteers, Address address)
        {
           
            double lat1 = address.Lat;
            double lon1 = address.Lon;
            
            double lat2, lon2, MinDistance;

            // initial distance
            Volunteer ClosestVolunteer = Volunteers[0];
            
            lat2 = ClosestVolunteer.Address.Lat;
            lon2 = ClosestVolunteer.Address.Lon;

            MinDistance = HarvestineDistance(lat1, lon1, lat2, lon2);

            // find minimum distance
            foreach (Volunteer v in Volunteers)
            {
                lat2 = v.Address.Lat;
                lon2 = v.Address.Lon;
               
                double dist = HarvestineDistance(lat1, lon1, lat2, lon2);
                if (dist < MinDistance)
                {
                    MinDistance = dist;
                    ClosestVolunteer = v;
                }

            }

            return ClosestVolunteer;
        }

        private int[] CreateKClusters(int k, double[][]locations)
        {
            Accord.Math.Random.Generator.Seed = 0;

            // Create a new K-Means algorithm with 3 clusters 
            KMeans kmeans = new KMeans(k);
            
            KMeansClusterCollection clusters = kmeans.Learn(locations);

            int[] labels = clusters.Decide(locations);
            return labels;
        }

        private double HarvestineDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6372.8; // In kilometers
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);
            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Asin(Math.Sqrt(a));
            return R * 2 * Math.Asin(Math.Sqrt(a));
        }

        private double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }


        #endregion
    }
}
