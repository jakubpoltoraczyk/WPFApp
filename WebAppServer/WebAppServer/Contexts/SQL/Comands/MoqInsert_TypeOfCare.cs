using WebAppServer.Models;

namespace WebAppServer.Contexts.SQL.Comands
{
    public class MoqInsert_TypeOfCare : SqlComands<TypeOfCare>
    {
        public void Insert()
        {
            foreach (var item in MoqModels.MoqTypeOfCareList.GetInstance().GetMoqList())
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
            return "drop table \"PIOTEX\".\"TypeOfCare\" ";
        }
        public override string MakeInsertReq(TypeOfCare user)
        {
            return string.Format(
                            "INSERT INTO \"PIOTEX\".\"TypeOfCare\" " +
                            "(\"TypeOfCareName\") " +
                            "VALUES " +
                            "('{0}') ",
                            user.TypeOfCareName
                            );
        }
    }
}
