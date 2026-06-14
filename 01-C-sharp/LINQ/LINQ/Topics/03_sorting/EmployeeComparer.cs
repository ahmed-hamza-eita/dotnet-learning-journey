class EmployeeComparer : IComparer<Employee>
{

    public int Compare(Employee e1, Employee e2)
    {
        if (e1.FirstName == e2.FirstName)
        {
            return e1.Email.CompareTo(e2.Email);
        }
        else
        {
           return e1.FirstName.CompareTo(e2.FirstName); 
        }

    }
}