using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTestServiceClient.DTO;

namespace EduTestServiceClient.Repositories
{
    public class QuestionsRepository : GenericRepository<Question>, IQuestionsRepository
    {
        public QuestionsRepository(string serviceUrl, IAuthenticationService authenticator)
            : base(serviceUrl, "questions", authenticator)
        {
        }
    }
}
