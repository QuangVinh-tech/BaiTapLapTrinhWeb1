using Example.Models.Repository;
using Example.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    [Authorize] 
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        
        public IActionResult GetAll(string? searchString, string? type)
        {
            var allStudent = _studentRepository.GetAll(searchString, type);
            return View(allStudent);
        }

        
        public IActionResult GetStudentById(int id)
        {
            var student = _studentRepository.GetStudentsById(id);
            if (student != null) return View(student);
            return View("NotFound");
        }

       
        [Authorize(Roles = "Admin,Editor")]
       
        [HttpGet]
        public IActionResult EditStudentById(int id)
        {
            var studentVM = _studentRepository.GetStudentsById(id);
            if (studentVM != null) return View(studentVM);
            return View("NotFound");
        }

        [Authorize(Roles = "Admin,Editor")]
        
        [HttpPost]
        public IActionResult EditStudentById([FromRoute] int id, VMStudent student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existing = _studentRepository.GetStudentsById(id);
                    if (existing != null)
                    {
                        _studentRepository.UpdateStudentById(id, student);
                        TempData["successMessage"] = "Cập nhật thành công!";
                        return RedirectToAction("GetAll");
                    }
                    return View("NotFound");
                }
                TempData["errorMessage"] = "Dữ liệu không hợp lệ";
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

       
        [Authorize(Roles = "Admin,Editor")]
       
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Editor")]
       
        [HttpPost]
        public IActionResult AddStudent(VMStudent studentData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentRepository.AddStudent(studentData);
                    TempData["successMessage"] = "Thêm sinh viên thành công!";
                    return RedirectToAction("GetAll");
                }
                TempData["errorMessage"] = "Dữ liệu không hợp lệ";
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

       
        [Authorize(Roles = "Admin")]
       
        public IActionResult DelStudentById(int id)
        {
            var student = _studentRepository.GetStudentsById(id);
            if (student != null)
            {
                _studentRepository.DeleteStudentById(id);
                TempData["successMessage"] = "Đã xóa!";
                return RedirectToAction("GetAll");
            }
            return View("NotFound");
        }
    }
}

