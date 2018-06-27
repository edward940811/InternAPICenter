using Legal.LawSearch;
using Legal.LawSearch.Conditions;
using Legal.LawSearch.ViewModels;
using Legal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Legal.LawSearch.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ESHClouds.ApiCenter.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class LegalSearchController : BaseController
    {
        public LegalSearchController(ClaimsIdentity identity) : base(identity)
        {
        }

        [Route("file")]
        [HttpGet]
        public IActionResult GetLawFiles([FromQuery]LawSearchCondition condition)
        {
            if (condition == null) { return BadRequest("at least one condition"); }

            var service = new LawSearch(_companyId, int.Parse(_userId));
            List<LawFileVM> lawFiles = service.GetLawFiles(condition);
            var totalRecords = lawFiles.Count == 0 ? 0 : lawFiles[0].TotalRecords;

            var result = new PagingModel<List<LawFileVM>>()
            {
                PageIndex = condition.PageIndex,
                Data = lawFiles,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling((float)totalRecords / (float)condition.PageSize)
            };

            return Ok(result);
        }
        [Route("content")]
        [HttpGet]
        public IActionResult GetLawContents([FromQuery]LawSearchCondition condition)
        {
            if (condition == null) { return BadRequest("at least one condition"); }

            
            var service = new LawSearch(_companyId, int.Parse(_userId));
            var lawContents = service.GetLawContents(condition);
            var totalRecords = lawContents.Count == 0 ? 0 : lawContents[0].TotalRecords;

            var result = new PagingModel<List<LawContentVM>>()
            {
                PageIndex = condition.PageIndex,
                Data = lawContents,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling((float)totalRecords / (float)condition.PageSize)
            };

            return Ok(result);
        }

        [Route("law")]
        [HttpGet]
        public IActionResult GetLawInfoKeyword([FromQuery]LawSearchCondition condition)
        {
            if (condition == null) { return BadRequest("at least one condition"); }

            List<LawInfoVM> lawInfos = null;
            var service = new LawSearch(_companyId, int.Parse(_userId));
            lawInfos = service.GetLawInfos(condition);

            var totalRecords = lawInfos.Count == 0 ? 0 : lawInfos[0].TotalRecords;
            //去掉重複的關鍵字資料
            lawInfos = lawInfos.GroupBy(item => item.LawName).Select(g => g.First()).ToList();
            var result = new PagingModel<List<LawInfoVM>>()
            {
                PageIndex = condition.PageIndex,
                Data = lawInfos,
                TotalRecords = totalRecords,
                TotalPages = (int)Math.Ceiling((float)totalRecords / (float)condition.PageSize)
            };

            return Ok(result);
        }
    }
}