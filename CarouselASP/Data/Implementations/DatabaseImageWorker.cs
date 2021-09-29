using CarouselASP.Data.Database;
using CarouselASP.Data.Interfaces;
using CarouselASP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarouselASP.Data.Implementations
{
    public class DatabaseImageWorker : IImageWorker
    {
        private ImageDbContext dbContext;
        public DatabaseImageWorker(ImageDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<AlbumImage> Images => dbContext.AlbumImages;

        public async Task DeleteImage(AlbumImage image)
        {
            dbContext.AlbumImages.Remove(image);
            await dbContext.SaveChangesAsync();
        }

        public void DeleteImagesByPattern(string pattern)
        {
            pattern = pattern.ToLower();
            IEnumerable<AlbumImage> range = from img in dbContext.AlbumImages
                                            where (img.AlbumName.ToLower().Contains(pattern) ||
                                                   img.Artist.ToLower().Contains(pattern))
                                            select img;

            if (range != null && range.Count() != 0)
            {
                dbContext.RemoveRange(range);
                dbContext.SaveChanges();
            }
        }

        public async Task SaveImage(AlbumImage image)
        {
            await dbContext.AlbumImages.AddAsync(image);
            await dbContext.SaveChangesAsync();
        }
    }
}
