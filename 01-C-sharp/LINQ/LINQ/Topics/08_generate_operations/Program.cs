using LINQ.Utils;
Console.WriteLine("Generate Operations..........");

//Range 
Enumerable.Range(1, 10).Print("Range");

//Reapet
Enumerable.Repeat("Ahmed", 3).Print("Repeat");

// Empty Sequence
Enumerable.Empty<int>().Print("Empty Sequence");

#region Example
//create a class schedule for a teacher for 5 days, with 6 free periods each day.
//Find Absent Students
var weekDays = Enumerable.Range(1, 5);
var slotsForOneDay = Enumerable.Repeat("Available", 6);

var weeklySchedule = weekDays.Select(day => new
{
    Day = day,
    Slots = Enumerable.Repeat("Available", 6).ToList()
}
);

 



List<string> attendanceRecord = new() { "Ahmed", "Sara" };
List<string> allStudents = new() { "Ahmed", "Sara", "Ali", "Mona" };

IEnumerable<string> GetAbsentStudents(
    IEnumerable<string> attendanceRecord, IEnumerable<string> allStudents
)
{
    var absent = allStudents.Except(attendanceRecord);
    return absent.Any() ? absent : Enumerable.Empty<string>();
}

var absentStudents = GetAbsentStudents(attendanceRecord,allStudents);
#endregion

