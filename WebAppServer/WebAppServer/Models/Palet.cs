using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.Models
{
    /// <summary>
    /// Class model that holds informations about Palets
    /// </summary>
    public class Palet
    {
        [Key]
        public int PaletId { get; set; }
        public int PaletNumber { get; set; }
        public int PaletPlantsType_Id { get; set; }
        public DateTime DateOfPlanting { get; set; }
    }
}
