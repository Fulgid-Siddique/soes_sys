using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SOES.Core.Models;
using SOES.DataAccess.InMemory;

namespace SOES.WebUI.Controllers
{
    public class ApplicantManagerController : Controller
    {

        ApplicantRepository context;

        public ApplicantManagerController()
        {
            context = new ApplicantRepository();
        }
        // GET: ApplicantManager
        public ActionResult Index()
        {
            List<Applicant> applicants = context.Collection().ToList();
            return View(applicants);
        }

        public ActionResult Create()
        {
            Applicant applicant = new Applicant();
            return View(applicant);
        }
        [HttpPost]
        public ActionResult Create(Applicant applicant)
        {
            if (!ModelState.IsValid)
            {
                return View(applicant);
            }
            else
            {
                context.Insert(applicant);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            Applicant applicant = context.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(applicant);
            }
        }
        [HttpPost]
        public ActionResult Edit(Applicant applicant, string id)
        {
            Applicant applicantToEdit = context.Find(id);
            if (applicantToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (ModelState.IsValid)
                    return View(applicant);
                {
                    applicantToEdit.ApplicantName = applicant.ApplicantName;
                    applicantToEdit.FatherName = applicant.FatherName;
                    applicantToEdit.Address = applicant.Address;
                    applicantToEdit.CellNo1 = applicant.CellNo1;
                    applicantToEdit.CellNo2 = applicant.CellNo2;
                    applicantToEdit.Education = applicant.Education;
                    applicantToEdit.PassportNo = applicant.PassportNo;
                    applicantToEdit.PPIssueDate = applicant.PassportNo;
                    applicantToEdit.PPExpiryDate = applicant.PPExpiryDate;
                    applicantToEdit.PPIssuePlace = applicant.PPIssuePlace;

                    context.Commit();

                    return RedirectToAction("Index");
                }

            }
        }

        public ActionResult Delete(string id)
        {
            Applicant applicantToDelete = context.Find(id);
            if (applicantToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(applicantToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            Applicant applicantToDelete = context.Find(id);
            if (applicantToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}