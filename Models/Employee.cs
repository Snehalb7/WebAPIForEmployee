namespace WebAPIForEmployee.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public DateTime CreatedDate { get; set; }

        public int isActive { get; set; }
    }
}
