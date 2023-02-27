using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;
using Multitracks.Models;
using Multitracks.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;



namespace Multitracks.Controllers
{
    [AllowAnonymous]    
    public class ArtistController : ApiController
    {
       //private readonly IArtistRepository _artistRepository;

        //public ArtistController()
        //{
        //    //_artistRepository= artistRepository;    
        //}

        
        [Route("api/artist/search/{name}")]
        [HttpGet]
        public HttpResponseMessage GetArtistByName(string name)
        {
            try
            {
                var artist = ArtistRepository.GetArtistByName(name);
                return Request.CreateResponse(HttpStatusCode.OK, artist);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/artist/Add")]

        public async Task<IHttpActionResult> AddArtist(Artist artist)
        {
            try
            {
                var result = await ArtistRepository.AddArtist(artist);
                return Ok(result);
            }
            catch(Exception ex)             
            {
                return BadRequest(ex.Message);
            }
        }

    }
}