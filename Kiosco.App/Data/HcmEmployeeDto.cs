using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Kiosco.App.Data
{

    public class HcmEmployeeDto
    {
        [JsonProperty("EMP_PERSON_NUMBER")]
        public string PersonNumber { get; set; }



        [JsonProperty("PERSON_NUMBER")]
        [Display(Name = "PERSON_NUMBER")]
        public string PersonNumber2 { get; set; }



        [JsonProperty("EFFECTIVE_START_DATE")]
        [Display(Name = "EFFECTIVE_START_DATE")]
        public DateTime EfectiveStartDate { get; set; }



        [JsonProperty("EFFECTIVE_END_DATE")]
        [Display(Name = "EFFECTIVE_END_DATE")]
        public DateTime EfectiveEndDate { get; set; }



        [JsonProperty("EMPLOYEE_CATEGORY")]
        [Display(Name = "EMPLOYEE_CATEGORY")]
        public string EMPLOYEE_CATEGORY { get; set; }



        [JsonProperty("JOB_FUNCTION_CODE")]
        public string JobFunctionCode { get; set; }



        [JsonProperty("JOB_CODE")]
        public string JobCode { get; set; }



        [JsonProperty("EMP_LAST_NAME")]
        public string LastName { get; set; }



        [JsonProperty("EMP_MATERNAL_LAST")]
        public string MaternalLastName { get; set; }



        [JsonProperty("EMP_NAME")]
        public string Name { get; set; }



        [JsonProperty("EMP_MIDDLE_NAME")]
        public string MiddleName { get; set; }



        [JsonProperty("SUP_NAME")]
        public string SupervisorName { get; set; }



        [JsonProperty("SUP_PERSON_NUMBER")]
        public string SupervisorPersonNumber { get; set; }



        [JsonProperty("STATUS")]
        public string Status { get; set; }



        [JsonProperty("START_DATE")]
        public DateTime startDate { get; set; }



        [JsonProperty("NATIONAL_IDENTIFIER_NUMBER")]
        public string NationalIdentifierNumber { get; set; }



        [JsonProperty("ADDRESS_LINE_1")]
        public string AddressLine1 { get; set; }



        [JsonProperty("ADDRESS_LINE_2")]
        public string AddressLine2 { get; set; }



        [JsonProperty("ADDRESS_LINE_3")]
        public string AddressLine3 { get; set; }



        [JsonProperty("TOWN_OR_CITY")]
        public string TownCity { get; set; }



        [JsonProperty("PHONE_TYPE")]
        public string PhoneType { get; set; }



        [JsonProperty("PHONE_NUMBER")]
        public string PhoneNumber { get; set; }



        [JsonProperty("AREA_CODE")]
        public string AreaCode { get; set; }



        [JsonProperty("COUNTRY_CODE_NUMBER")]
        public string CountryCode { get; set; }



        [JsonProperty("EMAIL_ADDRESS")]
        public string EmailAddress { get; set; }



        [JsonProperty("DATE_OF_BIRTH")]
        public DateTime DateofBirth { get; set; }



        [JsonProperty("SEX")]
        public string Sex { get; set; }



        [JsonProperty("MARITAL_STATUS")]
        public string MaritalStatus { get; set; }



        [JsonProperty("EMPLOYMENT_CATEGORY")]
        public string EmploymentCategory { get; set; }



        [JsonProperty("HOURLY_SALARIED_CODE")]
        public string HourlySalariedCode { get; set; }



        [JsonProperty("NORMAL_HOURS")]
        public string NormalHours { get; set; }



        [JsonProperty("POSITION_CODE")]
        public string PositionCode { get; set; }



        [JsonProperty("POSITION_NAME")]
        public string PositionName { get; set; }



        [JsonProperty("DEPARTMENT")]
        public string Department { get; set; }



        [JsonProperty("LOCATION_NAME")]
        public string LocationName { get; set; }



        [JsonProperty("GRADE_CODE")]
        public string GradeCode { get; set; }



        [JsonProperty("GRADE_NAME")]
        public string GradeName { get; set; }



        [JsonProperty("JOB_NAME")]
        public string JobName { get; set; }



        [JsonProperty("REGULAR_TEMPORARY")]
        public string RegularTemporary { get; set; }



        [JsonProperty("FULL_PART_TIME")]
        public string FullPartType { get; set; }



        [JsonProperty("EMPLOYEE_CATG_MEANING")]
        public string EmployeeCatgMeaning { get; set; }



        [JsonProperty("JOB_FAMILY_CODE")]
        public string JobFamilyCode { get; set; }



        [JsonProperty("JOB_FAMILY_NAME")]
        public string JobFamilyName { get; set; }



        [JsonProperty("SALARY_BASIS_NAME")]
        public string SalaryBasisName { get; set; }



        [JsonProperty("EMP_IDENTIFIER")]
        public string EmployeeIdentifier { get; set; }



        //Termination Properties
        [JsonProperty("TERMINATION_DATE")]
        public DateTime? ActualTerminationDate { get; set; }



        [JsonProperty("ACTION_NAME")]
        public string TerminationActionName { get; set; }



        [JsonProperty("ACTION_REASON")]
        public string TerminationActionReason { get; set; }

    }
}
