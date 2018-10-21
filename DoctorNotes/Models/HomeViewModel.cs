//  --------------------------------------------------------------------------------------
// DoctorNotes.HomeViewModel.cs
// 2018/10/20
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace DoctorNotes.Models
{
    public class HomeViewModel
    {
        public Note CurrentNote { get; set; }

        public IEnumerable<Note> PreviousNotes { get; set; }
    }
}