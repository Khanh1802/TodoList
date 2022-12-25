using AutoMapper;
using ToDoList.Data.Models;
using ToDoList.Dtos.Jobs;

namespace ToDoList.MapperProfiles
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobDto>()
                //Đối với những thuộc tính JobDto có nhưng Job không có, đặt lại custom map cho những fields này 
                .ForMember(x => x.NameJob, opt => opt.MapFrom(o => o.Name))
                .ForMember(x => x.NameCategory, opt => opt.MapFrom(o => o.Category.Name))
                .ForMember(x => x.NameState, opt => opt.MapFrom(o => o.State.Name));

            CreateMap<CreateJobDto, Job>();
            CreateMap<UpdateJobDto, Job>();

        }
    }
}
