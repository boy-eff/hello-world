using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.API.DTO;
using HelloWorld.API.Interfaces;
using HelloWorld.Domain.Entities;
using HelloWorld.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorld.API.Controllers
{
    public class ReviewController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReviewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WordCollectionReview>>> GetReviewsAsync()
        {
            IEnumerable<WordCollectionReview> reviews = await _unitOfWork.ReviewRepository.GetReviewsAsync();
            if (reviews != null) return Ok(reviews);
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult> AddReview(WordCollectionReview review)
        {
            _unitOfWork.ReviewRepository.AddReview(review);
            if (await _unitOfWork.Complete())
            {
                return NoContent();
            }
            return BadRequest();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<WordCollectionReview>> GetReview(int id)
        {
            return await _unitOfWork.ReviewRepository.GetReview(id);
        }
    }
}