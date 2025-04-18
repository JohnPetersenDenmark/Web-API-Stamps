using API_upload.Data;
using API_upload.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;
using CustomerWaypointApp.Models;
using Web_API_Stamps.Models;

namespace API_upload.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetStampById")]
        public async Task<IActionResult> GetStampById(int id)
        {

            var outputJson = new StampFullDto();

            var stamp = await _context.Stamps.FindAsync(id);


            if (stamp != null)
            {
                var imageList = await _context.ImagesData.ToListAsync();
                var imageData = await _context.ImagesData.FirstOrDefaultAsync(i => i.StampId == stamp.Id);

                if (imageData != null)
                {
                    outputJson.StampImageBase64Data = Convert.ToBase64String(imageData.FileData);
                }


                outputJson.Id = stamp.Id;
                outputJson.FilePath = stamp.FilePath;
                outputJson.ContentType = stamp.ContentType;
                outputJson.FileName = stamp.FileName;
                outputJson.UploadedAt = stamp.UploadedAt;

                //outputJson.StampImageBase64Data = Convert.ToBase64String(stamp.FileData);

                outputJson.StampName = stamp.StampName;
                outputJson.CatalogNumber = stamp.CatalogNumber;
                outputJson.Watermark = stamp.Watermark;
                outputJson.PrintMethod = stamp.PrintMethod;

                outputJson.YearOfIssue = stamp.YearOfIssue;
                outputJson.SpecialFeatures = stamp.SpecialFeatures;
                outputJson.StampSeries = stamp.StampSeries;
                outputJson.Color = stamp.Color;

                outputJson.AdditionalNotes = stamp.AdditionalNotes;
                outputJson.Country = stamp.Country;
                outputJson.Condition = stamp.Condition;
                outputJson.HistoricalSignificance = stamp.HistoricalSignificance;

                outputJson.Provenance = stamp.Provenance;
                outputJson.Size = stamp.Size;
                outputJson.FaceValue = stamp.FaceValue;
                outputJson.Rarity = stamp.Rarity;

                outputJson.StampCategory = stamp.StampCategory;


            }
            return Ok(outputJson);
        }



        [HttpGet("stamps")]
        public async Task<IActionResult> GetStamps()
        {
            var stampList = await _context.Stamps.ToListAsync();
            var thumbnailList = await _context.ThumbnailsData.ToListAsync();

            var returnList = new List<StampLightDto>();

            foreach (var stamp in stampList)
            {
                var dto = new StampLightDto();
                dto.Id = stamp.Id;
                dto.YearOfIssue = stamp.YearOfIssue;
                dto.Country = stamp.Country;
                dto.CatalogNumber = stamp.CatalogNumber;
                dto.StampName = stamp.StampName;
                dto.StampCategory = stamp.StampCategory;

                var thumbnail = thumbnailList.Where(t => stamp.Id == t.StampId).FirstOrDefault();
                if (thumbnail != null)
                {
                    dto.ThumbnailDataBase64 = Convert.ToBase64String(thumbnail.FileData);
                }

                returnList.Add(dto);
            }

            return Ok(returnList);
        }




        private async Task<byte[]> MakeThumbNail(MemoryStream memoryStream)
        {
            using var image = await Image.LoadAsync(memoryStream);
            image.Mutate(x => x.Resize(150, 0)); // Resize to width 150, maintain aspect

            using var thumbStream = new MemoryStream();
            await image.SaveAsJpegAsync(thumbStream);
            return (thumbStream.ToArray());
        }

        [HttpPost("uploadstamp")]
        public async Task<IActionResult> UploadStamp([FromBody] StampFullDto stampDto)
        {
            if (stampDto == null)
                return BadRequest("No stamp data received.");

            Stamp stamp;

            if (stampDto.Id == 0)
            {
                // 🆕 Adding a new stamp
                stamp = CopyStampDtoToStamp(stampDto, null);

                await _context.Stamps.AddAsync(stamp);
                await _context.SaveChangesAsync(); // ✅ Save here to get the generated Stamp.Id

                if (!string.IsNullOrWhiteSpace(stampDto.StampImageBase64Data))
                {
                    var imageBytes = Convert.FromBase64String(stampDto.StampImageBase64Data);

                    var imageData = new ImageData
                    {
                        FileData = imageBytes,
                        StampId = stamp.Id
                    };
                    await _context.ImagesData.AddAsync(imageData);

                    using var stream = new MemoryStream(imageBytes);
                    var thumbnailData = new ThumbnailData
                    {
                        FileData = await MakeThumbNail(stream),
                        StampId = stamp.Id
                    };
                    await _context.ThumbnailsData.AddAsync(thumbnailData);
                }

                if (stampDto.StampCategory != null)
                {
                    var stampCategory = stampDto.StampCategory;
                }
            }
            else
            {
                // 🔄 Updating an existing stamp
                var existingStamp = await _context.Stamps.FindAsync(stampDto.Id);
                if (existingStamp == null)
                    return NotFound($"Stamp with ID {stampDto.Id} not found.");

                stamp = CopyStampDtoToStamp(stampDto, existingStamp);

                _context.Stamps.Update(stamp);

                // 🔁 Update image if provided
                if (!string.IsNullOrWhiteSpace(stampDto.StampImageBase64Data))
                {
                    var imageBytes = Convert.FromBase64String(stampDto.StampImageBase64Data);

                    var imageData = await _context.ImagesData.FirstOrDefaultAsync(i => i.StampId == stamp.Id);
                    if (imageData != null)
                    {
                        imageData.FileData = imageBytes;
                        _context.ImagesData.Update(imageData);
                    }

                    var thumbnailData = await _context.ThumbnailsData.FirstOrDefaultAsync(i => i.StampId == stamp.Id);
                    if (thumbnailData != null)
                    {
                        using var stream = new MemoryStream(imageBytes);
                        thumbnailData.FileData = await MakeThumbNail(stream);
                        _context.ThumbnailsData.Update(thumbnailData);
                    }
                }
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        //

        private Stamp CopyStampDtoToStamp(StampFullDto stampDto, Stamp stamp)
        {
            if (stamp == null)
            {
                stamp = new Stamp();
            }

            {
                stamp.FilePath = stampDto.FilePath;
                stamp.FileName = stampDto.FileName;
                stamp.UploadedAt = DateTime.Now;
                //FileData = memoryStream.ToArray();  // Store binary data here
                stamp.ContentType = stampDto.ContentType;

                stamp.StampName = stampDto.StampName;
                stamp.Country = stampDto.Country;
                stamp.YearOfIssue = stampDto.YearOfIssue;
                stamp.CatalogNumber = stampDto.CatalogNumber;


                stamp.Watermark = stampDto.Watermark;
                stamp.Condition = stampDto.Condition;
                stamp.Size = stampDto.Size;
                stamp.FaceValue = stampDto.FaceValue;


                stamp.Color = stampDto.Color;
                stamp.PrintMethod = stampDto.PrintMethod;
                stamp.Rarity = stampDto.Rarity;
                stamp.SpecialFeatures = stampDto.SpecialFeatures;


                stamp.StampSeries = stampDto.StampSeries;
                stamp.HistoricalSignificance = stampDto.HistoricalSignificance;
                stamp.Provenance = stampDto.Provenance;
                stamp.AdditionalNotes = stampDto.AdditionalNotes;

                stamp.StampCategory = stampDto.StampCategory;
            }
            ;
            return stamp;
        }

        [HttpGet("stampCategories")]
        public async Task<IActionResult> GetStampCategories()
        {
            var categoryList = await _context.Categories.ToListAsync();
            var thumbnailList = await _context.ThumbnailsData.ToListAsync();

            var returnList = new List<StampCategoryDto>();

            foreach (var category in categoryList)
            {
                var dto = new StampCategoryDto();
                dto.Id = category.Id;
                dto.Category = category.Category;

                returnList.Add(dto);
            }

            return Ok(returnList);
        }

        [HttpPost("uploadStampCategory")]
        public async Task<IActionResult> UploadStampCategory([FromBody] StampCategoryDto categoryDto)
        {
            if (categoryDto.Id == 0)
            {
               
                var category = new StampCategory(); 
                category.Id = categoryDto.Id;
                category.Category = categoryDto.Category;

                await _context.Categories.AddAsync(category);                          
            }
            else
            {
                // 🔄 Updating an existing stamp
                var existingCategory = await _context.Categories.FindAsync(categoryDto.Id);
                if (existingCategory == null)
                    return NotFound($"Stamp with ID {categoryDto.Id} not found.");

                existingCategory.Category = categoryDto.Category;

                _context.Categories.Update(existingCategory);
            }

            await _context.SaveChangesAsync(); // ✅ Save here to get the generated Stamp.Id     
            return Ok();
        }
    }
}

