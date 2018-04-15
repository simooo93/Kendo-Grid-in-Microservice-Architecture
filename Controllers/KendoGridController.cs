namespace Client.Controllers
{
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.Threading.Tasks;
    using Common;
    using Common.HttpRequests;
    using global::Client.ViewModels;
    using System.Collections.Generic;

    public class KendoGridController : Controller
    {

        private IHttpRequestService _httpRequestServce;


        public KendoGridController(IHttpRequestService httpRequestService)
        {
            this._httpRequestServce = httpRequestService;
        }

        public IActionResult Index(string surveyName)
        {
            return this.View();
        }

        public async Task<IActionResult> Test_Read([DataSourceRequest] DataSourceRequest request)
        {
            DataSourceRequestWrapper dataSourceRequestWrapper = request.GetDataSourceRequestWrapper();

            if (request.Filters != null && request.Filters.Count > 0)
            {
                dataSourceRequestWrapper.Filters = JsonConvert.SerializeObject(request.Filters,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
            }

            var response = await this._httpRequestServce.Post<DataSourceResultWrapper<TestVM>>(ApiRoutes.WebApi.TestObjectsGrid, dataSourceRequestWrapper);

            if (response.IsSuccessful)
            {
                var dataSourceResult = response.Model.ToDataSourceResult();
                return this.Json(dataSourceResult);
            }

            return this.Json(new { });
        }

        public async Task<IActionResult> Test_Read_Filter(string field)
        {
            var response = await this._httpRequestServce.Post<IEnumerable<TestVM>>($"{ApiRoutes.WebApi.TestObjectsGrid}?field={field}", new DataSourceRequestWrapper());

            if (response.IsSuccessful)
            {
                return this.Json(response.Model);
            }

            return this.Json(new { });
        }
    }
}