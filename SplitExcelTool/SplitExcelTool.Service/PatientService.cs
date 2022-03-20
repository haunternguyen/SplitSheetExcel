﻿using SplitExcelTool.Model;
using SplitExcelTool.Repositories;

namespace SplitExcelTool.Service
{
	public interface IPatientService
	{
		Patient AddPatient(Patient patient);
		List<Patient> GetAllPatients();

		Patient GetPatientByTestCode(string testCode);
	}

	public class PatientService : IPatientService
	{
		private readonly IPatientRepository _patientRepository;
		public PatientService(IPatientRepository patientRepository)
		{
			_patientRepository = patientRepository;
		}
		public Patient AddPatient(Patient patient)
		{
			return _patientRepository.AddPatient(patient);
		}
		public List<Patient> GetAllPatients()
		{
			return _patientRepository.GetAllPatients();
		}
		public Patient GetPatientByTestCode(string testCode)
		{
			return _patientRepository.GetPatientByTestCode(testCode);
		}
	}
}