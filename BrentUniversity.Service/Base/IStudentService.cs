using System.Collections.Generic;
using BrentUniversity.Data;

namespace BrentUniversity.Service.Base
{
    public interface IStudentService : IEntityService<Student>
    {
        Student GetById(int id);
        IEnumerable<Student> GetAllStudentsWithEnrollmentsAndFiltered();
    }
}
