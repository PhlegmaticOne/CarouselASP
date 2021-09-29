using CarouselASP.Data.Interfaces;
using CarouselASP.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarouselASP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IImageWorker imageWorker;
        public IEnumerable<AlbumImage> Images => imageWorker.Images;

        [BindProperty]
        public FormAlbumImageModel FormAlbumImageModel { get; set; }
        public IndexModel(IImageWorker imageWorker)
        {
            this.imageWorker = imageWorker;
        }
        public IActionResult OnGet() => Page();
        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\covers", FormAlbumImageModel.Image.FileName), FileMode.Create))
                {
                    await FormAlbumImageModel.Image.CopyToAsync(stream);
                }
                await imageWorker.SaveImage(new AlbumImage() { AlbumName = FormAlbumImageModel.AlbumName, Artist = FormAlbumImageModel.Artist, Path = "covers\\" + FormAlbumImageModel.Image.FileName });
            }
        }
        public void OnPostDelete(string pattern)
        {
            if (!String.IsNullOrWhiteSpace(pattern))
            {
                imageWorker.DeleteImagesByPattern(pattern);
            }
        }
    }
}
