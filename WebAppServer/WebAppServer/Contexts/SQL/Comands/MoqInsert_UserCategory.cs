using WebAppServer.Models;

namespace WebAppServer.Contexts.SQL.Comands
{
    public class MoqInsert_UserCategory : SqlComands<UserCategory>
    {
        public void Insert()
        {
            foreach (var item in MoqModels.MoqUserCategoryList.GetInstance().GetMoqList())
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
            return "drop table \"PIOTEX\".\"UserCategory\" ";
        }
        public override string MakeInsertReq(UserCategory user)
        {
            return string.Format(
                            "INSERT INTO \"PIOTEX\".\"UserCategory\" " +
                            "(\"UserCategoryName\") " +
                            "VALUES " +
                            "('{0}') ",
                            user.UserCategoryName
                            );
        }
    }
}
