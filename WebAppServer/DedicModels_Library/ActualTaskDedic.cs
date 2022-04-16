using System;

namespace DedicModels_Library
{
    /// <summary>
    /// Model Class that holds joined values from database about tasks to do and done
    /// </summary>
    public class ActualTaskDedic
    {
        //public int ActualTaskId { get; set; }
        //----------------Data to update--------------------------
        public int? User_Id { get; set; }                            
        public DateTime? RealizationDate { get; set; }
        //----------------Data to set--------------------------
        //public int Palet_Id { get; set; }
        public int PaletNumber { get; set; }
        public DateTime DateOfPlanting { get; set; }
        //public int PaletPlantsType_Id { get; set; }
            public string PaletPlantsTypeName { get; set; }

        //public int CareSchedule_Id { get; set; }
            public DateTime TimeOfCare { get; set; }
            public int PriorityNumber { get; set; }
            //public int TypeOfCare_Id { get; set; }
                public string TypeOfCareName { get; set; }

    }
}
