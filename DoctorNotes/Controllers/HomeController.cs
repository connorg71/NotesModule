using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DoctorNotes.Models;

namespace DoctorNotes.Controllers
{
    public class HomeController : Controller
    {
        static readonly List<Note> Notes = new List<Note>
                                           {
                                               new Note {Id = 1, Notes = "<p>Note 1</p>"},
                                               new Note {Id = 2, Notes = "<p>Note 2</p>"},
                                               new Note {Id = 3, Notes = "<p>Note 3</p>"}
                                           };

        // GET: Home
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel {CurrentNote = new Note(), PreviousNotes = Notes};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(HomeViewModel viewModel)
        {
            // TODO:  Insert the new note into the DNN database
            viewModel.CurrentNote.Id = Notes.Count + 1;
            Notes.Add(viewModel.CurrentNote);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult NotificationSent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Notify()
        {

            // TODO:  Retrieve the newest message from the DNN database
            var message = Notes.OrderBy(p => p.Id)
                               .Last();

            // TODO:  Send an email using DNN
            return RedirectToAction(nameof(NotificationSent));
        }
    }
}