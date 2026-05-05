using Example.Data;
using Example.Models.Domain;
using Example.Models.ViewModel;

namespace Example.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private SchoolDbContext dbContext;

        public StudentRepository(SchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Student> GetAll(string? searchString, string? type)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var list = from l in dbContext.Students select l;
                if (type == "Mssv")
                    return list.Where(s => s.Mssv.Contains(searchString));
                else
                    return list.Where(s => s.Name.Contains(searchString));
            }
            return dbContext.Students;
        }

        public VMStudent? GetStudentsById(int id)
        {
            var student = dbContext.Students.FirstOrDefault(p => p.Id == id);
            if (student != null)
            {
                string genderVm = student.Gender == false ? "female" : "male";
                return new VMStudent()
                {
                    Id = id,
                    Name = student.Name,
                    Birth = student.Birth,
                    ImgUrl = student.ImgUrl,
                    Gender = genderVm,
                    Mssv = student.Mssv,
                    Description = student.Description,
                };
            }
            return null;
        }

        public void UpdateStudentById(int id, VMStudent model)
        {
            var student = dbContext.Students.FirstOrDefault(p => p.Id == id);
            if (student != null)
            {
                student.Name = model.Name;
                student.Birth = model.Birth;
                student.Gender = model.Gender == "male";
                student.ImgUrl = model.ImgUrl;
                student.Mssv = model.Mssv;
                student.Description = model.Description;
                dbContext.Update(student);
                dbContext.SaveChanges();
            }
        }

        public void AddStudent(VMStudent model)
        {
            var student = new Student()
            {
                Name = model.Name,
                Birth = model.Birth,
                Gender = model.Gender == "male",
                ImgUrl = model.ImgUrl,
                Mssv = model.Mssv,
                Description = model.Description
            };
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }

        public void DeleteStudentById(int id)
        {
            var student = dbContext.Students.FirstOrDefault(p => p.Id == id);
            if (student != null)
            {
                dbContext.Students.Remove(student);
                dbContext.SaveChanges();
            }
        }
    }
}
