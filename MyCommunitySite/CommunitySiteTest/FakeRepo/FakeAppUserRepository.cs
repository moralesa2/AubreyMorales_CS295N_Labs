using MyCommunitySite.Models;

namespace CommunitySiteTest.FakeRepo
{
    public class FakeAppUserRepository : IRepository<AppUser>
    {
        private List<AppUser> appUsers = new List<AppUser>();

        public  AppUser? Get(int id)
        {
            AppUser appUser = appUsers.Find(a => Int32.Parse(a.Id) == id);
            return appUser;
        }

        public int StoreUser(AppUser model)
        {
            int status = 0;
            if (model != null)
            {
                model.Id = (appUsers.Count + 1).ToString();
                appUsers.Add(model);
                status = 1;
            }
            return status;
        }

        public void Insert(AppUser entity) => appUsers.Add(entity);

        public IEnumerable<AppUser> List(QueryOptions<AppUser> options) => appUsers;

        public AppUser? Get(QueryOptions<AppUser> options)
        {
            throw new NotImplementedException();
        }

        public void Update(AppUser entity) { }
        public void Delete(AppUser entity) { }
        public void Delete(int id) { }
        public void Save() { }
    }
}
