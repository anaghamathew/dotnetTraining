using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCMovieApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCMovieApp.Models
{
    public class LicenceDetails
    {
        /*[ForeignKey("Movie")]
        public int MovieId { get; set; }*/
        public int Id { get; set; }
        public string LicencyName { get; set; }

        public String Address1 { get; set; }
    }
}
