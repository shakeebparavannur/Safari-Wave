using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Safari_Wave.Models;
using Safari_Wave.Models.DTOs;
using Safari_Wave.Models.Enums;
using Safari_Wave.Repository.Interface;

namespace Safari_Wave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        
        private readonly IPackageManagement _packageManagement;
        public PackagesController(IPackageManagement packageManagement)
        {
            _packageManagement = packageManagement;
        }

        // GET: api/Packages
        [HttpGet]
        public async Task <ActionResult> GetPackages()
        {
            var packages = await _packageManagement.GetPackages();
            if(packages == null)
            {
                return NotFound();
            }
            return  Ok(packages);
        }
        //[Authorize]
        [HttpGet("package/{id}",Name ="GetPackageById")]
        public async Task< ActionResult> GetPackageById(int id)
        {
            var package = await _packageManagement.GetPackageById(id);
            if(package == null)
            {
                return NotFound();
            }
            return Ok(package);
        }

        [Authorize]
        [HttpPost]
        [Route("AddPackage")]
        public async Task<ActionResult>CreatePackage([FromForm] CreatePackageDto createPackageDto  )
        {
            try
            {
                var package = await _packageManagement.CreatePackage(createPackageDto);
                if (package == null)
                {
                    return BadRequest();
                }
                return Ok(package);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("search_package")]
        public async Task<ActionResult> GetPackageByName([FromBody] string name)
        {
            var packages = await _packageManagement.GetPackageByName(name);
            if(packages == null)
            {
                return NotFound();
            }
            return Ok(packages);
        }
        [Authorize(Roles ="admin")]
        [HttpPut("{id}")]
        public async Task <ActionResult> EditPackage(int id , CreatePackageDto package)
        {
            var updatedPackage = await _packageManagement.UpdatePackage(id, package);
            if(updatedPackage == null)
            {
                return BadRequest();
            }
            return Ok(updatedPackage);
        }

        [Authorize(Roles ="admin")]
        [HttpDelete("delete/{id}")]
        public ActionResult DeletePackage(int id)
        {
            var delPackage = _packageManagement.DeletePackage(id);
            if(delPackage== false)
            {
                return NotFound();
            }
            else return Ok($"Package with id:{id} is deleted successfully");
        }
        [HttpPost]
        [Route("filterPackage")]
        public async Task<ActionResult> FilterPackages([FromBody] FilterPackage filterPackage)
        {
            var packages = await _packageManagement.GetFilteredPackage(filterPackage);
            if (packages == null)
            {
                return NotFound("No result");
            }
            return Ok(packages);
        }
        [HttpGet("feutures")]
        public async Task<IActionResult> FeturedPackages()
        {
            var feturedpackages = await _packageManagement.FeturedPackages();
            if (feturedpackages == null)
            {
                return NotFound();
            }
            return Ok(feturedpackages);

        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id}/updateprize")]
        public async Task<IActionResult> UpdatePrice(int id, [FromBody] decimal price)
        {
            try
            {
                var pack = await _packageManagement.UpdatePrice(id, price);
                
                return Ok(pack);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
