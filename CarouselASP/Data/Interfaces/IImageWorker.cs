using CarouselASP.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarouselASP.Data.Interfaces
{
    public interface IImageWorker
    {
        IEnumerable<AlbumImage> Images { get; }
        Task SaveImage(AlbumImage image);
        Task DeleteImage(AlbumImage image);
        void DeleteImagesByPattern(string pattern);
    }
}
