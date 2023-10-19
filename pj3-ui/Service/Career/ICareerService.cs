using pj3_ui.Models;
using pj3_ui.Models.Career;
using pj3_ui.Models.User;

namespace pj3_ui.Service.Career
{
    public interface ICareerService
    {
        IEnumerable<CareerModel> GetCareers();

        CareerModel GetCareerByID(CareerGet careerGet);
        int InsertCareerJob(CareerJobModel careerJobGet);
    }
}
