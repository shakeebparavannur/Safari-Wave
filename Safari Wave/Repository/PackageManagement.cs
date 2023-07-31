using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Safari_Wave.Models;
using Safari_Wave.Models.DTOs;
using Safari_Wave.Models.DTOs.Booking;
using Safari_Wave.Models.Enums;
using Safari_Wave.Repository.Interface;
using Safari_Wave.Repository;

namespace Safari_Wave.Repository
{
    public class PackageManagement : IPackageManagement
    {
        private readonly SafariWaveContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment environment;
        private readonly SaveImage saveImage;
        public PackageManagement(SafariWaveContext context, IMapper mapper, IWebHostEnvironment env,SaveImage saveImage)
        {
            _context = context;
            _mapper = mapper;
            this.environment = env;
            this.saveImage = saveImage;
        }

        public async Task<GetPackageDto> CreatePackage(CreatePackageDto createPackageDto)
        {
            try
            {
                var package = _mapper.Map<Package>(createPackageDto);
                package.CoverImage = await saveImage.SaveImages(createPackageDto.CoverImage, "coverImage");
                package.Image1 = await saveImage.SaveImages(createPackageDto.Image1, "image");
                package.Image2 = await saveImage.SaveImages(createPackageDto.Image2, "image");
                package.Image3 = await saveImage.SaveImages(createPackageDto.Image3, "image");
                package.Image4 = await saveImage.SaveImages(createPackageDto.Image4, "image");
                
                _context.Packages.Add(package);
                await _context.SaveChangesAsync();

                return _mapper.Map<GetPackageDto>(package);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public bool DeletePackage(int id)
        {
            var package = _context.Packages.Find(id);
            if(package == null)
            {
                return false;
            }
            _context.Packages.Remove(package);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<GetPackageDto>> FeturedPackages()
        {
            var feutPackage =await _context.Packages.Where(p => p.IsFeatured == true).ToListAsync();
            if (feutPackage == null)
            {
                return null;
            }
            var feutPackageDto = _mapper.Map<List<GetPackageDto>>(feutPackage);
            return feutPackageDto;
        }

        public async Task<IEnumerable<GetPackageDto>> GetFilteredPackage(FilterPackage filterPackage)
        {
            var packages =await _context.Packages.ToListAsync();
            var filteredPackage = packages.Where(p => p.Location.Contains(filterPackage.Location) && p.Type.Contains(filterPackage.Type) && p.Facilities.Contains(filterPackage.Faciliies) && (p.PricePerHead >= filterPackage.minPrice && p.PricePerHead <= filterPackage.maxPrice));
            var filterPackageDto = _mapper.Map<List<GetPackageDto>>(filteredPackage);
            return filterPackageDto;
        }
        public async Task <Package> GetPackageById(int id)
        {
            
            var package = await _context.Packages.Include(p => p.Bookings).Include(p=>p.Reviews).FirstOrDefaultAsync(x => x.PackId == id);
            if (package == null)
            {
                return null;
            }
            
            return package;
        }
            public async Task<IEnumerable<GetPackageDto>> GetPackageByName(string name)
            {
                var package =await _context.Packages.Where(x=>x.PackageName.Contains(name)||x.Location.Contains(name)).ToListAsync();
                if(package == null)
                {
                    return null;
                }
               var packageDto = _mapper.Map<IEnumerable<GetPackageDto>>(package);
               return packageDto;
            }
        public async Task<IEnumerable<GetPackageDto>> GetPackages()
        {
            var packages =await _context.Packages.ToListAsync();
            if(packages == null)
            {
                return null;
            }
            var packagesDto = _mapper.Map<List<GetPackageDto>>(packages);
            return packagesDto;

        }

        public async Task<GetPackageDto> UpdateFeture(int id, bool feture)
        {
            var package = await _context.Packages.FirstOrDefaultAsync(x=>x.PackId == id);
            if(package == null)
            {
                throw new Exception("Item Not Found");
            }
            package.IsFeatured = feture;
            await _context.SaveChangesAsync();
            var packageDto = _mapper.Map<GetPackageDto>(package);
            return packageDto;
        }

        public async Task <GetPackageDto> UpdatePackage(int id,CreatePackageDto updatePackageDto)
        {
            var package = await _context.Packages.FirstOrDefaultAsync(x => x.PackId == id);
            if (package == null)
            {
                return null;
            }
            _mapper.Map(updatePackageDto , package);
            await _context.SaveChangesAsync();
            var packageDto = _mapper.Map<GetPackageDto>(package);
            return packageDto;
            
        }

        public async Task<GetPackageDto> UpdatePrice(int id, decimal price)
        {
            var pack = await _context.Packages.FirstOrDefaultAsync(x => x.PackId == id);
            if (pack == null)
            {
                throw new FileNotFoundException("Package not Available");
            }
            if(price>=pack.PricePerHead)
            {
                throw new Exception("Price is above the maximum price");
            }
            if (price <= 0)
            {
                throw new Exception("Price must be a valid entry");
            }
            pack.OfferPrice = price;
            await _context.SaveChangesAsync();
            var packDto = _mapper.Map<GetPackageDto>(pack);
            return packDto;
        }
    }
}
