using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTestServiceClient.DTO;

namespace EduTestServiceClient.Repositories
{
    public class TestsRepository : GenericRepository<Test>, ITestsRepository
    {
        public TestsRepository(string serviceUrl, IAuthenticationService authenticator) 
            : base(serviceUrl, "tests", authenticator)
        {
        }
    }
}
