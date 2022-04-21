using WebAppServer.Models;

namespace WebAppServer.Contexts.SQL.Comands
{
    public class MoqInsert_PaletPlantsType : SqlComands<PaletPlantsType>
    {
        public void Insert()
        {
            foreach (var item in MoqModels.MoqPaletPlantsTypeList.GetInstance().GetMoqList())
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
            return "drop table \"PIOTEX\".\"PaletPlantsType\" ";
        }
        public override string MakeInsertReq(PaletPlantsType user)
        {
            return string.Format(
                            "INSERT INTO \"PIOTEX\".\"PaletPlantsType\" " +
                            "(\"PaletPlantsTypeName\") " +
                            "VALUES " +
                            "('{0}') ",
                            user.PaletPlantsTypeName
                            );
        }
    }
}
