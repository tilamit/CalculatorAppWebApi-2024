using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI.WebControls;
using Calculator;
using System.Web.Http.Cors;
using CalculatorAppWebApi.Models;
using System.Web;
using System.Collections;

namespace CalculatorAppWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        [Route("api/values/GetData")]
        [HttpPost]
        public string GetData([FromBody] Expression aExpression)
        {
            var parser = new ExpressionParser();
            string val = string.Empty;

            try
            {
                if (parser.Execute(aExpression.MathExpression).ToString() == "∞")
                {
                    val = "Divide by zero not allowed!";
                }
                else
                {
                    val = parser.Execute(aExpression.MathExpression).ToString();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message != null)
                    val = "Error: " + ex.Message;
            }

            return val;
        }



        [Route("api/values/SetData")]
        [HttpPost]
        public void SetData([FromBody] DataMem aDataMem)
        {
            List<DataMem> aLst = new List<DataMem>();
            //var Session = HttpContext.Current.Session;

            if (aDataMem.Expression.Length > 0 && aDataMem.Result.ToString().Length > 0)
            {
                DataMem obj = new DataMem();

                if (aLst.Count == 0)
                {
                    obj.Expression = aDataMem.Expression;
                    obj.Result = aDataMem.Result;

                    aLst.Add(obj);

                    
                }
                
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
