using pj3_ui.Models;
using pj3_ui.Models.Career;
using pj3_ui.Models.User;

namespace pj3_ui.Service.Career
{
    public interface ICareerService
    {
        IEnumerable<CareerModel> GetCareers();
        IEnumerable<CareerModel> GetAllCareers();
        IEnumerable<CareerModel> GetCareersByUserID(CareerGet CareerGet);
        CareerModel GetCareerByID(CareerGet careerGet);
        CareerModel GetCareerDetailByUserID(CareerGet CareerGet);
        int InsertCareerJob(CareerJobModel careerJobGet);
        IEnumerable<CareerJobModel> GetCareerJob();
        int InsertCareer(CareerModel CareerModel);
        int UpdateCareer(CareerModel CareerModel);
        int UpdateCareerJob(CareerJobModel CareerJobModel);
        IEnumerable<CareerJob> GetCareerJobAdmin();
    }
}
