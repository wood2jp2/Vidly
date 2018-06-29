using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genre
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}