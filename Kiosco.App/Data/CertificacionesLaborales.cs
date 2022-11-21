using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Kiosco.App.Data
{
    public class CertificacionesLaborales
    {
        public DateTime P_EFFDATE { get; set; }
        public string P_PERNUM { get; set; }
        public string WELLNESS_SUPERVISOR { get; set; }
        public string EMP_LAST_NAME { get; set; }
        public string EMP_IDENTIFIER { get; set; }
        public string EMP_MATERNAL_LAST { get; set; }
        public string EMP_NAME { get; set; }
        public string EMP_MIDDLE_NAME { get; set; }
        public string EMP_PERSON_NUMBER { get; set; }
        public string EMP_ASSIG_NUMBER { get; set; }
        public string SUP_NAME { get; set; }
        public string SUP_PERSON_NUMBER { get; set; }
        public string SUP_ASSIG_NUMBER { get; set; }
        public string STATUS { get; set; }
        public string START_DATE { get; set; }
        public string NATIONAL_IDENTIFIER_TYPE { get; set; }
        public string NATIONAL_IDENTIFIER_NUMBER { get; set; }
        public string ADDRESS_LINE_1 { get; set; }
        public string ADDRESS_LINE_2 { get; set; }
        public string ADDRESS_LINE_3 { get; set; }
        public string TOWN_OR_CITY { get; set; }
        public string PHONE_TYPE { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string AREA_CODE { get; set; }
        public string COUNTRY_CODE_NUMBER { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public string DATE_OF_BIRTH { get; set; }
        public string SEX { get; set; }
        public string MARITAL_STATUS { get; set; }
        public string CURRENT_SALARY { get; set; }
        public string EFFECTIVE_START_DATE { get; set; }
        public string EFFECTIVE_END_DATE { get; set; }
        public string EMPLOYEE_CATEGORY { get; set; }
        public string EMPLOYMENT_CATEGORY { get; set; }
        public string NORMAL_HOURS { get; set; }
        public string FREQUENCY { get; set; }
        public string ACTION_CODE { get; set; }
        public string POSITION_CODE { get; set; }
        public string POSITION_NAME { get; set; }
        public string DEPARTMENT { get; set; }
        public string LOCATION_CODE { get; set; }
        public string LOCATION_NAME { get; set; }
        public string GRADE_CODE { get; set; }
        public string GRADE_NAME { get; set; }
        public string JOB_FUNCTION_CODE { get; set; }
        public string JOB_NAME { get; set; }
        public string JOB_CODE { get; set; }
        public string JOB_CATEGORY_CODE { get; set; }
        public string REGULAR_TEMPORARY { get; set; }
        public string FULL_PART_TIME { get; set; }
        public string EMPLOYEE_CATG_MEANING { get; set; }
        public string EMPLOYEE_CATG_DESCRIPTION { get; set; }
        public string JOB_FAMILY_CODE { get; set; }
        public string JOB_FAMILY_NAME { get; set; }
        public string JOB_FUNCTION_NAME { get; set; }
        public string SALARY_BASIS_NAME { get; set; }

        [JsonIgnore]
        [NotMapped]
        public double EMPLOYEE_Money => double.Parse(
            !string.IsNullOrEmpty(EMPLOYEE_CATEGORY)? EMPLOYEE_CATEGORY : "0.00"
            );
    }
}
