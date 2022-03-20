using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SplitExcelTool.Model
{
    public class Patient
    {
        [Key]
        public string TestCode { get; set; }
        public string FullName { get; set; }
        public string Result { get; set; }



    }
    public enum PatientIndex
	{
        FulllName = 3,
        Result = 12,
        TestCode = 11
    }
}