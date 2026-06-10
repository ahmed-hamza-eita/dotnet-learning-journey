#region Pure and Impure 
/*
PureAndImpureFunctions p = new PureAndImpureFunctions();
//pure 
Console.WriteLine(p.Add(2, 3)); // always 5

// Impure 1
Console.WriteLine(p.AddToTotal(5)); // 5
Console.WriteLine(p.AddToTotal(3)); // 8 - changes each call

// Impure 2
int num = 10;
Console.WriteLine(p.Increment(ref num)); // 11
Console.WriteLine(num);                  // 11 - original value changed

// Impure 3
Console.WriteLine(p.GetRandom()); // different every time
Console.WriteLine(p.GetRandom()); // different every time
*/
#endregion

#region Delegates

//DelegatesReview.M2(DelegatesReview.M1);

#endregion

#region  Procedural approach and Functional approach
//With Procedural approach
ExtnensionProcedural.RunExtensionProcedural();

//with Functional approach
ExtensionFunctional.RunExtensionFunctional();
#endregion



