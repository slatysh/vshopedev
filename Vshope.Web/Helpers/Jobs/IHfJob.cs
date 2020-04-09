using System;
using System.Threading.Tasks;

namespace Vshope.Web.Helpers.Jobs
{
    public interface IHfJob
    {
        Task RunAtTimeOf(DateTime now);
    }
}
