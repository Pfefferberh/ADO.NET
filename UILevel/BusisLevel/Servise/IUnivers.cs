using BusisLevel.ModelDTO;
using System.Collections.Generic;

namespace BusisLevel.Servise
{
    public interface IUnivers
    {
        IEnumerable<StudentDTO> GetStudents();
        IEnumerable<GroupDTO> GetGroup();
        void AddStudents(StudentDTO student);
        void AddGroup(GroupDTO group);
        void DeleteStudent(StudentDTO students);
        void DeleteGroup(GroupDTO group);
        void UpdateStudent(StudentDTO students);
        void UpdateGroup(GroupDTO group);
    }
}
