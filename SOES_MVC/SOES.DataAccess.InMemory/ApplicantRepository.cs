using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using SOES.Core.Models;

namespace SOES.DataAccess.InMemory
{
    public class ApplicantRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Applicant> applicants = new List<Applicant>();
        public ApplicantRepository()
        {
            applicants = cache["applicants"] as List<Applicant>;
            if (applicants == null)
            {
                applicants = new List<Applicant>();
            }
        }
        public void Commit()
        {
            cache["applicants"] = applicants;
        }

        public void Insert(Applicant a)
        {
            applicants.Add(a);
        }
        public void Update(Applicant applicant)
        {
            Applicant applicanttoUpdate = applicants.Find(a => a.id == applicant.id);
            if (applicanttoUpdate != null)
            {
                applicanttoUpdate = applicant;
            }
            else
            {
                throw new Exception("Applicant Not Found");
            }
        }

        public Applicant Find(string id)
        {
            Applicant applicant = applicants.Find(a => a.id == id);
            if (applicant != null)
            {
                return applicant;
            }
            else
            {
                throw new Exception("Applicant Not Found");

            }
        }

        public IQueryable<Applicant> Collection()
        {
            return applicants.AsQueryable();
        }

        public void Delete (string id)
        {
            Applicant applicanttoDelete = applicants.Find(a => a.id == id);
            if (applicanttoDelete != null)
            {
                applicants.Remove(applicanttoDelete);
            }
            else
            {
                throw new Exception("Applicant Not Found");
            }
        }
    }
}
