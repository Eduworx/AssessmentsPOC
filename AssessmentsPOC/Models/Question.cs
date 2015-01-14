using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssessmentsPOC.Models
{
    public class Question
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public AssessmentTypes Type { get; set; }

        public double Grade { get; set; }

        [Key, ForeignKey("Assessment")]
        public int AssessmentId { get; set; }

        public virtual List<Option> Options { get; set; }
    }
}