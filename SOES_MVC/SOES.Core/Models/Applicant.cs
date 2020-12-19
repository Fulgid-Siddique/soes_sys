using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOES.Core.Models
{
    public class Applicant
    {
        public string id { get; set; }
        [DisplayName("Name")]
        public string ApplicantName { get; set; }
        [DisplayName("F/Name")]
        public string FatherName { get; set; }
        public string DOB { get; set; }
        [StringLength(13)]
        public string CNIC { get; set; }
        [StringLength(9)]
        public string PassportNo { get; set; }
        public string PPIssueDate { get; set; }
        public string PPExpiryDate { get; set; }
        public string PPIssuePlace { get; set; }
        public string Trade { get; set; }
        public string Address { get; set; }
        public string Education { get; set; }
        public string LocalExpereince { get; set; }
        public string AbrodaExpereince { get; set; }
        public string CellNo1 { get; set; }
        public string CellNo2 { get; set; }
        public string Ref { get; set; }
        public string Image { get; set; }

        public Applicant()
        {
            this.id = Guid.NewGuid().ToString();
        }


    }
}
