using WebAppServer.Models;

namespace WebAppServer.Contexts.SQL.Comands
{
    public class MoqInsert_CareSchedule : SqlComands<CareSchedule>
    {
        public void Insert()
        {
            foreach (var item in MoqModels.MoqCareScheduleList.GetInstance().GetMoqList())
            {
                Insert_T(item);
            }
        }

        public void Delete()
        {
            Delete_T();
        }

        public override string MakeDeleteReq()
        {
            return "drop table \"PIOTEX\".\"CareSchedule\" ";
        }
        public override string MakeInsertReq(CareSchedule user)
        {
            string formattedDate = user.TimeOfCare.ToString("yyyy/MM/dd HH:mm:ss");
            //2003/05/03 21:02:44
            return string.Format(
                            "INSERT INTO \"PIOTEX\".\"CareSchedule\" " +
                            "(\"TypeOfCare_Id\", \"PaletPlantsType_Id\", \"PriorityNumber\", \"TimeOfCare\") " +
                            "VALUES " +
                            "('{0}', '{1}', '{2}', (TO_DATE('{3}', 'yyyy/mm/dd hh24:mi:ss'))) ",
                            user.TypeOfCare_Id, user.PaletPlantsType_Id, user.PriorityNumber, formattedDate
                            );
        }
    }
}
