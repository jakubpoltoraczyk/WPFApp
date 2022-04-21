using WebAppServer.Models;

namespace WebAppServer.Contexts.SQL.Comands
{
    public class MoqInsert_Palet : SqlComands<Palet>
    {
        public void Insert()
        {
            foreach (var item in MoqModels.MoqPaletList.GetInstance().GetMoqList())
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
            return "drop table \"PIOTEX\".\"Palet\" ";
        }
        public override string MakeInsertReq(Palet user)
        {
            string formattedDate = user.DateOfPlanting.ToString("yyyy/MM/dd HH:mm:ss");
            //2003/05/03 21:02:44
            return string.Format(
                            "INSERT INTO \"PIOTEX\".\"Palet\" " +
                            "(\"PaletNumber\", \"PaletPlantsType_Id\", \"DateOfPlanting\") " +
                            "VALUES " +
                            "('{0}', '{1}', (TO_DATE('{2}', 'yyyy/mm/dd hh24:mi:ss'))) ",
                            user.PaletNumber, user.PaletPlantsType_Id, formattedDate
                            );
        }
    }
}
