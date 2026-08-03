using Microsoft.AspNetCore.Mvc;


public class FileController : Controller
{
    [Route("file")]
    public IActionResult GetPdf()
    {
        return File("PDF/Certificate.pdf", "application/pdf");
    }

    [Route("outside-file")]
    public PhysicalFileResult GetOutsidePdf()
    {
        string path = @"C:\Users\aheit\OneDrive\Desktop\Certificate.pdf";
        string type = "application/pdf";
        return PhysicalFile(path, type);
    }

    [Route("byte-file")]
    public FileContentResult GetFileAsByte()
    {
        string path = @"C:\Users\aheit\OneDrive\Desktop\Certificate.pdf";
        string type = "application/pdf";
        if (!System.IO.File.Exists(path))
        {
            //not found
        }

        var fileByte = System.IO.File.ReadAllBytes(path);

        return File(fileByte, type);
    }
}

