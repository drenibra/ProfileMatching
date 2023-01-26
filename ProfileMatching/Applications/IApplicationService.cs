using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileMatching.Models;

namespace ProfileMatching.Applications
{
    public interface IApplicationService
    {
        Task<Application> apply(Application application);

        Task<List<Application>> getApplications();

        Task<Application> getApplicationsByJobId(int id);

        Task<string> deleteApplication(int id);
    }
}