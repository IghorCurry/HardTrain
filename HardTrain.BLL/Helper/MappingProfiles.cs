using Mapster;
using HardTrain.BLL.Models;
using HardTrain.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardTrain.DAL.Entities.ExersiceEntities;
using AutoMapper;

namespace HardTrain.BLL.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Exersice, ExersiceViewModel>();
        CreateMap<ExersiceViewModel, Exersice>();
        CreateMap<Exersice, ExersiceCreateModel>();
        CreateMap<ExersiceCreateModel, Exersice>();
        CreateMap<Training, TrainingCreateModel>();
        CreateMap<Training, TrainingViewModel>();
        
        
        
        
        //var mapper = new MapperConfiguration(cfg =>
        //{
        //    cfg.CreateMap<Training, TrainingCreateModel>();
        //    /*cfg.CreateMap<Training, TrainingUpdateModel>()*/;
        //    cfg.CreateMap<Training, TrainingViewModel>();
        //});
        //CreateMap<Exersice, ExersiceUpdateModel>();
    }
    
}
