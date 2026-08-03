using Microsoft.AspNetCore.Mvc;


public class FileController : Controller
{
    [Route("file")]
    public IActionResult GetPdf()
    {
        return File("PDF/Certificate.pdf","application/pdf");
    }
}

