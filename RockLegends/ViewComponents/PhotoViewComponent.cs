using Microsoft.AspNetCore.Mvc;

namespace RockLegends.ViewComponents
{
    public class PhotoViewComponent : ViewComponent
    {
        MusicContext _context;

        public PhotoViewComponent(MusicContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var ph = _context.Artists.Find(id)!.Photo;
            return View(ph);
        }

    }
}
