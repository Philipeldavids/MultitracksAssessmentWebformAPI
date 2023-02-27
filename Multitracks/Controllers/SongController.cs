using Multitracks.Models;
using Multitracks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace Multitracks.Controllers
{
    [AllowAnonymous]
    public class SongController : ApiController
    {
        //private readonly ISongRepository _songRepository;
        //public SongController(ISongRepository songRepository)
        //{
        //    _songRepository = songRepository;
        //}

        [HttpGet]
        [Route("api/Song/GetAllSongs/")]
        public IHttpActionResult GetAllSongs(PaginationFilter filter)
        {
            try{
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var pagedsongs = SongRepository.GetAllSongs()
                                .OrderBy(x => x.SongId)
                                .Skip((validFilter.PageNumber -1)* validFilter.PageSize)
                                .Take(validFilter.PageSize)
                                .ToList();

                return Ok(new PagedResponse<List<Song>>(pagedsongs, validFilter.PageNumber, validFilter.PageSize));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}