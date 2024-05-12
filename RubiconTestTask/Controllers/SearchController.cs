using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace RubiconTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        [HttpGet]
        public List<Rectangles> Intersect(double Left, double Right, double Top, double Bottom)
        {
            string connectionString =
                 "Data Source=ILLYA;Initial Catalog=RubiconDB;"
                 + "Integrated Security=true;"
                 + "User id=sa;"
                 + "Password=12345;";

            // Provide the query string with a parameter placeholder. 
            string queryString =
                "select * from Rectangles t1 " +
                "where(t1.[Left] < @RightParam and t1.[Right] > @LeftParam and t1.[Top] > @BottomParam and t1.[Bottom] < @TopParam) ";

            var result = new List<Rectangles>();

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {              
                try
                {
                    result = connection.Query<Rectangles>(queryString, new { LeftParam = Left, RightParam = Right, TopParam = Top, BottomParam = Bottom }).AsList<Rectangles>();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
            return result;

        }
    }
}
