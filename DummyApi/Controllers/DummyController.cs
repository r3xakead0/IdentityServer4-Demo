using DummyApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace DummyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DummyController : ControllerBase
    {

        private readonly ILogger<DummyController> _logger;

        public DummyController(ILogger<DummyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult List()
        {
            try
            {
                var lstDummy = new List<Dummy>();

                int numberWords = new Random().Next(0, 20 - 1);
                for (int i = 1; i <= numberWords; i++)
                {
                    lstDummy.Add(new Dummy() { Id = i, Name = RandomWord(10) });
                }

                return Ok(lstDummy);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var objDummy = new Dummy()
                {
                    Id = id,
                    Name = RandomWord(10)
                };
                return Ok(objDummy);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(Dummy request)
        {
            try
            {
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, Dummy request)
        {
            try
            {
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string RandomWord(int numberLetters)
        {
            string word = "";

            // Make an array of the letters we will use.
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

            // Make a random number generator.
            Random rand = new Random();

            // Make a word.
            for (int j = 1; j <= numberLetters; j++)
            {
                // Pick a random number between 0 and 25
                // to select a letter from the letters array.
                int letter_num = rand.Next(0, letters.Length - 1);

                // Append the letter.
                word += letters[letter_num];
            }

            return word;
        }
    }
}
