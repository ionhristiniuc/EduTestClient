﻿using EduTestServiceClient.DTO;

namespace EduTestServiceClient.Repositories
{
    public interface IUsersRepository : IGenericRepository<User>
    {
         // some specific users related methods

        void AddCourseToUser(int userId, int courseId);
    }    
}