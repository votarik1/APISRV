using Core.Models.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.DTO.Request;

namespace MetricsManager.Client
{
    public interface IMetricsAgentClient
    {
        AllCpuMetricsResponses GetAllCpuMetrics(AllCpuMetricsRequest request);
        AllRamMetricsResponses GetAllRamMetrics(AllRamMetricsRequest request);

        AllHddMetricsResponses GetAllHddMetrics(AllHddMetricsRequest request);
        AllNetworkMetricsResponses GetAllNetworkMetrics(AllNetworkMetricsRequest request);

        AllDotNetMetricsResponses GetAllDotNetMetrics(AllDotNetMetricsRequest request); 
    }
}
