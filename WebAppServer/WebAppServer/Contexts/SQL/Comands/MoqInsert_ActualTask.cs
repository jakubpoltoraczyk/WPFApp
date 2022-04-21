using System;
using WebAppServer.Models;

namespace WebAppServer.Contexts.SQL.Comands
{
    public class MoqInsert_ActualTask : SqlComands<ActualTask>
    {
        public void Insert()
        {
            foreach (var item in MoqModels.MoqActualTaskList.GetInstance().GetMoqList())
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
            return "drop table \"PIOTEX\".\"ActualTask\" ";
        }

        public override string MakeInsertReq(ActualTask user)
        {
            string formattedDate = "";
            if (user.RealizationDate != null)
            {
                formattedDate = ((DateTime)user.RealizationDate).ToString("yyyy/MM/dd HH:mm:ss");
            }
            //2003/05/03 21:02:44
            return string.Format(
                            "INSERT INTO \"PIOTEX\".\"ActualTask\" " +
                            "(\"ActualTaskId\", \"RealizationDate\", \"Palet_Id\", \"User_Id\", \"CareSchedule_Id\") " +
                            "VALUES " +
                            "('{0}', (TO_DATE('{1}', 'yyyy/mm/dd hh24:mi:ss')), '{2}', '{3}', '{4}' ) ",
                            user.ActualTaskId, formattedDate, user.Palet_Id, user.User_Id, user.CareSchedule_Id
                            ); 
        }
    }
}
