using JFApiNasa.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFApiNasa.Services;

public class JFApodService
{
    public async Task<JFApod> GetImage(DateTime dt)
    {
        JFApod dto = null;
        HttpResponseMessage response;
        string requestUrl = $"https://api.nasa.gov/planetary/apod?date={dt.ToString("yyyy-MM-dd")}&api_key=80kbltUFlGGCP1Q1dtgfjW3Pq6zAVOHRbN9K7xj1\r\n";
        try
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            HttpClient client = new HttpClient();
            response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = await response.Content.ReadAsStringAsync();
                dto = JsonConvert.DeserializeObject<JFApod>(json);
            }
        }
        catch (Exception ex)
        {
            string message = ex.Message;
            throw;
        }
        return dto;
    }

}
