using WebAppServer.Models;

namespace WebAppServer.Contexts.SQL.Comands
{
    public class MoqInsert_Users : SqlComands<Users>
    {
        public void Insert()
        {
            foreach (var item in MoqModels.MoqUsersList.GetInstance().GetMoqList())
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
            return "drop table \"PIOTEX\".\"Users\" ";
        }
        public override string MakeInsertReq(Users user)
        {
            string formattedDate = user.Birthday.ToString("yyyy/MM/dd HH:mm:ss");
            //2003/05/03 21:02:44
            return string.Format(
                            "INSERT INTO \"PIOTEX\".\"Users\" " +
                            "(\"Name\", \"LastName\", \"Mail\", \"Phone\", \"Birthday\", \"UserCategory_Id\", \"Company_Id\") " +
                            "VALUES " +
                            "('{0}', '{1}', '{2}', '{3}', (TO_DATE('{4}', 'yyyy/mm/dd hh24:mi:ss')), {5}, {6}) ",
                            user.Name, user.LastName, user.Mail, user.Phone, formattedDate, user.UserCategory_Id, user.Company_Id
                            );
        }
    }
}
