using WebAppServer.Models;

namespace WebAppServer.Contexts.SQL.Comands
{
    public class MoqInsert_Company : SqlComands<Company>
    {
        public void Insert()
        {
            foreach (var item in MoqModels.MoqCompanyList.GetInstance().GetMoqList())
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
            return "drop table \"PIOTEX\".\"Company\" ";
        }
        public override string MakeInsertReq(Company user)
        {
            return string.Format(
                            "INSERT INTO \"PIOTEX\".\"Company\" " +
                            "(\"CompanyName\") " +
                            "VALUES " +
                            "('{0}') ",
                            user.CompanyName
                            );
        }
    }
}
