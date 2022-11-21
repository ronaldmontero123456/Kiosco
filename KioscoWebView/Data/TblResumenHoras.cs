namespace KioscoWebView.Data
{
    public class TblResumenHoras
    {
        public int employeeId { get; set; }
        public string employeeNumber { get; set; }
        public string employeeName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string role { get; set; }
        public string grade { get; set; }
        public string department { get; set; }
        public string subDepartment { get; set; }
        public int workedDays { get; set; }
        public int absentDays { get; set; }
        public int sickLeaves { get; set; }
        public int resetDays { get; set; }
        public int vactionDays { get; set; }
        public float normalHours { get; set; }
        public float normalOverTime { get; set; }
        public float category1 { get; set; }
        public float category2 { get; set; }
        public int mealBreakOT { get; set; }
        public float holidayOverTime { get; set; }
        public float nightHours { get; set; }
        public int workedHours { get; set; }
        public object payRollID { get; set; }
    }
}
