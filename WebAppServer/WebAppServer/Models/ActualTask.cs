using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.Models
{
    /// <summary>
    /// Class model that holds values about actual and done tasks
    /// </summary>
    public class ActualTask
    {
        [Key]
        public int ActualTaskId { get; set; }
        public DateTime? RealizationDate { get; set; }               //data faktycznego zrobienia przez usera,  data kiedy powinno sie zrobic -> obliczona z Palet.DateOfPlanting + CareSchedule.TimeOfCare
        public int Palet_Id { get; set; }
        public int? User_Id { get; set; }                            // id usera który wykonal zadanie
        public int CareSchedule_Id { get; set; }

    }
}
