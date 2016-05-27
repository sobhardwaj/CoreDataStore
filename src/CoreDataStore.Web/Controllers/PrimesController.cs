using Microsoft.AspNetCore.Mvc;

//https://lostechies.com/gabrielschenker/2016/04/22/testing-and-debugging-a-containerized-asp-net-application/


namespace CoreDataStore.Web.Controllers
{
    [Route("api/[controller]")]
    public class PrimesController : Controller
    {
        [HttpGet("{number}")]
        public bool Get(int number)
        {
            var isPrime = number > 1;
            for (var i = 2; i < number / 2; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }


    }
}
