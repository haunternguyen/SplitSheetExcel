using SplitExcelTool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitExcelTool.Repositories
{
	public interface IPatientRepository
	{
		Patient AddPatient(Patient category);

		List<Patient> GetAllPatients();

		Patient GetPatientByTestCode(string testCode);
	}

	public class PatientRepository : DatabaseRepositoryBase, IPatientRepository
	{
		public Patient AddPatient(Patient patient)
		{
			DataContext.Patients.Add(patient);
			DataContext.SaveChanges();

			return patient;
		}
		public List<Patient> GetAllPatients()
		{
			return DataContext.Patients.ToList();
		}
		public Patient GetPatientByTestCode(string testCode)
		{
			return DataContext.Patients.Where(p=>p.TestCode == testCode).FirstOrDefault();
		}
	}
}
