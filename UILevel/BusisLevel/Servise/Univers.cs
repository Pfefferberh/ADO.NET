using AutoMapper;
using BusisLevel.ModelDTO;
using DBLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using DBLevel.Reposetory;

namespace BusisLevel.Servise
{
   public  class Univers : IUnivers
    {
        private readonly IGenericRepository<Student> repoStudent;
        private readonly IGenericRepository<Groups> repoGroup;
        private readonly IMapper mapper;
        public Univers(IGenericRepository<Student> _repoStudent,
           IGenericRepository<Groups> _repoGroup, IMapper _mapper)
        {
            repoStudent = _repoStudent;
            repoGroup = _repoGroup;
            mapper = _mapper;
        }
        public void AddGroup(GroupDTO group)
        {
            var addGroup = mapper.Map<Groups>(group);
            repoGroup.Create(addGroup);
        }

        public void AddStudents(StudentDTO student)
        {
            var addStudent = mapper.Map<Student>(student);
            var group = repoGroup.Read().FirstOrDefault(x => x.Name == student.GroupName);
            addStudent.Groups = group;
            repoStudent.Create(addStudent);
        }

        public void DeleteGroup(GroupDTO group)
        {
            var deleteGroup = mapper.Map<Groups>(group);
            repoGroup.Delete(deleteGroup);
        }

        public void DeleteStudent(StudentDTO student)
        {
            var deleteStudent = mapper.Map<Student>(student);
            var group = repoGroup.Read().FirstOrDefault(x => x.Name == student.GroupName);
            deleteStudent.Groups = group;
            var del = repoStudent.Read().FirstOrDefault(x => x.Id == deleteStudent.Id);
            repoStudent.Delete(del);
        }

        public IEnumerable<GroupDTO> GetGroup()
        {
            var group = repoGroup.Read();
            var modelGroup = mapper.Map<ICollection<GroupDTO>>(group);
            return modelGroup;
        }

        public IEnumerable<StudentDTO> GetStudents()
        {
            var student = repoStudent.Read().ToList();
            var modelStudent = mapper.Map<ICollection<StudentDTO>>(student);
            return modelStudent;
        }

        public void UpdateGroup(GroupDTO group)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(StudentDTO students)
        {
            var updateStudent = mapper.Map<Student>(students);
            var group = repoGroup.Read().FirstOrDefault(x => x.Name == students.GroupName);
            updateStudent.Groups = group;
            updateStudent.IdGroup = group.Id;
            var up = updateStudent;
            repoStudent.Update(up);
        }
    }
}
