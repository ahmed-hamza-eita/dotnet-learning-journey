using System.Linq;

#region Delegates

//DelegatesReview.M2(DelegatesReview.M1);

#endregion

#region  Procedural approach and Functional approach
//With Procedural approach
ExtnensionProcedural.RunExtensionProcedural();

//with Functional approach
ExtensionFunctional.RunExtensionFunctional();


//Book Exapmle
//================================
// Procedural - method for each filter
// ================================
BookProcedural.Print(BookProcedural.GetAvailableProgrammingBooks(), "Available Programming Books");
BookProcedural.Print(BookProcedural.GetAffordableBooksSorted(), "Affordable Books (Price < 300)");


// ================================
// Functional - one method for all filters
// ================================
var books=BookRepository.LoadBooks();
BookFunctional.Filter(books,(b=>b.Genre == "Programming" && b.IsAvailable)).Print("Available Programming Books");
BookFunctional.Filter(books,(b=>b.Price <300)).Print("Affordable Books (Price < 300)");

//using Linq
var GetAvailableProgrammingBooks = books.Where(
    b=>b.Genre=="Programming" && b.IsAvailable
);
BookFunctional.Print(GetAvailableProgrammingBooks,"Available Programming Books");
#endregion

