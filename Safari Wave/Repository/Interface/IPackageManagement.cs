﻿using Safari_Wave.Models;
using Safari_Wave.Models.DTOs;
using Safari_Wave.Models.Enums;

namespace Safari_Wave.Repository.Interface
{
    public interface IPackageManagement
    {
        Task<IEnumerable<GetPackageDto>> GetPackages();
        Task<GetPackageDto> GetPackageById(int id);
        Task<IEnumerable<GetPackageDto>> GetPackageByName(string name);
        Task <GetPackageDto> CreatePackage(CreatePackageDto createPackageDto);
        Task<GetPackageDto> UpdatePackage(int id,CreatePackageDto updatePackageDto);
        bool DeletePackage(int id);
        Task<IEnumerable<GetPackageDto>> GetFilteredPackage(FilterPackage filterPackage);
        Task<IEnumerable<GetPackageDto>> FeturedPackages();
        Task<GetPackageDto> UpdatePrice(int id,decimal price);






    }
}
